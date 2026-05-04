---
trigger: always_on
---

For all C# WinForms code, never hardcode user-facing UI text. Dialogs, notifications, validation messages, labels, buttons, tooltips, menu items, and form titles must be stored in the appropriate .resx Resource file and used through Resource properties in the form code. Keep the code clean, professional, and localization-friendly.