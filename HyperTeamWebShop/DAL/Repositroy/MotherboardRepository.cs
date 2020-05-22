using HyperTeamWebShop.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.Repositroy
{
    public class MotherboardRepository : IRepository<Motherboard>
    {
        private readonly ShopContext context;
        public MotherboardRepository(ShopContext context) 
        {
            this.context = context;
        }

        public IQueryable<Motherboard> GetAll()
        {
            var motherboards = context.Motherboards;
            return motherboards.AsQueryable();
        }

        public Motherboard GetById(int id)
        {
            var motherboard = context.Motherboards.Where(m => m.Id == id).FirstOrDefault();
            return motherboard;
        }

        public int Insert(Motherboard motherboard)
        {
            context.Motherboards.Add(motherboard);
            context.SaveChanges();
            
            var motherboardEntity = GetById(motherboard.Id);
            return motherboardEntity.Id;
        }

        public int Update(Motherboard motherboard)
        {
            context.Motherboards.AddOrUpdate(motherboard);
            context.SaveChanges();

            var motherboardEntity = GetById(motherboard.Id);
            return motherboardEntity.Id;
        }

        public void Delete(int id)
        {
            var motherboardEntity = GetById(id);
            context.Motherboards.Remove(motherboardEntity);
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
