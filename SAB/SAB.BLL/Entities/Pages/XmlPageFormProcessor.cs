
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class XmlFormPageProcessor : XmlBasePageProcessor
	{
		public XmlFormPageProcessor()
		{
			
		}

		public override bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			XmlPageAttributeProcessor.FillAttributes(theRequest, theResponse);
			VariableProcessor.Process(theRequest, theResponse);
			QueryProcessor.Process(theRequest, theResponse);
			IXmlPageNodeProcessor aXmlPageNodeProcessor = new HtmlFormNodeProcessor();
			aXmlPageNodeProcessor.Process(theRequest, theResponse);


			return true;
		}
	}
}
