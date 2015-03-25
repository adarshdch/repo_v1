
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
			var aHtmlForms = theRequest.Data.PageDocument.XPathSelectElements("//HtmlForm");
			aHtmlForms.ForEach(ProcessHtmlForm);
			var db = DbFactory.GetMasterDatabase();
			
			var t = db.ExecuteDataSet(CommandType.Text, aHtmlForms.First().Attribute("query").Value);
			var s = t.XmlElement();
			aHtmlForms.First().Add(s);
			return true;
		}

		private void ProcessHtmlForm(XElement theHtmlForm)
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
