using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.Repositroy
{
    public class ProcessorRepository : IRepository<Processor>
    {
        private readonly ShopContext context;
        public ProcessorRepository(ShopContext context) 
        {
            this.context = context;
        }

        public IQueryable<Processor> GetAll()
        {
            var processors = context.Processors;
            return processors.AsQueryable();
        }
        public Processor GetById(int id)
        {
            var processor = context.Processors.Where(p => p.Id == id).FirstOrDefault();
            return processor;
        }

        public int Insert(Processor processor)
        {
            context.Processors.Add(processor);
            context.SaveChanges();

            var processorEntity = GetById(processor.Id);
            return processorEntity.Id;
        }

        public int Update(Processor processor)
        {
            context.Processors.AddOrUpdate(processor);
            context.SaveChanges();

            var processorEntity = GetById(processor.Id);
            return processorEntity.Id;
        }

        public void Delete(int id)
        {
            var processorEntity = GetById(id);
            context.Processors.Remove(processorEntity);
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
