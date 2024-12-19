namespace PresentationLayer.Helpers
{
    public static class TimeAgoHelper
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalSeconds < 60)
                return $"{timeSpan.Seconds} saniye önce";
            if (timeSpan.TotalMinutes < 60)
                return $"{timeSpan.Minutes} dakika önce";
            if (timeSpan.TotalHours < 24)
                return $"{timeSpan.Hours} saat önce";
            if (timeSpan.TotalDays < 7)
                return $"{timeSpan.Days} gün önce";
            if (timeSpan.TotalDays < 30)
                return $"{(int)(timeSpan.TotalDays / 7)} hafta önce";
            if (timeSpan.TotalDays < 365)
                return $"{(int)(timeSpan.TotalDays / 30)} ay önce";

            return $"{(int)(timeSpan.TotalDays / 365)} yıl önce";
        }
    }
}
