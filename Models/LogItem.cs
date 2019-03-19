using System;

namespace krash.Models {

    public enum LogItemType {
        Warning,
        Error,
        Action,
        Info
    }

    public class LogItem {
        private static DateTime EPOCH = new DateTime(1970,1,1,0,0,0,0, DateTimeKind.Utc);
        public LogItemType type { get; set; }
        public string message { get; set; }
        public string filename { get; set; }
        public long timestamp { get; set; }

        public override string ToString() {
            return $"| {EPOCH.AddMilliseconds(timestamp)} | {type} | {message} | {filename ?? "none"} |";
        }
    }
}