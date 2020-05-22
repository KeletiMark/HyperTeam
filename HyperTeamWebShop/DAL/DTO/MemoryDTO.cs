using HyperTeamWebShop.EF;
using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.DTO
{
    public class MemoryDTO : ProductDTO<MemoryDTO,Memory>
    {
        public int Id { get; set; }

        public string SlotType { get; set; }
        public int ClockFrequency { get; set; }
        public int MemorySizeInGb { get; set; }
        public int Height { get; set; }
        public int Latecy { get; set; }

        public IEnumerable<MotherboardDTO> CompatibleMotherboards { get; set; }

        public override MemoryDTO EntityToDto(Memory memory)
        {
            if (memory != null)
            {
                return new MemoryDTO
                {
                    Id = memory.Id,
                    SlotType = memory.SlotType.ToString(),
                    ClockFrequency = memory.ClockFrequency,
                    MemorySizeInGb = memory.MemorySizeInGb,
                    Height = memory.Height,
                    Latecy = memory.Latecy,
                    ImgURL = memory.ImgURL,
                    Manufacturer = memory.Manufacturer,
                    Type = memory.Type,
                    Price = memory.SellingPrice
                };
            }
            else 
            {
                throw new Exception("Memory doesn't exist.");
            }

        }

        public override Memory DtoToEntity(MemoryDTO memoryDto) 
        {
            try
            {
                return new Memory
                {
                    Id = memoryDto.Id,
                    SlotType = (SlotType)Enum.Parse(typeof(SlotType), memoryDto.SlotType),
                    ClockFrequency = memoryDto.ClockFrequency,
                    MemorySizeInGb = memoryDto.MemorySizeInGb,
                    Height = memoryDto.Height,
                    Latecy = memoryDto.Latecy,
                    ImgURL = memoryDto.ImgURL,
                    Manufacturer = memoryDto.Manufacturer,
                    Type = memoryDto.Type,
                    SellingPrice = memoryDto.Price
                };
            }
            catch (Exception)
            {
                throw new Exception("Some of the property wasn't valid.");
            }
        }
    }
}
