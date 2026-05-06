# WinForms Accordion Claim Rule

If a new `AccordionControlElement` is added to the `FormERP` navigation menu (usually in `FormERP.Designer.cs`), you MUST also add a corresponding permission (claim) to the `subContext.cs` file as seed data.

## Instructions:
1. Identify the `Name` property of the new `AccordionControlElement` set in `FormERP.cs` (within `InitComponentName`).
2. Add a new `DcClaim` entry to the `modelBuilder.Entity<DcClaim>().HasData(...)` section in `subContext.cs`.
3. Add a new `TrRoleClaim` entry to the `modelBuilder.Entity<TrRoleClaim>().HasData(...)` section in `subContext.cs`, assigning the new claim to the `"Admin"` role.
4. Ensure the `RoleClaimId` in `TrRoleClaim` is unique and follows the existing sequence.
