using HyperTeamWebShop.DAL.DTO;
using HyperTeamWebShop.DAL.Repositroy;
using HyperTeamWebShop.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public class ProcessorService : ServiceBase<ProcessorDTO>
    {
        private ProcessorDTO processorDto = new ProcessorDTO();
        private readonly ProcessorRepository processorRepository;
        private readonly MotherboardService motherboardService;

        public ProcessorService(ProcessorRepository processorRepository, MotherboardService motherboardService) 
        {
            this.processorRepository = processorRepository;
            this.motherboardService = motherboardService;
        }

        public override IEnumerable<ProcessorDTO> GetAll() 
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

        public override ProcessorDTO GetById(int id) 
        {
            processorDto = processorDto.EntityToDto(processorRepository.GetById(id));
            SetCompatibleItems();
            return processorDto;
        }

        public override int Insert(ProcessorDTO processor)
        {
            processorRepository.Insert(processorDto.DtoToEntity(processor));
            return processor.Id;
        }

        public override int Update(ProcessorDTO processor)
        {
            processorRepository.Update(processorDto.DtoToEntity(processor));
            return processor.Id;
        }

        public override void Delete(int id)
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
