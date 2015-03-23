
using System.ComponentModel;
using SAB.Entities;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class FacadePageProcessor
	{
		public bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			XmlBasePageProcessor aPageProcessor = ResolvePageProcessor(theRequest.Data.Page.PageType);
			
			aPageProcessor.Process(theRequest, theResponse);
			theResponse.Data.Result = aPageProcessor.TransformXmlToHtml(theRequest);

			return true;
		}

		private static XmlBasePageProcessor ResolvePageProcessor(PageType thePageType)
		{
			XmlBasePageProcessor aPageProcessor = null;

			switch (thePageType)
			{
				case PageType.Form:
					aPageProcessor = new XmlFormPageProcessor();
					break;
				default:
					throw new InvalidEnumArgumentException(typeof(PageType).Name, 1, typeof(PageType));
			}

			return aPageProcessor;
		}
	}
}
