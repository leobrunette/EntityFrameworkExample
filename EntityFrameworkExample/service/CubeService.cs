using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.service
{
    public class CubeService
    {

        private CubeRepository repo;
        public CubeService()
        {
            repo = new CubeRepository();
        }

        public List<Cube> GetAll()
        {
            return repo.GetAll();
        }

        public List<Cube> GetActive()
        {
            return repo.GetActive();
        }

        public List<Cube> GetArchive()
        {
            return repo.GetArchive();
        }

        public void Create(Cube cube)
        {
            repo.Create(cube);
        }

        public void Edit(Cube cube)
        {
            repo.Edit(cube);
        }

        public Cube Find(int? id)
        {
            return repo.Find(id);

        }
    }
}