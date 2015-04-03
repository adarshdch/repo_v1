

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Practices.ObjectBuilder2;

namespace SAB.BLL.Entities.Pages
{
	internal class VariableProcessor
	{
		public static void Process(Infra.Entities.CusRequest<PageRequest> theRequest, Infra.Entities.CusResponse<PageResponse> theResponse)
		{
			var aVariableNodes = theRequest.Data.PageDocument.FirstNode.XPathSelectElements("Variables/Variable");
			var variableNodes = aVariableNodes as IList<XElement> ?? aVariableNodes.ToList();

			variableNodes.ForEach(theVariableNode =>
			{
				switch (theVariableNode.Attribute("source").Value.ToLower())
				{
					case "querystring":
						theVariableNode.SetAttributeValue("value", theRequest.Data.Params[theVariableNode.Attribute("key").Value] ?? string.Empty);
						break;
				}
			});

			var aPageDocumentText = new StringBuilder(theRequest.Data.PageDocument.FirstNode.ToString());
			variableNodes.ForEach(theVariable =>
			{
				var aVariableKey = string.Format("[*{0}*]", theVariable.Attribute("key").Value);
				var aVariableValue = theVariable.Attribute("value").Value;
				aPageDocumentText.Replace(aVariableKey, aVariableValue);
			});

			theRequest.Data.PageDocument.FirstNode.ReplaceWith(XElement.Parse(aPageDocumentText.ToString()));
		}
	}
}
