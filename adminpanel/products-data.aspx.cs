using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class adminpanel_products_data : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, prodPhoto, videoPreview;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Products" : "Edit Products";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null)
                {
                    editinfo.Visible = true;
                    viewinfo.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        GetData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                }
                else
                {
                    editinfo.Visible = false;
                    viewinfo.Visible = true;
                    FillGrid();
                }

                c.FillComboBox("ProdCatName", "ProdCatId", "ProductCategory", "DelMark=0", "ProdCatName", 0, ddrProdCat);
            }
            lblId.Visible = false;

            txtProdSpec.Attributes.Add("maxlenght" ,"300");
            txtProdDesc.Attributes.Add("maxlenght", "300");

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }


    private void FillGrid()
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("Select a.ProductId, a.FK_ProdCatId, a.ProductName, a.ProductMRP, a.ProductVideoLink, a.readCount, b.ProdCatName From ProductsData a Inner Join ProductCategory b ON a.FK_ProdCatId=b.ProdCatId Where a.DelMark=0  Order By a.ProductId DESC"))
            {
                gvProducts.DataSource = dtNws;
                gvProducts.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvProducts.UseAccessibleHeader = true;
                    gvProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }


    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"products-data.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";


                Literal litAnchphto = new Literal();
                litAnchphto = (Literal)e.Row.FindControl("litAnchphto");
                litAnchphto.Text = "<a href=\"add-product-photos.aspx?albumId=" + e.Row.Cells[0].Text + "\" class=\"addPhoto\" title=\"Add Photos \"></a>";

                object Vidioflag = c.GetReqData("ProductsData", "ProductVideoLink", "ProductId=" + e.Row.Cells[0].Text).ToString();

                Literal litVideoLink = (Literal)e.Row.FindControl("litVideoLink");

                if (Vidioflag != DBNull.Value && Vidioflag != null && Vidioflag.ToString() != "")
                {


                    if (Vidioflag.ToString() == "")
                    {

                        litVideoLink.Text = "";
                    }
                    else
                    {
                        litVideoLink.Text = "<img src=\"images/icons/mark.gif\">";
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvProducts_RowDataBound", ex.Message.ToString());
            return;
        }
    }

    public void GetAllControls(ControlCollection ctrs)
    {
        foreach (Control c in ctrs)
        {
            if (c is System.Web.UI.WebControls.TextBox)
            {
                TextBox tt = c as TextBox;
                tt.Text = tt.Text.Trim().Replace("'", "");
            }
            if (c.HasControls())
            {
                GetAllControls(c.Controls);
            }
        }
    }

    public void GetData(int ProductIdx)
    {
        try
        {
            using (DataTable dtprod = c.GetDataTable("select * from ProductsData where ProductId=" + ProductIdx))
            {
                if (dtprod.Rows.Count > 0)
                {
                    DataRow row = dtprod.Rows[0];
                    lblId.Text = ProductIdx.ToString();

                    ddrProdCat.SelectedValue = row["FK_ProdCatId"].ToString();
                    txtProdName.Text = row["ProductName"].ToString();
                    txtMrp.Text = row["ProductMRP"].ToString();
                    txtProdDesc.Text = row["ProductDesc"].ToString();
                    txtProdSpec.Text = row["ProductSpecification"].ToString();
                    txtVidLink.Text = row["ProductVideoLink"].ToString();
                    //txtDate.Text = Convert.ToDateTime(row["projDate"]).ToString("dd/MM/yyyy");

                    if (row["ProductPhoto"] != DBNull.Value && row["ProductPhoto"] != null && row["ProductPhoto"].ToString() != "" && row["ProductPhoto"].ToString() != "no-photo.png")
                    {
                        prodPhoto = "<img src=\"" + Master.rootPath + "upload/products/thumb/" + row["ProductPhoto"].ToString() + "\" width=\"200\" />";
                        btnRemove.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                    }

                    if (row["ProductVideoLink"] != DBNull.Value && row["ProductVideoLink"] != null && row["ProductVideoLink"].ToString() != "")
                    {
                        txtVidLink.Text = "www.youtube.com/watch?v=" + row["ProductVideoLink"].ToString();

                        videoPreview = "<iframe width=\"400\" height=\"220\" src=\"https://www.youtube.com/embed/" + row["ProductVideoLink"].ToString() + "\"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\"allowfullscreen></iframe>";

                    }

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetData", ex.Message.ToString());
            return;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllControls(this.Controls);
            if (txtProdName.Text == "" || ddrProdCat.SelectedIndex == 0 || txtMrp.Text == "" || txtProdDesc.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * marked fields are mandatory');", true);
                return;
            }

            string videoLink = "";
            if (txtVidLink.Text != "")
            {
                if (txtVidLink.Text.Contains("www.youtube.com") == true)
                {
                    string[] arrLink = txtVidLink.Text.Split('/');
                    string[] arrKey = arrLink[arrLink.Length - 1].Split('=');
                    videoLink = arrKey[arrKey.Length - 1];
                }
                else if (txtVidLink.Text.Contains("youtu.be"))
                {
                    string[] arrVidLink = txtVidLink.Text.Split('/');
                    string tempvidLink = arrVidLink[arrVidLink.Length - 1];

                    if (tempvidLink.ToString().Contains("?"))
                    {
                        string[] arrFinalLink = tempvidLink.ToString().Split('?');
                        videoLink = arrFinalLink[0];

                    }
                    else
                    {
                        videoLink = tempvidLink.ToString();
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid video link entered');", true);
                    return;
                }
            }
            

                int maxId = lblId.Text == "[New]" ? c.NextId("ProductsData", "ProductId") : Convert.ToInt32(lblId.Text);

                if (fuImage.HasFile)
                {
                    string fExt = Path.GetExtension(fuImage.FileName).ToString().ToLower();

                    if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                    {
                        prodPhoto = "product-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                        ImageUploadProcess(prodPhoto);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
                        return;

                    }
                }
                else if (fuImage.HasFile == false && lblId.Text == "[New]")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select project image ');", true);
                    return;
                }


                if (lblId.Text == "[New]")
                {
                    c.ExecuteQuery("Insert into ProductsData(ProductId, FK_ProdCatId,  ProductName, ProductSpecification, ProductDesc, ProductMRP, ProductVideoLink, ProductPhoto, readCount, DelMark)Values(" + maxId + ", " + ddrProdCat.SelectedValue + ",  '" + txtProdName.Text + "', '" + txtProdSpec.Text + "', '" + txtProdDesc.Text + "', " + txtMrp.Text + ", '" + videoLink + "', '" + prodPhoto + "', 0, 0)");


                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Product  Added');", true);
                }
                else
                {

                    c.ExecuteQuery("Update ProductsData set FK_ProdCatId='" + ddrProdCat.SelectedValue + "', ProductName='" + txtProdName.Text + "', ProductSpecification='" + txtProdSpec.Text + "', ProductDesc='" + txtProdDesc.Text + "', ProductMRP=" + txtMrp.Text + ", ProductVideoLink='" + videoLink + "' where ProductId=" + maxId);


                    if (fuImage.HasFile)
                    {
                        c.ExecuteQuery("Update ProductsData Set ProductPhoto='" + prodPhoto + "' where ProductId=" + maxId + "");
                    }


                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Product  Updated');", true);
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-data.aspx', 2000);", true);

                txtProdName.Text = "";
                ddrProdCat.SelectedIndex = 0;

          //  }
        
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }


    private void ImageUploadProcess(string prodPhoto)
    {
        try
        {

            string origImgPath = "~/upload/products/original/";
            string thumbImgPath = "~/upload/products/thumb/";
            string normalImgPath = "~/upload/products/";

            fuImage.SaveAs(Server.MapPath(origImgPath) + prodPhoto);
            c.ImageOptimizer(prodPhoto, origImgPath, normalImgPath, 800, true);
            c.ImageOptimizer(prodPhoto, normalImgPath, thumbImgPath, 480, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + prodPhoto);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //c.ExecuteQuery("update ProductsData set DelMark=1 where ProductId=" + Request.QueryString["id"]);
            c.ExecuteQuery("Delete From ProductsPhotos where FK_ProductId=" + Request.QueryString["id"]);
            c.ExecuteQuery("Delete From ProductsData Where ProductId=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Product Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-data.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnDelete_Click", ex.Message.ToString());
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("products-data.aspx");
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update ProductsData set ProductPhoto='no-photo.png' where ProductId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Photo Removed');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-data.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnRemove_Click", ex.Message.ToString());
            return;

        }
    }
}