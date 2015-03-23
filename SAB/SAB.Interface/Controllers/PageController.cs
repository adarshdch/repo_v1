
using System.Web.Mvc;
using SAB.BLL.Entities.Pages;
using SAB.BLL.Manager;
using SAB.Entities;
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
			var aRequest = new CusRequest<PageRequest>()
			{
				Data = new PageRequest()
				{
					OrgCode = "Master",
					PageCode = code,
					ContentType = ResponseContentType.FullXml
				}
			};

			var aResponse = new CusResponse<PageResponse>()
			{
				Status = TaskStatus.Success,
				Data = new PageResponse()
			};

			_pageManager.Process(aRequest, aResponse);

			return aResponse.Status.Equals(TaskStatus.Failure) ? aResponse.Message : aResponse.Data.Result;
		}

		[HttpPost]
		[ActionName("post")]
		public string Post()
		{
			return "Posted successfully!";
		}

	}
}
