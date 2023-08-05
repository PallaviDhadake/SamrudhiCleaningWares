using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, currentYear, evntstr, prodstr, submenu, prodcat, prodstrfoo, evntcatstr, evntvid, bannerstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentYear = DateTime.Now.Year.ToString();
        rootPath = c.ReturnHttp();

        if(!IsPostBack)
        {
            if (Request.QueryString["act"] != null)
            {
                if (Request.QueryString["act"] == "logout")
                {
                    Session["adminMaster"] = null;
                    Response.Redirect(rootPath, false);
                }

            }
            EventsMarkup();
            ProductsMarkup();
            ProdCatMenu();
            ProdCategory();
            EventsCatImg();
            EventsCatvid();
            ProdCatMenufoot();
            BannerImages();
        }

    }


    private void BannerImages()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dtBanner = c.GetDataTable("select  BannerID, BannerImage, BannerOrder from BannersData where DelMark=0 order by BannerOrder"))
            {
                if (dtBanner.Rows.Count > 0)
                {
                    string className = "";
                    int i = 0;

                    strMarkup.Append("<div class=\"carousel-inner\" role=\"listbox\">");
                    foreach (DataRow row in dtBanner.Rows)
                    {
                        i++;
                        if (i == 1)
                        {
                            className = "active";
                        }
                        else
                        {
                            className = "";
                        }
                        if (c.IsRecordExist("Select BannerID From BannersData Where BannerID=" + row["BannerID"].ToString() + ""))
                        {

                            strMarkup.Append("<div class=\"carousel-item " + className + "\">");
                            if (row["BannerImage"] != DBNull.Value && row["BannerImage"].ToString() != "" && row["BannerImage"].ToString() != "no-photo.png" && row["BannerImage"] != null)
                            {

                                strMarkup.Append("<img src=\"" + rootPath + "upload/bannerimages/" + row["BannerImage"].ToString() + "\" alt=\"" + row["BannerImage"].ToString() + "\" class=\"img-fluid w-100\" />");

                            }
                            else
                            {
                                strMarkup.Append("<img src=\"images/banner1.jpg\" class=\"img-fluid w-100 \">");
                            }
                            strMarkup.Append("</div>");
                        }
                    }
                    strMarkup.Append("</div>");
                    bannerstr = strMarkup.ToString();
                }
                else
                {
                    //strMarkup.Append("<di class=\"item\">");
                    bannerstr = "<img src=\"images/banner1.jpg\" class=\"img-fluid w-100\">";
                    //strMarkup.Append("</div>");
                }
            }
        }
        catch (Exception ex)
        {
            bannerstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }



    private void EventsCatImg()
    {
        try
        {
            using (DataTable dtevntcat = c.GetDataTable("select * from EventsGalleryCategory where DelMark=0 AND EventCatTypeId=1"))
            {

                if (dtevntcat.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    int counter = 1;
                    //strMarkup.Append("<div class=\"row\">");
                    foreach (DataRow row in dtevntcat.Rows)
                    {
                        strMarkup.Append("<li>");

                        //string nUrl = rootPath + "events-gallery/";

                        string nUrl = rootPath + "events-gallery/" + c.UrlGenerator(row["EventCategory"].ToString().ToLower() + "-" + row["EventCatId"].ToString());

                        strMarkup.Append("<a href=\""+ nUrl +"\" class=\"dropdown-item\">"+row["EventCategory"].ToString()+"</a>");

                        strMarkup.Append("</li>");
                        
                        if (counter < dtevntcat.Rows.Count)
                        {
                            strMarkup.Append("<li>");
                            strMarkup.Append("<hr class=\"dropdown-divider\">");
                            strMarkup.Append("</li>");
                        }
                        counter++;

                    }
                    evntcatstr = strMarkup.ToString();
                }

            }
        }
        catch (Exception ex)
        {
            evntcatstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void EventsCatvid()
    {
        try
        {
            using (DataTable dtevntcat = c.GetDataTable("select * from EventsGalleryCategory where DelMark=0 AND EventCatTypeId=2"))
            {

                if (dtevntcat.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    int counter = 1;
                    //strMarkup.Append("<div class=\"row\">");
                    foreach (DataRow row in dtevntcat.Rows)
                    {
                        strMarkup.Append("<li>");

                        string nUrl = rootPath + "events-gallery/" + c.UrlGenerator(row["EventCategory"].ToString().ToLower() + "-" + row["EventCatId"].ToString());

                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"dropdown-item\">" + row["EventCategory"].ToString() + "</a>");

                        strMarkup.Append("</li>");

                        if (counter < dtevntcat.Rows.Count)
                        {
                            strMarkup.Append("<li>");
                            strMarkup.Append("<hr class=\"dropdown-divider\">");
                            strMarkup.Append("</li>");
                        }
                        counter++;

                    }
                    evntvid = strMarkup.ToString();
                }

            }
        }
        catch (Exception ex)
        {
            evntvid = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void ProdCatMenu()
    {
        try
        {
            using (DataTable dtproductmenu = c.GetDataTable("select * from ProductCategory where DelMark=0"))
            {
                //int totalcategory= dtproductmenu.Rows.Count;
                //int menu = totalcategory / 2;

                //int menucount = 0;

                if (dtproductmenu.Rows.Count > 0)   
                {
                    StringBuilder strMarkup = new StringBuilder();
                    //strMarkup.Append("<div class=\"row\">");
                    foreach (DataRow row in dtproductmenu.Rows)
                    {
                        //menucount++;
                        strMarkup.Append("<div class=\"col-sm-6\">");
                        strMarkup.Append("<ul class=\"multi-column-dropdown\">");
                        strMarkup.Append("<li>");
                        string nUrl = rootPath + "product-category/" + c.UrlGenerator(row["ProdCatName"].ToString().ToLower() + "-" + row["ProdCatId"].ToString());
                        strMarkup.Append("<a href=\""+ nUrl + "\">" + row["ProdCatName"].ToString() + "</a>");
                        strMarkup.Append("</li>");
                        strMarkup.Append("</ul>");
                        strMarkup.Append("</div>");

                        //if (menu == menucount)
                        //{
                        //    strMarkup.Append("<div class=\"col-sm-6\">");
                        //    strMarkup.Append("<ul class=\"multi-column-dropdown\">");
                        //    strMarkup.Append("<li>");
                        //    //string nUrls = rootPath + "our-products/" + c.UrlGenerator(row["ProductName"].ToString().ToLower() + "-" + row["ProductId"].ToString());
                        //    strMarkup.Append("<a href=\"\">" + row["ProdCatName"].ToString() + "</a>");
                        //    strMarkup.Append("</li>");
                        //    strMarkup.Append("</ul>");
                        //    strMarkup.Append("</div>");
                        //}

                    }

                    submenu = strMarkup.ToString();
                }
                else
                {
                    //evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            prodstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void ProdCategory()
    {
        try
        {
            using (DataTable dtproductmenu = c.GetDataTable("select TOP 4 ProdCatId, ProdCatName, ProdCatDesc, ProdCatCoverPhoto from ProductCategory where DelMark=0"))
            {
                //int totalcategory= dtproductmenu.Rows.Count;
                //int menu = totalcategory / 2;

                //int menucount = 0;

                if (dtproductmenu.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                   
                    foreach (DataRow row in dtproductmenu.Rows)
                    {
                        
                        strMarkup.Append("<div class=\"col-xl-3 col-lg-6 col-md-6 text-center\">");
                        strMarkup.Append("<div class=\"p-2\">");
                        strMarkup.Append("<div class=\"servericeBorder\">");
                        strMarkup.Append("<div class=\"p-4\">");

                        strMarkup.Append("<div class=\"servimg mb-5\">");
                        if (row["ProdCatCoverPhoto"] != DBNull.Value && row["ProdCatCoverPhoto"].ToString() != "" && row["ProdCatCoverPhoto"].ToString() != "no-photo.png" && row["ProdCatCoverPhoto"] != null)
                        {
                            strMarkup.Append("<img src=\"" + rootPath + "upload/productscategory/thumb/" + row["ProdCatCoverPhoto"].ToString() + " \" alt=\"" + row["ProdCatName"].ToString() + " \"  class=\"img-fluid servimg\" >");

                        }
                        strMarkup.Append("</div>");
                        strMarkup.Append("<h4 class=\"semiBold semiMedium mb-4\">"+row["ProdCatName"].ToString()+"</h4>");
                        string prodcatData = row["ProdCatDesc"].ToString().Length >= 54 ? row["ProdCatDesc"].ToString().Substring(0, 54) + "..." : row["ProdCatDesc"].ToString();

                        strMarkup.Append("<p class=\"clrdarkgrey light line-ht-5\">" + prodcatData + "</p>");
                        string nUrl = rootPath + "product-category/" + c.UrlGenerator(row["ProdCatName"].ToString().ToLower() + "-" + row["ProdCatId"].ToString());
                        strMarkup.Append("<a href=\"" + nUrl + "\"><img src=\"images/icons/next.png\"/></a>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");

                    }

                    prodcat = strMarkup.ToString();
                }
                else
                {
                    //evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            prodcat = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }



    public string GetNewsData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 3 newsId, newsDate, newsTitle, newsDesc from NewsData where DelMark=0 order by newsId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {
                    
                    foreach (DataRow row in dttest.Rows)
                    {

                        if (c.IsRecordExist("Select newsId From NewsData Where newsId=" + row["newsId"].ToString() + ""))
                        {

                            strMarkup.Append("<div class=\"col-lg-4\"  data-aos=\"fade-right\"  data-aos-duration=\"1000\">");
                            strMarkup.Append("<div class=\"p-4\">");

                            string nUrl = rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());
                            string nwsTitle = row["newsTitle"].ToString().Length >= 39 ? row["newsDesc"].ToString().Substring(0, 39) + "..." : row["newsTitle"].ToString();
                            strMarkup.Append("<a href=\"" + nUrl + "\" class=\"clrdarkgrey semiBold nwstitle semiMedium\">" + nwsTitle + "</a>");
                            strMarkup.Append("<span class=\"space10\"></span>");
                            DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                            strMarkup.Append("<span class=\"clrdarkgrey small\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                            strMarkup.Append("<hr />");
                            strMarkup.Append("<span class=\"space15\"></span>");
                            string nwsDesc = row["newsDesc"].ToString().Length >= 187 ? row["newsDesc"].ToString().Substring(0, 187) + "..." : row["newsDesc"].ToString();
                            strMarkup.Append("<p class=\"clrdarkgrey light fontRegular line-ht-5 mb-3\">" + nwsDesc + "</p>");
                            strMarkup.Append("<a href=\""+ nUrl + "\" class=\"nwsbtn\"><img src=\"images/icons/right-arrow.png\"/></a>");

                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");

                            //strMarkup.Append("<div class=\"testpad mb-3\" >");
                            //strMarkup.Append("<div class=\"reviewquote\">");
                            //strMarkup.Append("<img src=\"images/icons/test-qoute.png\">");
                            //strMarkup.Append("</div>");
                            //strMarkup.Append("</div>");
                            //strMarkup.Append("<span class=\"semiBold fontRegular colorPrime\">" + row["TestName"].ToString() + "</span>");
                            //strMarkup.Append("<span class=\"space5\"></span>");
                            //strMarkup.Append("<span class=\"light clrGrey\">" + row["TestLocation"].ToString() + "</span>");
                            //strMarkup.Append("<span class=\"space10\"></span>");
                            //strMarkup.Append("<p class=\"fontRegular light line-ht-7\">" + row["TestDesc"].ToString() + "</p>");
                            //if (counter < dttest.Rows.Count)
                            //{
                            //    strMarkup.Append("<span class=\"greyLine\"></span>");
                            //}
                            //counter++;
                            //strMarkup.Append("<span class=\"space10\"></span>");
                        }
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }


    public string GetTestData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 3 TestId, TestName, TestLocation, TestDesc, TestRating from Testimonials where DelMark=0 AND ApproveFlag=1 order by TestId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {

                    foreach (DataRow row in dttest.Rows)
                    {

                        if (c.IsRecordExist("Select TestId From Testimonials Where TestId=" + row["TestId"].ToString() + ""))
                        {

                            strMarkup.Append("<div class=\"col-lg-4\"  data-aos=\"fade-right\"  data-aos-duration=\"1000\">");
                            strMarkup.Append("<div class=\"testboxinfo\">");
                            strMarkup.Append("<div class=\"p-4\">");
                            //string nUrl = rootPath + "testimonials/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["TestId"].ToString());
                            //string nwsTitle = row["newsTitle"].ToString().Length >= 39 ? row["newsDesc"].ToString().Substring(0, 39) + "..." : row["newsTitle"].ToString();
                            strMarkup.Append("<span  class=\"semiBold semiMedium colorWhite\">"+row["TestName"].ToString()+"</span>");
                            strMarkup.Append("<span class=\"space5\"></span>");
                            strMarkup.Append("<span class=\"fontRegular colorWhite\">" + row["TestLocation"].ToString() + "</span>");
                            strMarkup.Append("<span class=\"space20\"></span>");
                            string testDesc = row["TestDesc"].ToString().Length >= 245 ? row["TestDesc"].ToString().Substring(0, 245) + "..." : row["TestDesc"].ToString();
                            strMarkup.Append("<p class=\"clrdarkgrey light fontRegular line-ht-5 mb-3\">" + testDesc + "</p>");
                            //if (row["TestRating"] != DBNull.Value && row["TestRating"] != null && row["TestRating"].ToString() != "")
                            //{
                            //    switch (row["TestRating"].ToString())
                            //    {

                            //        case "1":
                            //            strMarkup.Append("<img src=\"images/icons/1-star.png\"/>");
                            //            break;
                            //        case "2":
                            //            strMarkup.Append("<img src=\"images/icons/2-star.png\"/>");
                            //            break;
                            //        case "3":
                            //            strMarkup.Append("<img src=\"images/icons/3-star.png\"/>");
                            //            break;
                            //        case "4":
                            //            strMarkup.Append("<img src=\"images/icons/4-star.png\"/>");
                            //            break;
                            //        case "5":
                            //            strMarkup.Append("<img src=\"images/icons/5-star.png\"/>");
                            //            break;

                            //    }
                            //}
                            //strMarkup.Append("<span class=\"space10\">");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");

                            //strMarkup.Append("<div class=\"testpad mb-3\" >");
                            //strMarkup.Append("<div class=\"reviewquote\">");
                            //strMarkup.Append("<img src=\"images/icons/test-qoute.png\">");
                            //strMarkup.Append("</div>");
                            //strMarkup.Append("</div>");
                            //strMarkup.Append("<span class=\"semiBold fontRegular colorPrime\">" + row["TestName"].ToString() + "</span>");
                            //strMarkup.Append("<span class=\"space5\"></span>");
                            //strMarkup.Append("<span class=\"light clrGrey\">" + row["TestLocation"].ToString() + "</span>");
                            //strMarkup.Append("<span class=\"space10\"></span>");
                            //strMarkup.Append("<p class=\"fontRegular light line-ht-7\">" + row["TestDesc"].ToString() + "</p>");
                            //if (counter < dttest.Rows.Count)
                            //{
                            //    strMarkup.Append("<span class=\"greyLine\"></span>");
                            //}
                            //counter++;
                            //strMarkup.Append("<span class=\"space10\"></span>");
                        }
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }


    private void EventsMarkup()
    {
        try
        {
            using (DataTable dtevnt = c.GetDataTable("select TOP 1 EvntId, EvntDate, LEFT(EvntTitle, 50) as  EvntTitle, LEFT(EvntDesc, 190) as EvntDesc, EvntPhoto from EventsGallery where DelMark=0"))
            {
                if (dtevnt.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    //strMarkup.Append("<div class=\"row\">");
                    foreach (DataRow row in dtevnt.Rows)
                    {
                        strMarkup.Append("<div class=\"col-lg-6 themeBGThr d-flex align-items-center justify-content-center\">");
                        strMarkup.Append("<div class=\"p-5\">");
                        strMarkup.Append("<span class=\"fontRegular\">Events</span>");
                        strMarkup.Append("<span class=\"space10\"></span>");
                        string enttitle = row["EvntTitle"].ToString().Length >= 50 ? row["EvntTitle"].ToString().Substring(0, 50) + "..." : row["EvntTitle"].ToString();
                        strMarkup.Append("<span class=\"semiBold semiMedium\">" + enttitle + "</span>");
                        strMarkup.Append("<span class=\"space10\"></span>");
                        DateTime nDate = Convert.ToDateTime(row["EvntDate"]);
                        strMarkup.Append("<span class=\"fst-italic fontRegular\">" + nDate.ToString("dd / MM / yyyy") + "</span>");
                        string evntdesc = row["EvntDesc"].ToString().Length >= 190 ? row["EvntDesc"].ToString().Substring(0, 190) + "..." : row["EvntDesc"].ToString();
                        strMarkup.Append("<p class=\"mt-4 mb-5 fontRegular light line-ht-5\">" + evntdesc + "</p>");


                        //string existUrl = rootPath + "events-gallery/" + Page.RouteData.Values["categId"].ToString() + "/";

                        //string nUrl = existUrl + c.UrlGenerator(row["EvntTitle"].ToString().ToLower() + "-" + row["EvntId"].ToString());

                        string nUrl = rootPath + "events-gallery/" + c.UrlGenerator(row["EvntTitle"].ToString().ToLower() + "-" + row["EvntId"].ToString());

                        strMarkup.Append("<a href=\"\" Class=\"btnEvent\">View Event</a>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");

                        //strMarkup.Append("<div class=\"col-md-4\">");
                        //if (row["EvntPhoto"] != DBNull.Value && row["EvntPhoto"].ToString() != "" && row["EvntPhoto"].ToString() != "no-photo.png" && row["EvntPhoto"] != null)
                        //{
                        //    strMarkup.Append("<img src=\"" + rootPath + "upload/events/" + row["EvntPhoto"].ToString() + " \" alt=\"" + row["EvntPhoto"].ToString() + " \"  class=\"img-fluid w-100 newsborder\" >");
                        //}
                        //strMarkup.Append("</div>");
                        //strMarkup.Append("<div class=\"col-md-8\">");

                        //string evntTitle = row["EvntTitle"].ToString().Length >= 72 ? row["EvntTitle"].ToString().Substring(0, 72) + "..." : row["EvntTitle"].ToString();

                        //string nUrl =rootPath + "events-gallery/" + c.UrlGenerator(row["EvntTitle"].ToString().ToLower() + "-" + row["EvntId"].ToString());

                        //strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium colorPrime text-decoration-none eventtitle\">" + evntTitle + "</a>");
                        //strMarkup.Append("<span class=\"space5\"></span>");
                        //DateTime nDate = Convert.ToDateTime(row["EvntDate"]);
                        //strMarkup.Append("<span class=\"clrGrey small fst-italic\">" + nDate.ToString("dd / MM / yyyy") + "</span>");

                        //string evntdesc = row["EvntDesc"].ToString().Length >= 72 ? row["EvntDesc"].ToString().Substring(0, 254) + "..." : row["EvntDesc"].ToString();

                        //strMarkup.Append("<p class=\"fontRegular light  line-ht-7 mt-3 mb-4\">" + evntdesc + "</p>");
                        //strMarkup.Append("<a href=\"" + nUrl + "\" class=\"btnexplore\">Explore</a>");
                        //strMarkup.Append("</div>");

                        //if (counter < dtevnt.Rows.Count)
                        //{
                        //    strMarkup.Append("<span class=\"greyLine\"></span>");
                        //}
                        //counter++;
                   // }

                    using (DataTable dttest = c.GetDataTable("Select EvntGalPhotoId, FK_EvntId, EvntGalPhoto  from EventGalleryPhotos Where FK_EvntId=" + row["EvntId"] + ""))
                    {
                            if (dttest.Rows.Count > 0)
                            {
                                strMarkup.Append("<div class=\"col-lg-6 themeBGThr d-flex align-items-center justify-content-center\">");
                                strMarkup.Append("<div class=\"swiper mySwiper3\">");
                                strMarkup.Append("<div class=\"swiper-wrapper\">");
                                foreach (DataRow prow in dttest.Rows)
                                {
                                    strMarkup.Append("<div class=\"swiper-slide\">");
                                    strMarkup.Append("<img src=\"" + rootPath + "upload/events/" + prow["EvntGalPhoto"].ToString() + " \" alt=\"" + prow["EvntGalPhoto"].ToString() + " \" />");
                                    strMarkup.Append("</div>");

                                }
                                strMarkup.Append("</div>");
                                strMarkup.Append("<div class=\"swiper-button-next\"></div>");
                                strMarkup.Append("<div class=\"swiper-button-prev\"></div>");
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");

                            }
                        }

                }
                    //strMarkup.Append("</div>");
                    evntstr = strMarkup.ToString();
                }
                else
                {
                    //evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            evntstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void ProductsMarkup()
    {
        try
        {
            using (DataTable dtproduct = c.GetDataTable("select TOP 12 ProductId, ProductName, ProductPhoto from ProductsData where DelMark=0"))
            {
                if (dtproduct.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    //strMarkup.Append("<div class=\"row\">");
                    foreach (DataRow row in dtproduct.Rows)
                    {
                        strMarkup.Append("<div class=\"swiper-slide position-relative\" data-aos=\"zoom-in\" data-aos-duration=\"1000\">");

                        string nUrl = rootPath + "our-products/" + c.UrlGenerator(row["ProductName"].ToString().ToLower() + "-" + row["ProductId"].ToString())
                            ;
                        strMarkup.Append("<a href=\""+ nUrl + "\" class=\"text-decoration-none\">");
                        strMarkup.Append("<img src=\"" + rootPath + "upload/products/thumb/" + row["ProductPhoto"].ToString() + " \" alt=\"" + row["ProductPhoto"].ToString() + " \" />");
                        strMarkup.Append("<div class=\"productbx\">");
                        strMarkup.Append("<span class=\"\">"+row["ProductName"].ToString()+"</span>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</a>");
                        strMarkup.Append("</div>");

                    }
                    
                    prodstr = strMarkup.ToString();
                }
                else
                {
                    //evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            prodstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    private void ProdCatMenufoot()
    {
        try
        {
            using (DataTable dtproductmenu = c.GetDataTable("select TOP 8 ProdCatId, ProdCatName from ProductCategory where DelMark=0"))
            {
                //int totalcategory= dtproductmenu.Rows.Count;
                //int menu = totalcategory / 2;

                //int menucount = 0;

                if (dtproductmenu.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    //strMarkup.Append("<div class=\"row\">");
                    strMarkup.Append("<div class=\"\">");
                    strMarkup.Append("<ul class=\"footerNav\">");
                    foreach (DataRow row in dtproductmenu.Rows)
                    {
                        //menucount++;
                       
                        strMarkup.Append("<li>");
                        string nUrl = rootPath + "product-category/" + c.UrlGenerator(row["ProdCatName"].ToString().ToLower() + "-" + row["ProdCatId"].ToString());
                        strMarkup.Append("<a href=\"" + nUrl + "\">" + row["ProdCatName"].ToString() + "</a>");
                        strMarkup.Append("</li>");
                       

                        //if (menu == menucount)
                        //{
                        //    strMarkup.Append("<div class=\"col-sm-6\">");
                        //    strMarkup.Append("<ul class=\"multi-column-dropdown\">");
                        //    strMarkup.Append("<li>");
                        //    //string nUrls = rootPath + "our-products/" + c.UrlGenerator(row["ProductName"].ToString().ToLower() + "-" + row["ProductId"].ToString());
                        //    strMarkup.Append("<a href=\"\">" + row["ProdCatName"].ToString() + "</a>");
                        //    strMarkup.Append("</li>");
                        //    strMarkup.Append("</ul>");
                        //    strMarkup.Append("</div>");
                        //}

                    }
                    strMarkup.Append("</ul>");
                    strMarkup.Append("</div>");
                    prodstrfoo = strMarkup.ToString();
                }
                else
                {
                    //evntstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            prodstrfoo = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

}