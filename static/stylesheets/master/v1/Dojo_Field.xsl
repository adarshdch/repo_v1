<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template name="Field" match="Field">
		<tr>
			<td>
				<label>
					<xsl:attribute name="for">
						<xsl:value-of select="@sid"/>
					</xsl:attribute>
					<xsl:value-of select="@label"/>
				</label>
			</td>
			<td>
				<input>
					<xsl:call-template name="SetFieldAttributes"/>
					<xsl:attribute name="sid">
						<xsl:value-of select="@sid"/>
					</xsl:attribute>
					<xsl:attribute name="name">
						<xsl:value-of select="@sid"/>
					</xsl:attribute>
					<xsl:attribute name="value">
						<xsl:value-of select="@value"/>
					</xsl:attribute>
					<xsl:if test="@required">
						<xsl:attribute name="required">
							<xsl:value-of select="@required"/>
						</xsl:attribute>
					</xsl:if>
				</input>
			</td>
		</tr>
		<!--<xsl:if test="not(../@display='inline')">
			<br/>
		</xsl:if>-->
	</xsl:template>

	<xsl:template name="Button" match="Button">
		<tr>
			<td></td>
			<td colspan="*">
				<button>
					<xsl:attribute name="data-dojo-type">
						<xsl:text>dijit/form/Button</xsl:text>
					</xsl:attribute>
					<xsl:attribute name="type">
						<xsl:value-of select="@type"/>
					</xsl:attribute>
					<xsl:attribute name="operation">
						<xsl:value-of select="@operation"/>
					</xsl:attribute>
					<xsl:value-of select="@label"/>
				</button>
			</td>
		</tr>
	</xsl:template>

	<xsl:template name="SetFieldAttributes">
		<xsl:choose>
			<xsl:when test="@type='text'">
				<xsl:attribute name="data-dojo-type">
					<xsl:text>dijit/form/ValidationTextBox</xsl:text>
				</xsl:attribute>
			</xsl:when>
		</xsl:choose>
	</xsl:template>

</xsl:stylesheet>