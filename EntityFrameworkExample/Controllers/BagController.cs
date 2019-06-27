using EntityFrameworkExample.Models;
using EntityFrameworkExample.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkExample.Controllers
{
    public class BagController : Controller
    {
        BagService service = new BagService();
        // GET: Bag
        public ActionResult Index()
        {
            return (Index(true));
        }

        public ActionResult IndexInactive()
        {
            return (Index(false));
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
            Bag bag = service.Find((int)id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }
        // GET: Bags/Create
        public ActionResult Add()
        {
            return View();
        }



        // POST: Bags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Weight,Radius,Height,ConstructionMaterial,Contents,CurrentLocation,DateCreated")] Bag bag)
        {
            bag.DateCreated = DateTime.Now;

            if (bag.Contents == null)
            {
                bag.Contents = "";
            }

            if (ModelState.IsValid)
            {
                service.Create(bag);

                return RedirectToAction("Index");
            }

            return View(bag);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = service.Find((int)id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        // POST: Bags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Radius,Height,ConstructionMaterial,Contents,CurrentLocation,DateCreated")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                service.Edit(bag);

                return RedirectToAction("Index");
            }
            return View(bag);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult ArchiveConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = service.Find((int)id);
            if (bag == null)
            {
                return HttpNotFound();
            }

            bag.Weight *= -1;

            service.Edit(bag);

            return RedirectToAction("Index");
        }
    }
}