﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial2_DiegoDuran.Models;

namespace Parcial2_DiegoDuran.Controllers
{
    public class FriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Friends
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Friends.ToList());
        }

        // GET: Friends/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return HttpNotFound();
            }
            return View(friends);
        }

        // GET: Friends/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendID,Name,NickName,BirthDate")] Friends friends)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friends);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friends);
        }

        // GET: Friends/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return HttpNotFound();
            }
            return View(friends);
        }

        // POST: Friends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendID,Name,NickName,BirthDate")] Friends friends)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friends).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friends);
        }

        // GET: Friends/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return HttpNotFound();
            }
            return View(friends);
        }

        // POST: Friends/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friends friends = db.Friends.Find(id);
            db.Friends.Remove(friends);
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
