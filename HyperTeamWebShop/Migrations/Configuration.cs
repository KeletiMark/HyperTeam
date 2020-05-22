namespace HyperTeamWebShop.Migrations
{
    using HyperTeamWebShop.EF;
    using HyperTeamWebShop.EF.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopContext context)
        {
            List<Motherboard> motherboards = new List<Motherboard>();
            List<Processor> processors = new List<Processor>();
            List<Memory> memories = new List<Memory>();

            motherboards.Add(new Motherboard(SocketType.AM4,SlotType.DDR4,2,false,MotherBoardSize.ATX,"ASUS", "ROG STRIX B450 - F","motherboard1.png",35000,42000));
            motherboards.Add(new Motherboard(SocketType.AM4,SlotType.DDR4,4,false,MotherBoardSize.ATX,"MSI", "B450 TOMAHAWK MAX", "motherboard2.png",32000,40000));
            motherboards.Add(new Motherboard(SocketType.AM4,SlotType.DDR4,4,false,MotherBoardSize.ATX, "GIGABYTE", "B450 AORUS PRO", "motherboard3.png",33000,43000));
            motherboards.Add(new Motherboard(SocketType.AM4,SlotType.DDR4,6,false,MotherBoardSize.eATX, "MSI", "Meg X570 Godlike", "motherboard4.png",189000,234000));
            motherboards.Add(new Motherboard(SocketType.LGA1051,SlotType.DDR4,6,false,MotherBoardSize.mATX, "ASUS", "ROG STRIX B360-G", "motherboard5.png",19000,36000));
            motherboards.Add(new Motherboard(SocketType.LGA1051,SlotType.DDR4,2,false,MotherBoardSize.mITX, "ASRock", "H110M-ITX", "motherboard6.png",8000,12750));
            motherboards.Add(new Motherboard(SocketType.AM3,SlotType.DDR3,1,true,MotherBoardSize.ATX, "ASRock", "970 Pro3 R2.0", "motherboard7.png",17000,25000));
            motherboards.Add(new Motherboard(SocketType.LGA1050,SlotType.DDR3,4,false,MotherBoardSize.mATX, "BIOSTAR", "H81MHV3", "motherboard8.png",16000,21250));
            motherboards.Add(new Motherboard(SocketType.AM3,SlotType.DDR3,2,true,MotherBoardSize.mATX, "GIGABYTE", "GA-78LMT-USB3 R2", "motherboard9.png",11000,19000));
            motherboards.Add(new Motherboard(SocketType.LGA1050,SlotType.DDR3,2,true,MotherBoardSize.mATX, "BIOSTAR", "H110MH V3", "motherboard10.png",11000,18400));

            processors.Add(new Processor(SocketType.AM4,6,3600,32,true,"AMD", "Ryzen 5 3600 Hexa-Core", "processor1.png",49000,61000));
            processors.Add(new Processor(SocketType.AM4,8,3700,16,true,"AMD", "Ryzen 7 2700X Octa-Core", "processor2.png",56000,72000));
            processors.Add(new Processor(SocketType.AM4,4,3100,8,true,"AMD", "Ryzen 3 1200 Quad-Core", "processor3.png",11000,20000));
            processors.Add(new Processor(SocketType.AM3,2,2700,4,false,"AMD", "Athlon 200GE Dual-Core", "processor4.png",8000,12000));
            processors.Add(new Processor(SocketType.AM3,4,3100,4,false,"AMD", "A8-9600 Quad-Core", "processor5.png",7000,19000));
            processors.Add(new Processor(SocketType.LGA1051,6,2900,9,false, "Intel", "Core i5-9400F Hexa-Cores", "processor6.png",39000,53000));
            processors.Add(new Processor(SocketType.LGA1050,4,3600,6,false, "Intel", "Core i3-9100F Quad-Core", "processor7.png",23000,37000));
            processors.Add(new Processor(SocketType.LGA1051,8,3600,16,false, "Intel", "Core i9-9900K Octa-Core", "processor8.png",96000,160000));
            processors.Add(new Processor(SocketType.LGA1051,6,3600,12,true, "Intel", "Core i7-8700K Hexa-Core", "processor9.png",86000,134000));
            processors.Add(new Processor(SocketType.LGA1051,4,3200,16,true, "Intel", "Core i5-6500 Quad-Core", "processor10.png",59000,82000));

            memories.Add(new Memory(SlotType.DDR3,1600,8,2,45,"Kingston", "HyperX FURY","memory1.png",12000,17000));
            memories.Add(new Memory(SlotType.DDR3,1866,8,2,50,"Kingston", "HyperX FURY","memory2.png",13000,20000));
            memories.Add(new Memory(SlotType.DDR3,1333,2,2,120,"CSX", "CSXD3LO", "memory3.png",4000,8000));
            memories.Add(new Memory(SlotType.DDR3,2133,32,2,30,"G.SKILL", "F3-2133C9Q-32GZH", "memory4.png",72000,93000));
            memories.Add(new Memory(SlotType.DDR3,2133,32,2,30, "Corsair", "CML32GX3M4A1600C10", "memory5.png",51000,74000));
            memories.Add(new Memory(SlotType.DDR4,3200,16,2,30, "G.SKILL", "F4-3200C16D-16GTZR", "memory6.png",19000,37000));
            memories.Add(new Memory(SlotType.DDR4,3200,32,2,30, "Crucial", "Ballistix Sport LT", "memory7.png",19000,37000));
            memories.Add(new Memory(SlotType.DDR4,3200,32,2,30, "Kingston", "HyperX FURY", "memory8.png",19000,37000));
            memories.Add(new Memory(SlotType.DDR4,3200,32,2,30, "Kingston", "HyperX Predator", "memory9.png",11000,29000));
            memories.Add(new Memory(SlotType.DDR4,3200,32,2,30, "G.SKILL", "Ripjaws V", "memory10.png",21000,32000));

            foreach (var motherboard in motherboards)
            {
                context.Motherboards.AddOrUpdate(motherboard);
            }

            foreach (var processor in processors) 
            {
                context.Processors.AddOrUpdate(processor);
            }

            foreach (var memory in memories)
            {
                context.Memories.AddOrUpdate(memory);
            }

        }
    }
}
