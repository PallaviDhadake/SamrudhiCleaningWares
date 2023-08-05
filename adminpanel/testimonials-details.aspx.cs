using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminpanel_testimonials_details : System.Web.UI.Page
{
    iClass c = new iClass();
    public string[] ordTestiData = new string[30];
    public string pgTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GetreviewData(Convert.ToInt32(Request.QueryString["id"]));
        }
        lblId.Visible = false;

        object ApproveFlg = c.GetReqData("Testimonials", "ApproveFlag", "TestId="+Request.QueryString["id"]);

        if (ApproveFlg.ToString() == "1")
        {
            btnApprove.Enabled = false;
        }

    }

    public void GetreviewData(int ReviewIdx)
    {
        try
        {
            using (DataTable dtreview = c.GetDataTable("select * from Testimonials where TestId=" + ReviewIdx))

            {
                if (dtreview.Rows.Count > 0)
                {
                    DataRow row = dtreview.Rows[0];
                    lblId.Text = ReviewIdx.ToString();

                    txtPersonNm.Text = row["TestName"].ToString();
                    //txtDate.Text = Convert.ToDateTime(row["TestDate"]).ToString("dd/MM/yyyy");
                    txtEmail.Text = row["TestEmail"].ToString();
                    txtTesDesc.Text = row["TestDesc"].ToString();
                    txtRating.Text = row["TestRating"].ToString();
                    txtCity.Text = row["TestLocation"].ToString();

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetreviewData", ex.Message.ToString());
            return;
        }
    }


    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update Testimonials set ApproveFlag=1 where TestId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Testimonials Approved Sucessfully');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('testimonials-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnApprove_Click", ex.Message.ToString());
            return;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            txtTesDesc.Text = txtTesDesc.Text.Trim().Replace("'", "");
            txtPersonNm.Text = txtPersonNm.Text.Trim().Replace("'", "");
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "");
            txtCity.Text = txtCity.Text.Trim().Replace("'", "");

            //if (c.ValidateMobile(txtMobNo.Text) == false)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Please Enter Valid Mobile Number');", true);
            //    return;
            //}
            if (c.EmailAddressCheck(txtEmail.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Please Enter Valid Email Address');", true);
                return;
            }

            c.ExecuteQuery("Update Testimonials Set TestDesc='" + txtTesDesc.Text + "', TestName='" + txtPersonNm.Text + "', TestLocation='" + txtCity.Text + "', TestEmail='" + txtEmail.Text + "', TestRating='"+ txtRating .Text+ "' Where TestId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Testimonials Updated Sucessfully');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('testimonials-master.aspx', 2000);", true);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnUpdate_Click", ex.Message.ToString());
            return;
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("testimonials-master.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            c.ExecuteQuery("Delete from Testimonials where TestId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Testimonials Deleted ');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('testimonials-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnDelete_Click", ex.Message.ToString());
            return;
        }

    }
}