<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	
	<xsl:template name="Field" match="Field">
		<label>
			<xsl:attribute name="for">
				<xsl:value-of select="@sid"/>
			</xsl:attribute>
			<xsl:value-of select="@label"/>
		</label>
		<input>
			<xsl:attribute name="type">
				<xsl:value-of select="@type"/>
			</xsl:attribute>
			<xsl:attribute name="sid">
				<xsl:value-of select="@sid"/>
			</xsl:attribute>
			<xsl:attribute name="name">
				<xsl:value-of select="@sid"/>
			</xsl:attribute>
			<xsl:if test="@required">
				<xsl:attribute name="required">
					<xsl:value-of select="@required"/>
				</xsl:attribute>
			</xsl:if>
			<xsl:attribute name="data-dojo-type">
				<xsl:text>dijit/form/ValidationTextBox</xsl:text>
			</xsl:attribute>
			 
			
		</input>
		
	</xsl:template>

	<xsl:template name="Button" match="Button">
		<button>
			<xsl:attribute name="data-dojo-type">
				<xsl:text>dijit/form/Button</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="type">
				<xsl:value-of select="@type"/>
			</xsl:attribute>
			<xsl:value-of select="@label"/>
		</button>
	</xsl:template>
	
</xsl:stylesheet>