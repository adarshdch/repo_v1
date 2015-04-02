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
					<xsl:call-template name="SetFieldCustomAttributes"/>
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

	<xsl:template match="Buttons">
		<tr>
			<td></td>
			<td colspan="*">
				<xsl:apply-templates/>
			</td>
		</tr>
	</xsl:template>
	<xsl:template name="Button" match="Button">
		<button>
			<xsl:attribute name="data-dojo-type">
				<xsl:text>dijit/form/Button</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="type">
				<xsl:choose>
					<xsl:when test="@type">
						<xsl:value-of select="@type"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>button</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:value-of select="@label"/>
			<xsl:choose>
				<xsl:when test="not(Script)">
					<script type="dojo/on" data-dojo-event="click" data-dojo-args="evt">
						this.getParent().submit();
					</script>
				</xsl:when>
			</xsl:choose>
			<xsl:apply-templates/>
		</button>
	</xsl:template>

	<xsl:template match="Script">
		<script type="dojo/on" data-dojo-args="evt">
			<xsl:attribute name="data-dojo-event">
				<xsl:choose>
					<xsl:when test="@event">
						<xsl:value-of select="@event"/>		
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>click</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:value-of disable-output-escaping="yes" select="."/>
		</script>
	</xsl:template>
								
	
	<xsl:template name="SetFieldCustomAttributes">
		<xsl:choose>
			<xsl:when test="@type='text'">
				<xsl:attribute name="data-dojo-type">
					<xsl:text>dijit/form/ValidationTextBox</xsl:text>
				</xsl:attribute>
			</xsl:when>
		</xsl:choose>
	</xsl:template>

</xsl:stylesheet>