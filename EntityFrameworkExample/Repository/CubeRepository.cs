using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class CubeRepository
    {
        private DataContext dbContext;
        public CubeRepository()
        {
            dbContext = new DataContext();
        }

        public List<Cube> GetAll()
        {
            return dbContext.Cubes.ToList();
        }

        public List<Cube> GetActive()
        {
            return GetAll().Where(b => b.Weight > 0).ToList();
        }

        public List<Cube> GetArchive()
        {
            return GetAll().Where(b => b.Weight < 0).ToList();
        }

        public void Create(Cube cube)
        {
            dbContext.Cubes.Add(cube);
            dbContext.SaveChanges();
        }

        public void Edit(Cube cube)
        {
            dbContext.Entry(cube).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Cube Find(int? id)
        {
            return dbContext.Cubes.Find(id);

        }
    }
}