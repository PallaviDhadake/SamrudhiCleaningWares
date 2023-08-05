using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class product_category : System.Web.UI.Page
{
    iClass c = new iClass();
    public string prodcatstr;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!IsPostBack)
        {
            //if (String.IsNullOrEmpty(Page.RouteData.Values["ProductId"].ToString()))
            //{
                //    string[] arrLinks = Page.RouteData.Values["ProdCatId"].ToString().Split('-');
                //    ProdCatData(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
                //    // GetProductData();
                //}
                //else
                //{
                string[] arrLinks = Page.RouteData.Values["ProdCatId"].ToString().Split('-');
                ProdCatData(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
            //}
            
        }
       
    }


    public void ProdCatData(int ProdCatIdx)
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("Select ProductId, ProductName, ProductPhoto From ProductsData Where DelMark=0 AND FK_ProdCatId=" + ProdCatIdx))
            {
                if (dttest.Rows.Count > 0)
                {
                    //int counter = 1;
                    foreach (DataRow row in dttest.Rows)
                    {
                        //using (DataTable dtprodcat = c.GetDataTable("Select ProductId, ProductName, ProductPhoto From ProductsData Where DelMark=0 AND FK_ProdCatId="+row["FK_ProdCatId"] +""))
                        //{
                        string nUrl = Master.rootPath + "our-products/" + c.UrlGenerator(row["ProductName"].ToString().ToLower() + "-" + row["ProductId"].ToString());
                       
                        strMarkup.Append("<div class=\"col-md-3 prodcatbox\" >");
                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"text-decoration-none\">");
                        strMarkup.Append("<div class=\"p-2\">");
                            strMarkup.Append("<div class=\"border\">");
                            if (row["ProductPhoto"] != DBNull.Value && row["ProductPhoto"].ToString() != "" && row["ProductPhoto"].ToString() != "no-photo.png" && row["ProductPhoto"] != null)
                            {
                                strMarkup.Append("<img src=\"" + Master.rootPath + "upload/products/thumb/" + row["ProductPhoto"].ToString() + " \" alt=\"" + row["ProductName"].ToString() + " \"  class=\"img-fluid mb-2\" >");

                            }
                            strMarkup.Append("</div>");
                            strMarkup.Append("<div class=\"border\">");
                            strMarkup.Append("<div class=\"p-2\">");
                            strMarkup.Append("<span class=\"fontRegular clrdarkgrey regular prodcatname\">" + row["ProductName"].ToString() + "</span>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        strMarkup.Append("</a>");

                        strMarkup.Append("</div>");
                           
                        //}
                    }
                    prodcatstr = strMarkup.ToString();
                }
                else
                {
                    prodcatstr= "Nothing Products Category to display";
                }
            }
        }
        catch (Exception ex)
        {
            prodcatstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

}