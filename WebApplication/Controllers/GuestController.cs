using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [AllowAnonymous]
    public class GuestController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();
        public ActionResult Index(string type, string searchString, string venue, DateTime? dateRange)
        {
            var events = from e in db.Events select e;
            ViewBag.Venues = events.Select(v => v.Meet.Venue).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                switch (type)
                {
                    case "age":
                        events = events.Where(s => s.AgeRange.ToString().Contains(searchString));
                        return View(events.ToList());
                    case "stroke":
                        events = events.Where(s => s.Stroke.Contains(searchString));
                        return View(events.ToList());
                    case "name":
                        var participant = from p in db.Participants where p.Child.Firstname.StartsWith(searchString) select p;
                        events = events.Where(e => e.Participants.Contains(participant.FirstOrDefault()));
                        return View(events.ToList());
                }
            }
            switch (type)
            {
                case "14":
                    events = events.Where(s => s.AgeRange <= 14);
                    return View(events.ToList());
                case "16":
                    events = events.Where(s => s.AgeRange <= 16);
                    return View(events.ToList());
                case "distance5":
                    events = events.Where(s => s.Distance <= 5 && s.Distance > 0);
                    return View(events.ToList());
                case "distance10":
                    events = events.Where(s => s.Distance <= 10 && s.Distance > 5);
                    return View(events.ToList());
                case "distance15":
                    events = events.Where(s => s.Distance <= 15 && s.Distance > 10);
                    return View(events.ToList());
                case "distance20":
                    events = events.Where(s => s.Distance <= 20 && s.Distance > 15);
                    return View(events.ToList());
                case "distance25":
                    events = events.Where(s => s.Distance <= 25 && s.Distance > 20);
                    return View(events.ToList());
                case "male":
                    events = events.Where(s => s.Gender == "M");
                    return View(events.ToList());
                case "female":
                    events = events.Where(s => s.Gender == "F");
                    return View(events.ToList());
            }
            if(dateRange != null)
            {
                events = events.Where(s => s.Meet.Date >= dateRange);
                return View(events.ToList());
            }
                        return View(events.ToList());
        }
    }
}