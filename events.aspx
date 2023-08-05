<%@ Page Title="Events Gallery | Samruddhi Cleaning Wares" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="events.aspx.cs" Inherits="events" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Page Header Starts -->
    <div class="pgHeader6" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="semiBold colorSec text-uppercase">Events & Gallery</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">Celebriting Events At Samruddhi Cleaning Ware</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>


    <%-- Events gallery start --%>
    <div class="container">
        <div class="p-3">
            <%--<span class="semiBold semiMedium clrdarkgrey">Events</span>--%>
            <%--<span class="fontRegular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>
            <span class="space30"></span>
            <div class="row gy-2">
                <%=evntstr %>

  <%--              <div class="col-md-4">
                    <img src="images/floor-cleaning.jpg"  class="img-fluid w-100"/>
                </div>
                <div class="col-md-8">
                    <h3 class="semiBold semiMedium colorPrime eventtitle">Samruddhi Cleaning Wares 3rd Anniversary</h3>
                    <span class="space5"></span>
                    <span class="clrGrey small fst-italic">14/02/2023</span>
                    <p class="fontRegular light  line-ht-7 mt-3 mb-4">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                    <a href="#" class="btnexplore">Explore</a>
                </div>
                 <span class="greyLine"></span>

                <div class="col-md-4">
                    <img src="images/floor-cleaning.jpg"  class="img-fluid w-100"/>
                </div>
                <div class="col-md-8">
                    <h3 class="semiBold semiMedium colorPrime eventtitle">Samruddhi Cleaning Wares 3rd Anniversary</h3>
                    <span class="space5"></span>
                    <span class="clrGrey small fst-italic">14/02/2023</span>
                    <p class="fontRegular light  line-ht-7 mt-3 mb-4">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                    <a href="#" class="btnexplore">Explore</a>
                </div>
                 <span class="greyLine"></span>

                <div class="col-md-4">
                    <img src="images/floor-cleaning.jpg"  class="img-fluid w-100"/>
                </div>
                <div class="col-md-8">
                    <h3 class="semiBold semiMedium colorPrime eventtitle">Samruddhi Cleaning Wares 3rd Anniversary</h3>
                    <span class="space5"></span>
                    <span class="clrGrey small fst-italic">14/02/2023</span>
                    <p class="fontRegular light  line-ht-7 mt-3 mb-4">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                    <a href="#" class="btnexplore">Explore</a>
                </div>--%>
             
            </div>

        </div>
    </div>
    <%-- Events gallery end --%>
    <span class="space30"></span>
</asp:Content>

