using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System.Collections.Generic;

namespace EntityFrameworkExample.Controllers
{
    internal class BarrelService
    {

        private BarrelRepository repo;
        public BarrelService()
        {
            repo = new BarrelRepository();
        }

        public List<Barrel> GetAll()
        {
            return repo.GetAll();
        }

        public List<Barrel> GetActive()
        {
            return repo.GetActive();
        }

        public List<Barrel> GetArchive()
        {
            List<Barrel> list = repo.GetArchive();
            for(int i = 0; i < list.Count; i++)
            {
                list[i].Weight *= -1;
            }
            return list;
        }

        public void Create(Barrel barrel)
        {
            repo.Create(barrel);
        }

        public void Edit(Barrel barrel)
        {
            repo.Edit(barrel);
        }

        public Barrel Find(int? id)
        {
            return repo.Find(id);

        }
    }
}