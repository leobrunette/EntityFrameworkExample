using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;

namespace EntityFrameworkExample.Controllers
{
    internal class BarrelService
    {

        private BarrelRepository repo;
        public BarrelService()
        {
            repo = new BarrelRepository();
        }

        public void Create(Barrel barrel)
        {
            repo.Create(barrel);
        }

        public void Edit(Barrel barrel)
        {
            repo.Edit(barrel);
        }

        public void Remove(int? id)
        {
            repo.Remove(id);
        }
        public Barrel Find(int? id)
        {
            return repo.Find(id);

        }
    }
}