using DevExpress.CodeParser;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Foxoft
{
    public static class Authorization
    {
        static EfMethods efMethods = new();
        public static string CurrAccCode { get; set; }
        public static string UserName { get => CurrAccCode; set => CurrAccCode = value; }
        public static string UserDesc { get; set; } = string.Empty;

        public static List<DcRole> DcRoles { get; set; }

        public static string OfficeCode { get; set; }

        public static string StoreCode { get; set; }

        public static bool Authorized(string role)
        {
            bool authorized = false;
            DcRoles.ForEach(x => authorized = x.RoleCode.Contains(role));     //check user role

            return authorized;
        }

        public static bool Login(string user, string password, bool Checked)
        {
            return Login(user, password, Settings.Default.CompanyCode, Checked);
        }

        public static bool Login(string user, string password, string companyCode, bool Checked)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show(Properties.Resources.Auth_InvalidUserOrPassword);
                return false;
            }

            // 1. Authenticate against Main database DcUsers
            DcUser? mainUser = efMethods.LoginMainUser(user, password);
            if (mainUser == null)
            {
                // Fallback for local DcCurrAcc if user not in main db
                DcCurrAcc fallbackCurrAcc = efMethods.Login(user, password);
                if (fallbackCurrAcc == null)
                {
                    XtraMessageBox.Show(Properties.Resources.Auth_InvalidUserOrPassword);
                    return false;
                }
            }
            else if (mainUser.IsDisabled)
            {
                XtraMessageBox.Show(Properties.Resources.Auth_UserIsDisabled);
                return false;
            }
            else
            {
                // 2. Check company permissions for this user
                if (!string.IsNullOrWhiteSpace(companyCode))
                {
                    bool hasAccess = efMethods.UserHasCompanyAccess(user, companyCode);
                    if (!hasAccess)
                    {
                        XtraMessageBox.Show(Properties.Resources.Auth_NoCompanyPermission);
                        return false;
                    }
                }
            }

            // 3. Sub-context session & user role configuration
            DcCurrAcc userCurrAcc = efMethods.SelectEntityById<DcCurrAcc>(user);
            if (userCurrAcc != null)
            {
                DcCurrAcc store = efMethods.SelectStore(userCurrAcc.StoreCode);
                if (store == null && !string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase))
                {
                    XtraMessageBox.Show(Properties.Resources.Auth_StoreNotActive);
                    return false;
                }
            }

            List<TrSession> trSessions = efMethods.SelectEntities<TrSession>();

            foreach (var session in trSessions)
            {
                try
                {
                    var process = Process.GetProcessById(session.PID);

                    if (!string.Equals(process.ProcessName, "Foxoft.exe", StringComparison.InvariantCultureIgnoreCase))
                    {
                        efMethods.DeleteEntity(session);
                    }
                    else if (string.Equals(session.CurrAccCode, user, StringComparison.InvariantCultureIgnoreCase))
                    {
                        XtraMessageBox.Show(Properties.Resources.Auth_UserAlreadyLoggedIn);
                        return false;
                    }
                }
                catch (ArgumentException)
                {
                    efMethods.DeleteEntity(session);
                }
            }

            efMethods.InsertEntity(new TrSession
            {
                CurrAccCode = user,
                PID = Process.GetCurrentProcess().Id,
                CreatedDate = DateTime.Now
            });

            Authorization.CurrAccCode = user;
            Authorization.UserDesc = mainUser?.UserDesc
                ?? efMethods.SelectCurrAcc(user)?.CurrAccDesc
                ?? user;
            Authorization.DcRoles = efMethods.SelectRolesByCurrAcc(user);
            if ((Authorization.DcRoles == null || Authorization.DcRoles.Count == 0) &&
                string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase))
            {
                Authorization.DcRoles = new List<DcRole>
                {
                    new DcRole { RoleCode = "Admin", RoleDesc = "Administrator" }
                };
            }

            if (userCurrAcc != null)
            {
                Authorization.StoreCode = userCurrAcc.StoreCode;
                Authorization.OfficeCode = userCurrAcc.OfficeCode;
            }
            else
            {
                Authorization.StoreCode = efMethods.SelectStores().FirstOrDefault()?.CurrAccCode;
                Authorization.OfficeCode = efMethods.SelectOffices().FirstOrDefault()?.OfficeCode;
            }

            return true;
        }

    }
}
