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



public partial class events : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, evntstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //string[] arrLinks1 = Page.RouteData.Values["categId"].ToString().Split('-');

                string myCategory = Page.RouteData.Values["categId"].ToString();
                string myAlbum = Page.RouteData.Values["myAlbumId"].ToString();

                //EventsMarkup(Convert.ToInt32(arrLinks1[arrLinks1.Length - 1]));

                if (myAlbum != "")
                {
                    string[] arrlinks = Page.RouteData.Values["myAlbumId"].ToString().Split('-');
                    GetEventDetails(Convert.ToInt32(arrlinks[arrlinks.Length - 1]));
                }
                else
                {   
                    string[] arrlinks = Page.RouteData.Values["categId"].ToString().Split('-');
                    EventsMarkup(Convert.ToInt32(arrlinks[arrlinks.Length - 1]));
                }
            }
        }
        catch (Exception ex)
        {
            evntstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    private void EventsMarkup(int EvntsIdx)
    {
        try
        {
            using (DataTable dtevnt = c.GetDataTable("select a.EvntId, a.EvntDate, LEFT(EvntTitle, 72) as  EvntTitle, LEFT(EvntDesc, 254) as EvntDesc, a.EvntPhoto, b.EventCatTypeId, b.EventCategory from EventsGallery a Inner Join EventsGalleryCategory b ON a.FK_EventCatId=b.EventCatId where a.DelMark=0 AND EventCatTypeId=1 AND FK_EventCatId=" + EvntsIdx + " Order By EvntDate desc, EvntId desc"))
            {
                if (dtevnt.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    int counter = 1;
                    foreach (DataRow row in dtevnt.Rows)
                    {
                        strMarkup.Append("<div class=\"col-md-4\">");
                        if (row["EvntPhoto"] != DBNull.Value && row["EvntPhoto"].ToString() != "" && row["EvntPhoto"].ToString() != "no-photo.png" && row["EvntPhoto"] != null)
                        {
                            strMarkup.Append("<img src=\"" + Master.rootPath + "upload/events/" + row["EvntPhoto"].ToString() + " \" alt=\"" + row["EvntPhoto"].ToString() + " \"  class=\"img-fluid w-100 newsborder\" >");
                        }
                        strMarkup.Append("</div>");
                        strMarkup.Append("<div class=\"col-md-8\">");

                        string evntTitle = row["EvntTitle"].ToString().Length >= 72 ? row["EvntTitle"].ToString().Substring(0, 72) + "..." : row["EvntTitle"].ToString();

                        string existUrl = Master.rootPath + "events-gallery/" + Page.RouteData.Values["categId"].ToString() + "/";

                        string nUrl = existUrl + c.UrlGenerator(row["EvntTitle"].ToString().ToLower() + "-" + row["EvntId"].ToString());

                        strMarkup.Append("<a href=\""+ nUrl + "\" class=\"semiBold semiMedium colorPrime text-decoration-none eventtitle\">" + evntTitle + "</a>");

                        strMarkup.Append("<span class=\"space5\"></span>");
                        DateTime nDate = Convert.ToDateTime(row["EvntDate"]);
                        strMarkup.Append("<span class=\"clrGrey small fst-italic\">"+ nDate.ToString("dd / MM / yyyy") + "</span>");

                        string evntdesc = row["EvntDesc"].ToString().Length >= 72 ? row["EvntDesc"].ToString().Substring(0, 254) + "..." : row["EvntDesc"].ToString();

                        strMarkup.Append("<p class=\"fontRegular light  line-ht-7 mt-3 mb-4\">"+ evntdesc + "</p>");
                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"btnexplore\">Explore</a>");
                        strMarkup.Append("</div>");

                        if (counter < dtevnt.Rows.Count)
                        {
                            strMarkup.Append("<span class=\"greyLine\"></span>");
                        }
                        counter++;

                    }
                    evntstr = strMarkup.ToString();
                }
                else
                {
                    evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }

            //video markup
            using (DataTable dttestdata = c.GetDataTable("select a.EvntId, a.EvntDate, LEFT(EvntTitle, 72) as  EvntTitle, LEFT(EvntDesc, 254) as EvntDesc, a.EvntPhoto, a.EvntVideo, b.EventCatTypeId from EventsGallery a Inner Join EventsGalleryCategory b ON a.FK_EventCatId=b.EventCatId where a.DelMark=0 AND EventCatTypeId=2 AND FK_EventCatId=" + EvntsIdx + " Order By EvntDate desc, EvntId desc"))
            {
                StringBuilder strMarkup = new StringBuilder();
                int counter = 1;
                if (dttestdata.Rows.Count > 0)
                {
                    strMarkup.Append("<div id=\"videoreview\">");
                    strMarkup.Append("<div class=\"row\">");
                    foreach (DataRow prow in dttestdata.Rows)
                    {

                        strMarkup.Append("<div class=\"col-md-4\">");
                        strMarkup.Append("<div class=\"pad_15\">");
                        strMarkup.Append("<a data-fancybox href=\"https://www.youtube.com/watch?v=" + prow["EvntVideo"] + "\">");
                        strMarkup.Append("<img src=\"http://img.youtube.com/vi/" + prow["EvntVideo"] + "/0.jpg\"alt=\"" + prow["EvntVideo"].ToString() + "\"class=\"width100\">");
                        strMarkup.Append("</a>");

                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");

                        //Video markup start for details
                        strMarkup.Append("<div class=\"col-md-8\">");
                        string evntTitle = prow["EvntTitle"].ToString().Length >= 72 ? prow["EvntTitle"].ToString().Substring(0, 72) + "..." : prow["EvntTitle"].ToString();

                        string existUrl = Master.rootPath + "events-gallery/" + Page.RouteData.Values["categId"].ToString() + "/";

                        string nUrl = existUrl + c.UrlGenerator(prow["EvntTitle"].ToString().ToLower() + "-" + prow["EvntId"].ToString());
                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium colorPrime text-decoration-none eventtitle\">" + evntTitle + "</a>");

                        strMarkup.Append("<span class=\"space5\"></span>");
                        DateTime nDate = Convert.ToDateTime(prow["EvntDate"]);
                        strMarkup.Append("<span class=\"clrGrey small fst-italic\">" + nDate.ToString("dd / MM / yyyy") + "</span>");

                        string evntdesc = prow["EvntDesc"].ToString().Length >= 72 ? prow["EvntDesc"].ToString().Substring(0, 254) + "..." : prow["EvntDesc"].ToString();

                        strMarkup.Append("<p class=\"fontRegular light  line-ht-7 mt-3 mb-4\">" + evntdesc + "</p>");
                        //strMarkup.Append("<a href=\"" + nUrl + "\" class=\"btnexplore\">Explore</a>");
                        strMarkup.Append("</div>");

                        if (counter < dttestdata.Rows.Count)
                        {
                            strMarkup.Append("<span class=\"greyLine\"></span>");
                        }
                        counter++;

                    }
                    strMarkup.Append("</div>");
                    strMarkup.Append("</div>");
                    //return strMarkup.ToString();
                    evntstr = strMarkup.ToString();
                }
                //else
                //{
                //    evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                //}
            }

        }
        catch (Exception ex)
        {
            evntstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void GetEventDetails(int EvntIdx)
    {
        try
        {
            //c.ExecuteQuery("Update NewsData Set readCount=readCount+1 Where newsId=" + EvntIdx);
            using (DataTable dtNws = c.GetDataTable("Select * From EventsGallery Where EvntId=" + EvntIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    StringBuilder strMarkup = new StringBuilder();

                    this.Title = row["EvntTitle"].ToString() + "| Latest Events of Samruddhi Cleaning Wares.";

                    strMarkup.Append("<h2 class=\"pageH2 themeClrPrime mrg_B_5 capitalize\">" + row["EvntTitle"].ToString() + "</h2>");
                    DateTime nDate = Convert.ToDateTime(row["EvntDate"]);
                    strMarkup.Append("<span class=\"newspost\">Admin | " + nDate.ToString("dd MMM yyyy") + "</span>");

                    strMarkup.Append("<span class=\"space5\"></span>");

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
                    strMarkup.Append("<div class=\"space15\"></div>");
                    strMarkup.Append("<p class=\"paraTxt\">" + Regex.Replace(row["EvntDesc"].ToString(), @"\r\n?|\n", "<br />") + "</p>");
                    strMarkup.Append("<span class=\"space10\"></span>");


                    using (DataTable dttest = c.GetDataTable("Select EvntGalPhotoId, FK_EvntId, EvntGalPhoto  from EventGalleryPhotos Where FK_EvntId=" + EvntIdx + ""))
                    {
                        if (dttest.Rows.Count > 0)
                        {

                           
                            strMarkup.Append("<div class=\"row\">");
                           

                            foreach (DataRow prow in dttest.Rows)
                            {
                                strMarkup.Append("<div class=\"col-md-3\">");
                                strMarkup.Append("<div class=\"border\">");
                                strMarkup.Append("<div class=\"p-2\">");

                                if (prow["EvntGalPhoto"] != DBNull.Value && prow["EvntGalPhoto"].ToString() != "" && prow["EvntGalPhoto"].ToString() != "no-photo.png" && prow["EvntGalPhoto"] != null)
                                {

                                    strMarkup.Append("<a href=\"" + Master.rootPath + "upload/events/" + prow["EvntGalPhoto"].ToString() + "\"  data-fancybox=\"imggroup\">");
                                    strMarkup.Append("<img src=\"" + Master.rootPath + "upload/events/" + prow["EvntGalPhoto"].ToString() + "\" alt=\"" + prow["EvntGalPhoto"].ToString() + "\" class=\"img-fluid w-100\">");
                                    strMarkup.Append("</a>");

                                }
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");

                            }

                            strMarkup.Append("</div>");
                        }
                    }

                    evntstr = strMarkup.ToString();
                    strMarkup.Append("<div class=\"float_clear\">");
                }
            }

        }
        catch (Exception ex)
        {
            evntstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }

}