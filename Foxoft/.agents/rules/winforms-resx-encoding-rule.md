---
trigger: always_on
---

When reading, modifying, or writing XML-based resource files (`.resx` or `.az.resx`), always ensure the file encoding is strictly handled as **UTF-8 (preserving multi-byte characters like ə, ş, ğ, ö, ü, ı, ç, Ə, Ş, Ğ, Ö, Ü, İ, Ç)**.

### Rules for Resource Encoding:
1. **Never use default ANSI or Windows-1252 encoding** to parse, read, or save resource files containing non-ASCII characters. This prevents Mojibake (corrupted characters).
2. **Reading and Writing in Scripts**:
   - In PowerShell, never use `Get-Content` or `Set-Content` without explicitly specifying `-Encoding utf8` (or use `[System.IO.File]::ReadAllText($path, [System.Text.Encoding]::UTF8)` / `[System.IO.File]::WriteAllText($path, $text, [System.Text.Encoding]::UTF8)` which is far more reliable across PowerShell versions).
   - In C#, always pass `System.Text.Encoding.UTF8` when calling file I/O operations or XML writers/readers.
3. **Verification**:
   - Always verify that Azerbaijani letters (such as `ə`, `ş`, `ğ`, `ö`, `ü`, `ı`, `ç`) remain in their human-readable form and are not double-encoded into garbled patterns (e.g. `MÉ™ÅŸÄŸulluq` instead of `Məşğulluq`, `mÃ¼tlÉ™qdir` instead of `mütləqdir`).
