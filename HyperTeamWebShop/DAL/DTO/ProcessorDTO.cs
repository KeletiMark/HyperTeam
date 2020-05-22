using HyperTeamWebShop.EF;
using HyperTeamWebShop.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.DTO
{
    public class ProcessorDTO : ProductDTO<ProcessorDTO,Processor>
    {
        public int Id { get; set; }

        public string SocketType { get; set; }
        public int Cores { get; set; }
        public int ClockFrequency { get; set; }
        public int L3CacheSize { get; set; }
        public bool SMTSupport { get; set; }

        public IEnumerable<MotherboardDTO> CompatibleMotherboards { get; set; }

        public override ProcessorDTO EntityToDto(Processor processor)
        {
            if (processor != null)
            {
                return new ProcessorDTO
                {
                    Id = processor.Id,
                    SocketType = processor.SocketType.ToString(),
                    Cores = processor.Cores,
                    ClockFrequency = processor.ClockFrequency,
                    L3CacheSize = processor.L3CacheSize,
                    SMTSupport = processor.SMTSupport,
                    ImgURL = processor.ImgURL,
                    Manufacturer = processor.Manufacturer,
                    Type = processor.Type,
                    Price = processor.SellingPrice
                };
            }
            else 
            {
                throw new Exception("Processor doesn't exist.");
            }

        }

        public override Processor DtoToEntity(ProcessorDTO processorDto)
        {
            try
            {
                return new Processor
                {
                    Id = processorDto.Id,
                    SocketType = (SocketType)Enum.Parse(typeof(SocketType), processorDto.SocketType),
                    Cores = processorDto.Cores,
                    ClockFrequency = processorDto.ClockFrequency,
                    L3CacheSize = processorDto.L3CacheSize,
                    SMTSupport = processorDto.SMTSupport,
                    ImgURL = processorDto.ImgURL,
                    Manufacturer = processorDto.Manufacturer,
                    Type = processorDto.Type,
                    SellingPrice = processorDto.Price
                };
            }
            catch (Exception)
            {
                throw new Exception("Some of the property wasn't valid.");
            }
        }
    }
}
