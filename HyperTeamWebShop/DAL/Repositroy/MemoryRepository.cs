using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.Repositroy
{
    public class MemoryRepository : IRepository<Memory>
    {
        private readonly ShopContext context;
        public MemoryRepository(ShopContext context) 
        {
            this.context = context;
        }

        public IQueryable<Memory> GetAll()
        {
            var memories = context.Memories;
            return memories.AsQueryable();
        }

        public Memory GetById(int id)
        {
            var memoryEntity = context.Memories.Where(m => m.Id == id).FirstOrDefault();
            return memoryEntity;
        }
 
        public int Insert(Memory memory)
        {
            context.Memories.Add(memory);
            context.SaveChanges();

            var memoryEntity = GetById(memory.Id);
            return memoryEntity.Id;
        }

        public int Update(Memory memory)
        {
            context.Memories.AddOrUpdate(memory);
            context.SaveChanges();

            var memoryEntity = GetById(memory.Id);
            return memoryEntity.Id;
        }

        public void Delete(int id)
        {
            var memoryEntity = GetById(id);
            context.Memories.Remove(memoryEntity);
            context.SaveChanges();
        }

        public void Archive(int id)
        {
            throw new NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }

    }
}
