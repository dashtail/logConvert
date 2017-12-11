using System;
using System.Collections.Generic;
using System.Text;

namespace LogConvert {
    public class Log {
        public string Provider { get; set; }
        public string HttpMethod { get; set; }
        public string StatusCode { get; set; }
        public string UriPath { get; set; }
        public string TimeTaken { get; set; }
        public string ResponsiveSize { get; set; }
        public string CacheStatus { get; set; }

        public Log (string line) {
            try {
                var splitedLine = line.Split ('|');
                Provider = "\"MINHA CDN\"";
                ResponsiveSize = splitedLine[0];
                StatusCode = splitedLine[1];
                CacheStatus = splitedLine[2];
                HttpMethod = splitedLine[3].Split ('"', ' ') [1];
                UriPath = splitedLine[3].Split (' ', ' ') [1];
                TimeTaken = splitedLine[4].Substring (0, 3);

            } catch {
                Console.WriteLine ("Formato do log diferente do esperado!");
                throw;
            }
        }

        public string WriteLine () {
            return string.Format ("{0} {1} {2} {3} {4} {5} {6}",
                Provider, HttpMethod, StatusCode, UriPath, TimeTaken,
                ResponsiveSize, CacheStatus);
        }
    }
}