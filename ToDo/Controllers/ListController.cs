using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;
using Microsoft.AspNet.Identity;

namespace ToDo.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /List/
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(user => user.Id == currentUserId);
            //var modelList = db.ToDoDBlist.ToList().Where(user => user.User == currentUser);
            var modelList = db.ToDoDBlist.Where(user => user.UserId == currentUserId).ToList();
            return View(modelList);   
        }


        private IEnumerable<ToDoDB> GetList()
        {
            string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(user => user.Id == currentUserId);
            return db.ToDoDBlist.Where(user => user.UserId == currentUserId).ToList();   
        }

        public ActionResult BuildTable()
        {
            return PartialView("_ListControll",GetList());
        }

        // GET: /List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoDB tododb = db.ToDoDBlist.Find(id);
            if (tododb == null)
            {
                return HttpNotFound();
            }
            return View(tododb);
        }

        // GET: /List/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Description,checkList")] ToDoDB tododb)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(user => user.Id == currentUserId);
                tododb.User = currentUser;
                db.ToDoDBlist.Add(tododb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tododb);
        }

        // GET: /List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoDB tododb = db.ToDoDBlist.Find(id);
            if (tododb == null)
            {
                return HttpNotFound();
            }
            return View(tododb);
        }

        // POST: /List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Description,checkList")] ToDoDB tododb)
        {
            if (ModelState.IsValid)
            {
                //bugging losting FK when save
                //db.Entry(tododb).State = EntityState.Modified;
                var dbModel = db.ToDoDBlist.Where(x=>x.ID == tododb.ID).FirstOrDefault();
                if (dbModel == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    dbModel.checkList = tododb.checkList;
                    dbModel.Title = tododb.Title;
                    dbModel.Description = tododb.Description;
                    db.SaveChanges();
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tododb);
        }

        [HttpPost]
        public ActionResult ClickEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoDB tododb = db.ToDoDBlist.Find(id);
            if (tododb == null)
            {
                return HttpNotFound();
            }
            else
            {
                tododb.checkList = value;
                db.Entry(tododb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return PartialView("_ListControll", GetList());
        }

        // GET: /List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoDB tododb = db.ToDoDBlist.Find(id);
            if (tododb == null)
            {
                return HttpNotFound();
            }
            return View(tododb);
        }

        // POST: /List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoDB tododb = db.ToDoDBlist.Find(id);
            db.ToDoDBlist.Remove(tododb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
