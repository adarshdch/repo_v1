
using System.ComponentModel;
using SAB.Entities;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class FacadePageProcessor
	{
		public bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			var aPageProcessor = ResolvePageProcessor(theRequest.Data.Page.PageType);
			
			return aPageProcessor.Process(theRequest, theResponse);
		}

		private IPageProcessor ResolvePageProcessor(PageType thePageType)
		{
			IPageProcessor aPageProcessor = null;

			switch (thePageType)
			{
				case PageType.Form:
					aPageProcessor = new FormXmlPageProcessor();
					break;
				default:
					throw new InvalidEnumArgumentException(typeof(PageType).Name, 1, typeof(PageType));
			}

			return aPageProcessor;
		}
	}
}
