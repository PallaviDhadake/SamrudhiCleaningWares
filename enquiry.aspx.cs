using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


public partial class enquiry : System.Web.UI.Page
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
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtCity.Text == "" || txtCountry.Text=="" || txtCompName.Text=="")
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


           
            StringBuilder strMail = new StringBuilder();

            strMail.Append("Dear Sir, <br/>");
            strMail.Append("You have a new Enquiry at Samruddhi Cleaning Wares, <br/>");
            strMail.Append("Details are given below, <br/><br/>");
            strMail.Append("Name : <b>" + txtName.Text + "</b> <br/>");
            strMail.Append("Email : <b>" + txtEmail.Text + "</b> <br/>");
            strMail.Append("Mobile No: <b>" + txtPhone.Text + "</b> <br/>");
            strMail.Append("Comapny Name : <b>" + txtCompName.Text + "</b> <br/>");
            strMail.Append("Address : <b>" + txtAdd.Text + "</b> <br/>");
            strMail.Append("City : <b>" + txtCity.Text + "</b> <br/>");
            strMail.Append("Country : <b>" + txtCountry.Text + "</b> <br/>");

            // strMail.Append("Resume: <b>" + fileName + "</b> <br/>");

            //c.SendMail("info@intellect-systems.com", "Ganesh Bakery Nandni", "pallavidhadake20@gmail.com", strMail.ToString(), "New Enquiry at Ganesh Bakery About Career", "", true, ""+Master.rootPath+"upload/resumes/", "fileName");

            c.SendMail("info@intellect-systems.com", " Samruddhi Cleaning Wares", "pallavidhadake20@gmail.com", strMail.ToString(), "New enquiry at  Samruddhi Cleaning Wares", "", true,"","");

            //errMsg = c.ErrNotification(1, "Thank you for your enquiry. We will contact you soon.");

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Thank you for your enquiry. We will contact you soon.');", true);

            txtName.Text = txtCountry.Text = txtCity.Text = txtEmail.Text = txtPhone.Text = txtCompName.Text = txtAdd.Text = "";
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
