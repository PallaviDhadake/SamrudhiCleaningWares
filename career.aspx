<%@ Page Title="Career | Samrudhhi Cleaning Ware" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="career.aspx.cs" Inherits="career" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader4" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="semiBold colorSec text-uppercase">Career</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">We Are Hiring, Join Our Team</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space50"></span>

    <div class="container">
        <%--<span class="semiBold semiMedium clrdarkgrey">Grow with us</span>--%>
        <span class="space30"></span>
      <%--  <span class="fontRegular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>
        <%--<span class="space60"></span>--%>
        <div class="row">
             <div class="col-md-6">
                 <div class="">
                <img src="images/career.png" class="img-fluid w-100" />
                 </div>
            </div>
            <div class="col-md-6">
                <div class="py-3">
                    <span class="space30"></span>
                    <h5 class="semiBold large clrGrey line-ht-5">Having <span class="colorSec">Access</span> To<br />
                        Life Long <span class=" colorSec">Career</span></h5>
                    <span class="space15"></span>
                    <p class="fontRegular light clrdarkgrey mb-4">Success is inevitable for those who dream big and aim high. We at Samruddhi Group have always believed in broader imaginations and better innovations. As a group we have always adhered to our ethos of ingrained value systems</p>
                    <span class="space10"></span>
                    <%--<a href="#" class="buttonForm text-decoration-none">Send Details</a>--%>
                </div>
            </div>
           
            <span class="space30"></span>
            <div class="col-md-10">
                <span class="clrdarkgrey semiBold semiMedium">Fill the form for better future</span>
                <span class="space20"></span>
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtName" class="conTextBox" placeholder="Full Name *" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtEmail" class="conTextBox" placeholder="Email *" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtPhone" class="conTextBox" MaxLength="10" placeholder="Mobile No *" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txteduc" class="conTextBox" placeholder="Education *" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-row">
                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtexp" class="conTextBox" MaxLength="3" placeholder="Experiance " runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <span class="space20"></span>

                        <div class="form-group col-md-6">
                            <label for="inputEmail4" class="light">Upload Resume:*</label>
                            <asp:FileUpload ID="fuResume" runat="server" CssClass="" />
                        </div>

                        <%--<div class="form-group">
                            <asp:TextBox ID="txtMsg" class="conTextBox" TextMode="MultiLine" Height="150" placeholder="Message *" runat="server"></asp:TextBox>
                        </div>--%>
                        <span class="space30"></span>
                        <asp:Button ID="btnSubmit" CssClass="buttonForm text-uppercase" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    <span class="space30"></span>
</asp:Content>

