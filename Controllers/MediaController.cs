using MediaRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaRater.Controllers
{

    public class MediaController : Controller
    {
        private MediaRaterDbContext _db = new MediaRaterDbContext();
        // GET: Media
        public ActionResult Index()
        {
            return View(_db.Media.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Media med)
        {
            if (ModelState.IsValid)
            {
                //med.Reviews = new List<Review>();
                _db.Media.Add(med);
                //Review rev = new Review() { MediaID = med.MediaID, OnMedia = med, StarRating = 5, Text = "Greate movvie" };
                //_db.Media.Find(med.MediaID).Reviews.Add(rev);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(med);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Media foundMedia = (_db.Media.Find(id));
            if (foundMedia == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(foundMedia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Media med)
        {
            if (ModelState.IsValid)
            {
                
                _db.Entry(med).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(med);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Media med = _db.Media.Find(id);
            if (med == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(med);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Media med = _db.Media.Find(id);
            var revs = _db.Reviews.Where(e => e.MediaID == id).ToList();
            if (revs.Count > 0)
            {
                foreach (Review review in revs)
                {
                    _db.Reviews.Remove(review);
                }
            }
            _db.Media.Remove(med);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Media med = _db.Media.Find(id);
            var revs = _db.Reviews.Where(e => e.MediaID == id );
            if (med == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            MediaDetails medD = new MediaDetails
            {
                MediaID = med.MediaID,
                AgeRating = med.AgeRating,
                Description = med.Description,
                Name = med.Name,
                Reviews = revs.ToList<Review>()
            };
            return View(medD);
        }
    }
}