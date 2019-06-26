using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class BarrelRepository
    {
        private DataContext dbContext;
        public BarrelRepository()
        {
            dbContext = new DataContext();
        }

        public List<Barrel> GetAll()
        {
            return dbContext.Barrels.ToList();
        }

        public List<Barrel> GetActive()
        {
            return GetAll().Where(b => b.Weight > 0).ToList();
        }

        public List<Barrel> GetArchive()
        {
            return GetAll().Where(b => b.Weight < 0).ToList();
        }

        public void Create(Barrel barrel)
        {
            dbContext.Barrels.Add(barrel);
            dbContext.SaveChanges();
        }

        public void Edit(Barrel barrel)
        {
            dbContext.Entry(barrel).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Barrel Find(int? id)
        {
            return dbContext.Barrels.Find(id);

        }
    }
}