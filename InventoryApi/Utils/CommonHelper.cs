using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Utils
{
        public class Roles
        {
            public bool IsAdmin { get; set; }
            public bool IsDepartmentAdmin { get; set; }
            public bool IsPayrollAdmin { get; set; }
        }

        public class CommonHelper
        {
            public static string GetAccessFromRole(Roles role)
            {
                if (role.IsAdmin)
                {
                    return "Super Admin";
                }
                else if (role.IsDepartmentAdmin)
                {
                    return "Department Admin";
                }
                else if (role.IsPayrollAdmin)
                {
                    return "Payroll Admin";
                }
                return "";
            }

            public static Roles GetRoleFromAccess(string access)
            {
                Roles role = new Roles
                {
                    IsAdmin = false,
                    IsDepartmentAdmin = false,
                    IsPayrollAdmin = false
                };

                switch (access)
                {
                    case "Super Admin":
                        role.IsAdmin = true;
                        break;
                    case "Department Admin":
                        role.IsDepartmentAdmin = true;
                        break;
                    case "Payroll Admin":
                        role.IsPayrollAdmin = true;
                        break;
                    default:
                        role.IsAdmin = false;
                        role.IsDepartmentAdmin = false;
                        role.IsPayrollAdmin = false;
                        break;
                }

                return role;
            }

            public static int GetCodeFromStatus(string status)
            {
                switch (status)
                {
                    case "Active":
                    case "ACTIVE":
                        return 1;
                    case "Hold":
                    case "HOLD":
                        return 2;
                    case "InActive":
                    case "RESIGNED":
                    case "TERMINATED":
                        return 3;
                    case "Vacation":
                    case "VACATION":
                        return 4;
                    default:
                        return 1;
                }
            }

            public static int TotalNumberOfDaysInMonth(int year, int month)
            {
                return DateTime.DaysInMonth(year, month);
            }

            public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
            {
                // Unix timestamp is seconds past epoch
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
                return dtDateTime;
            }
        }
}
