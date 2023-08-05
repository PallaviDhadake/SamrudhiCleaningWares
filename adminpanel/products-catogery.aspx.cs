using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class adminpanel_products_catogery : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, prodPhoto;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Products Category" : "Edit Products Category";
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
            }
            lblId.Visible = false;
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }

        txtProdDesc.Attributes.Add("maxlength", "300");
    }



    private void FillGrid()
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("Select ProdCatId,ProdCatName From ProductCategory Where DelMark=0"))
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
                litAnch.Text = "<a href=\"products-catogery.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";

            }
        }
        catch(Exception ex)
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


    public void GetData(int ProdCatIdx)
    {
        try
        {
            using (DataTable dtprodcat = c.GetDataTable("select * from ProductCategory where ProdCatId=" + ProdCatIdx))
            {
                if (dtprodcat.Rows.Count > 0)
                {
                    DataRow row = dtprodcat.Rows[0];
                    lblId.Text = ProdCatIdx.ToString();

                   // ddrProdCat.SelectedItem.Text = row["ProdCatName"].ToString();
                    txtProdDesc.Text = row["ProdCatDesc"].ToString();
                    txtProdCat.Text = row["ProdCatName"].ToString();
                    //txtDate.Text = Convert.ToDateTime(row["projDate"]).ToString("dd/MM/yyyy");

                    //if (row["ProdCatName"] != DBNull.Value && row["ProdCatName"] != null && row["ProdCatName"].ToString() != "")
                    //{
                    //    switch (row["ProdCatName"].ToString())
                    //    {
                    //        case "Broom":
                    //            ddrProdCat.SelectedValue = "1";
                    //            break;

                    //        case "Brush":
                    //            ddrProdCat.SelectedValue = "2";
                    //            break;

                    //        case "Wiper":
                    //            ddrProdCat.SelectedValue = "3";
                    //            break;

                    //        case "Mop":
                    //            ddrProdCat.SelectedValue = "4";
                    //            break;

                    //        case "Spin Mop":
                    //            ddrProdCat.SelectedValue = "5";
                    //            break;

                    //        case "Spare Accessories":
                    //            ddrProdCat.SelectedValue = "6";
                    //            break;

                    //        case "Soap Case":
                    //            ddrProdCat.SelectedValue = "7";
                    //            break;

                    //        case "Drying Stand":
                    //            ddrProdCat.SelectedValue = "8";
                    //            break;

                    //        case "Wipe":
                    //            ddrProdCat.SelectedValue = "9";
                    //            break;

                    //        case "Scrubber":
                    //            ddrProdCat.SelectedValue = "10";
                    //            break;

                    //        case "Ladder":
                    //            ddrProdCat.SelectedValue = "11";
                    //            break;

                    //        case "Supali":
                    //            ddrProdCat.SelectedValue = "12";
                    //            break;

                    //        case "Loofan":
                    //            ddrProdCat.SelectedValue = "13";
                    //            break;

                    //        case "Kharata":
                    //            ddrProdCat.SelectedValue = "14";
                    //            break;

                    //        case "Rack":
                    //            ddrProdCat.SelectedValue = "15";
                    //            break;

                    //        case "Plunger":
                    //            ddrProdCat.SelectedValue = "16";
                    //            break;

                    //        case "Liquid":
                    //            ddrProdCat.SelectedValue = "17";
                    //            break;

                    //    }
                    //}


                    if (row["ProdCatCoverPhoto"] != DBNull.Value && row["ProdCatCoverPhoto"] != null && row["ProdCatCoverPhoto"].ToString() != "" && row["ProdCatCoverPhoto"].ToString() != "no-photo.png")
                    {
                        prodPhoto = "<img src=\"" + Master.rootPath + "upload/productscategory/thumb/" + row["ProdCatCoverPhoto"].ToString() + "\" width=\"200\" />";
                        btnRemove.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
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
            if (txtProdDesc.Text == "" || txtProdCat.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All Fields are mandatory');", true);
                return;
            }

            int maxId = lblId.Text == "[New]" ? c.NextId("ProductCategory", "ProdCatId") : Convert.ToInt32(lblId.Text);

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
            else if (fuImage.HasFile==false && lblId.Text == "[New]")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select product category image');", true);
                return;
            }


            if (lblId.Text == "[New]")
            {

                if (c.IsRecordExist("Select ProdCatId from ProductCategory where ProdCatName='" + txtProdCat.Text + "' And DelMark=0"))
                {

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Entered Product Category is already exist');", true);
                    return;
                }

                c.ExecuteQuery("Insert into ProductCategory(ProdCatId, ProdCatName, ProdCatDesc, ProdCatCoverPhoto, DelMark)Values(" + maxId + ", '" + txtProdCat.Text + "',  '" + txtProdDesc.Text + "', '" + prodPhoto + "', 0)");


                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Products Category Added');", true);
            }
            else
            {

                if (c.IsRecordExist("select ProdCatId from ProductCategory where ProdCatName='" + txtProdCat.Text + "' And ProdCatId!=" + lblId.Text + " AND DelMark=0"))
                {

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Entered Product Category is already exist');", true);
                    return;
                }


                c.ExecuteQuery("Update ProductCategory set ProdCatName='" + txtProdCat.Text+ "', ProdCatDesc='" + txtProdDesc.Text + "' where ProdCatId=" + maxId);


                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update ProductCategory Set ProdCatCoverPhoto='" + prodPhoto + "' where ProdCatId=" + maxId + "");
                }


                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Products Category Updated');", true);
            }

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-catogery.aspx', 2000);", true);

            txtProdDesc.Text = "";
            txtProdCat.Text = "";


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

            string origImgPath = "~/upload/productscategory/original/";
            string thumbImgPath = "~/upload/productscategory/thumb/";
            string normalImgPath = "~/upload/productscategory/";

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
            if (c.IsRecordExist("Select ProductId From ProductsData where FK_ProdCatId=" + Request.QueryString["id"]))
            {

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Products are present under this Category You can not Delete category');", true);
                return;

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Products are present under this category, You can't Delete category');", true);
                //return;
            }
            else
            {   
                c.ExecuteQuery("Delete From ProductCategory where ProdCatId=" + Request.QueryString["id"]);
            }

            //c.ExecuteQuery("update ProductCategory set DelMark=1 where ProdCatId=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Products Category Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-catogery.aspx', 2000);", true);
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
        Response.Redirect("products-catogery.aspx");
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update ProductCategory set ProdCatCoverPhoto='no-photo.png' where ProdCatId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Photo Removed');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-catogery.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnRemove_Click", ex.Message.ToString());
            return;

        }
    }
}