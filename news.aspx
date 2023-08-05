<%@ Page Title="Latest News | Samruddhi Cleaning Ware" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <%--<span class="space150"></span>--%>
    <%--<span class="space20"></span>--%>
    <div class="pgHeader5" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container ">
                <div class="p-4">
                    <h1 class="semiBold colorSec text-uppercase">News</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">Latest News Samruddhi Cleaning Wares</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>

    <%-- News Start --%>
    <div class="container">
        <div class="p-3">
            <%--<span class="semiBold semiMedium clrdarkgrey">News</span>--%>
            <%--<span class="fontRegular regular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>
            <span class="space30"></span>

            <%=nwsstr %>

            <%--<div class="card mb-5">
                <div class="row g-0">
                    <div class="card mb-5">
                        <div class="row g-0">
                            <div class="card-header"><span class="clrGrey fst-italic">2/22/2023 12:00:00 AM</span></div>
                            <div class="p-2">
                                <div class="card-body">
                                    <blockquote class="blockquote mb-0"><a href="http://localhost:49724/news/a-well-known-quote-contained-in-a-blockquote-element-5" class="fontRegular regular mb-4 newstitle text-decoration-none">A well-known quote, contained in a blockquote element</a><footer class="blockquote-footer fontRegular light clrdarkgrey">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s<span class="space20"></span><a href="" class="linkbtn">Read More</a><span class="space10"></span></footer>
                                    </blockquote>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>

                    <div class="card mb-5">
                        <div class="row g-0">
                            <div class="col-md-4">
                                <img src="http://localhost:49724/upload/news/thumb/news-photo-422022023145515.jpg " alt="A well-known quote, contained in a blockquote element " class="img-fluid w-100 h-100"></div>
                            <div class="col-md-8">
                                <div class="card-header"><span class="clrGrey fst-italic">2/22/2023 12:00:00 AM</span></div>
                                <div class="p-2">
                                    <div class="card-body">
                                        <blockquote class="blockquote mb-0"><a href="http://localhost:49724/news/a-well-known-quote-contained-in-a-blockquote-element-4" class="fontRegular regular mb-4 newstitle text-decoration-none">A well-known quote, contained in a blockquote element</a><footer class="blockquote-footer fontRegular light clrdarkgrey">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s<span class="space20"></span><a href="" class="linkbtn">Read More</a><span class="space10"></span></footer>
                                        </blockquote>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card mb-5">
                        <div class="row g-0">
                            <div class="col-md-4">
                                <img src="http://localhost:49724/upload/news/thumb/news-photo-208022023165700.jpg " alt="It is a long established fact that a reader will be distracted by the " class="img-fluid w-100 h-100"></div>
                            <div class="col-md-8">
                                <div class="card-header"><span class="clrGrey fst-italic">2/8/2023 12:00:00 AM</span></div>
                                <div class="p-2">
                                    <div class="card-body">
                                        <blockquote class="blockquote mb-0"><a href="http://localhost:49724/news/it-is-a-long-established-fact-that-a-reader-will-be-distracted-by-the-2" class="fontRegular regular mb-4 newstitle text-decoration-none">It is a long established fact that a reader will be distracted by the</a><footer class="blockquote-footer fontRegular light clrdarkgrey">It is a long established fact that a reader will be distracted by the<span class="space20"></span><a href="" class="linkbtn">Read More</a><span class="space10"></span></footer>
                                        </blockquote>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>




















           <%-- <div class="card mb-5">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img src="images/window-cleaning.jpg" class="img-fluid w-100 h-100" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-header">
                            <span class="clrGrey fst-italic">13/02/2023</span>
                        </div>
                        <div class="card-body">
                            <blockquote class="blockquote mb-0">
                                <p class="fontRegular regular mb-4 newstitle">A well-known quote, contained in a blockquote element.</p>
                                <footer class="blockquote-footer fontRegular light">
                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting.
                                    <span class="space20"></span>
                                    <a href="#" class="linkbtn">Read More</a>
                                    <span class="space10"></span>
                                </footer>
                            </blockquote>
                        </div>
                    </div>
                </div>
            </div>--%>

            <%--<div class="card mb-5">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img src="images/pg-header-1.jpg" class="img-fluid w-100 h-100" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-header">
                            <span class="clrGrey fst-italic">13/02/2023</span>
                        </div>
                        <div class="p-2">
                            <div class="card-body">
                                <blockquote class="blockquote mb-0">
                                    <p class="fontRegular regular mb-4 newstitle">A well-known quote, contained in a blockquote element.</p>
                                    <footer class="blockquote-footer fontRegular light clrdarkgrey">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting.
                                    <span class="space20"></span>
                                        <a href="#" class="linkbtn">Read More</a>
                                        <span class="space10"></span>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="card mb-5">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img src="images/pg-header-1.jpg" class="img-fluid w-100 h-100" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-header">
                            <span class="clrGrey fst-italic">13/02/2023</span>
                        </div>
                        <div class="p-2">
                            <div class="card-body">
                                <blockquote class="blockquote mb-0">
                                    <p class="fontRegular regular mb-4 newstitle">A well-known quote, contained in a blockquote element.</p>
                                    <footer class="blockquote-footer fontRegular light clrdarkgrey">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. lectronic typesetting.
                                    <span class="space20"></span>
                                        <a href="#" class="linkbtn">Read More</a>
                                        <span class="space10"></span>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="card mb-5">
                <div class="row g-0">
                        <div class="card-header">
                            <span class="clrGrey fst-italic">13/02/2023</span>
                        </div>
                        <div class="p-2">
                            <div class="card-body">
                                <blockquote class="blockquote mb-0">
                                    <p class="fontRegular regular mb-4 newstitle">A well-known quote, contained in a blockquote element.</p>
                                    <footer class="blockquote-footer fontRegular light clrdarkgrey">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting.
                                    <span class="space20"></span>
                                        <a href="#" class="linkbtn">Read More</a>
                                        <span class="space10"></span>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                </div>
            </div>--%>

        </div>
    </div>
    <%-- News End --%>
    <span class="space30"></span>
</asp:Content>

