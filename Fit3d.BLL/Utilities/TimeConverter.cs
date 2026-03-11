namespace Fit3d.BLL.Utilities
{
    public static class TimeConverter
    {
        private static readonly TimeZoneInfo VietNamTimeZone =
            TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        public static DateTimeOffset GetCurrentVietNamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, VietNamTimeZone);
        }
    }
}
