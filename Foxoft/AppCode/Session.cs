using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace LinqTest
{
    public class ClsLookupAccountName
    {
        public const uint SE_GROUP_LOGON_ID = 0xC0000000; // from winnt.h
        public const int TokenGroups = 2; // from TOKEN_INFORMATION_CLASS

        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public uint Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_GROUPS
        {
            public int GroupCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public SID_AND_ATTRIBUTES[] Groups;
        };

        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool ConvertSidToStringSid(IntPtr pSID, out IntPtr ptrSid);

        [DllImport("kernel32.dll")]
        static extern IntPtr LocalFree(IntPtr hMem);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(
            IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            int TokenInformationLength,
            out int ReturnLength);

        public static string GetLogonId()
        {
            int TokenInfLength = 0;
            bool Result = GetTokenInformation(WindowsIdentity.GetCurrent().Token, TOKEN_INFORMATION_CLASS.TokenGroups, IntPtr.Zero, TokenInfLength, out TokenInfLength);
            IntPtr TokenInformation = Marshal.AllocHGlobal(TokenInfLength);
            Result = GetTokenInformation(WindowsIdentity.GetCurrent().Token, TOKEN_INFORMATION_CLASS.TokenGroups, TokenInformation, TokenInfLength, out TokenInfLength);

            if (!Result)
            {
                Marshal.FreeHGlobal(TokenInformation);
                return string.Empty;
            }

            string retVal = string.Empty;
            TOKEN_GROUPS groups = (TOKEN_GROUPS)Marshal.PtrToStructure(TokenInformation, typeof(TOKEN_GROUPS));
            int sidAndAttrSize = Marshal.SizeOf(new SID_AND_ATTRIBUTES());
            for (int i = 0; i < groups.GroupCount; i++)
            {
                SID_AND_ATTRIBUTES sidAndAttributes = (SID_AND_ATTRIBUTES)Marshal.PtrToStructure(
                    new IntPtr(TokenInformation.ToInt64() + i * sidAndAttrSize + IntPtr.Size), typeof(SID_AND_ATTRIBUTES));
                if ((sidAndAttributes.Attributes & SE_GROUP_LOGON_ID) == SE_GROUP_LOGON_ID)
                {
                    IntPtr pstr = IntPtr.Zero;
                    ConvertSidToStringSid(sidAndAttributes.Sid, out pstr);
                    retVal = Marshal.PtrToStringAuto(pstr);
                    LocalFree(pstr);
                    break;
                }
            }

            Marshal.FreeHGlobal(TokenInformation);
            return retVal;
        }
    }
}