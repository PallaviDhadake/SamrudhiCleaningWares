<%@ Page Title="" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCvO0AHfg1cuND1KXbw3t5xZr5p4PVrEk4">
    </script>
    <script type="text/javascript">
        function initialize() {

            var myLatlng = new google.maps.LatLng(16.850027375216158, 74.60324208139164);

            var mapOptions = {
                center: myLatlng,
                zoom: 18, scrollwheel: false, draggable: true,
            };

            var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
            var autoqed = {
                path: 'M95.35,50.645c0,13.98-11.389,25.322-25.438,25.322c-14.051,0-25.438-11.342-25.438-25.322   c0-13.984,11.389-25.322,25.438-25.322C83.964,25.322,95.35,36.66,95.35,50.645 M121.743,50.645C121.743,22.674,98.966,0,70.866,0   C42.768,0,19.989,22.674,19.989,50.645c0,12.298,4.408,23.574,11.733,32.345l39.188,56.283l39.761-57.104   c1.428-1.779,2.736-3.654,3.916-5.625l0.402-0.574h-0.066C119.253,68.516,121.743,59.874,121.743,50.645',
                fillColor: '#76c04e',
                fillOpacity: 1,
                scale: 0.3
            };
            var marker = new google.maps.Marker({
                position: myLatlng,
                icon: autoqed,
                map: map,
                title: "SAMRUDDHI CLEANING WARES",
                animation: google.maps.Animation.DROP
            });
            //alert("test");
            marker.addListener('click', toggleBounce);
            function toggleBounce() {
                if (marker.getAnimation() !== null) {
                    marker.setAnimation(null);
                } else {
                    marker.setAnimation(google.maps.Animation.BOUNCE);
                }
            }
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>

    <style>
        #map-canvas {
            height: 350px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader8" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="semiBold colorSec text-uppercase">Contact Us</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">Contact With Us</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>

    <%-- Contact us start --%>
    <div class="container">

        <%--<h2 class="semiBold mb-2">Get in touch with us</h2>--%>
        <%--<span class="fontRegular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>
    </div>
    <span class="space30"></span>

    <div id="map-canvas"></div>

    <span class="space60"></span>
    <div class="container">
        <div class="row gy-4">
            <div class="col-md-4 position-relative">
                <div class="">
                    <div class="border">
                        <div class="p-2">
                            <div class="themeBGSec shadow">
                                <div class="p-2">
                                    <span class="semiBold semiMedium text-white">Address</span>
                                </div>
                            </div>
                            <span class="space30"></span>
                            <span class="con-addr line-ht-5 fontRegular"><span class="semiBold colorBlack">Corporate Office: </span>Plot No. A-1, Samruddhi Park Behind Chintamanrao College Opp. Vishrambag Railway Sattion Sangli , Maharashtra 416 415.</span>
                            <span class="space15"></span>

                            <span class="con-addr line-ht-5 fontRegular"><span class="semiBold colorBlack">Regd Office: </span>198-3, Jaysingpur, Tal. Shirol, Dist. Kolhapur, Maharashtra 416415</span>
                            <span class="space15"></span>

                            <span class="con-addr line-ht-5 fontRegular"><span class="semiBold colorBlack">Manufacturing Unit: </span>
                                <span class="space10"></span>
                                <span class="semiBold">SAMADHAN INDUSTRIES LLP</span><br />
                                L1: GAT No-69; Hatkanangale Vadgaon Road Birdevwadi Tal - Hatkanangale Dist - Kolhapur Mh 416109
                                <span class="space15"></span>
                                <span class="semiBold">WARE HOUSE</span><br />
                                L2 :-GAT NO-150/1, at Post: Laxmiwadi, Tal - Hatkanangale, Dist - Kolhapur, MH Pin Code- 416109 L3:- D-12/2, Miraj MIDC, Miraj - 416410</span>

                         <%--   <span class=""><span class="semiBold colorBlack"></span>
                                <span class="space10"></span>
                                --%>

                            <span class="space30"></span>
                        </div>
                    </div>
                </div> 
            </div>
            <div class="col-md-4 position-relative">
                <div class="">
                    <div class="border">
                        <div class="p-2">
                            <div class="themeBGSec">
                                <div class="p-2">
                                    <span class="semiBold semiMedium text-white">Email</span>
                                </div>
                            </div>
                            <span class="space30"></span>
                            <a href="#" class="con-email line-ht-5 fontRegular ">info&#64samruddhicleaningware&#46com</a>
                            <span class="space30"></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 position-relative">
                <div class="">
                    <div class="border">
                        <div class="p-2">
                            <div class="themeBGSec">
                                <div class="p-2">
                                    <span class="semiBold semiMedium text-white">Contact No</span>
                                </div>
                            </div>
                            <span class="space30"></span>
                            <a href="tel:+919209033650" class="con_call line-ht-5 fontRegular txtDecNone">+91 9209033650</a>
                            <span class="space30"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Contact us end --%>
    <span class="space30"></span>
</asp:Content>

