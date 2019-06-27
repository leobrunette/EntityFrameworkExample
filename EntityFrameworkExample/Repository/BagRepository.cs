using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class BagRepository
    {
        private DataContext dbContext;
        public BagRepository()
        {
            dbContext = new DataContext();
        }

        public List<Bag> GetAll()
        {
            return dbContext.Bags.ToList();
        }

        public List<Bag> GetActive()
        {
            return GetAll().Where(b => b.Weight > 0).ToList();
        }

        public List<Bag> GetArchive()
        {
            return GetAll().Where(b => b.Weight < 0).ToList();
        }

        public void Create(Bag bag)
        {
            dbContext.Bags.Add(bag);
            dbContext.SaveChanges();
        }

        public void Edit(Bag bag)
        {
            dbContext.Entry(bag).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Bag Find(int? id)
        {
            return dbContext.Bags.Find(id);

        }
    }
}