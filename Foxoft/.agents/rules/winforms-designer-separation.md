---
trigger: always_on
---

For Windows Forms, always keep designer-generated UI code separate from the main form logic.

When creating forms or adding controls/components, place all UI declarations, InitializeComponent logic, layout settings, and designer-related code only in {FormName}.Designer.cs.

Do not add designer components or UI initialization code to {FormName}.cs. That file must contain only business logic and event handler implementations.