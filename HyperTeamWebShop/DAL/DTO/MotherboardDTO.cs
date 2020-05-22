using HyperTeamWebShop.EF;
using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.DTO
{
    public class MotherboardDTO : ProductDTO<MotherboardDTO,Motherboard>
    {
        public int Id { get; set; }

        public string SocketType {get; set;}
        public string SlotType { get; set; }
        public int USB3Ports { get; set; }
        public bool WifiAdapter { get; set; }
        public string MotherBoardSize { get; set; }

        public IEnumerable<ProcessorDTO> CompatibleProcessors { get; set; }

        public override MotherboardDTO EntityToDto(Motherboard motherboard)
        {
            if (motherboard != null)
            {
                return new MotherboardDTO
                {
                    Id = motherboard.Id,
                    SocketType = motherboard.SocketType.ToString(),
                    SlotType = motherboard.SlotType.ToString(),
                    USB3Ports = motherboard.USB3Ports,
                    WifiAdapter = motherboard.WifiAdapter,
                    MotherBoardSize = motherboard.MotherBoardSize.ToString(),
                    ImgURL = motherboard.ImgURL,
                    Manufacturer = motherboard.Manufacturer,
                    Type = motherboard.Type,
                    Price = motherboard.SellingPrice
                };
            }
            else 
            {
                throw new Exception("Motherboard doesn't exist.");
            }

        }

        public override Motherboard DtoToEntity(MotherboardDTO motherboardDto)
        {
            try
            {
                return new Motherboard
                {
                    Id = motherboardDto.Id,
                    SocketType = (SocketType)Enum.Parse(typeof(SocketType), motherboardDto.SocketType),
                    SlotType = (SlotType)Enum.Parse(typeof(SlotType), motherboardDto.SlotType),
                    USB3Ports = motherboardDto.USB3Ports,
                    WifiAdapter = motherboardDto.WifiAdapter,
                    MotherBoardSize = (MotherBoardSize)Enum.Parse(typeof(MotherBoardSize), motherboardDto.MotherBoardSize),
                    ImgURL = motherboardDto.ImgURL,
                    Manufacturer = motherboardDto.Manufacturer,
                    Type = motherboardDto.Type,
                    SellingPrice = motherboardDto.Price
                };
            }
            catch (Exception)
            {
                throw new Exception("Some of the property wasn't valid.");
            }
        }
    }
}
