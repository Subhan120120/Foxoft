using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraBars;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using DevExpress.XtraBars.Ribbon;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace Foxoft.AppCode
{
    public class CustomMethods
    {
        EfMethods efMethods = new EfMethods();
        public string EncryptString(string plainText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public string DecryptString(string cipherText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string GetDataFromFile(string pathFile)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(pathFile))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public List<Image> GetImagesFrom(String folderPath, String[] filters, SearchOption searchOption)
        {
            List<Image> filesFound = new();

            foreach (var filter in filters)
            {
                if (CustomExtensions.DirectoryExist(folderPath))
                {
                    string[] fileNames = Directory.GetFiles(folderPath, String.Format("*.{0}", filter), searchOption);

                    foreach (var fileName in fileNames)
                    {
                        string fullPath = Path.Combine(folderPath, fileName);

                        if (File.Exists(fullPath))
                            using (var file = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                Image img = Image.FromStream(file);
                                img.Tag = fullPath;
                                filesFound.Add(img);
                            }
                    }
                }
            }

            return filesFound;
        }



    }
}
