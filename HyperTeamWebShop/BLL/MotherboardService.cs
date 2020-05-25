using HyperTeamWebShop.DAL.DTO;
using HyperTeamWebShop.DAL.Repositroy;
using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public class MotherboardService : IService<MotherboardDTO>
    {
        private MotherboardDTO motherboardDTO = new MotherboardDTO();
        private readonly IRepository<Motherboard> motherboardRepository;
        private readonly IRepository<Processor> processorRepository;

        public MotherboardService(IRepository<Motherboard> motherboardRepository, IRepository<Processor> processorRepository)
        {
            this.motherboardRepository = motherboardRepository;
            this.processorRepository = processorRepository;
        }

        public IEnumerable<MotherboardDTO> GetAll()
        {
            var motherboards = new List<MotherboardDTO>();
            foreach (var motherboard in motherboardRepository.GetAll())
            {
                motherboardDTO = motherboardDTO.EntityToDto(motherboard);
                SetCompatibleItems();
                motherboards.Add(motherboardDTO);
            }
            return motherboards;
        }

        public MotherboardDTO GetById(int id)
        {
            motherboardDTO = motherboardDTO.EntityToDto(motherboardRepository.GetById(id));
            SetCompatibleItems();
            return motherboardDTO;
        }

        public int Insert(MotherboardDTO motherboard)
        {
            motherboardRepository.Insert(motherboardDTO.DtoToEntity(motherboard));
            return motherboard.Id;
        }

        public int Update(MotherboardDTO motherboard)
        {
            motherboardRepository.Update(motherboardDTO.DtoToEntity(motherboard));
            return motherboard.Id;
        }

        public void Delete(int id)
        {
            motherboardRepository.Delete(id);
        }

        private void SetCompatibleItems()
        {
            motherboardDTO.CompatibleProcessors = FindCompatibleProcessor();
        }

        private IEnumerable<ProcessorDTO> FindCompatibleProcessor()
        {
            List<ProcessorDTO> processorDTOs = new List<ProcessorDTO>();
            var processorDTO = new ProcessorDTO();
            foreach (var processor in processorRepository.GetAll())
            {
                processorDTOs.Add(processorDTO.EntityToDto(processor));
            }
            return processorDTOs.Where(p => p.SocketType == motherboardDTO.SocketType);
        }

    }
}
