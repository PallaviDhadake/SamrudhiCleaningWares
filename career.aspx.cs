using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class career : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSubmit.Attributes.Add("onclick", "this.disabled=true; this.value='Processing...';" + ClientScript.GetPostBackEventReference(btnSubmit, null) + ";");
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txteduc.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * marked fields are mandatory');", true);
                return;
            }

            if (c.EmailAddressCheck(txtEmail.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Email Address');", true);
                return;
            }
            if (c.ValidateMobile(txtPhone.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Mobile No.');", true);
                return;
            }


            string fileName = "";
            if (fuResume.HasFile)
            {
                string fExt = Path.GetExtension(fuResume.FileName).ToString().ToLower();
                if (fExt == ".doc" || fExt == ".pdf" || fExt == ".txt")
                {
                    fileName = "Resume" + " " + txtName.Text + fExt;
                    fuResume.SaveAs(Server.MapPath("~/upload/Resume/") + fileName);


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .doc, .pdf, .txt files are allowed');", true);
                    //errMsg = c.ErrNotification(2, "Only .doc, .pdf, .txt files are allowed");
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Please Select Resume To Upload');", true);
                return;
            }


            string resumepath = Server.MapPath("upload/Resume/") + fileName;
            //string resumepath = "upload/resumes/";

            StringBuilder strMail = new StringBuilder();

            strMail.Append("Dear Sir, <br/>");
            strMail.Append("You have a new Enquiry at Samruddhi Cleaning Wares, <br/>");
            strMail.Append("Details are given below, <br/><br/>");
            strMail.Append("Name : <b>" + txtName.Text + "</b> <br/>");
            strMail.Append("Email : <b>" + txtEmail.Text + "</b> <br/>");
            strMail.Append("Mobile No: <b>" + txtPhone.Text + "</b> <br/>");
            strMail.Append("Education : <b>" + txteduc.Text + "</b> <br/>");
            strMail.Append("Experiance : <b>" + txtexp.Text + "</b> <br/>");

            // strMail.Append("Resume: <b>" + fileName + "</b> <br/>");

            //c.SendMail("info@intellect-systems.com", "Ganesh Bakery Nandni", "pallavidhadake20@gmail.com", strMail.ToString(), "New Enquiry at Ganesh Bakery About Career", "", true, ""+Master.rootPath+"upload/resumes/", "fileName");

            c.SendMail("info@intellect-systems.com", " Samruddhi Cleaning Wares", "pallavidhadake20@gmail.com", strMail.ToString(), "New Application at  Samruddhi Cleaning Wares", "", true, resumepath, fileName);

            //errMsg = c.ErrNotification(1, "Thank you for your enquiry. We will contact you soon.");

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Thank you for your Application. We will contact you soon.');", true);

            txtName.Text = txtexp.Text = txteduc.Text = txtEmail.Text = txtPhone.Text = "";
            //ddrDept.SelectedIndex = ddrSupOrp.SelectedIndex = 0;
            //errMsg = c.ErrNotification(1, "Thank you for your Feedback..!! We'll get back to you soon..!!");

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSubmit_Click", ex.Message.ToString());
            return;
        }
    }

}
