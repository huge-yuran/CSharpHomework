<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body style="center">
  <h2 style="text-align:center">Orders</h2>
  <table border="1" align="center">
    <tr bgcolor="#9acd32">
      <th style="text-align:center">订单号</th>
      <th style="text-align:center">客户</th>
	  <th style="text-align:center">电话号码</th>
	  <th style="text-align:center">商品详细信息（名称/数量/价格）</th>
    </tr>
    <xsl:for-each select="ArrayOfOrder/Order">
    <tr>
      <td><xsl:value-of select="ID"/></td>
      <td><xsl:value-of select="Name"/></td>
	  <td><xsl:value-of select="phoneNum"/></td>
	  <td><xsl:value-of select="Items"/></td>
    </tr>
    </xsl:for-each>
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>