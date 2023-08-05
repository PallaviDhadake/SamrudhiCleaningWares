<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <title>Samruddhi Cleaning Ware</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Font Roboto -->
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700&family=Varela+Round&display=swap" rel="stylesheet" />

    <!-- Bootstrap -->
    <link href="Vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- aos -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet"/>
    <script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>

    <!-- Swiper slider -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>

    <!--Animate Css  -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />

    <!-- Main Css -->
    <link href="css/samruddhi.css" rel="stylesheet" />
    
</head>
<body>
     <!-- Navigation Starts -->
    <section id="navrbar">
        <div class="header">
            <div class="p-1">
                <div class="container-fluid">
                    <div class="socialBox">
                        <a href="#" target="_blank" class="topFb" title="Follow Us on facebook"></a>
                        <a href="#" target="_blank" class="topInsta" title="Follow Us on Instagram"></a>
                        <a href="#" target="_blank" class="topyouTube" title="Follow Us on Youtube"></a>
                    </div>
                    <a href="tel:+919209033650" class="colorWhite text-decoration-none">+91 9209 03 3650</a>
                </div>
            </div>
        </div>
        <div id="navigationBar">
            <div class="container-fluid">
                <nav class="navbar navbar-expand-xl m-0 p-0">
                    <div class="container-fluid m-0 p-0">
                        <a class="navbar-brand" href="#">
                            <%--<img alt="" src="images/samruddhi-logo.png" class="lg me-3" />--%>
                            <img alt="" src="images/samruddhi-logo.png" class="samruddhilogo me-3" />
                            <img alt="" src="images/samrudhhi-lg-name.png" class="lgName" />
                            <%--<img alt="" src="images/samrudhhi-lg-name.png" class="lgName" />--%>
                        </a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                            <img src="images/icons/social/nav-btn-color.png" />
                        </button>
                        <div class="collapse navbar-collapse" id="navbarNavDropdown">
                            <!-- Navigation starts -->
                            <ul class="navbar-nav ms-auto">
                                <li class="nav-item">
                                    <a class="nav-link" aria-current="page" href="#">Home</a>
                                </li>

                                <li class="nav-item dropdown">
                                    <a class="nav-link subnav" data-toggle="dropdown" aria-current="page" href="#">About</a>
                                    <ul class="dropdown-menu ">
                                        <li>
                                            <a class="dropdown-item" href="about-us">Company Profile</a>
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="testimonials">Reviews</a>
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="news">News</a>
                                        </li>
                                </ul>
                                </li>

                                <li class="nav-item dropdown">
                                    <a href="our-products" class=" nav-link subnav" data-toggle="dropdown">Products <b class="caret"></b></a>
                                    <ul class="dropdown-menu multi-column columns-2">
                                        <div class="row">
                                            <%=submenu %>
                                         <%--   <div class="col-sm-6">
                                                <ul class="multi-column-dropdown">
                                                    <li><a href="#">Brooms</a></li>
                                                    <li><a href="#">Mop</a></li>
                                                    <li><a href="#">Brush</a></li>
                                                    <li><a href="#">Wiper</a></li>
                                                    <li><a href="#">Spare Accessories</a></li>
                                                </ul>
                                            </div>
                                            <div class="col-sm-6">
                                                <ul class="multi-column-dropdown">
                                                    <li><a href="#">Brooms</a></li>
                                                    <li><a href="#">Mop</a></li>
                                                    <li><a href="#">Brush</a></li>
                                                    <li><a href="#">Wiper</a></li>
                                                    <li><a href="#">Spare Accessories</a></li>
                                                </ul>
                                            </div>--%>
                                        </div>
                                    </ul>
                                </li>
                                <%--<li class="nav-item">
                                    <a class="nav-link" href="testimonials">Review</a>
                                </li>--%>
                               <%-- <li class="nav-item">
                                    <a class="nav-link" href="#">Market</a>
                                </li>--%>


                                <li class="nav-item dropdown">
                                <a class="nav-link subnav" role="button" href="#" id="navbarNavDropdown" data-bs-toggle="dropdown" aria-expanded="false">
                                    Gallery & Events
                                </a>
                                <ul class="dropdown-menu" aria-labelledby="navbarNavDropdown">
                                   <li>
                                        <a class="dropdown-item" href="#">
                                            Images &raquo;
                                        </a>
                                        <ul class="dropdown-menu dropdown-submenu">
                                            <%=evntcatstr %>
                                            <%--<li>
                                                <a class="dropdown-item" href="#">Awards & Recognition</a>
                                            </li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li>
                                                <a class="dropdown-item" href="#">Press News</a>
                                            </li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li>
                                                <a class="dropdown-item" href="#">Samruddhi Meet</a>
                                            </li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li>
                                                <a class="dropdown-item" href="#">Tour Samruddhi</a>
                                            </li>--%>
                                        </ul>
                                    </li>
                                   <%-- <li>
                                        <hr class="dropdown-divider">
                                    </li>--%>
                                    <li>
                                        <a class="dropdown-item" href="#">
                                            Videos &raquo;
                                        </a>
                                        <ul class="dropdown-menu dropdown-submenu">
                                            <%=evntvid %>
                                           <%-- <li>
                                                <a class="dropdown-item" href="#">Products videos</a>
                                            </li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li>
                                                <a class="dropdown-item" href="#">Exhibition videos</a>
                                            </li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li>
                                                <a class="dropdown-item" href="#">Other videos</a>
                                            </li>--%>
                                        </ul>
                                    </li>
                                </ul>
                            </li>

                               <%-- <li class="nav-item">
                                    <a class="nav-link" href="events-gallery">Gallery & Events</a>
                                </li>--%>

                                <li class="nav-item dropdown">
                                    <a class="nav-link subnav" data-toggle="dropdown" aria-current="page" href="#">Distributor</a>
                                    <ul class="dropdown-menu ">
                                        <li>
                                            <a class="dropdown-item" href="#">Locate Us</a>
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="enquiry">Enquiry</a>
                                        </li>
                                    </ul>
                                </li>

                               <%-- <li class="nav-item">
                                    <a class="nav-link" href="enquiry">Enquiry</a>
                                </li>--%>
                                <li class="nav-item">
                                    <a class="nav-link" href="career">Career</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="contact-us">Contact Us</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </div>
    </section>
    <!-- Navigations End -->

    <!-- banner start -->
    <section id="banner">
        <!--<span class="space80"></span>
        <span class="space60"></span>-->
        <div class="">
            <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                <div class="">
                    <%=bannerstr %>
                    <%--<div class="carousel-inner">--%>
                       <%-- <div class="carousel-item active">
                            <img src="images/banner-1.jpg" class="img-fluid w-100" />
                            <div class="banneroverly">
                                <div class="container">
                                    <div class="row d-flex align-items-center justify-content-center bannerht">
                                        <div class="col-2">
                                            <img src="images/gini-mini.png" class="img-fluid gini" />
                                        </div>
                                        <div class="col-10">
                                            <span class="bold xxx-large colorWhite">Gini Super Spin Mop</span><br />
                                            <span class="space20"></span>                                            <span class="light regular colorWhite">Spin mops have circular microfiber heads that help clean your floors and other hard-to-reach areas and come with mop buckets.</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <%--<div class="carousel-item">
                            <img src="images/banner-2.jpg" class="img-sfluid w-100" />
                            <div class="banneroverly">
                                <div class="container">
                                    <div class="row  d-flex align-items-center justify-content-center bannerht">
                                        <div class="col-2">
                                            <img src="images/gini-mini.png" class="img-fluid gini" />
                                        </div>
                                        <div class="col-10">
                                            <span class="bold xxx-large colorWhite">Cotton & Sponge Wipee</span><br />
                                            <span class="space20"></span>                                            <span class="light regular colorWhite">It is a 3-in-1 cleaning tool for convenient and efficient cleaning. Microfiber with super absorbency removes dirt and dust. </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <%--<div class="carousel-item">
                            <img src="images/banner-3.jpg" class="img-sfluid w-100" />
                            <div class="banneroverly">
                                <div class="container">
                                    <div class="row  d-flex align-items-center justify-content-center bannerht">
                                        <div class="col-2">
                                            <img src="images/gini-mini.png" class="img-fluid gini" />
                                        </div>
                                        <div class="col-10">
                                            <span class="bold xxx-large colorWhite">Carpet Brush Magic <br /></span><br />
                                            <span class="space20"></span>                                            <span class="light regular colorWhite">Handy Carpet cleaning brush for cleaning house carpets, car carpets and household upholstery.</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    <%--</div>--%>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                        <img src="images/previous.png" />
                        <!--<span class="carousel-control-prev-icon" aria-hidden="true"></span>-->
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                        <img src="images/next.png" />
                        <!--<span class="carousel-control-next-icon" aria-hidden="true"></span>-->
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
        </div>
    </section>
    <!-- banner end -->

    <!-- About Us strat -->
    <section id="about">
        <span class="space80"></span>
        <div class="container text-center gy-" data-aos="fade-right" data-aos-duration="1000">
            <h2 class="colorPrime semiBold mb-3">About Samruddhi Cleaning Ware</h2>
            <img src="images/samruddhi-logo-small.png" class="img-fluid mb-3" />
            <%--<span class="space10"></span>--%>
            <p class="clrdarkgrey light line-ht-5">
                <span class="font-weight-bold">Samruddhi Cleaning Ware</span> is one of the renowned manufactures in the  reflecting quality through its products. We manufacture a wide range of products which are distributed under the brand name, Samruddhi Cleaning Ware.
                The company is strategically located near Sangli city, Maharashtra India. Our company’s superior quality products have always attracted tremendous market appeal due to our competitive edge in new product development, modern designs and vast market network. Our topmost priority is customer satisfaction by providing variety, quality and range of products which has distinct utility, class and performance.
            </p>
        </div>
    </section>
     <!-- About Us End -->

    <!-- category start -->
    <section id="services">
        <div class="container-xxl py-5">
            <div class="container pt-5 text-center">
                <h2 class="colorPrime semiBold">Check Out The Most Popular Categories</h2>
                <span class="mb-4 fontRegular regular clrdarkgrey">We Focused On Modern products that users need</span>
                <span class="space80"></span>
                <div class="row">
                    <%=prodcat %>
                    <%--<div class="col-xl-3 col-lg-6 col-md-6 text-center" data-aos="fade-left" data-aos-duration="10">
                        <div class="p-2">
                            <div class="servericeBorder">
                                <div class="p-4">
                                    <div class="servimg mb-5">
                                        <img src="images/samruddhi-broom.jpeg" class="img-fluid servimg" />
                                        
                                    </div>
                                    <h2 class="semiBold semiMedium mb-4">No Dust Brooms</h2>
                                    <p class="clrdarkgrey light line-ht-5">Lorem ipsum dolor sit amet, consectetur adipiscing.</p>
                                    <a href="#"><img src="images/icons/next.png" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-md-6" data-aos="fade-right" data-aos-duration="900">
                        <div class="p-2">
                            <div class="servericeBorder">
                                <div class="p-4">
                                    <div class="servimg mb-5">
                                        <img src="images/samruddhi-brush.jpeg" class="img-fluid servimg" />
                                        
                                    </div>
                                    <h2 class="semiBold semiMedium mb-4">Cloth Brush</h2>
                                    <p class="clrdarkgrey light line-ht-5">Lorem ipsum dolor sit amet, consectetur adipiscing.</p>
                                    <a href="#"><img src="images/icons/next.png" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-md-6" data-aos="fade-up" data-aos-duration="800">
                        <div class="p-2">
                            <div class="servericeBorder">
                                <div class="p-4">
                                    <div class="servimg mb-5">
                                        <img src="images/brush-toilate.png" class="img-fluid servimg" />
                                        
                                    </div>
                                    <h2 class="semiBold semiMedium mb-4">Toilate Brush</h2>
                                    <p class="clrdarkgrey light line-ht-5">Lorem ipsum dolor sit amet, consectetur adipiscing.</p>
                                    <a href="#"><img src="images/icons/next.png" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-md-6" data-aos="fade-down" data-aos-duration="600">
                        <div class="p-2">
                            <div class="servericeBorder">
                                <div class="p-4">
                                    <div class="servimg mb-5">
                                        <img src="images/samruddhi-spinner-buket.jpeg" class="img-fluid servimg" />
                                       
                                    </div>
                                    <h2 class="semiBold semiMedium mb-4">Spin Bucket</h2>
                                    <p class="clrdarkgrey light line-ht-5">Lorem ipsum dolor sit amet, consectetur adipiscing.</p>
                                    <a href="#"><img src="images/icons/next.png" /></a>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </section>
    <!-- category end -->
   
    <!-- features start -->
    <section id="fetures">
        <span class="space40"></span>
        <div class="container" data-aos="fade-right" data-aos-duration="1000">
            <div class="p-3">
                <div class="row">
                    <span class="clrdarkgrey semiMedium semiBold text-uppercase">Our Features</span>
                    <span class="space15"></span>
                    <span class="semiBold medium colorPrime text-uppercase">Explore samruddhi cleaning ware</span>
                    <span class="space20"></span>

                    <p class="clrdarkgrey light line-ht-5">Our dream and dreams of every person associated with us have taken wings and flown higher and beyond the skies. Today, the success of our Group stands testimony to our values, dreams, imaginations and innovations.</p>
                </div>
            </div>
        </div>
    </section>
    <span class="space60"></span>
     <!-- features end -->


    <!-- Product  Start -->
    <section id="product" class="" data-aos="fade-up" data-aos-duration="1000">
        <div class="bgproduct">
            <div class="">
                <div class="container">
                    <span class="space40"></span>
                    <h1 class="semiBold medium section-title-pro mb-3">Our Popular Products</h1>
                    <span class="space60"></span>
                    <div class="">
                        <div class="swiper mySwiper">
                            <div class="swiper-wrapper">
                                <%=prodstr %>
                                <%--<div class="swiper-slide position-relative" data-aos="zoom-in" data-aos-duration="1000">
                                    <img src="images/products/toilate-brushes.png" />
                                    <div class="productbx">
                                        <span>Brush</span>
                                    </div>
                                </div>
                                <div class="swiper-slide position-relative" data-aos="zoom-in" data-aos-duration="1000">
                                    <img src="images/products/Jet-Spin-Mop-s.jpg" />
                                    <div class="productbx">
                                        <span>Mop</span>
                                    </div>
                                </div>--%>
                            </div>
                            
                            <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                        </div>
                    </div>
                </div>
                <span class="space40"></span>
                <div class="text-center">
                    <a href="#" class="btnquote">View More</a>
                </div>
            </div>
            <span class="space60"></span>
        </div>
    </section>
    <span class="space60"></span>
    <!--products end-->

    <!--news start-->
    <section id="news">
        <div class="container">
            <div class="p-3">
                <div class="text-center">
                    <h2 class="colorPrime semiBold">News</h2>
                    <span class="space10"></span>
                </div>
                <div class="row">
                    <%=GetNewsData() %>

                    <%--<div class="col-lg-4" data-aos="fade-right" data-aos-duration="1000">
                        <div class="p-4">
                            <a class="clrdarkgrey semiBold nwstitle semiMedium">Lorem ipsum dolor sit amet, consectetur</a>
                            <span class="space10"></span>
                            <span class="clrdarkgrey small">05/02/2023</span>
                            <hr />
                            <span class="space15"></span>
                            <p class="clrdarkgrey light fontRegular line-ht-5 mb-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur iaculis rutrum metus, ut posuere neque. Fusce faucibus ex non justo pharetra tempus. Integer quam nibh molestie eleifend</p>
                            <a href="#" class="nwsbtn"><img src="images/icons/right-arrow.png" /></a>
                        </div>
                    </div>
                    <div class="col-lg-4" data-aos="fade-up" data-aos-duration="1000">
                        <div class="p-4">
                            <a class="clrdarkgrey semiBold nwstitle semiMedium">Lorem ipsum dolor sit amet, consectetur</a>
                            <span class="space10"></span>
                            <span class="clrdarkgrey small">05/02/2023</span>
                            <hr />
                            <span class="space15"></span>
                            <p class="clrdarkgrey light fontRegular line-ht-5 mb-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur iaculis rutrum metus, ut posuere neque. Fusce faucibus ex non justo pharetra tempus. Integer quam nibh molestie eleifend</p>
                            <a href="#" class="nwsbtn"><img src="images/icons/right-arrow.png" /></a>
                        </div>
                    </div>
                    <div class="col-lg-4" data-aos="fade-left" data-aos-duration="1000">
                        <div class="p-4">
                            <a class="clrdarkgrey semiBold nwstitle semiMedium">Lorem ipsum dolor sit amet, consectetur</a>
                            <span class="space10"></span>
                            <span class="clrdarkgrey small">05/02/2023</span>
                            <hr />
                            <span class="space15"></span>
                            <p class="clrdarkgrey light fontRegular line-ht-5 mb-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur iaculis rutrum metus, ut posuere neque. Fusce faucibus ex non justo pharetra tempus. Integer quam nibh molestie eleifend</p>
                            <a href="#" class="nwsbtn"><img src="images/icons/right-arrow.png" /></a>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="text-center">
                <a href="news" class="nwsmorebtn">More News</a>
            </div>
            <span class="space10"></span>
        </div>
    </section>
    <span class="space60"></span>
    <!--news end-->

    <!--events start-->
    <section id="event" >
        <div class="container" data-aos="fade-left" data-aos-duration="1000">
            <div class="text-center">
                <h2 class="colorPrime semiBold">Events & Gallery</h2>
                <span class="space10"></span>
                <span class="clrdarkgrey fontRegular line-ht-5">Lorem ipsum dolor sit amet, consectetur adipiscing elit</span>
                <span class="space30"></span>
            </div>
            <div class="p-3">
                <div class="row g-0">
                    <%=evntstr %>
              <%--      <div class="col-lg-6 themeBGThr d-flex align-items-center justify-content-center">
                        <div class="p-5">
                            <span class="fontRegular">Events</span>
                            <span class="space10"></span>
                            <span class="semiBold semiMedium">Lorem ipsum dolor sit amet, consectetur</span>
                            <span class="space10"></span>
                            <span class="fst-italic fontRegular">06/03/2023</span>
                            <p class="mt-4 mb-5 fontRegular light line-ht-5">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur iaculis rutrum metus, ut posuere neque. Fusce faucibus ex non justo pharetra tempus. Integer quam nibh molestie eleifend</p>
                            <a href="#" class="btnEvent">View Event</a>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="swiper mySwiper3">
                            <div class="swiper-wrapper">
                                <div class="swiper-slide"><img src="images/products/project-img-3.jpg" /></div>
                                <div class="swiper-slide"><img src="images/products/project-img-4.jpg" /></div>
                                <div class="swiper-slide"><img src="images/products/project-img-5.jpg" /></div>
                                <div class="swiper-slide"><img src="images/products/project-8.jpeg" /></div>
                                <div class="swiper-slide"><img src="images/products/project-img-5.jpg" /></div>
                                <div class="swiper-slide"><img src="images/products/project-8.jpeg" /></div>
                            </div>
                            <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </section>
    <span class="space60"></span>
    <!--events end-->

    <!-- Testimonials Start -->
    <section id="testimonials" data-aos="fade-down" data-aos-duration="1000">
        <div class="bgTestimonial">
            <div class="blackOverlay">
                <span class="space60"></span>
                <div class="container">
                    <div class="p-2">
                        <h1 class="semiBold large section-title mb-3 colorWhite">What People Say</h1>
                        <span class="space30"></span>
                        <div class="row gx-5 gy-4">
                            <%=GetTestData() %>
                            <%--<div class="col-lg-4">
                                <div class="testboxinfo">
                                    <div class="p-4">
                                        <span class="semiBold semiMedium colorWhite">Pallavi Dhadake</span>
                                        <span class="space5"></span>
                                        <span class="fontRegular colorWhite">Sangli</span>
                                        <span class="space20"></span>
                                        <p class="fontRegular light line-ht-5 colorWhite"> &#8220; Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. &#8222; </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="testboxinfo">
                                    <div class="p-4">
                                        <span class="semiBold semiMedium colorWhite">Pallavi Dhadake</span>
                                        <span class="space5"></span>
                                        <span class="fontRegular colorWhite">Sangli</span>
                                        <span class="space20"></span>
                                        <p class="fontRegular light line-ht-5 colorWhite"> &#8220; Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. &#8222; </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="testboxinfo">
                                    <div class="p-4">
                                        <span class="semiBold semiMedium colorWhite">Pallavi Dhadake</span>
                                        <span class="space5"></span>
                                        <span class="fontRegular colorWhite">Sangli</span>
                                        <span class="space20"></span>
                                        <p class="fontRegular light line-ht-5 colorWhite"> &#8220; Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. &#8222; </p>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <span class="space40"></span>
                    <div class="text-center">
                        <a href="testimonials" class="btnquote">View More</a>
                    </div>
                </div>
                <span class="space60"></span>
            </div>
        </div>
    </section>
    <!-- testimonials end -->


    <!-- Footer start -->
    <!--<span class="space40"></span>-->
    <div class="footer">
        <span class="space40"></span>
        <div class="container overflowHidden">
            <div class="row">
                <div class="col-md-3">
                    <div class="p-2">
                        <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Navigation</h4>
                        <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                        <ul class="footerNav">
                            <li><a href="<%=rootPath %>">Home</a></li>
                            <li><a href="about-us">About Us</a></li>
                            <li><a href="our-products">Products</a></li>
                            <li><a href="enquiry">Enquiry</a></li>
                            <li><a href="testimonials">Testimonials</a></li>
                            <%--<li><a href="events-gallery">Events</a></li>--%>
                            <li><a href="career">Career</a></li>
                            <li><a href="contact-us">Contact us</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="p-2">
                        <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Our Products</h4>
                        <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                        <div class="row">
                            <%=prodstrfoo %>


                          <%--  <div class="col-6">
                                <ul class="footerNav">
                                    <li><a href="http://localhost:49724/product-category/broom-2">Broom</a></li>
                                </ul>
                            </div>
                            <div class="col-6">
                                <ul class="footerNav">
                                    <li><a href="http://localhost:49724/product-category/drying-stand-5">Drying Stand</a></li>
                                </ul>
                            </div>
                            <div class="col-6">
                                <ul class="footerNav">
                                    <li><a href="http://localhost:49724/product-category/plunger-7">Plunger</a></li>
                                </ul>
                            </div>
                            <div class="col-6">
                                <ul class="footerNav">
                                    <li><a href="http://localhost:49724/product-category/supali-8">Supali</a></li>
                                </ul>
                            </div>--%>


                            <%--<div class="col-6">
                                <ul class="footerNav">
                                    <li><a href="#">Brooms</a></li>
                                    <li><a href="#">Brush</a></li>
                                    <li><a href="#">Mop</a></li>
                                    <li><a href="#">Wiper</a></li>
                                    <li><a href="#">Ladder</a></li>
                                </ul>
                            </div>
                            <div class="col-6">
                                <ul class="footerNav">
                                    <li><a href="#">Spin Mop</a></li>
                                    <li><a href="#">Scrubber</a></li>
                                    <li><a href="#">Wipee</a></li>
                                    <li><a href="#">Drying Stand</a></li>
                                    <li><a href="#">Plunger</a></li>
                                </ul>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="p-2">
                        <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Get Social</h4>
                        <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                        <a href="#" target="_blank" class="foo_fb foo_socialIco" title="Follow us on facebook"></a>
                        <a href="#" target="_blank" class="foo_twitter foo_socialIco" title="Follow us on twitter"></a>
                        <a href="#" target="_blank" class="foo_insta foo_socialIco" title="Follow us on Instagram"></a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="p-2">
                        <h4 class="footerCaption clrWhite mb-2 semiBold upperCase letter-sp-2">Contact Info</h4>
                        <div class="fLine mb-3"><span class="fAbsLine"></span></div>
                        <span class="addr line-ht-5 small">Carporate Office: Plot No. A-1, Samruddhi Park Behind Chintamanrao College Opp. Vishrambag Railway Sattion Sangli 416 415, Maharashtra.</span>
                        <span class="space15"></span>
                        <a href="#" class="email breakWord line-ht-5 small txtDecNone">info&#64;samruddhicleaningware&#46;com</a>
                        <span class="space15"></span>
                        <a href="+919209033650" class="foo_call line-ht-5 small txtDecNone">+91 9209 03 3650</a>
                    </div>
                </div>
            </div>
            <div class="float_clear"></div>
        </div>
        <span class="space20"></span>
        <span class="footerLine"></span>
        <div class="container text-center">
            <div class="p-3">
                <span class="clrGrey mrg_B_5 small fontRegular">&copy; <%= currentYear %> | Samruddhi Cleaning Wares , All Rights Reserved</span>
                <span class="clrGrey small fontRegular">Website By <a href="http://www.intellect-systems.com" target="_blank" class="intellect" title="Website Design and Development Service By Intellect Systems">Intellect Systems</a></span>
            </div>
        </div>
    </div>
    <!-- Footer Ends -->

    <script>
        $(document).ready(function () {
            $('[data-toggle=tooltip]').tooltip();
        });
    </script>

    <script>
        var swiper = new Swiper(".mySwiper", {
            slidesPerView: 4,
            spaceBetween: 30,
            pagination: {
                el: ".swiper-pagination",
                clickable: true,
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });

        var swiper3 = new Swiper(".mySwiper3", {
            grabCursor: true,
            effect: "creative",
            creativeEffect: {
                prev: {
                    shadow: true,
                    translate: ["-20%", 0, -1],
                },
                next: {
                    translate: ["100%", 0, 0],
                },
            },

            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });

       
    </script>

    <script>
        $(function () {
            //alert("function called");
            // Check the initial Poistion of the Sticky Header
            var stickyHeaderTop = $('#navigationBar').offset().top;

            $(window).scroll(function () {
                //alert("alert1");
                if ($(window).scrollTop() > stickyHeaderTop) {
                    $('#navigationBar').css({ position: 'fixed', top: '0px' });
                    $('#navigationBar').css('display', 'block');
                }
                else {
                    $('#navigationBar').css({ position: 'sticky', top: '0px' });
                    $('#navigationBar').css('display', 'block');
                }
            });
        });
    </script>

    <script>
        AOS.init();
    </script>
</body>
</html>
