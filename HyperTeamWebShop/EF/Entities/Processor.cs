using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.EF
{
    public class Processor : Product
    {
        public int Id { get; set; }

        public SocketType SocketType { get; set; }
        public int Cores { get; set; }
        public int ClockFrequency { get; set; }
        public int L3CacheSize { get; set; }
        public bool SMTSupport { get; set; }

        public Processor() { }

        public Processor(SocketType socket, int cores, int clockFrequency, int l3CacheSize, bool smtSupport, string manu, string type, string imgUrl, int purchasePrice, int sellingPrice) : base(manu,type, imgUrl, purchasePrice, sellingPrice) 
        {
            SocketType = socket;
            Cores = cores;
            ClockFrequency = clockFrequency;
            L3CacheSize = l3CacheSize;
            SMTSupport = smtSupport;
        }

    }
}
