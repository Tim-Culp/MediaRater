using MediaRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaRater.Controllers
{
    public class ReviewController : Controller
    {
        private MediaRaterDbContext _db = new MediaRaterDbContext();
        // GET: Review
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Media med = _db.Media.Find(id);
            System.Diagnostics.Debug.WriteLine("MEDIA PASSED IN: " + med.Name + ",\n" +
                med.Description + ",\n" +
                med.AgeRating);
            if (med == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            Review blankReview = new Review() { MediaID = int.Parse(id.ToString()), OnMedia = med };
            System.Diagnostics.Debug.WriteLine("ONMEDIA PASSED IN: " + blankReview.OnMedia.Name + ",\n" +
                blankReview.OnMedia.Description + ",\n" +
                med.AgeRating);
            return View(blankReview);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review rev)
        {
            System.Diagnostics.Debug.WriteLine("1st Rev: " + rev.MediaID.ToString());
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(rev);
                //Media med = _db.Media.Find(rev.OnMedia.MediaID);
                System.Diagnostics.Debug.WriteLine("Rev: " + rev.MediaID.ToString());
                //med.Reviews.Add(rev);
                //_db.Entry(med).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "Media");

            }
            return View(rev);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Review rev = _db.Reviews.Find(id);
            if (rev == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(rev);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Review revs = _db.Reviews.Find(id);
            _db.Reviews.Remove(revs);
            _db.SaveChanges();
            return RedirectToAction("Details", "Media", new { id = revs.MediaID });
        }
    }
}