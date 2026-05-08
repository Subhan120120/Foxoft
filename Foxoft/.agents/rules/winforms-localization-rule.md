---
trigger: always_on
---

For all C# WinForms code, never hardcode user-facing UI text.

All labels, captions, button texts, form titles, menu items, tooltips, dialogs, notifications, validation messages, error messages, and other visible text must be stored in the appropriate .resx Resource files and referenced through strongly-typed Resource properties in the form code.

Resource key naming rules:
- Form-specific texts must use the pattern: Form_Product_*
- Common reusable texts must use the pattern: Common_* 
  Example: Common_Save, Common_Copy, Common_Delete
- Field names and grid column captions must use the related entity resource key:
  Entity_EntityName_FieldName

Keep all WinForms code fully localization-friendly and avoid any hardcoded UI strings in form logic or designer code.