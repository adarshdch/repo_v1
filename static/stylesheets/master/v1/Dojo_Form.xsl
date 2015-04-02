<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:param name="OrgCode" select="OrgCode"/>
	<xsl:param name="PageCode" select="PageCode"/>
	<xsl:param name="OutputType" select="OutputType"/>

	<xsl:output omit-xml-declaration="yes" indent="yes" method="xml" cdata-section-elements="Script"/>

	<xsl:include href="http://localhost/static\stylesheets\master\v1\Dojo_Field.xsl" />

	<xsl:template match="/">
		<xsl:choose>
			<xsl:when test="$OutputType='FullHtml'">
				<xsl:call-template name="FullHtml"/>
			</xsl:when>
			<xsl:when test="$OutputType='FullXml'">
				<xsl:call-template name="FullXml"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$OutputType"/>
				<xsl:text>:Invalid ContentType has been provided.</xsl:text>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="FullHtml">
		<html>
			<head>
				<title>
					<xsl:value-of select="/Form/@title"/>
				</title>
				<link rel="stylesheet" href="/js/lib/dojo/1.10.4/dijit/themes/claro/claro.css"/>

				<script>dojoConfig = { parseOnLoad: true }</script>
				<script src='/js/lib/dojo/1.10.4/dojo/dojo.js'></script>

				<script>
					require([
					"dojo/parser",
					"sab/form/Form",
					"dijit/Fieldset",
					"dijit/registry",
					"dijit/form/Button",
					"dijit/form/ValidationTextBox",
					"dijit/form/DateTextBox",
					"dijit/form/RadioButton",
					"dijit/form/CheckBox",
					"dijit/form/DropDownButton",
					"dijit/form/ComboBox",
					"dijit/TooltipDialog",
					"dojo/store/Memory",
					"dojo/request/xhr"
					]);
				</script>
			</head>
			<body class="claro">
				<xsl:apply-templates/>
			</body>
		</html>
	</xsl:template>



	<xsl:template name="HtmlForm" match="HtmlForm">
		<div data-dojo-type="sab/form/Form" enctype="multipart/form-data" action="">
			<xsl:attribute name="sid">
				<xsl:value-of select="$PageCode"/>
			</xsl:attribute>
			<xsl:choose>
				<xsl:when test="@display='inline'">
					<xsl:apply-templates/>
				</xsl:when>
				<xsl:otherwise>
					<table>
						<xsl:apply-templates/>
					</table>
				</xsl:otherwise>
			</xsl:choose>
		</div>
	</xsl:template>

	<xsl:template name="FullXml">
		<xsl:copy-of select="."/>
	</xsl:template>

</xsl:stylesheet>