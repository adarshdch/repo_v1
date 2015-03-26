
using System.Net.Http.Headers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
		[ActionName("v1")]
		public string Get(string pagecode)
		{
			var aRequest = new CusRequest<PageRequest>()
			{
				Data = new PageRequest()
				{
					Operation = DbOperation.Select,
					OrgCode = "Master",
					PageCode = pagecode,
					ContentType = ResponseContentType.FullHtml
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
		[ActionName("v1")]
		public string Post(string pagecode)
		{

			var aResponse = new CusResponse<PageResponse>()
			{
				Data = new PageResponse()
				{
					Result = "Result output!"
				},
				Status = TaskStatus.Success,
				Message = "Successfully posted!"
			};

			return JsonConvert.SerializeObject(aResponse, Formatting.Indented, new StringEnumConverter());
		}

	}
}
