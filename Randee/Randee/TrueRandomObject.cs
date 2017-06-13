using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randee
{
    public class Random
    {
        public List<int> data { get; set; }
        public string completionTime { get; set; }
    }

    public class Result
    {
        public Random random { get; set; }
        public int bitsUsed { get; set; }
        public int bitsLeft { get; set; }
        public int requestsLeft { get; set; }
        public int advisoryDelay { get; set; }
    }

    public class TrueRandomObject
    {
        public string jsonrpc { get; set; }
        public Result result { get; set; }
        public int id { get; set; }
    }
}
