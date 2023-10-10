using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokenAPI.common
{
    public class Result
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ApiParser
    {
        public string message { get; set; }
        public int total_records { get; set; }
        public int total_pages { get; set; }
        public object previous { get; set; }
        public string next { get; set; }
        public List<Result> results { get; set; }
    }


}
