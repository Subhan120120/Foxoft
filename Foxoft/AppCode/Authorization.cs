﻿using DevExpress.CodeParser;
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
                if (store == null)
                {
                    XtraMessageBox.Show("Mağaza Aktiv Deyil");
                    return false;
                }

                List<TrSession> trSessions = efMethods.SelectEntities<TrSession>();
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
                        efMethods.DeleteEntity<TrSession>(session);
                    }
                }

                TrSession trSession = new()
                {
                    CurrAccCode = user,
                    PID = Process.GetCurrentProcess().Id,
                    CreatedDate = DateTime.Now
                };

                efMethods.InsertEntity<TrSession>(trSession);

                Authorization.CurrAccCode = user;
                Authorization.DcRoles = efMethods.SelectRolesByCurrAcc(user);
                Authorization.StoreCode = efMethods.SelectEntityById<DcCurrAcc>(user).StoreCode;
                Authorization.OfficeCode = efMethods.SelectEntityById<DcCurrAcc>(user).OfficeCode;

                return true;
            }
            else
            {
                XtraMessageBox.Show("İstifadəçi və ya şifrə yanlışdır");
                return false;
            }
        }

    }
}
