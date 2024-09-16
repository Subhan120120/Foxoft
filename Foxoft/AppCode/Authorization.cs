using DevExpress.CodeParser;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
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
            DcCurrAcc userCurrAcc = efMethods.Login(user, password);

            if (userCurrAcc != null)
            {
                DcCurrAcc store = efMethods.SelectStore(userCurrAcc.StoreCode);

                if (store != null)
                {
                    List<TrSession> trSessions = efMethods.SelectSessions();

                    foreach (var session in trSessions)
                    {
                        try
                        {
                            Process process = Process.GetProcessById(session.PID);

                            if (process is not null && session.CurrAccCode.Equals(user, StringComparison.InvariantCultureIgnoreCase))
                            {
                                XtraMessageBox.Show("Istifadəçi artıq sistemə daxil olub.");
                                return false;
                            }
                        }
                        catch (ArgumentException)
                        {
                            efMethods.DeleteSession(session);
                        }
                    }

                    TrSession trSession = new();
                    trSession.CurrAccCode = user;
                    trSession.PID = Process.GetCurrentProcess().Id;
                    trSession.CreatedDate = DateTime.Now;

                    efMethods.InsertTrSession(trSession);

                    Authorization.CurrAccCode = user;
                    Authorization.DcRoles = efMethods.SelectRoles(user);
                    Authorization.StoreCode = efMethods.SelectStoreCode(user);
                    Authorization.OfficeCode = efMethods.SelectOfficeCode(user);
                }
                else
                {
                    XtraMessageBox.Show("Mağaza Aktiv Deyil");
                    return false;
                }
            }
            else
            {
                XtraMessageBox.Show("İstifadəçi və ya şifrə yanlışdır");
                return false;
            }

            return true;
        }
    }
}
