<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html"/>
	<xsl:template match="//Assembly">
		<html>
			<head>
				<link rel="stylesheet" href="standard.css" />
				<title>Types in <xsl:value-of select="@Name"/></title>
			</head>
			<body>
				<xsl:apply-templates select="Types/Type"/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="Types/Type">
		<div class="Type">
			<div class="Name"><xsl:value-of select="@Name"/></div>
			<div class="Members">
				<xsl:apply-templates select="Members/Member"/>
			</div>
		</div>
	</xsl:template>	
	<xsl:template match="Members/Member">
		<div class="Member"><xsl:value-of select="@Name"/></div>
	</xsl:template>	
</xsl:stylesheet>