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
    public class CubeController : Controller
    {
        CubeService service = new CubeService();
        // GET: Cube
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
            Cube cube = service.Find((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }
        // GET: Cubes/Create
        public ActionResult Add()
        {
            return View();
        }



        // POST: Cubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Weight,SideLength,ConstructionMaterial,Contents,CurrentLocation,DateCreated")] Cube cube)
        {
            cube.DateCreated = DateTime.Now;

            if (cube.Contents == null)
            {
                cube.Contents = "";
            }

            if (ModelState.IsValid)
            {
                service.Create(cube);

                return RedirectToAction("Index");
            }

            return View(cube);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = service.Find((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        // POST: Cubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,SideLength,ConstructionMaterial,Contents,CurrentLocation,DateCreated")] Cube cube)
        {
            if (ModelState.IsValid)
            {
                service.Edit(cube);

                return RedirectToAction("Index");
            }
            return View(cube);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult ArchiveConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = service.Find((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }

            cube.Weight *= -1;

            service.Edit(cube);

            return RedirectToAction("Index");
        }
    }
}