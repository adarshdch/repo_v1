
using System;
using System.Linq;
using System.Xml.XPath;
using Microsoft.Practices.ObjectBuilder2;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class XmlPageAttributeProcessor
	{
		public static void FillAttributes(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			if (string.IsNullOrWhiteSpace(theRequest.Data.Step))
				return;

			var aElelementCollection = theRequest.Data.PageDocument.XPathSelectElements("//*");
			aElelementCollection.ForEach(theElement =>
			{
				var aRenderInSteps = theElement.Attribute("renderinsteps");
				if (aRenderInSteps == null || string.IsNullOrWhiteSpace(aRenderInSteps.Value))
					return;

				var aSteps = aRenderInSteps.Value.Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries);
				if (aSteps.Contains(theRequest.Data.Step) == false)
				{
					theElement.SetAttributeValue("visible", false);
				}

			});


		}
	}
}
