using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleTwitter.Web.Commanding;
using SimpleTwitter.ReadModel;

namespace SimpleTwitter.Web.Controllers
{
	public class TweetController : Controller
	{
		//
		// GET: /Tweet/
		public ActionResult Index()
		{
			var context = new ReadModelDataContext();
			var query = from item in context.TweetListItems
						orderby item.TimeStamp descending
						select item;

			return View( query.ToList() );
		}

		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add( PostNewTweetCommand command )
		{
			var service = new SimpleTwitterCommandServiceClient();
			service.Excecute( command );

			return RedirectToAction( "Index" );
		}
	}
}
