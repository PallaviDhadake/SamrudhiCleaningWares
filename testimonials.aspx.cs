using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services;
public partial class testimonials : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //[WebMethod]
    //public static string SaveTestimonials(Testimonials custinfo)
    //{
    //    try
    //    {
    //        iClass c = new iClass();
    //        int MaxId = c.NextId("Testimonials", "TestId");

    //        string testimonialsName = custinfo.TestPerson.ToString().Trim().Replace("'", "");
    //        string testimonialsInfo = custinfo.TestInfo.ToString().Trim().Replace("'", "");

    //        int starRating = 0;

    //        if (HttpContext.Current.Session["testRating"] != null)
    //        {
    //            starRating = Convert.ToInt32(HttpContext.Current.Session["testRating"].ToString());
    //        }

    //        c.ExecuteQuery("Insert Into Testimonials(TestId, TestDate, TestLocation, TestName, TestDesc, TestEmail, TestRating, DelMark) " +
    //            " Values(" + MaxId + ", '" + DateTime.Now + "', '" + custinfo.TestCity + "', '" + testimonialsName + "',  '"+ testimonialsInfo + "' , '" + custinfo.TestEmail + "', " + starRating + ",  0)");

            

    //        HttpContext.Current.Session["testRating"] = null;

    //        return "1";
            
    //    }
    //    catch (Exception ex)
    //    {
    //        return ex.Message.ToString();
    //    }   
    //}

    [WebMethod]
    public static string GetRating(string ratingValue)
    {
        HttpContext.Current.Session["testRating"] = ratingValue;
        return HttpContext.Current.Session["testRating"].ToString();
    }


    public string GetTestData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select * from Testimonials where DelMark=0 And ApproveFlag=1 order by TestId DESC "))
            {
                if (dttest.Rows.Count > 0)
                {
                    int counter = 1;
                    foreach (DataRow row in dttest.Rows)
                    {
                        strMarkup.Append("<div class=\"testpad mb-3\" >");
                        strMarkup.Append("<div class=\"reviewquote\">");
                        strMarkup.Append("<img src=\"images/icons/test-qoute.png\">");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("<span class=\"semiBold fontRegular colorPrime\">"+row["TestName"].ToString() +"</span>");
                        strMarkup.Append("<span class=\"space5\"></span>");
                        strMarkup.Append("<span class=\"light clrGrey\">"+row["TestLocation"].ToString()+"</span>");
                        strMarkup.Append("<span class=\"space10\"></span>");

                        if (row["TestRating"] != DBNull.Value && row["TestRating"] != null && row["TestRating"].ToString() != "")
                        {
                            switch (row["TestRating"].ToString())
                            {

                                case "1":
                                    strMarkup.Append("<img src=\"images/icons/1-star.png\"/>");
                                    break;
                                case "2":
                                    strMarkup.Append("<img src=\"images/icons/2-star.png\"/>");
                                    break;
                                case "3":
                                    strMarkup.Append("<img src=\"images/icons/3-star.png\"/>");
                                    break;
                                case "4":
                                    strMarkup.Append("<img src=\"images/icons/4-star.png\"/>");
                                    break;
                                case "5":
                                    strMarkup.Append("<img src=\"images/icons/5-star.png\"/>");
                                    break;

                            }
                        }

                        strMarkup.Append("<span class=\"space10\"></span>");
                        strMarkup.Append("<p class=\"fontRegular light line-ht-7\">"+row["TestDesc"].ToString()+"</p>");
                        if (counter < dttest.Rows.Count)
                        {
                            strMarkup.Append("<span class=\"greyLine\"></span>");
                        }
                        counter++;
                        strMarkup.Append("<span class=\"space10\"></span>");
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "No testimonials to display";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            txtName.Text = txtName.Text.Trim().Replace("'", "");
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "");
            txtCity.Text = txtCity.Text.Trim().Replace("'", "");

            txtDesc.Text = txtDesc.Text.Trim().Replace("'", "");

           
            if (txtName.Text == "" || txtEmail.Text == "" || txtCity.Text == "" || txtDesc.Text == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Marked fields are Mandatory');", true);
                return;
            }

            if (Request.Form["rating"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Please Select star rating');", true);
                    return;
                
            }

            if (c.EmailAddressCheck(txtEmail.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Email Address');", true);
                return;
            }
           

            string selecterating;
            if (Request.Form["rating"] != null)
            {
                selecterating = Request.Form["rating"].ToString();


                int MaxId = c.NextId("Testimonials", "TestId");

                c.ExecuteQuery("Insert Into Testimonials(TestId, TestDate, TestDesc, TestName, TestLocation, TestEmail, TestRating, ApproveFlag, DelMark) " +
                  " Values(" + MaxId + ", '" + DateTime.Now + "', '" + txtDesc.Text + "', '" + txtName.Text + "', '" + txtCity.Text +
                 "', '" + txtEmail.Text + "', " + selecterating + ", 0, 0)");
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Testimonials  Added');", true);


            txtName.Text = txtEmail.Text = txtDesc.Text = txtCity.Text = "";
            selecterating = "0";

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }

    }
}