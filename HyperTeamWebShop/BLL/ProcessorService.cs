using HyperTeamWebShop.DAL.DTO;
using HyperTeamWebShop.DAL.Repositroy;
using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public class ProcessorService : IService<ProcessorDTO>
    {
        private ProcessorDTO processorDto = new ProcessorDTO();
        private readonly IRepository<Processor> processorRepository;
        private readonly IService<MotherboardDTO> motherboardService;

        public ProcessorService(IRepository<Processor> processorRepository, IService<MotherboardDTO> motherboardService) 
        {
            this.processorRepository = processorRepository;
            this.motherboardService = motherboardService;
        }

        public IEnumerable<ProcessorDTO> GetAll() 
        {
            var processors = new List<ProcessorDTO>();
            foreach (var processor in processorRepository.GetAll())
            {
                processorDto = processorDto.EntityToDto(processor);
                SetCompatibleItems();
                processors.Add(processorDto);
            }
            return processors;
        }

        public ProcessorDTO GetById(int id) 
        {
            processorDto = processorDto.EntityToDto(processorRepository.GetById(id));
            SetCompatibleItems();
            return processorDto;
        }

        public int Insert(ProcessorDTO processor)
        {
            processorRepository.Insert(processorDto.DtoToEntity(processor));
            return processor.Id;
        }

        public int Update(ProcessorDTO processor)
        {
            processorRepository.Update(processorDto.DtoToEntity(processor));
            return processor.Id;
        }

        public void Delete(int id)
        {
            processorRepository.Delete(id);
        }

        private void SetCompatibleItems() 
        {
            processorDto.CompatibleMotherboards = FindCompatible();
        }

        private IEnumerable<MotherboardDTO> FindCompatible()
        {
            return motherboardService.GetAll().Where(m => m.SocketType == processorDto.SocketType);
        }
    }
}
