
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public abstract class XmlBasePageProcessor : IPageProcessor
	{

		public abstract bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse);

		public string TransformXmlToHtml(CusRequest<PageRequest> theRequest)
		{
			string aOutput;
			using (var aXsltReader = new StringReader(theRequest.Data.Template)) // xslInput is a string that contains xsl
			using (var aXmlReader = new StringReader(theRequest.Data.PageDocument.ToString())) // xmlInput is a string that contains xml
			{
				using (var aXslt = XmlReader.Create(aXsltReader))
				using (var aXml = XmlReader.Create(aXmlReader))
				{
					var aTransformer = new XslCompiledTransform(true);
					aTransformer.Load(aXslt);

					using (var aStringWriter = new StringWriter())
					using (var aOutputWriter = XmlWriter.Create(aStringWriter, aTransformer.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
					{
						aTransformer.Transform(aXml, GetXsltArgumentList(theRequest), aOutputWriter);
						aOutput = aStringWriter.ToString();
					}
				}
			}
			return aOutput;
		}

		private XsltArgumentList GetXsltArgumentList(CusRequest<PageRequest> theRequest)
		{
			var aXsltArgs = new XsltArgumentList();
			aXsltArgs.AddParam(Literals.PageCode, "", theRequest.Data.PageCode);
			aXsltArgs.AddParam(Literals.OrgCode, "", theRequest.Data.OrgCode);
			aXsltArgs.AddParam(Literals.OutputType, "", theRequest.Data.ContentType.ToString());
			return aXsltArgs;
		}
	}
}
