using System;
using System.Net;
using System.Web.Mvc;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class BarrelController : Controller
    {
        BarrelService service = new BarrelService();
        // GET: Barrel
        public ActionResult Index()
        {
            return (Index(true));
        }
        [HttpPost]
        public ActionResult Index(bool active)
        {
            if (active)
            {
                return View(service.GetActive());
            }
            else
            {
                return View(service.GetArchive());
            }
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.Find((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }
        // GET: Barrels/Create
        public ActionResult Add()
        {
            return View();
        }

        

        // POST: Barrels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Weight,Radius,Height,ConstructionMaterial,Contents,CurrentLocation,DateCreated")] Barrel barrel)
        {
            barrel.DateCreated = DateTime.Now;

            if(barrel.Contents == null)
            {
                barrel.Contents = "";
            }

            if (ModelState.IsValid)
            {
                service.Create(barrel);

                //return RedirectToAction("Index");
            }

            return View(barrel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.Find((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }

        // POST: Barrels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Radius,Height,ConstructionMaterial,Contents,CurrentLocation,DateCreated")] Barrel barrel)
        {
            if (ModelState.IsValid)
            {
                service.Edit(barrel);

                return RedirectToAction("Index");
            }
            return View(barrel);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult ArchiveConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.Find((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }

            barrel.Weight *= -1;

            service.Edit(barrel);

            return RedirectToAction("Index");
        }
    }
}