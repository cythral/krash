using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace krash.Models {
    public class Report {
        public string userAgent { get; set; }

        public string ip { get; set; }

        [Required]
        public string repo { get; set; }

        [Required]
        public string version { get; set; }

        [Required]
        public IEnumerable<LogItem> log { get; set; }

        public override string ToString() {
            string result = $"**IP Address**: {ip}";
            result += $"\n**User Agent**: {userAgent}";
            result += $"\n**Version**: {version}";
            result += "\n\n| Timestamp | Type | Message | Filename |";
            result += "\n| :--- | :--- | :--- | :--- |";
            
            foreach(LogItem item in log) {
                result += $"\n{item}";
            }

            return result;
        }
    }
}