using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.EF
{
    public class Memory : Product
    {
        public int Id { get; set; }

        public SlotType SlotType { get; set; }
        public int ClockFrequency { get; set; }
        public int MemorySizeInGb { get; set; }
        public int Height { get; set; }
        public int Latecy { get; set; }

        public Memory() { }

        public Memory(SlotType slot, int clockFrequency, int memorySize, int height, int latecy, string manu, string type, string imgUrl, int purchasePrice, int sellingPrice) : base(manu, type, imgUrl, purchasePrice, sellingPrice)
        {
            SlotType = slot;
            ClockFrequency = clockFrequency;
            MemorySizeInGb = memorySize;
            Height = height;
            Latecy = latecy;
        }

    }
}
