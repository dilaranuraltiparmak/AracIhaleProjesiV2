using System;

namespace AracIhale.CoreMVC.Enums
{

        public enum KullaniciRoller
        {
            Admin = 1,
            Kullanici = 2,
            SuperAdmin = 3
        }
        public static class KullaniciRol
        {
            public static string GetRoleName(int roleId)
            {
                return Enum.GetName(typeof(KullaniciRoller), roleId);
            }
        }
    }

