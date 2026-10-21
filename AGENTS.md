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

## 4. Resource Encoding & Character Integrity (Strict UTF-8)

Resource files containing Azerbaijani characters must maintain strict encoding integrity to prevent Mojibake (text corruption):

- **Target Characters**: Must reliably preserve Azerbaijani letters: `ə`, `ş`, `ğ`, `ö`, `ü`, `ı`, `ç`, `Ə`, `Ş`, `Ğ`, `Ö`, `Ü`, `İ`, `Ç`.
- **Prohibited Encodings**: Never read, parse, or save `.resx` / `.az.resx` files with default ANSI, Windows-1252, or ASCII encodings.
- **PowerShell File I/O**:
  - Do not use bare `Get-Content` or `Set-Content` without explicit `-Encoding utf8`.
  - Prefer robust .NET UTF-8 APIs:
    - Reading: `[System.IO.File]::ReadAllText($path, [System.Text.Encoding]::UTF8)`
    - Writing: `[System.IO.File]::WriteAllText($path, $text, [System.Text.Encoding]::UTF8)`
- **C# File I/O**: Always pass `System.Text.Encoding.UTF8` to stream readers, stream writers, or XML writers.
- **Integrity Verification**: Ensure characters remain human-readable and are not corrupted (e.g., `Məşğulluq` must never become `MÉ™ÅŸÄŸulluq`, `mütləqdir` must never become `mÃ¼tlÉ™qdir`).

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
