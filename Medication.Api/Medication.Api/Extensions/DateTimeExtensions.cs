namespace Medication.Api.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToStringUtc(this DateTime time)
        {
            return $"DateTime({time.Ticks}, DateTimeKind.Utc)";
        }
    }
}
