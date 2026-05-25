# Foxoft Project Instructions

These are persistent instructions for coding agents working in this repository.
They apply to the entire project unless a more specific `AGENTS.md` exists in a
subdirectory.

## Core Rules

- Keep designer-generated UI code only in `*.Designer.cs` files.
- Prefer DevExpress components where possible, especially for Windows Forms UI.
- Keep all user-facing text in `.resx` resource files and reference it through strongly typed resource properties.
- Do not hardcode SQL strings unless necessary.
- For SQL Server queries, use aliases with `=` syntax.

## Windows Forms And DevExpress

When creating or modifying Windows Forms interfaces, use DevExpress controls
instead of standard WinForms controls where appropriate. Keep the UI modern,
consistent, and compatible with the existing DevExpress-based project structure.

## Designer Code Separation

For Windows Forms, always keep designer-generated UI code separate from the main
form logic.

Place all UI declarations, `InitializeComponent` logic, layout settings, and
designer-related code only in `{FormName}.Designer.cs`.

Do not add designer components or UI initialization code to `{FormName}.cs`.
That file must contain only business logic and event handler implementations.

## Localization

For all C# WinForms code, never hardcode user-facing UI text.

All labels, captions, button texts, form titles, menu items, tooltips, dialogs,
notifications, validation messages, error messages, and other visible text must
be stored in the appropriate `.resx` resource files and referenced through
strongly typed resource properties in the form code.

Resource key naming rules:

- Form-specific texts must use the pattern `Form_Product_*`.
- Common reusable texts must use the pattern `Common_*`.
- Common examples: `Common_Save`, `Common_Copy`, `Common_Delete`.
- Field names and grid column captions must use the related entity resource key:
  `Entity_EntityName_FieldName`.

Keep all WinForms code fully localization-friendly and avoid hardcoded UI strings
in form logic or designer code.

## Resource Encoding

When reading, modifying, or writing XML-based resource files (`.resx` or
`.az.resx`), always handle encoding strictly as UTF-8. Preserve multi-byte
Azerbaijani characters such as `ə`, `ş`, `ğ`, `ö`, `ü`, `ı`, `ç`, `Ə`, `Ş`,
`Ğ`, `Ö`, `Ü`, `İ`, and `Ç`.

Rules for resource encoding:

1. Never use default ANSI or Windows-1252 encoding to parse, read, or save
   resource files containing non-ASCII characters. This prevents Mojibake and
   corrupted text.
2. In PowerShell, never use `Get-Content` or `Set-Content` without explicitly
   specifying `-Encoding utf8`.
3. Prefer reliable UTF-8 APIs in PowerShell:
   `[System.IO.File]::ReadAllText($path, [System.Text.Encoding]::UTF8)` and
   `[System.IO.File]::WriteAllText($path, $text, [System.Text.Encoding]::UTF8)`.
4. In C#, always pass `System.Text.Encoding.UTF8` when calling file I/O
   operations or XML readers/writers.
5. After edits, verify that Azerbaijani letters remain human-readable and are
   not double-encoded into garbled patterns such as `MÉ™ÅŸÄŸulluq` instead of
   `Məşğulluq`, or `mÃ¼tlÉ™qdir` instead of `mütləqdir`.

## FormERP Navigation Permissions

If a new `AccordionControlElement` is added to the `FormERP` navigation menu,
usually in `FormERP.Designer.cs`, also add a corresponding permission claim to
`subContext.cs` as seed data.

Required steps:

1. Identify the `Name` property of the new `AccordionControlElement` set in
   `FormERP.cs` within `InitComponentName`.
2. Add a new `DcClaim` entry to the
   `modelBuilder.Entity<DcClaim>().HasData(...)` section in `subContext.cs`.
3. Add a new `TrRoleClaim` entry to the
   `modelBuilder.Entity<TrRoleClaim>().HasData(...)` section in `subContext.cs`,
   assigning the new claim to the `"Admin"` role.
4. Ensure the `RoleClaimId` in `TrRoleClaim` is unique and follows the existing
   sequence.

## SQL

- Do not hardcode SQL strings unless necessary.
- For SQL Server queries, use aliases with `=` syntax.
