<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:s="urn:students">
    <xsl:template match="/s:students">
        <html>
            <style>
                ul {
                    list-style-type: none;
                }
            </style>
            <body>
                <h2>Students list</h2>
                <ul class="students">
                    <xsl:for-each select="s:student">
                        <li>
                            <xsl:value-of select="s:name" />
                            <ul>
                                <li>
                                    <xsl:value-of select="s:gender" />
                                </li>
                                <li>
                                    <xsl:value-of select="s:birth_date" />
                                </li>
                                <li>
                                    <span>Exams:</span><br/>
                                    <ul>
                                        <xsl:for-each select="s:exams/s:exam">
                                            <li>Exam name:
                                                <xsl:value-of select="s:name" />
                                            </li>
                                            <li>Score:
                                                <xsl:value-of select="s:score" />
                                            </li>
                                        </xsl:for-each>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </xsl:for-each>
                </ul>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>