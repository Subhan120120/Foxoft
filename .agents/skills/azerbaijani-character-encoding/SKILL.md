---
name: azerbaijani-character-encoding
description: >-
  Strict guidelines, Unicode escape mappings, and verification procedures to prevent
  and fix Azerbaijani character encoding corruption (mojibake) across .resx and .cs files in Foxoft.
---

# Azerbaijani Character Encoding & Zero-Mojibake Skill

This skill provides step-by-step instructions, character lookup tables, and verification scripts to ensure that Azerbaijani characters (`ə`, `ğ`, `ş`, `ç`, `ı`, `ö`, `ü`, `Ə`, `Ş`, `Ğ`, `Ö`, `Ü`, `İ`, `Ç`) are never corrupted in `.resx`, `.cs`, or designer files.

---

## 1. Golden Rules to Prevent Mojibake

1. **NEVER pass raw Azerbaijani characters in PowerShell CLI or `.ps1` scripts**:
   - Windows PowerShell 5.1 runs under ANSI/Windows-1254 codepage by default.
   - Any literal Azerbaijani string parsed by PowerShell from command-line arguments or script bodies will be misread as ANSI and converted to double-encoded UTF-8 mojibake.
2. **ALWAYS use built-in editing tools (`edit_file`, `write_file`)**:
   - The AI agent's native file editing tools operate directly in UTF-8 without shell codepage interference.
3. **In C# / scripts, ALWAYS use Unicode Escape Sequences**:
   - When writing code, helpers, or migrations that manipulate Azerbaijani text, always write Unicode escape codes (`\u0259`, etc.) instead of literal characters. Escapes are 7-bit ASCII and cannot be corrupted by any shell.
4. **ALWAYS write `.resx` files with UTF-8 BOM**:
   - Visual Studio requires the Byte Order Mark (`EF BB BF`) on `.resx` files: `new System.Text.UTF8Encoding(true)`.

---

## 2. Azerbaijani Unicode Escape Reference Table

| Character | Name | Unicode Escape (Code) | Upper / Lower Pair |
| :---: | :--- | :---: | :---: |
| **ə** | Azerbaijani Small Schwa | `\u0259` | Lowercase |
| **Ə** | Azerbaijani Capital Schwa | `\u018F` | Uppercase |
| **ğ** | Small G with Breve | `\u011F` | Lowercase |
| **Ğ** | Capital G with Breve | `\u011E` | Uppercase |
| **ş** | Small S with Cedilla | `\u015F` | Lowercase |
| **Ş** | Capital S with Cedilla | `\u015E` | Uppercase |
| **ç** | Small C with Cedilla | `\u00E7` | Lowercase |
| **Ç** | Capital C with Cedilla | `\u00C7` | Uppercase |
| **ı** | Small Dotless I | `\u0131` | Lowercase |
| **I** | Capital Dotless I | `I` (`\u0049`) | Uppercase |
| **i** | Small Dotted I | `i` (`\u0069`) | Lowercase |
| **İ** | Capital Dotted I | `\u0130` | Uppercase |
| **ö** | Small O with Diaeresis | `\u00F6` | Lowercase |
| **Ö** | Capital O with Diaeresis | `\u00D6` | Uppercase |
| **ü** | Small U with Diaeresis | `\u00FC` | Lowercase |
| **Ü** | Capital U with Diaeresis | `\u00DC` | Uppercase |

---

## 3. How to Safely Update `.resx` Files

### Method 1: Direct File Edit (Recommended)
Use `edit_file` to insert `<data name="..." xml:space="preserve"><value>Mətn</value></data>` directly.

### Method 2: C# Script with Unicode Escapes
When updating programmatically via C#:
```csharp
var utf8WithBom = new System.Text.UTF8Encoding(true);
string content = File.ReadAllText(path, utf8WithBom);
// Use Unicode escapes in string literals:
string text = "M\u0259hsul Uy\u011funla\u015fd\u0131rma";
// ...
File.WriteAllText(path, content, utf8WithBom);
```

---

## 4. Verification & Mojibake Detection Script

Always execute this verification snippet after any task that touches localized text:

```powershell
$targetFiles = Get-ChildItem -Path Foxoft -Recurse -Include *.cs,*.resx
$found = 0
foreach ($f in $targetFiles) {
    $text = [System.IO.File]::ReadAllText($f.FullName, [System.Text.Encoding]::UTF8)
    if ($text -match '[\u00C0-\u00FF][\u0080-\u00BF]|\u2122') {
        Write-Warning "Mojibake detected in: $($f.FullName)"
        $found++
    }
}
if ($found -eq 0) {
    Write-Output "VERIFICATION PASSED: 0 mojibake occurrences."
} else {
    throw "VERIFICATION FAILED: $found file(s) contain corrupted text."
}
```

---

## 5. Mojibake Diagnostic Dictionary

If you see these patterns in output, they correspond to double-UTF-8 corrupted characters:

| Corrupted String (Mojibake) | Intended Azerbaijani Letter |
| :---: | :---: |
| `É™` | `ə` |
| `Æ ` / `Æ` | `Ə` |
| `ÄŸ` | `ğ` |
| `Äž` | `Ğ` |
| `ÅŸ` | `ş` |
| `Åž` | `Ş` |
| `Ã§` | `ç` |
| `Ã‡` | `Ç` |
| `Ä±` | `ı` |
| `Ä°` | `İ` |
| `Ã¶` | `ö` |
| `Ã–` | `Ö` |
| `Ã¼` | `ü` |
| `Ãœ` | `Ü` |
