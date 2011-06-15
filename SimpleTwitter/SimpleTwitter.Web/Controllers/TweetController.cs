using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleTwitter.Web.Commanding;

namespace SimpleTwitter.Web.Controllers
{
    public class TweetController : Controller
    {
        //
        // GET: /Tweet/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PostNewTweetCommand command)
        {
            var service = new SimpleTwitterCommandServiceClient();
            service.Excecute(command);

            return View(command);
        }
    }
}
