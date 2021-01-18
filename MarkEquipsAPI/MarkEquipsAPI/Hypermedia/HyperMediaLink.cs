using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string _href;
        public string Type { get; set; }
        public string Action { get; set; }

        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(_href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set
            {
                _href = value;
            }

        }
    }
}
