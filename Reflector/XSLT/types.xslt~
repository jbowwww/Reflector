<?xml version="1.0" encoding="us-ascii"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/ReflectedContainer/Assembly">
	
		<html>
	
			<head>
				<link rel="stylesheet" href="standard.css" />
				<title>Types in <xsl:for-each select="Modules/Module"><xsl:value-of select="@Name"/> </xsl:for-each></title>
			</head>
	
			<body>
	
				<xsl:for-each select="Types/Type">
					<div class="Type">
						<div class="Name"><xsl:value-of select="@Name"/></div>
						<div class="Members">
							<xsl:for-each select="Members/Member">
								<div class="Member"><xsl:value-of select="@Name"/></div>
							</xsl:for-each>
						</div>
					</div>
				</xsl:for-each>
	
			</body>

		</html>
	
	</xsl:template>

</xsl:stylesheet>