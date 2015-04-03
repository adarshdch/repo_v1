
using System;
using System.IO;
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

			if (string.IsNullOrWhiteSpace(theRequest.Data.RecordKey))
			{
				return true;
			}

			var aHtmlForms = theRequest.Data.PageDocument.XPathSelectElements("//HtmlForm").ToList();
			
			aHtmlForms.ForEach(ProcessHtmlFormQuery);
		
			//TODO Implement this for all HtmlForms
			var aDataSet = OrgDatabase.SelectQuery(theRequest.Data.OrgCode, aHtmlForms.First().Attribute("query").Value);

			for (var count = 0; count < aHtmlForms.Count(); count++)
			{
				var aTable = aDataSet.Tables[count];
				if (aTable == null || aTable.Rows == null || aTable.Rows.Count == 0)
				{
					throw new FileNotFoundException("Record not found!");
				}
				var aHtmlFormFields = aHtmlForms[0].Elements("Field");
				aHtmlFormFields.ForEach(theField => theField.SetAttributeValue("value", aTable.Rows[0][theField.Attribute("sid").Value]));
			}

			return true;
		}

		private void ProcessHtmlFormQuery(XElement theHtmlForm)
		{
			if (theHtmlForm.Attribute("query") != null )
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
