<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <head>
                <style>
                    thead {color:green;}
                    tbody {color:blue;}
                    tfoot {color:red;}

                    #albums, th, td {
                    border: 1px solid black;
                    text-align: center;
                    }

                    #albums td {
                    padding: 10px;
                    }

                    #songs {
                    border-collapse: collapse;
                    }

                    #songs td {
                    padding: 5px;
                    }
                </style>
            </head>

            <body>
                <table id="albums">
                    <thead>
                        <tr>
                            <th>album</th>
                            <th>artist</th>
                            <th>year</th>
                            <th>producer</th>
                            <th>price</th>
                            <th>songs</th>
                        </tr>
                    </thead>
                    <tbody>
                        <xsl:for-each select="albums/album">
                            <tr>
                                <td>
                                    <xsl:value-of select="name" />
                                </td>
                                <td>
                                    <xsl:value-of select="artist" />
                                </td>
                                <td>
                                    <xsl:value-of select="year" />
                                </td>
                                <td>
                                    <xsl:value-of select="producer" />
                                </td>
                                <td>
                                    <xsl:value-of select="price" />
                                </td>
                                <td>
                                    <table id="songs">
                                        <thead>
                                            <tr>
                                                <th>Title</th>
                                                <th>Length</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        <xsl:for-each select="songs/song">
                                            <tr>
                                                <td>
                                                    <xsl:value-of select="title" />
                                                </td>
                                                <td>
                                                    <xsl:value-of select="duration" />
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                        </tbody>
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
