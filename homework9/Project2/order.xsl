<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<HTML>
    <head>
        <title>Price List</title>
    </head>
<body>
    <table>
        <xsl:apply-templates/>
    </table>          
</body>  
</HTML>
</xsl:template>

<xsl:template match="ArrayOfOrder">
    <xsl:apply-templates select="Order"/>
</xsl:template>

<xsl:template match="Order">
    <tr>
        <td>
            <xsl:value-of select="Name"/>
        </td>
        <td>
            <xsl:value-of select="Clent"/>
        </td>
        <td>
            <xsl:value-of select="Items"/>
        </td>
    </tr>
</xsl:template>

</xsl:stylesheet>