<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="product-category.aspx.cs" Inherits="product_category" %>

<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .prodcatname{}
        .prodcatname:hover{color:#0094ff}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader7" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="semiBold colorSec text-uppercase">Products Category</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">Our Products Category</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>
    <div class="container text-center ">
        <%--<h2 class="semiBold mb-1">Enquiry</h2>--%>
        <%--<span class="fontRegular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>

        <span class="space30"></span>
        <div class="row">
            <%=prodcatstr %>
            <%--<div class="col-md-3">
                <div class="p-2">
                    <div class="border">
                        <img src="images/broom-1.jpg" class="img-fluid mb-2" />
                    </div>

                    <div class="border">
                        <div class="p-2">
                            <span class="fontRegular clrdarkgrey regular">Broom</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="p-2">
                    <div class="border">
                        <img src="images/broom-1.jpg" class="img-fluid mb-2" />
                    </div>

                    <div class="border">
                        <div class="p-2">
                            <span class="fontRegular clrdarkgrey regular">Broom</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="p-2">
                    <div class="border">
                        <img src="images/broom-1.jpg" class="img-fluid mb-2" />
                    </div>

                    <div class="border">
                        <div class="p-2">
                            <span class="fontRegular clrdarkgrey regular">Broom</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="p-2">
                    <div class="border">
                        <img src="images/broom-1.jpg" class="img-fluid mb-2" />
                    </div>

                    <div class="border">
                        <div class="p-2">
                            <span class="fontRegular clrdarkgrey regular">Broom</span>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
    <span class="space30"></span>

</asp:Content>

