using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BSAF16072021.Models;

namespace BSAF16072021.Areas.users.Controllers
{
    public class TopicTrainersController : Controller
    {
        private SQL160721Entities2 db = new SQL160721Entities2();

        // GET: users/TopicTrainers
        public ActionResult Index()
        {
            if (Session["trainer"] == null)
            {
                return RedirectToAction("Login", "Default");
            }
            var topicTrainers = db.TopicTrainers.Include(t => t.Topic).Include(t => t.Trainer);
            return View(topicTrainers.ToList());
        }

        // GET: users/TopicTrainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicTrainer topicTrainer = db.TopicTrainers.Find(id);
            if (topicTrainer == null)
            {
                return HttpNotFound();
            }
            return View(topicTrainer);
        }

        // GET: users/TopicTrainers/Create
        public ActionResult Create()
        {
            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name");
            ViewBag.id_trainer = new SelectList(db.Trainers, "trainer_id", "trainer_name");
            return View();
        }

        // POST: users/TopicTrainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_topictrainer,id_topic,id_trainer,startday,dadelete")] TopicTrainer topicTrainer)
        {
            if (ModelState.IsValid)
            {
                db.TopicTrainers.Add(topicTrainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name", topicTrainer.id_topic);
            ViewBag.id_trainer = new SelectList(db.Trainers, "trainer_id", "trainer_name", topicTrainer.id_trainer);
            return View(topicTrainer);
        }

        // GET: users/TopicTrainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicTrainer topicTrainer = db.TopicTrainers.Find(id);
            if (topicTrainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name", topicTrainer.id_topic);
            ViewBag.id_trainer = new SelectList(db.Trainers, "trainer_id", "trainer_name", topicTrainer.id_trainer);
            return View(topicTrainer);
        }

        // POST: users/TopicTrainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_topictrainer,id_topic,id_trainer,startday,dadelete")] TopicTrainer topicTrainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topicTrainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name", topicTrainer.id_topic);
            ViewBag.id_trainer = new SelectList(db.Trainers, "trainer_id", "trainer_name", topicTrainer.id_trainer);
            return View(topicTrainer);
        }

        // GET: users/TopicTrainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicTrainer topicTrainer = db.TopicTrainers.Find(id);
            if (topicTrainer == null)
            {
                return HttpNotFound();
            }
            return View(topicTrainer);
        }

        // POST: users/TopicTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopicTrainer topicTrainer = db.TopicTrainers.Find(id);
            db.TopicTrainers.Remove(topicTrainer);
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
