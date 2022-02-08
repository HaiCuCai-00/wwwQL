using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BSAF16072021.Models;

namespace BSAF16072021.Areas.training.Controllers
{
    public class TopicTraineesController : Controller
    {
        private SQL160721Entities2 db = new SQL160721Entities2();

        // GET: training/TopicTrainees
        public ActionResult Index()
        {
            if (Session["training"] == null)
            {
                return RedirectToAction("Login", "Default");
            }
            var topicTrainees = db.TopicTrainees.Include(t => t.Topic).Include(t => t.Trainee);
            return View(topicTrainees.ToList());
        }

        // GET: training/TopicTrainees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicTrainee topicTrainee = db.TopicTrainees.Find(id);
            if (topicTrainee == null)
            {
                return HttpNotFound();
            }
            return View(topicTrainee);
        }

        // GET: training/TopicTrainees/Create
        public ActionResult Create()
        {
            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name");
            ViewBag.id_trainee = new SelectList(db.Trainees, "trainee_id", "trainee_name");
            return View();
        }

        // POST: training/TopicTrainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_topictrainer,id_topic,startday,id_trainee,dadelete")] TopicTrainee topicTrainee)
        {
            if (ModelState.IsValid)
            {
                db.TopicTrainees.Add(topicTrainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name", topicTrainee.id_topic);
            ViewBag.id_trainee = new SelectList(db.Trainees, "trainee_id", "trainee_name", topicTrainee.id_trainee);
            return View(topicTrainee);
        }

        // GET: training/TopicTrainees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicTrainee topicTrainee = db.TopicTrainees.Find(id);
            if (topicTrainee == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name", topicTrainee.id_topic);
            ViewBag.id_trainee = new SelectList(db.Trainees, "trainee_id", "trainee_name", topicTrainee.id_trainee);
            return View(topicTrainee);
        }

        // POST: training/TopicTrainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_topictrainer,id_topic,startday,id_trainee,dadelete")] TopicTrainee topicTrainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topicTrainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_topic = new SelectList(db.Topics, "topic_id", "topic_name", topicTrainee.id_topic);
            ViewBag.id_trainee = new SelectList(db.Trainees, "trainee_id", "trainee_name", topicTrainee.id_trainee);
            return View(topicTrainee);
        }

        // GET: training/TopicTrainees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicTrainee topicTrainee = db.TopicTrainees.Find(id);
            if (topicTrainee == null)
            {
                return HttpNotFound();
            }
            return View(topicTrainee);
        }

        // POST: training/TopicTrainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopicTrainee topicTrainee = db.TopicTrainees.Find(id);
            db.TopicTrainees.Remove(topicTrainee);
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
