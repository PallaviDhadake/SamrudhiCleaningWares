using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class MasterParent : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string currentYear, rootPath, submenu, prodstrfoo, evntvid, evntcatstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentYear = DateTime.Now.Year.ToString();
        rootPath = c.ReturnHttp();
        ProdCatMenu();
        ProdCatMenufoot();
        EventsCatImg();
        EventsCatvid();
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //currentYear = DateTime.Now.Year.ToString();
        rootPath = c.ReturnHttp();
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
                        strMarkup.Append("<a href=\"" + nUrl + "\">" + row["ProdCatName"].ToString() + "</a>");
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
            submenu = c.ErrNotification(3, ex.Message.ToString());
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


}
