using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.Common
{
    public static class DateTimeMeFormat
    {

        // Cố gắng chuyển đổi một chuỗi văn bản (string) sang kiểu DateTime dựa trên một danh sách các định dạng cho trước.
        public static bool TryParseDate(string input, out DateTime result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                result = default(DateTime);
                return false;
            }

            var formats = new[]
            {
                "yyyy-MM-dd",
                "dd/MM/yyyy",
                "d/M/yyyy",
                "M/d/yyyy",
                "dd-MM-yyyy",
                "yyyyMMdd",
                "dd MMM yyyy",
                "d MMM yyyy"
            };

            return DateTime.TryParseExact(
                input.Trim(),
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out result);
        }

        // Tính tuổi của một người dựa trên ngày sinh.
        public static int CalculateAge(DateTime birthDate, DateTime? asOf = null)
        {
            var reference = (asOf ?? DateTime.Today).Date;
            if (birthDate.Date > reference)
                throw new ArgumentException("birthDate must be on or before reference date", nameof(birthDate));

            int age = reference.Year - birthDate.Year;
            if (reference < birthDate.AddYears(age)) age--;
            return age;
        }

        // Tính xem còn bao nhiêu ngày nữa là đến sinh nhật tiếp theo.
        public static int DaysUntilNextBirthday(DateTime birthDate, DateTime? from = null)
        {
            var start = (from ?? DateTime.Today).Date;
            var next = new DateTime(start.Year, birthDate.Month, birthDate.Day);

            if (next < start)
                next = next.AddYears(1);

            return (next - start).Days;
        }

        // Đếm số ngày làm việc (Thứ 2 đến Thứ 6) giữa hai khoảng thời gian.
        // Optionally exclude user-provided holidays.
        public static int BusinessDaysBetween(DateTime start, DateTime end, IEnumerable<DateTime> holidays = null)
        {
            if (start > end)
            {
                var tmp = start;
                start = end;
                end = tmp;
            }

            holidays = (holidays ?? Enumerable.Empty<DateTime>())
                .Select(d => d.Date)
                .ToHashSet();

            int businessDays = 0;
            for (var cur = start.Date; cur <= end.Date; cur = cur.AddDays(1))
            {
                if (cur.DayOfWeek == DayOfWeek.Saturday || cur.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                if (holidays.Contains(cur))
                    continue;
                businessDays++;
            }

            return businessDays;
        }

        // Cộng thêm một số ngày làm việc vào một mốc thời gian (ví dụ: "3 ngày làm việc kể từ hôm nay").
        public static DateTime AddBusinessDays(DateTime date, int businessDays)
        {
            if (businessDays == 0) return date;

            int direction = businessDays > 0 ? 1 : -1;
            int remaining = Math.Abs(businessDays);
            var current = date;

            while (remaining > 0)
            {
                current = current.AddDays(direction);
                if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                remaining--;
            }

            return current;
        }

        // Start / end helpers
        public static DateTime StartOfDay(DateTime dt) => dt.Date;
        public static DateTime EndOfDay(DateTime dt) => dt.Date.AddDays(1).AddTicks(-1);

        public static DateTime StartOfMonth(DateTime dt) => new DateTime(dt.Year, dt.Month, 1);
        public static DateTime EndOfMonth(DateTime dt) => StartOfMonth(dt).AddMonths(1).AddTicks(-1);

        public static DateTime StartOfYear(DateTime dt) => new DateTime(dt.Year, 1, 1);
        public static DateTime EndOfYear(DateTime dt) => StartOfYear(dt).AddYears(1).AddTicks(-1);

        // Unix timestamp helpers (seconds since 1970-01-01 UTC)
        //Chuyển đổi qua lại với định dạng Unix Timestamp (số giây tính từ mốc 01/01/1970).

        //Chuyển DateTime → số giây Unix
        public static long ToUnixTimeSeconds(DateTime dt)
        {
            var utc = dt.ToUniversalTime();
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((utc - epoch).TotalSeconds);
        }
        //Chuyển Unix time → DateTime
        public static DateTime FromUnixTimeSeconds(long seconds)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(seconds).ToLocalTime();
        }

        // Week of year according to current culture (ISO-like behavior can be achieved with CalendarWeekRule.FirstFourDayWeek and DayOfWeek.Monday)
        //ch: Xác định xem một ngày cụ thể nằm ở tuần thứ bao nhiêu trong năm (ví dụ: Tuần 1, Tuần 52).
        public static int GetWeekOfYear(DateTime dt, CalendarWeekRule rule = CalendarWeekRule.FirstDay, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var ci = CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(dt, rule, firstDayOfWeek);
        }

        // Vietnamese-friendly formatting
        //Mục đích: Xuất ngày tháng ra chuỗi tiếng Việt.
        public static string ToVietnameseShortDateString(DateTime dt) =>
            dt.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));

        public static string ToVietnameseLongDateString(DateTime dt) =>
            dt.ToString("dddd, dd MMMM yyyy", CultureInfo.GetCultureInfo("vi-VN"));
        // hàm so sánh 2 mốc thời gian và trả về một chuỗi mô tả sự khác biệt (ví dụ: "2 ngày trước", "3 giờ sau"). 
        public static string GetTimeDifferenceDescription(DateTime inputTime)
        {
            DateTime now = DateTime.Now;
            TimeSpan diff = inputTime - now;

            bool isFuture = diff.TotalSeconds > 0;
            double seconds = Math.Abs(diff.TotalSeconds);

            if (seconds < 60)
                return "vừa xong";

            if (seconds < 3600)
            {
                int minutes = (int)(seconds / 60);
                return isFuture ? $"{minutes} phút sau" : $"{minutes} phút trước";
            }

            if (seconds < 86400)
            {
                int hours = (int)(seconds / 3600);
                return isFuture ? $"{hours} giờ sau" : $"{hours} giờ trước";
            }

            if (seconds < 2592000) // ~30 ngày
            {
                int days = (int)(seconds / 86400);
                return isFuture ? $"{days} ngày sau" : $"{days} ngày trước";
            }

            if (seconds < 31536000) // ~1 năm
            {
                int months = (int)(seconds / 2592000);
                return isFuture ? $"{months} tháng sau" : $"{months} tháng trước";
            }

            int years = (int)(seconds / 31536000);
            return isFuture ? $"{years} năm sau" : $"{years} năm trước";
        }


        //hàm so sánh 2 mốc thời gian
        public static int CompareDate(DateTime t1, DateTime t2)
        {
            return DateTime.Compare(t1, t2);
        }

    }
}
