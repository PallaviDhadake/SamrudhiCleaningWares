using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
public partial class adminpanel_add_product_photos : System.Web.UI.Page
{
    iClass c = new iClass();
    public string productname, pgTitle, productPhoto, photoMarkup;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["albumId"] != null)
            {
                // CSR Title Display
                productname = c.GetReqData("ProductsData", "ProductName", "ProductId=" + Convert.ToInt32(Request.QueryString["albumId"])).ToString();

                GetAlbumPhotos(Convert.ToInt32(Request.QueryString["albumId"]));
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }


        if (Request.QueryString["id"] != null)
        {
            try
            {
                //string crsid = c.GetReqData("CSRPhotos", "FK_CSRId", "CSRPhotoId=" + Convert.ToInt32(Request.QueryString["albumId"])).ToString();

                c.ExecuteQuery("Delete From ProductsPhotos Where ProdPhotoId=" + Convert.ToInt32(Request.QueryString["id"]));
                GetAlbumPhotos(Convert.ToInt32(Request.QueryString["albumId"]));

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myJsFunction", "waitAndMove('add-photos.aspx', 3000);", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Photo Deleted');", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Record does not exist');", true);
                return;
            }
        }
        pgTitle = "Add Products Photos";

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuImg.HasFile)
            {
                string fExt = Path.GetExtension(fuImg.FileName).ToString().ToLower();
                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".gif")
                {
                    int PhotoId = c.NextId("ProductsPhotos", "ProdPhotoId");
                    string imgName = "Products-photo-" + PhotoId + fExt;


                    c.ExecuteQuery("Insert Into ProductsPhotos (ProdPhotoId, FK_ProductId, ProductPhoto) Values (" + PhotoId + ",  " + Convert.ToInt32(Request.QueryString["albumId"]) + ", '" + imgName + "')");
                    //ImageUploadProcess(imgName);
                    string FileName = Server.MapPath("~/upload/products/") + imgName;
                    fuImg.SaveAs(FileName);



                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Image uploaded');", true);

                    GetAlbumPhotos(Convert.ToInt32(Request.QueryString["albumId"]));

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg, .gif or .png files are allowed');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select image to upload');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSubmit_Click", ex.Message.ToString());
            return;
        }
    }


    private void GetAlbumPhotos(int photoIdX)
    {
        try
        {
            string rootPath = c.ReturnHttp();
            DataTable dtPhotos = new DataTable();
            dtPhotos = c.GetDataTable("Select * From ProductsPhotos Where FK_ProductId=" + photoIdX);

            if (dtPhotos.Rows.Count > 0)
            {
                StringBuilder strMarkup = new StringBuilder();
                foreach (DataRow row in dtPhotos.Rows)
                {
                    strMarkup.Append("<div class=\"imgBox\">");
                    strMarkup.Append("<div class=\"pad-5\">");
                    strMarkup.Append("<div class=\"border1\">");
                    strMarkup.Append("<div class=\"pad-5\">");
                    strMarkup.Append("<div class=\"imgContainer\">");
                    strMarkup.Append("<img src=\"" + rootPath + "upload/products/" + row["ProductPhoto"] + "\" class=\"w100\" />");
                    strMarkup.Append("</div>");
                    strMarkup.Append("</div>");
                    strMarkup.Append("</div>");
                    strMarkup.Append("</div>");
                    strMarkup.Append("<a href=\"add-product-photos.aspx?albumid=" + Request.QueryString["albumId"] + "&id=" + row["ProdPhotoId"] + "\" title=\"Delete Photo\"  class=\"gAnchdel\"></a>");
                    strMarkup.Append("</div>");
                }

                photoMarkup = strMarkup.ToString();
            }
            else
            {
                photoMarkup = "No photos to display";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetAlbumPhotos", ex.Message.ToString());
            return;
        }

    }


    private void ImageUploadProcess(string imgName)
    {
        try
        {
            string origImgPath = "~/upload/products/original/";
            string normalImgPath = "~/upload/products/";

            fuImg.SaveAs(Server.MapPath(origImgPath) + imgName);
            c.ImageOptimizer(imgName, origImgPath, normalImgPath, 700, false);


            File.Delete(Server.MapPath(origImgPath) + imgName);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }

}