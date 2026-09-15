using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using Foxoft.Models;

namespace Foxoft.AppCode.Service.Backup
{
    public sealed record ArchiveResult(
        string ArchiveFilePath,
        long CompressedSizeBytes,
        string CompressionUsed);

    public static class BackupArchiveService
    {
        public static string? FindRarExecutable(string? configuredPath = null)
        {
            if (!string.IsNullOrWhiteSpace(configuredPath) && File.Exists(configuredPath))
                return configuredPath;

            string[] commonPaths = new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "WinRAR", "Rar.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "WinRAR", "Rar.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "WinRAR", "WinRAR.exe"),
                @"C:\Program Files\WinRAR\Rar.exe",
                @"C:\Program Files (x86)\WinRAR\Rar.exe"
            };

            foreach (string p in commonPaths)
            {
                if (File.Exists(p))
                    return p;
            }

            return null;
        }

        public static async Task<ArchiveResult> CompressBackupAsync(
            string bakFilePath,
            BackupCompressionType compressionType,
            string? configuredRarPath = null,
            bool deleteOriginalBak = true,
            CancellationToken ct = default)
        {
            if (!File.Exists(bakFilePath))
                throw new FileNotFoundException("Backup faylı tapılmadı: " + bakFilePath, bakFilePath);

            long originalSize = new FileInfo(bakFilePath).Length;

            if (compressionType == BackupCompressionType.None)
            {
                return new ArchiveResult(bakFilePath, originalSize, "None");
            }

            string dir = Path.GetDirectoryName(bakFilePath) ?? string.Empty;
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(bakFilePath);

            // Attempt RAR if requested
            if (compressionType == BackupCompressionType.Rar)
            {
                string? rarExe = FindRarExecutable(configuredRarPath);
                if (!string.IsNullOrEmpty(rarExe))
                {
                    string rarPath = Path.Combine(dir, fileNameWithoutExt + ".rar");
                    if (File.Exists(rarPath))
                        File.Delete(rarPath);

                    ProcessStartInfo psi = new()
                    {
                        FileName = rarExe,
                        Arguments = $"a -ep1 -ibck -y \"{rarPath}\" \"{bakFilePath}\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true
                    };

                    using Process? proc = Process.Start(psi);
                    if (proc != null)
                    {
                        await proc.WaitForExitAsync(ct);
                        if (proc.ExitCode == 0 && File.Exists(rarPath))
                        {
                            long rarSize = new FileInfo(rarPath).Length;
                            if (deleteOriginalBak)
                            {
                                try { File.Delete(bakFilePath); } catch { /* ignore cleanup error */ }
                            }
                            return new ArchiveResult(rarPath, rarSize, "Rar");
                        }
                    }
                }

                // If RAR failed or not found, fall back to ZIP
                Debug.WriteLine("WinRAR tapılmadı və ya xəta baş verdi. Avtomatik olaraq ZIP arxivləməsinə keçirilir.");
            }

            // ZIP compression
            string zipPath = Path.Combine(dir, fileNameWithoutExt + ".zip");
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            await Task.Run(() =>
            {
                using FileStream zipToOpen = new(zipPath, FileMode.Create, FileAccess.Write, FileShare.None);
                using ZipArchive archive = new(zipToOpen, ZipArchiveMode.Create);
                archive.CreateEntryFromFile(bakFilePath, Path.GetFileName(bakFilePath), CompressionLevel.Optimal);
            }, ct);

            long zipSize = new FileInfo(zipPath).Length;

            if (deleteOriginalBak)
            {
                try { File.Delete(bakFilePath); } catch { /* ignore cleanup error */ }
            }

            return new ArchiveResult(zipPath, zipSize, "Zip");
        }
    }
}
