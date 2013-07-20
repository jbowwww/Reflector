<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="*">
   <dl><dt>Untranslated node:
       <strong><xsl:value-of select="name()"/></strong></dt>
   <dd>
    <xsl:copy>
      <xsl:apply-templates select="@*"/>
      <xsl:apply-templates select="node()"/>
    </xsl:copy>
  </dd>
  </dl>
  </xsl:template>
 <xsl:template match="text()|@*">
   Contents: <xsl:value-of select="."/>
 </xsl:template>

	
</xsl:stylesheet>	