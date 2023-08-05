using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class news : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, nwsstr, bCrumbStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Page.RouteData.Values["newsId"].ToString()))
                {
                    NewsMarkup();
                }
                else
                {
                    string[] arrLinks = Page.RouteData.Values["newsId"].ToString().Split('-');
                    GetNewsDetails(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));

                }
            }
        }
        catch (Exception ex)
        {
            nwsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    private void NewsMarkup()
    {
        try
        {
            using (DataTable dtnws = c.GetDataTable("select newsId, newsDate, newsTitle, LEFT(newsDesc, 150) as newsDesc, newsImage from NewsData where DelMark=0 Order By newsDate desc, newsId desc"))
            {
                if (dtnws.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    foreach (DataRow row in dtnws.Rows)
                    {
                       

                        if (row["newsImage"] != DBNull.Value && row["newsImage"].ToString() != "" && row["newsImage"].ToString() != "no-photo.png" && row["newsImage"] != null)
                        {
                            strMarkup.Append("<div class=\"card mb-5\">");
                            strMarkup.Append("<div class=\"row g-0\">");
                            strMarkup.Append("<div class=\"col-md-4\">");
                            if (row["newsImage"] != DBNull.Value && row["newsImage"].ToString() != "" && row["newsImage"].ToString() != "no-photo.png" && row["newsImage"] != null)
                            {
                                strMarkup.Append("<img src=\"" + Master.rootPath + "upload/news/thumb/" + row["newsImage"].ToString() + " \" alt=\"" + row["newsTitle"].ToString() + " \"  class=\"img-fluid w-100 newsborder\" >");

                            }
                            strMarkup.Append("</div>");
                            strMarkup.Append("<div class=\"col-md-8\">");
                            strMarkup.Append("<div class=\"card-header\">");
                            DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                            strMarkup.Append("<span class=\"clrGrey fst-italic\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("<div class=\"p-2\">");
                            strMarkup.Append("<div class=\"card-body\">");
                            strMarkup.Append("<blockquote class=\"blockquote mb-0\">");

                            string nUrl = Master.rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());

                            strMarkup.Append("<a href=\""+ nUrl + "\" class=\"fontRegular regular mb-4 clrdarkgrey newstitle text-decoration-none\">" + row["newsTitle"].ToString() + "</a>");

                            string nwsData = row["newsDesc"].ToString().Length >= 300 ? row["newsDesc"].ToString().Substring(0, 300) + "..." : row["newsDesc"].ToString();


                            strMarkup.Append("<footer class=\"blockquote-footer fontRegular light mt-2 clrdarkgrey\">" + nwsData + "");
                            strMarkup.Append("<span class=\"space20\"></span>");
                            strMarkup.Append("<a href=\""+ nUrl + "\" class=\"linkbtn\">Read More</a>");
                            strMarkup.Append("<span class=\"space10\"></span>");
                            strMarkup.Append("</footer>");
                            strMarkup.Append("</blockquote>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");

                        }

                        else
                        {
                            strMarkup.Append("<div class=\"card mb-5\">");
                            strMarkup.Append("<div class=\"row g-0\">");
                            strMarkup.Append("<div class=\"card-header\">");
                            DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                            strMarkup.Append("<span class=\"clrGrey fst-italic\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("<div class=\"p-2\">");
                            strMarkup.Append("<div class=\"card-body\">");
                            strMarkup.Append("<blockquote class=\"blockquote mb-0\">");

                            string nUrl = Master.rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());

                            strMarkup.Append("<a href=\"" + nUrl + "\" class=\"fontRegular regular mb-4 clrdarkgrey newstitle text-decoration-none\">" + row["newsTitle"].ToString() + "</a>");

                            string nwsData = row["newsDesc"].ToString().Length >= 300 ? row["newsDesc"].ToString().Substring(0, 300) + "..." : row["newsDesc"].ToString();


                            strMarkup.Append("<footer class=\"blockquote-footer fontRegular light mt-2 clrdarkgrey\">" + nwsData + "");
                            strMarkup.Append("<span class=\"space20\"></span>");
                            strMarkup.Append("<a href=\""+ nUrl + "\" class=\"linkbtn\">Read More</a>");
                            strMarkup.Append("<span class=\"space10\"></span>");
                            strMarkup.Append("</footer>");
                            strMarkup.Append("</blockquote>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }


                    }
                    nwsstr = strMarkup.ToString();
                }
                else
                {
                    nwsstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            nwsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void GetNewsDetails(int NwsIdx)
    {
        try
        {
            c.ExecuteQuery("Update NewsData Set readCount=readCount+1 Where newsId=" + NwsIdx);
            using (DataTable dtNws = c.GetDataTable("Select * From NewsData Where newsId=" + NwsIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    StringBuilder strMarkup = new StringBuilder();

                    this.Title = row["newsTitle"].ToString() + "| Latest News, Events of Samruddhi Cleaning Wares.";

                    strMarkup.Append("<h2 class=\"pageH2 themeClrPrime mrg_B_5 capitalize\">" + row["newsTitle"].ToString() + "</h2>");
                    DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                    strMarkup.Append("<span class=\"newspost\">Admin | " + nDate.ToString("dd MMM yyyy") + "</span>");

                    strMarkup.Append("<span class=\"space15\"></span>");
                    strMarkup.Append("<span class=\"semiMedium themeClrQtr fontRegular\">Total Views : " + row["readCount"].ToString() + "</span>");
                    strMarkup.Append("<span class=\"space20\"></span>");

                    //Sharing Options
                    strMarkup.Append("<div class=\"a2a_kit a2a_kit_size_24 a2a_default_style\" >");
                    strMarkup.Append("<a class=\"a2a_dd\" href=\"https://www.addtoany.com/share\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_facebook\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_twitter\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_google_plus\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_pinterest\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_email\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_linkedin\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_reddit\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_stumbleupon\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_digg\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_tumblr\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_whatsapp\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_blogger_post\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_delicious\"></a>");
                    strMarkup.Append("</div>");
                    strMarkup.Append("<script async src=\"https://static.addtoany.com/menu/page.js\"></script>");

                    //Add Page sharing links code here
                    strMarkup.Append("<div class=\"float_clear\"></div>");
                    strMarkup.Append("<div class=\"space20\"></div>");

                    if (row["newsImage"] != DBNull.Value && row["newsImage"].ToString() != "" && row["newsImage"].ToString() != "no-photo.png" && row["newsImage"] != null)

                        strMarkup.Append("<img src=\"" + Master.rootPath + "upload/news/" + row["newsImage"].ToString() + "\" alt=\"" + row["newsTitle"].ToString() + "\" class=\"width100\" />");
                    strMarkup.Append("<span class=\"space20\"></span>");
                    strMarkup.Append("<p class=\"paraTxt\">" + Regex.Replace(row["newsDesc"].ToString(), @"\r\n?|\n", "<br />") + "</p>");

                    nwsstr = strMarkup.ToString();
                    //bCrumbStr = "<ul class=\"bCrumb\"><li><a href=\"" + Master.rootPath + "\">Home</a></li><li>&raquo;</li><li><a href=\"" + Master.rootPath + "news\">Latest News</a></li><li>&raquo;</li><li>" + row["newsTitle"].ToString() + "</li></ul>";
                    strMarkup.Append("<div class=\"float_clear\">");
                }
            }

        }
        catch (Exception ex)
        {
            nwsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }
}