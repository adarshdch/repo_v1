
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Practices.ObjectBuilder2;
using SAB.DAL.EntLib;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class HtmlFormNodeProcessor : XmlPageNodeProcessor
	{
		
		public override bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			var aHtmlForms = theRequest.Data.PageDocument.XPathSelectElements("//HtmlForm").ToList();
			
			aHtmlForms.ForEach(ProcessHtmlFormQuery);
		
			//TODO Implement this for all HtmlForms
			var aDataSet = OrgDatabase.SelectQuery(theRequest.Data.OrgCode, aHtmlForms.First().Attribute("query").Value);

			for (var count = 0; count < aHtmlForms.Count(); count++)
			{
				var aTable = aDataSet.Tables[count];
				var aHtmlFormFields = aHtmlForms[0].Elements("Field");
				aHtmlFormFields.ForEach(theField => theField.SetAttributeValue("value", aTable.Rows[0][theField.Attribute("sid").Value]));
			}

			return true;
		}

		private void ProcessHtmlFormQuery(XElement theHtmlForm)
		{
			if (theHtmlForm.Attribute("query") != null && string.IsNullOrWhiteSpace(theHtmlForm.Attribute("query").Value))
				return;

			var aSelectQueryBuilder = new StringBuilder("SELECT ");
			var aFields = theHtmlForm.XPathSelectElements("Field");
			aSelectQueryBuilder.Append(string.Join(",", aFields.Select(theField => theField.Attribute("sid").Value)));
			aSelectQueryBuilder.Append(" FROM ");
			aSelectQueryBuilder.Append(theHtmlForm.Attribute("table").Value);
			theHtmlForm.SetAttributeValue("query", aSelectQueryBuilder.ToString());
		}
	}
}
