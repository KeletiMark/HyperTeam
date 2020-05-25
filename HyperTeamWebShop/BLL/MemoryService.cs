using HyperTeamWebShop.DAL.DTO;
using HyperTeamWebShop.DAL.Repositroy;
using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public class MemoryService : IService<MemoryDTO>
    {
        private MemoryDTO memoryDTO = new MemoryDTO();
        private readonly IRepository<Memory> memoryRepository;
        private readonly IService<MotherboardDTO> motherboardService;

        public MemoryService(IRepository<Memory> memoryRepository, IService<MotherboardDTO> motherboardService)
        {
            this.memoryRepository = memoryRepository;
            this.motherboardService = motherboardService;
        }

        public IEnumerable<MemoryDTO> GetAll()
        {
            var memories = new List<MemoryDTO>();
            foreach (var memory in memoryRepository.GetAll())
            {
                memoryDTO = memoryDTO.EntityToDto(memory);
                SetCompatibleItems();
                memories.Add(memoryDTO);
            }
            return memories;
        }

        public MemoryDTO GetById(int id)
        {
            memoryDTO = memoryDTO.EntityToDto(memoryRepository.GetById(id));
            SetCompatibleItems();
            return memoryDTO;
        }

        public int Insert(MemoryDTO memory)
        {
            memoryRepository.Insert(memoryDTO.DtoToEntity(memory));
            return memory.Id;
        }

        public int Update(MemoryDTO memory)
        {
            memoryRepository.Update(memoryDTO.DtoToEntity(memory));
            return memory.Id;
        }

        public void Delete(int id)
        {
            memoryRepository.Delete(id);
        }

        private void SetCompatibleItems()
        {
            memoryDTO.CompatibleMotherboards = FindCompatible();
        }

        private IEnumerable<MotherboardDTO> FindCompatible() 
        {
            return motherboardService.GetAll().Where(m => m.SlotType == memoryDTO.SlotType);
        }

    }
}
