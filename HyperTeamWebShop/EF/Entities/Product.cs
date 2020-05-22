using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.EF
{
    public abstract class Product
    {
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string ImgURL { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }

        public Product() { }

        public Product(string manufacturer, string type, string imgUrl, int purchasePrice, int sellingPrice) 
        {
            Manufacturer = manufacturer;
            Type = type;
            ImgURL = imgUrl;
            PurchasePrice = purchasePrice;
            SellingPrice = sellingPrice;
        }

    }
}
