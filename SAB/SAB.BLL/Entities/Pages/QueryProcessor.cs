
using System.Xml.XPath;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	internal class QueryProcessor
	{
		public static void Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			var aQueryCollection = theRequest.Data.PageDocument.XPathSelectElements("//Query");
			

		}
	}
}
