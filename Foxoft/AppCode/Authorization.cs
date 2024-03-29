﻿using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
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
            if (efMethods.Login(user, password))
            {
                Authorization.CurrAccCode = user;
                Authorization.DcRoles = efMethods.SelectRoles(user);
                Authorization.StoreCode = efMethods.SelectStoreCode(user);
                Authorization.OfficeCode = efMethods.SelectOfficeCode(user);

                return true;
            }
            else
                return false;
        }

    }
}
