using HyperTeamWebShop.DAL.DTO;
using HyperTeamWebShop.DAL.Repositroy;
using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public class MotherboardService : ServiceBase<MotherboardDTO>
    {
        private MotherboardDTO motherboardDTO = new MotherboardDTO();
        private readonly MotherboardRepository motherboardRepository;
        private readonly ProcessorRepository processorRepository;

        public MotherboardService(MotherboardRepository motherboardRepository, ProcessorRepository processorRepository)
        {
            this.motherboardRepository = motherboardRepository;
            this.processorRepository = processorRepository;
        }

        public override IEnumerable<MotherboardDTO> GetAll()
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

        public override MotherboardDTO GetById(int id)
        {
            motherboardDTO = motherboardDTO.EntityToDto(motherboardRepository.GetById(id));
            SetCompatibleItems();
            return motherboardDTO;
        }

        public override int Insert(MotherboardDTO motherboard)
        {
            motherboardRepository.Insert(motherboardDTO.DtoToEntity(motherboard));
            return motherboard.Id;
        }

        public override int Update(MotherboardDTO motherboard)
        {
            motherboardRepository.Update(motherboardDTO.DtoToEntity(motherboard));
            return motherboard.Id;
        }

        public override void Delete(int id)
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
