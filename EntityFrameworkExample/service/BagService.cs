using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.service
{
    public class BagService
    {
        private BagRepository repo;
        public BagService()
        {
            repo = new BagRepository();
        }

        public List<Bag> GetAll()
        {
            return repo.GetAll();
        }

        public List<Bag> GetActive()
        {
            return repo.GetActive();
        }

        public List<Bag> GetArchive()
        {
            List<Bag> list = repo.GetArchive();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Weight *= -1;
            }
            return list;
        }

        public void Create(Bag bag)
        {
            repo.Create(bag);
        }

        public void Edit(Bag bag)
        {
            repo.Edit(bag);
        }

        public Bag Find(int? id)
        {
            return repo.Find(id);
        }
        public Bag FindInactive(int? id)
        {
            Bag bar = repo.Find(id);
            bar.Weight *= -1;
            return bar;
        }


    }
}