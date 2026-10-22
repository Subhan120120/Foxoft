# Foxoft Project Instructions & Development Rules

These persistent instructions and rules apply to the entire Foxoft solution repository across all projects (`Foxoft`, `Foxoft.BackupWorker`, `Foxoft.NotificationWorker`, `Setup`, `TestRunner`). All coding agents and developers must strictly adhere to these standards.

---

## 1. Windows Forms & DevExpress UI Standards

- **Preferred Controls**: Always use DevExpress controls instead of standard Windows Forms (`System.Windows.Forms`) controls whenever creating or updating UI views.
- **Control Mapping**:
  - `XtraForm` / `RibbonForm` instead of `Form`
  - `SimpleButton` instead of `Button`
  - `TextEdit`, `DateEdit`, `CheckEdit`, `LookUpEdit` instead of standard textboxes, checkboxes, and comboboxes
  - `GridControl` & `GridView` instead of `DataGridView`
  - `LayoutControl` instead of manual pixel placement or standard table/flow panels
- **Consistency**: Maintain visual harmony with existing forms, utilizing the active DevExpress skin and vector palette.

---

## 2. Designer Code Separation

Keep UI layout declarations and business logic completely isolated:

- **`{FormName}.Designer.cs`**:
  - Contains **all** component declarations, `InitializeComponent()` logic, control layout, docking, styling, event subscriptions, and designer-generated code.
  - Never place business logic, data queries, or domain processing here.
- **`{FormName}.cs`**:
  - Contains **only** business logic, data binding, and event handler implementations.
  - Never instantiate, position, or configure UI layout elements directly in this file.

---

## 3. Localization & Resource Management

All user-facing UI text must be localizable. Never hardcode user-visible strings in C# code or designer files.

- **Resource Placement**: Store all strings in the appropriate `.resx` files (e.g., `Properties\Resources.resx` and `Properties\Resources.az.resx`).
- **Access Pattern**: Reference strings exclusively via strongly typed resource properties (e.g., `Properties.Resources.Common_Save`).
- **Key Naming Conventions**:
  | Category | Naming Pattern | Examples |
  | :--- | :--- | :--- |
  | **Form-specific text** | `Form_<FormName>_<Context>` | `Form_Product_Title`, `Form_CurrAcc_AutoCreateGoogleContact` |
  | **Shared / Reusable actions** | `Common_<Action/Term>` | `Common_Save`, `Common_Cancel`, `Common_Delete`, `Common_Confirm` |
  | **Entity fields & Grid columns** | `Entity_<EntityName>_<FieldName>` | `Entity_Product_Barcode`, `Entity_CurrAcc_PhoneNumber` |

---

## 4. Resource Encoding & Character Integrity (Strict UTF-8 & Zero-Mojibake Protocol)

Resource files (`.resx`, `.az.resx`), source files (`.cs`), and designer files containing Azerbaijani characters must maintain 100% encoding integrity at all times. Text corruption (Mojibake) is strictly prohibited.

### 4.1 Target Azerbaijani Characters
Must reliably preserve:
- **Lowercase**: `ə`, `ğ`, `ş`, `ç`, `ı`, `ö`, `ü`
- **Uppercase**: `Ə`, `Ğ`, `Ş`, `Ç`, `I` (or `İ`), `Ö`, `Ü`

### 4.2 Prohibited Practices & Root Causes of Mojibake (NEVER DO THIS)
1. **Never pass literal Azerbaijani characters in PowerShell commands/scripts**:
   - Windows PowerShell 5.1 runs under ANSI/OEM codepage (Windows-1254/1252/857).
   - Any literal Azerbaijani string written directly in a `.ps1` file or passed through the command line is misparsed as ANSI before reaching .NET, producing double-encoded UTF-8 mojibake (e.g. `ə` -> `É™`, `ş` -> `ÅŸ`, `ğ` -> `ÄŸ`, `ç` -> `Ã§`, `ü` -> `Ã¼`, `ö` -> `Ã¶`, `Ə` -> `Æ `).
2. **Never omit UTF-8 BOM on `.resx` files**:
   - Visual Studio and Windows Forms resource generators expect UTF-8 with BOM (`EF BB BF`).
   - Files saved without BOM or with ANSI encoding cause designer text corruption and build warnings.
3. **Never use standard PowerShell file-writing cmdlets**:
   - Do NOT use `Set-Content`, `Out-File`, `Add-Content`, or bare redirection (`>`).

### 4.3 Mandatory Protocol for Adding / Modifying Azerbaijani Text

#### Protocol A: Preferred Method — Built-in Agent Tools (`edit_file`, `write_file`)
- **Always** use the agent's native `edit_file` or `write_file` tools to edit `.resx` and `.cs` files. These tools operate strictly in clean UTF-8 without shell codepage interference.

#### Protocol B: Programmatic / Script Method — Pure Unicode Escape Sequences Only
- If creating a script or C# helper to update `.resx` files or strings, **NEVER put raw Azerbaijani letters directly in the script code**.
- **Always use standard Unicode escape sequences** (`\uXXXX`). Unicode escapes are pure 7-bit ASCII and can never be corrupted by any shell, editor, or compiler:
  | Azerbaijani Letter | Unicode Escape | Azerbaijani Letter | Unicode Escape |
  | :--- | :--- | :--- | :--- |
  | `ə` | `\u0259` | `Ə` | `\u018F` |
  | `ğ` | `\u011F` | `Ğ` | `\u011E` |
  | `ş` | `\u015F` | `Ş` | `\u015E` |
  | `ç` | `\u00E7` | `Ç` | `\u00C7` |
  | `ı` (dotless) | `\u0131` | `İ` (dotted) | `\u0130` |
  | `ö` | `\u00F6` | `Ö` | `\u00D6` |
  | `ü` | `\u00FC` | `Ü` | `\u00DC` |

#### Protocol C: Strict UTF-8 with BOM for .NET File I/O
When writing `.resx` or `.cs` files via .NET APIs:
- **Always specify UTF-8 with BOM**: `new System.Text.UTF8Encoding(true)`
  - **C#**: `File.WriteAllText(path, text, new System.Text.UTF8Encoding(true));`
  - **PowerShell**: `[System.IO.File]::WriteAllText($path, $text, (New-Object System.Text.UTF8Encoding($true)))`
- **Reading**: `[System.IO.File]::ReadAllText($path, [System.Text.Encoding]::UTF8)`

### 4.4 Mandatory Post-Edit Verification (Zero-Tolerance Gate)
After ANY task modifying `.resx` or `.cs` files, the agent MUST run this verification check before finishing:
```powershell
$text = [System.IO.File]::ReadAllText($path, [System.Text.Encoding]::UTF8)
if ($text -match '[\u00C0-\u00FF][\u0080-\u00BF]|\u2122') {
    throw "Mojibake detected in $path!"
}
```
**Sanity Checklist**: Verify human-readable Azerbaijani words:
- `Məhsul` (NOT `MÉ™hsul`)
- `Uyğunlaşdırma` (NOT `UyÄŸunlaÅŸdÄ±rma`)
- `Pillə` (NOT `PillÉ™`)
- `Ştrixkod` (NOT `Åžtrixkod`)
- `Əməliyyat` (NOT `Æ mÉ™liyyat`)
- `Məbləğ` (NOT `MÉ™blÉ™ÄŸ`)
- `Ölçü` (NOT `Ã–lÃ§Ã¼`)

---

## 5. FormERP Navigation & Permission Claims

When registering a new menu entry in the main ERP navigation tree:

- **Trigger**: An `AccordionControlElement` is added to `FormERP.Designer.cs`.
- **Mandatory Seed Data Steps**:
  1. **Control Name**: Locate the unique `Name` assigned to the `AccordionControlElement` in `FormERP.cs` (inside `InitComponentName`).
  2. **Add Claim (`DcClaim`)**: Add a corresponding `DcClaim` record inside the `modelBuilder.Entity<DcClaim>().HasData(...)` block in `subContext.cs`.
  3. **Assign to Admin (`TrRoleClaim`)**: Add a corresponding `TrRoleClaim` record in the `modelBuilder.Entity<TrRoleClaim>().HasData(...)` block in `subContext.cs`, binding the new claim to the `"Admin"` role.
  4. **Sequential Identity**: Verify that `RoleClaimId` is unique and follows the existing sequential ID scheme.

---

## 6. Domain Boundary: Strict Separation of `DcUser` and `DcCurrAcc`

`DcUser` and `DcCurrAcc` represent two fundamentally distinct domain concepts and must never substitute, replace, or be confused with one another:

| Property | `DcUser` | `DcCurrAcc` |
| :--- | :--- | :--- |
| **Database** | Global `Main` database (`mainContext`) | Tenant Company database (`subContext`) |
| **Primary Key** | `UserName` (string) | `CurrAccCode` (string) |
| **Domain Meaning** | Application users, operators, login authentication, system credentials, user permissions | Business counterparties, clients, vendors, internal cash/bank accounts, partner accounts |
| **Audit & Identity** | Audit stamps (`CreatedUserName`, `LastUpdatedUserName`), log actors (`Sender` in message/system logs) | Financial and trade transaction counterparty (`CurrAccCode`) |

### Strict Rules:
- **No Swapping**: Never use a `UserName` where a `CurrAccCode` is expected, or vice-versa.
- **No Foreign Keys**: Never add foreign key constraints from transaction or log tables (`TrMessageLogs`, etc.) to `DcCurrAcc` for user identity columns (`Sender`, `CreatedUserName`, `LastUpdatedUserName`).
- **No Existence Assumption**: Do not assume every `DcUser` has a matching `DcCurrAcc` entry in a tenant database. System users can operate without counterparty accounts.

---

## 7. SQL Query Standards & EF Core

- **ORM Preference**: Prefer LINQ queries with EF Core. Avoid raw SQL strings unless performance or complex queries strictly require it.
- **SQL Server Alias Syntax**: When writing raw SQL queries for SQL Server, always use the `=` syntax for column aliases instead of `AS`:
  ```sql
  -- Correct:
  SELECT TotalAmount = SUM(Amount), CustomerCode = CurrAccCode FROM TrInvoiceHeaders ...

  -- Incorrect:
  SELECT SUM(Amount) AS TotalAmount, CurrAccCode AS CustomerCode FROM TrInvoiceHeaders ...
  ```

---

## 8. Database Migrations Safety

- **STRICT PROHIBITION**: Never execute commands that apply migrations directly to databases (e.g., `dotnet ef database update`, `Update-Database`, or executing DDL scripts against active databases).
- Migrations may only be scaffolded or generated (`dotnet ef migrations add <MigrationName>`), never applied automatically.
