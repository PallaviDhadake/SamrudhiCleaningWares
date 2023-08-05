using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class adminpanel_Event_master : System.Web.UI.Page
{
    iClass c = new iClass();
    public string eventPhoto, pgTitle, videoPreview;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Events" : "Edit Events";
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
                        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        btnRemove.Visible = false;
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

                c.FillComboBox("EventCategory", "EventCatId", "EventsGalleryCategory", "DelMark=0", "EventCategory", 0, ddrevntcat);
            }
            lblId.Visible = false;

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }

        //txtEventDesc.Attributes.Add("maxlength", "5");
    }


    private void FillGrid()
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("Select EvntId, Convert(varchar(20), EvntDate, 103) as EvntDate, EvntTitle From EventsGallery Where DelMark=0 Order By EvntDate DESC"))
            {
                gvEvents.DataSource = dtNws;
                gvEvents.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvEvents.UseAccessibleHeader = true;
                    gvEvents.HeaderRow.TableSection = TableRowSection.TableHeader;
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


    protected void gvEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"Event-master.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";


                Literal litAnchphto = new Literal();
                litAnchphto = (Literal)e.Row.FindControl("litAnchphto");
                litAnchphto.Text = "<a href=\"add-events-photos.aspx?albumId=" + e.Row.Cells[0].Text + "\" class=\"addPhoto\" title=\"Add Photos \"></a>";


                    object Vidioflag = c.GetReqData("EventsGallery", "EvntVideo", "EvntId=" + e.Row.Cells[0].Text).ToString();

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
            c.ErrorLogHandler(this.ToString(), "gvEvents_RowDataBound", ex.Message.ToString());
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


    public void GetData(int EvntIdx)
    {
        try
        {
            using (DataTable dtproj = c.GetDataTable("select * from EventsGallery where EvntId=" + EvntIdx))
            {
                if (dtproj.Rows.Count > 0)
                {
                    DataRow row = dtproj.Rows[0];
                    lblId.Text = EvntIdx.ToString();

                    txtEventTitle.Text = row["EvntTitle"].ToString();
                    txtEventDesc.Text = row["EvntDesc"].ToString();
                    ddrevntcat.SelectedValue = row["FK_EventCatId"].ToString();

                    txtDate.Text = Convert.ToDateTime(row["EvntDate"]).ToString("dd/MM/yyyy");
                   

                    if (row["EvntPhoto"] != DBNull.Value && row["EvntPhoto"] != null && row["EvntPhoto"].ToString() != "" && row["EvntPhoto"].ToString() != "no-photo.png")
                    {
                        eventPhoto = "<img src=\"" + Master.rootPath + "upload/events/thumb/" + row["EvntPhoto"].ToString() + "\" width=\"200\" />";
                        btnRemove.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                    }


                    if (row["EvntVideo"] != DBNull.Value && row["EvntVideo"] != null && row["EvntVideo"].ToString() != "")
                    {
                        txtEventVideo.Text = "www.youtube.com/watch?v=" + row["EvntVideo"].ToString();

                        videoPreview = "<iframe width=\"400\" height=\"220\" src=\"https://www.youtube.com/embed/" + row["EvntVideo"].ToString() + "\"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\"allowfullscreen></iframe>";

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
            //Empty Validations
            if (txtDate.Text == "" || txtEventTitle.Text == "" || txtEventDesc.Text == "" || ddrevntcat.SelectedIndex==0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            //Insert Update data
            int maxId = lblId.Text == "[New]" ? c.NextId("EventsGallery", "EvntId") : Convert.ToInt32(lblId.Text);

            DateTime appDate = DateTime.Now;
            string[] arrDate = txtDate.Text.Split('/');
            if (c.IsDate(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Date');", true);
                return;
            }
            else
            {
                appDate = Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]);
            }

            DateTime cDate = DateTime.Now;
            string currentDate = cDate.ToString("yyyy-MM-dd HH:mm:ss.fff");


            string eventPhoto = "";
            if (fuImage.HasFile)
            {
                string fExt = Path.GetExtension(fuImage.FileName).ToString().ToLower();

                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                {
                    eventPhoto = "events-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                    ImageUploadProcess(eventPhoto);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
                    return;

                }
            }
            else if (fuImage.HasFile==false && lblId.Text == "[New]")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Event image ');", true);
                return;
            }

            string videoLink = "";
            if (txtEventVideo.Text != "")
            {
                if (txtEventVideo.Text.Contains("www.youtube.com") == true)
                {
                    string[] arrLink = txtEventVideo.Text.Split('/');
                    string[] arrKey = arrLink[arrLink.Length - 1].Split('=');
                    videoLink = arrKey[arrKey.Length - 1];
                }
                else if (txtEventVideo.Text.Contains("youtu.be"))
                {
                    string[] arrVidLink = txtEventVideo.Text.Split('/');
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
            else
            {
                txtEventVideo.Text = "";
            }


            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert into EventsGallery(EvntId, FK_EventCatId, EvntDate, EvntTitle, EvntVideo, EvntDesc,  EvntPhoto, DelMark)Values(" + maxId + ", "+ddrevntcat.SelectedValue+",  '" + appDate + "', '" + txtEventTitle.Text + "', '"+ videoLink + "', '" + txtEventDesc.Text + "', '"+eventPhoto+"', 0)");
              

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Event Data Added');", true);
            }

            else
            {
                c.ExecuteQuery("Update EventsGallery set EvntDate='" + appDate + "', EvntTitle='" + txtEventTitle.Text + "', EvntDesc='" + txtEventDesc.Text + "', EvntVideo='"+ videoLink + "' where EvntId=" + maxId);

                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update EventsGallery Set EvntPhoto='" + eventPhoto + "' where EvntId=" + maxId + "");
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Event Data Updated');", true);
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('Event-master.aspx', 2000);", true);

            txtDate.Text = txtEventTitle.Text = txtEventDesc.Text = txtEventVideo.Text="";
            fuImage.Visible = false;


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    private void ImageUploadProcess(string eventPhoto)
    {
        try
        {

            string origImgPath = "~/upload/events/original/";
            string thumbImgPath = "~/upload/events/thumb/";
            string normalImgPath = "~/upload/events/";

            fuImage.SaveAs(Server.MapPath(origImgPath) + eventPhoto);
            c.ImageOptimizer(eventPhoto, origImgPath, normalImgPath, 800, true);
            c.ImageOptimizer(eventPhoto, normalImgPath, thumbImgPath, 480, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + eventPhoto);

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
            c.ExecuteQuery("update EventsGallery set DelMark=1 where EvntId=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Event Data Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('Event-master.aspx', 2000);", true);
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
        Response.Redirect("Event-master.aspx");
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update EventsGallery set EvntPhoto='no-photo.png' where EvntId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Photo Removed');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('Event-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnRemove_Click", ex.Message.ToString());
            return;
        }
    }
}