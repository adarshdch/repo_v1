
using System.Web.Mvc;
using SAB.BLL.Entities.Page;
using SAB.BLL.Manager;
using SAB.Infra.Entities;

namespace SAB.Interface.Controllers
{
	public class PageController : Controller
	{
		private readonly IPageManager _pageManager;

		public PageController(IPageManager thePageManager)
		{
			_pageManager = thePageManager;
		}

		[HttpGet]
		[ActionName("get")]
		public string Get(string code)
		{
			var aRequest = new CusRequest<PageRequest>() {};
			var aResponse = _pageManager.Get(aRequest);
			return aResponse.Data.Result;
		}

		[HttpPost]
		[ActionName("post")]
		public string Post()
		{
			return "Posted successfully!";
		}

	}
}
