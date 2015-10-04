<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:s="urn:students">
    <xsl:template match="/">
        <html>
            <head>
                <style>
                    thead {color:green;}
                    tbody {color:blue;}
                    tfoot {color:red;}

                    #students, th, td {
                    border: 1px solid black;
                    text-align: center;
                    }
                    
                    #students td {
                    padding: 10px;
                    }

                    #exams {
                    border-collapse: collapse;
                    }
                    
                    #exams td {
                    padding: 5px;
                    }
                </style>
            </head>

            <body>
                <table id="students">
                    <thead>
                        <tr>
                            <th>name</th>
                            <th>gender</th>
                            <th>course</th>
                            <th>exams</th>
                        </tr>
                    </thead>
                    <tbody>
                        <xsl:for-each select="s:students/s:student">
                            <tr>
                                <td>
                                    <xsl:value-of select="s:name" />
                                </td>
                                <td>
                                    <xsl:value-of select="s:gender" />
                                </td>
                                <td>
                                    <xsl:value-of select="s:course" />
                                </td>
                                <td>
                                    <table id="exams">
                                        <xsl:for-each select="s:exams/s:exam">
                                            <tr>
                                                <td>
                                                    <xsl:value-of select="s:name" />
                                                </td>
                                                <td>
                                                    <xsl:value-of select="s:score" />
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </table>
                                </td>
                            </tr>
                        </xsl:for-each>
                    </tbody>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>