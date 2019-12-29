using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.ContextDbs;

namespace Web.Controllers
{
    public class PostController : Controller
    {
        private PostContext db;

        public PostController()
        {
            this.db = new PostContext();
        }

        public ActionResult Index(string searchStringTitle, string searchStringTag, string searchStringAuthor)
        {

            var people = from p in db.Posts
                           select p;

            // Search               
            ViewData["CurrentFilterTitle"] = searchStringTitle;
            if (!String.IsNullOrEmpty(searchStringTitle))
            {
                people = people.Where(s => s.Title.Contains(searchStringTitle) || s.Title.Contains(searchStringTitle));
            }

            ViewData["CurrentFilterTag"] = searchStringTag;
            if (!String.IsNullOrEmpty(searchStringTag))
            {
                people = people.Where(s => s.Tag.Contains(searchStringTag));
            }

            ViewData["CurrentFilterAuthor"] = searchStringAuthor;
            if (!String.IsNullOrEmpty(searchStringAuthor))
            {
                people = people.Where(s => s.Author.Contains(searchStringAuthor));
            }

            try
            {
                return View(people);
            } catch (Exception e) {
                string message = e.ToString ();
                Console.WriteLine(message);
                return RedirectToAction("Index");
            }

        }

        public ActionResult CountGoodIncrease(int Id)
        {
            Post post = this.db.Posts.Find(Id);
            if(post == null)
            {
                return HttpNotFound();
            }
            post.CountGood += 1;
           
            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }

        public ActionResult CountBadIncrease(int Id)
        {
            Post post = this.db.Posts.Find(Id);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.CountBad += 1;

            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create([Bind (Include = "Title,Content,Tag,Author")]Post p)
        {
            p.CountBad = 0;
            p.CountGood = 0;
            p.Created = new DateTime();

            if (ModelState.IsValid) 
            { 
                db.Posts.Add(p); 
                db.SaveChanges(); 
                return RedirectToAction("Index"); 
            } 
            return View ();
        }
      }
}