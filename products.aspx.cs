using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class products : System.Web.UI.Page
{
    iClass c = new iClass();
    public string prodstr, listspect;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Page.Header.DataBind();
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Page.RouteData.Values["ProductId"].ToString()))
                {
                    GetProductData();
                }
                else
                {
                    string[] arrLinks = Page.RouteData.Values["ProductId"].ToString().Split('-');
                    GetprodDetails(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));

                }
            }
        }
        catch (Exception ex)
        {
            prodstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    public void GetProductData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dtprod = c.GetDataTable("Select ProductId, ProductName, ProductPhoto from ProductsData where DelMark=0 Order By ProductId DESC"))
            {

                if (dtprod.Rows.Count > 0)
                {
                   // strMarkup.Append("<div class=\"row gy-5\">");
                    foreach (DataRow row in dtprod.Rows)
                    {
                        string nUrl = Master.rootPath + "our-products/" + c.UrlGenerator(row["ProductName"].ToString().ToLower() + "-" + row["ProductId"].ToString());
                        strMarkup.Append("<div class=\"col-md-3\">");
                        strMarkup.Append("<div class=\"content border\">");
                        strMarkup.Append("<a href=\""+ nUrl + "\" class=\"text-decoration-none\">");
                        strMarkup.Append("<div class=\"content-overlay\"></div>");
                        if (row["ProductPhoto"] != DBNull.Value && row["ProductPhoto"].ToString() != "" && row["ProductPhoto"].ToString() != "no-photo.png" && row["ProductPhoto"] != null)
                        {
                            strMarkup.Append("<img src=\"" + Master.rootPath + "upload/products/thumb/" + row["ProductPhoto"].ToString() + " \" alt=\"" + row["ProductPhoto"].ToString() + " \"  class=\"img-fluid \" >");
                        }
                        strMarkup.Append("<div class=\"themeBGPrime\">");
                        strMarkup.Append("<div class=\"px-2 py-2 d-flex align-items-center justify-content-center\">");
                        strMarkup.Append("<h4 class=\"semiBold semiMedium text-white\">"+row["ProductName"].ToString() +"</h4>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("<div class=\"content-details fadeIn-bottom\">");
                        strMarkup.Append("<img src=\"images/icons/view.png\" class=\"img-fluid\"  title=\"View Product\" />");

                        strMarkup.Append("</div>");
                        strMarkup.Append("</a>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                    }
                   // strMarkup.Append("</div>");
                    prodstr = strMarkup.ToString();
                }
                else
                {
                    prodstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        
        
        catch (Exception ex)
        {
            prodstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    private void GetprodDetails(int prodIdx)
    {
        try
        {
            //data.Visible = false;
            using (DataTable dtproj = c.GetDataTable("Select * From ProductsData Where ProductId=" + prodIdx))
            {
                if (dtproj.Rows.Count > 0)
                {
                    DataRow row = dtproj.Rows[0];
                    StringBuilder strMarkup = new StringBuilder();

                    this.Title = row["ProductName"].ToString() + "| Latest Products of Samruddhi Cleaning Wares.";

                    //strMarkup.Append("<h2 class=\"pageH2 themeClrPrime capitalize text-uppercase\">" + row["ProductName"].ToString() + "</h2>");
                    //strMarkup.Append("<div class=\"col-md-5\">");
                    //strMarkup.Append("<div class=\"p-3\">");
                    //strMarkup.Append("<div class=\"border d-flex align-items-center justify-content-center\">");
                    //strMarkup.Append("<div class=\"p-4\">");
                    //strMarkup.Append("<div id=\"carouselexamplefade\" class=\"carousel slide carousel-fade position-relative\" data-bs-ride=\"carousel\" data-bs-interval=\"3500\">");

                    using (DataTable dttest = c.GetDataTable("Select ProdPhotoId, FK_ProductId, ProductPhoto  from ProductsPhotos Where FK_ProductId=" + prodIdx + ""))
                    {
                        if (c.IsRecordExist("Select ProdPhotoId From ProductsPhotos Where FK_ProductId=" + prodIdx + ""))
                        {

                            if (dttest.Rows.Count > 0)
                            {
                                strMarkup.Append("<div class=\"col-lg-5 \">");
                                //strMarkup.Append("<div class=\"\">");
                                 strMarkup.Append("<div class=\"top-0 start-50 border\">");
                                strMarkup.Append("<div class=\"p-2\">");
                                strMarkup.Append("<div class=\"swiper mySwiper\">");
                                strMarkup.Append("<div class=\"swiper-wrapper\">");
                                //strMarkup.Append("<div class=\"p-2\">");
                                foreach (DataRow prow in dttest.Rows)
                                {
                                    strMarkup.Append("<div class=\"swiper-slide\">");
                                    strMarkup.Append("<div class=\"p-1\">");
                                    if (prow["ProductPhoto"] != DBNull.Value && prow["ProductPhoto"].ToString() != "" && prow["ProductPhoto"].ToString() != "no-photo.png" && prow["ProductPhoto"] != null)
                                    {
                                    //Added Fancybox
                                        strMarkup.Append("<a data-fancybox href=\"" + Master.rootPath + "upload/products/" + prow["ProductPhoto"].ToString() + "\" data-fancybox=\"imggroup\">");

                                        strMarkup.Append("<img src=\"" + Master.rootPath + "upload/products/" + prow["ProductPhoto"].ToString() + " \" alt=\"" + prow["ProductPhoto"].ToString() + " \" class=\"img-fluid w-100\" />");

                                        strMarkup.Append("</a>");
                                    }
                                    //End Markup
                                    strMarkup.Append("</div>");
                                    strMarkup.Append("</div>");

                                }

                                strMarkup.Append("</div>");
                                strMarkup.Append("<div class=\"swiper-button-next\"></div>");
                                strMarkup.Append("<div class=\"swiper-button-prev\"></div>");
                                strMarkup.Append("</div>");
                                //strMarkup.Append("</div>");
                                strMarkup.Append("<div class=\"clearfix\"></div>");
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                                //col-lg-5 end here
                                strMarkup.Append("</div>");
                            }

                        }
                        else
                        {
                            strMarkup.Append("<div class=\"col-md-4\">");
                            strMarkup.Append("<div class=\"border\">");
                            strMarkup.Append("<div class=\"p-2\">");

                            strMarkup.Append("<a data-fancybox href=\"" + Master.rootPath + "upload/products/" + row["ProductPhoto"].ToString() + "\" data-fancybox=\"imggroup\">");
                            strMarkup.Append("<img src=\"" + Master.rootPath + "upload/products/thumb/" + row["ProductPhoto"].ToString() + " \" alt=\"" + row["ProductPhoto"].ToString() + " \" class=\"img-fluid \"/>");
                            strMarkup.Append("</a>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                    }


                    //strMarkup.Append("</div>");
                    //strMarkup.Append("</div>");
                    //strMarkup.Append("</div>");
                    //strMarkup.Append("</div>");
                    //strMarkup.Append("</div>");

                    //Product single img

                    //strMarkup.Append("<div class=\"col-md-4\">");
                    //strMarkup.Append("<div class=\"border\">");
                    //strMarkup.Append("<div class=\"p-2\">");
                    //strMarkup.Append("<img src=\"" + Master.rootPath + "upload/products/thumb/" + row["ProductPhoto"].ToString() + " \" alt=\"" + row["ProductPhoto"].ToString() + " \" class=\"img-fluid \"/>");
                    //strMarkup.Append("</div>");
                    //strMarkup.Append("</div>");
                    //strMarkup.Append("</div>");

                    ////single img end


                    //Col-md-7 start here

                    strMarkup.Append("<div class=\"col-md-7\">");
                    strMarkup.Append("<div class=\"p-3\">");
                    strMarkup.Append("<h3 class=\"colorSec text-uppercase semiBold mb-3\">"+row["ProductName"].ToString() +"</h3>");
                    strMarkup.Append("<p class=\"fontRegular regular line-ht-5\">Price: <span class=\"light small semiBold\">&#8377; "+row["ProductMRP"].ToString() +"</span></p>");

                    //strMarkup.Append("<p class=\"fontRegular regular line-ht-5\">Specification: <span class=\"light small clrGrey line-ht-7\"> "+row["ProductSpecification"].ToString()+"</p>");

                   

                    if (row["ProductSpecification"] != DBNull.Value && row["ProductSpecification"].ToString() != "" && row["ProductSpecification"].ToString() != "" && row["ProductSpecification"] != null)
                    {
                        strMarkup.Append("<p class=\"fontRegular regular line-ht-5 mb-2\">Specification</p>");
                        strMarkup.Append("<ul class=\"bulletlist m-0 p-0 fontRegular clrGrey small\">");

                        //string names = "" + row["ProductSpecification"].ToString() + "";
                        //List<string> nameList = names.Split('.').ToList();

                        string names = "" + row["ProductSpecification"].ToString() + "";

                        int lineCount = names.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;

                        //List<string> nameList = new List<string>();   

                        foreach (string name in names.Split('\n'))
                        {

                            string data = name;
                            strMarkup.Append("<li><span>&#187;</span>" + data + "</li>");

                        }
                        strMarkup.Append("</ul>");

                    }

                    strMarkup.Append("<span class=\"space10\"></span>");

                    strMarkup.Append("<p class=\"fontRegular regular line-ht-5\">Description: <span class=\"light small clrGrey line-ht-7\"> " + row["ProductDesc"].ToString() + "</p>");

                    strMarkup.Append("<span class=\"space15\"></span>");

                    //video markup

                    if (row["ProductVideoLink"] != DBNull.Value && row["ProductVideoLink"].ToString() != "" && row["ProductVideoLink"].ToString() != "no-photo.png" && row["ProductVideoLink"] != null)
                    {
                        strMarkup.Append("<p class=\"semiBold semiMedium mb-3\">Product Video</p>");

                        strMarkup.Append("<a data-fancybox href=\"https://www.youtube.com/watch?v=" + row["ProductVideoLink"] + "\">");
                        strMarkup.Append("<img src=\"http://img.youtube.com/vi/" + row["ProductVideoLink"] + "/0.jpg\"alt=\"" + row["ProductVideoLink"].ToString() + "\"class=\"productvideo\">");
                        strMarkup.Append("</a>");
                    }

                    strMarkup.Append("</div>");
                    strMarkup.Append("</div>");
                    prodstr = strMarkup.ToString();
                }

            }
        }
        catch (Exception ex)
        {
            prodstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }
}