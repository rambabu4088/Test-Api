using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Utils
{
    public class Constants
    {
        public static int CheckTimeAdjustment = 15;
        public static int DesktopQRLocationDistance = 200;
        public static int DesktopQRTimeout = 20;
        public static string DefaultLocationApplicationType = LocationApplicationTypes.QR.ToString();
        public static string CheckTimeAdjustmentKey = "CheckTimeAdjustment";
        public static string DesktopQRLocationDistanceKey = "DesktopQRLocationDistance";
        public static string DesktopQRTimeoutKey = "DesktopQRTimeout";
        public static string ApplicationTypeKey = "ApplicationType";

        public static string CheckIn = "Check-In";
        public static string CheckOut = "Check-Out";
        public static string AttendanceAdjustmentRequest = "Attendance Adjustment";
        public static string OverTimeRequest = "Overtime Request";
        public enum LocationApplicationTypes { QR, STATICIP };

        private static readonly string[] LocationConfigurationKeys = { CheckTimeAdjustmentKey, DesktopQRLocationDistanceKey, DesktopQRTimeoutKey };
        public static List<string> LocationConfigurationOptions = new List<string>(LocationConfigurationKeys);
        public static int PayrollAdminLevel = 100;
        public enum RequestType { ExcuseRequest, OverTimeRequest }
        public enum RequestOwnerType { MyRequest, PendingWithMe }
        public enum RequestStatus { Pending, Approved, Rejected, Canceled, ApprovedCompleted = 100 };
    }
}
