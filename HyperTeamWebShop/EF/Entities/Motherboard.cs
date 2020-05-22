using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.EF
{
    public class Motherboard : Product
    {
        public int Id { get; set; }

        public SocketType SocketType {get; set;}
        public SlotType SlotType { get; set; }
        public int USB3Ports { get; set; }
        public bool WifiAdapter { get; set; }
        public MotherBoardSize MotherBoardSize { get; set; }

        public Motherboard() { }

        public Motherboard(SocketType socket, SlotType slot, int usb3ports, bool wifiSupport, MotherBoardSize boardSize, string manu, string type, string imgUrl, int purchasePrice, int sellingPrice) : base(manu,type,imgUrl,purchasePrice,sellingPrice) 
        {
            SocketType = socket;
            SlotType = slot;
            USB3Ports = usb3ports;
            WifiAdapter = wifiSupport;
            MotherBoardSize = boardSize;
        }

    }
}
