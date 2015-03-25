
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace SAB.DAL.EntLib
{
	public static class DbExtensions
	{
		public static XElement XmlElement(this DataSet theDataSet)
		{
			var aDataSetXml = new StringBuilder();

			aDataSetXml.Append("<DataSet>");
			foreach (DataTable theTable in theDataSet.Tables)
			{
				aDataSetXml.Append("<Table>");
				foreach (DataRow theRow in theTable.Rows)
				{
					aDataSetXml.Append("<Row>");
					foreach (var theField in theRow.ItemArray)
					{
						aDataSetXml.Append("<Field>");
						aDataSetXml.Append(theField);
						aDataSetXml.Append("</Field>");
					}
					aDataSetXml.Append("</Row>");
				}
				aDataSetXml.Append("</Table>");

			}
			aDataSetXml.Append("</DataSet>");

			return XElement.Parse(aDataSetXml.ToString());
		}
	}
}
