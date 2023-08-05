<%@ Page Title="Best Cleaning Products | Samruddhi Cleaning Wares" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .carousel-indicators {list-style: none !important; background: none;}
            .carousel-indicators li, .carousel-indicators li.active {list-style: none; background: none; width: 55px;
                height: 55px; position: relative;}
            .carousel-indicators img {position: absolute; width: 100%; border: 1px solid #161616; height: 100%; top: -25px; left:-280px; box-shadow: 0 10px 10px 0 rgba(0,0,0, 0.4); width: 55px; height: 55px; /* margin-top: 50px;*/}
            .productborder{border:1px solid #00b5f0}

             .swiper {
      /*width: 300px;
      height: 300px;*/
     /* position: absolute;
      left: 50%;
      top: 50%;
      margin-left: -150px;
      margin-top: -150px;*/
    }

    .swiper-slide {
      /*background:none;*/
      background-position: top !important;
      /*margin-top:-180px !important;*/
      background-size: cover;
    }

    .swiper-slide img {
      display: block;
      width: 100%;
    }
    .swiper-button-next{color:#82b47c;}
    .swiper-button-prev{color:#82b47c;}
    /*.imgsize{width:800px; height:600px !important}*/
    </style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Header Starts -->
    <div class="pgHeader3" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="semiBold colorSec text-uppercase">Products</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">Our Popular Cleaning Products</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>

    <%-- products details modal start --%>
    <!-- Button trigger modal -->

    <!-- Modal -->
    <%--<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">
                <div class="row">
                    <div class="col-md-5">
                        <div class="p-3">
                            <div class="border d-flex align-items-center justify-content-center">
                                <div class="p-4">
                                    <div id="carouselexamplefade" class="carousel slide carousel-fade position-relative" data-bs-ride="carousel" data-bs-interval="3500">
                                        <div class="">
                                            <!--indicators-->

                                            <ol class="carousel-indicators d-flex align-items-end flex-column justify-content-end mb-0">
                                                <li data-bs-target="#carouselexamplefade" data-bs-slide-to="0" class="active">
                                                    <img src="images/brush-savg.jpg" alt="..."></li>
                                                <li data-bs-target="#carouselexamplefade" data-bs-slide-to="1" class="active ">
                                                    <img src="images/brooms.jpg" alt="..."></li>
                                                <li data-bs-target="#carouselexamplefade" data-bs-slide-to="2" class="active ">
                                                    <img src="images/brush-savg.jpg" alt="..."></li>
                                                 <li data-bs-target="#carouselexamplefade" data-bs-slide-to="2" class="active ">
                                                    <img src="images/brush-savg.jpg" alt="..."></li>
                                            </ol>

                                            <div class="carousel-inner ms-3">
                                                <div class="carousel-item active">
                                                    <img src="images/brush-savg.jpg" class="d-block w-100 position-relative" alt="cleaning products">
                                                </div>
                                                <div class="carousel-item">
                                                    <img src="images/brooms.jpg" class="d-block w-100 position-relative" alt="archi interior designs">
                                                </div>
                                                <div class="carousel-item">
                                                    <img src="images/brush-savg.jpg" class="d-block w-100 position-relative" alt="archi interior designs">
                                                </div>
                                                <div class="carousel-item">
                                                    <img src="images/brush-savg.jpg" class="d-block w-100 position-relative" alt="archi interior designs">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7">
                        <div class="p-3">
                            <h3 class="colorSec text-uppercase semiBold mb-3">No Dust Broom Gaj Lakshmi</h3>

                            <p class="fontRegular regular line-ht-5">Price: <span class="light small clrGrey"> &#8377; 300</span></p>
                            <p class="fontRegular regular line-ht-5">Specification: <span class="light small clrGrey line-ht-7">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</span>
                                
                                <ul class="bulletlist m-0 p-0 fontRegular clrGrey small">
                                    <li><span>&#187;</span><b>Weight:</b> 100</li>
                                    <li><span>&#187;</span><b>Color:</b> Black</li>
                                    <li><span>&#187;</span><b>Material:</b> Plastic / Steel</li>
                                    <li><span>&#187;</span><b>Additional Info:</b> Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</li>
                                </ul>

                            </p>

                            <p class="fontRegular regular line-ht-5">Description: <span class="light small clrGrey line-ht-7">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <%-- products details modal end --%>

    <%-- Products Start --%>
    <div class="container" id="ourproducts">
        <div class="p-3">
            <%--<span class="semiBold semiMedium clrdarkgrey">Our Products</span>--%>
            <%--<span class="space30"></span>--%>
           <%-- <span class="fontRegular regular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>
            <%--<span class="space60"></span>--%>
            <div class="row gy-3">
               <%=prodstr %>


                <%--<div class="col-md-5">
                    <div class="swiper mySwiper">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                            <img src="https://swiperjs.com/demos/images/nature-1.jpg" />
                        </div>
                        <div class="swiper-slide">
                            <img src="https://swiperjs.com/demos/images/nature-2.jpg" />
                        </div>
                        <div class="swiper-slide">
                            <img src="https://swiperjs.com/demos/images/nature-3.jpg" />
                        </div>
                        <div class="swiper-slide">
                            <img src="https://swiperjs.com/demos/images/nature-4.jpg" />
                        </div>
                    </div>
                    <div class="swiper-pagination"></div>
                         <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                </div>
                </div>--%>
                


                <%--<h2 class="pageH2 themeClrPrime mb-4 capitalize text-uppercase">No dust gaj lakshami</h2>
                <div class="col-md-5">
                    <div class="p-3">
                        <div class="border d-flex align-items-center justify-content-center">
                            <div class="p-4">
                                <div id="carouselexamplefade" class="carousel slide carousel-fade position-relative" data-bs-ride="carousel" data-bs-interval="3500">
                                    <ol class="carousel-indicators d-flex align-items-end flex-column justify-content-end mb-0">
                                        <li data-bs-target="#carouselexamplefade" data-bs-slide-to="7" class="active">
                                            <img src="http://localhost:58104/upload/products/Products-photo-7.jpg " alt="Products-photo-7.jpg " class="img-fluid ">
                                        </li>
                                    </ol>
                                    <div class="carousel-inner ms-3">
                                        <div class="carousel-item active">
                                            <img src="http://localhost:58104/upload/products/product-photo-915022023155044.jpg " alt="product-photo-915022023155044.jpg " class="d-block w-100 position-relative"></div>
                                    </div>
                                    <ol class="carousel-indicators d-flex align-items-end flex-column justify-content-end mb-0">
                                        <li data-bs-target="#carouselexamplefade" data-bs-slide-to="8" class="active">
                                            <img src="http://localhost:58104/upload/products/Products-photo-8.jpg " alt="Products-photo-8.jpg " class="img-fluid "></></ol>
                                    <div class="carousel-inner ms-3">
                                        <div class="carousel-item ">
                                            <img src="http://localhost:58104/upload/products/product-photo-915022023155044.jpg " alt="product-photo-915022023155044.jpg " class="d-block w-100 position-relative"></div>
                                    </div>
                                    <ol class="carousel-indicators d-flex align-items-end flex-column justify-content-end mb-0">
                                        <li data-bs-target="#carouselexamplefade" data-bs-slide-to="9" class="active">
                                            <img src="http://localhost:58104/upload/products/Products-photo-9.png " alt="Products-photo-9.png " class="img-fluid "></></ol>
                                    <div class="carousel-inner ms-3">
                                        <div class="carousel-item ">
                                            <img src="http://localhost:58104/upload/products/product-photo-915022023155044.jpg " alt="product-photo-915022023155044.jpg " class="d-block w-100 position-relative"></div>
                                    </div>
                                    <ol class="carousel-indicators d-flex align-items-end flex-column justify-content-end mb-0">
                                        <li data-bs-target="#carouselexamplefade" data-bs-slide-to="10" class="active">
                                            <img src="http://localhost:58104/upload/products/Products-photo-10.jpg " alt="Products-photo-10.jpg " class="img-fluid "></></ol>
                                    <div class="carousel-inner ms-3">
                                        <div class="carousel-item ">
                                            <img src="http://localhost:58104/upload/products/product-photo-915022023155044.jpg " alt="product-photo-915022023155044.jpg " class="d-block w-100 position-relative"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="p-3">
                        <h3 class="colorSec text-uppercase semiBold mb-3">No dust gaj lakshami</h3>
                        <p class="fontRegular regular line-ht-5">Price: <span class="light small clrGrey">&#8377; 300</span></p>
                        <p class="fontRegular regular line-ht-5">Specification: <span class="light small clrGrey line-ht-7">demo</p>
                        <p class="fontRegular regular line-ht-5">Description: <span class="light small clrGrey line-ht-7">demo</p>
                    </div>
                </div>--%>





                <%--<div class"col-md-3"><div class="content border"><a href="" class="text-decoration-none"><div class="content-overlay"></div><img src="http://localhost:58104/upload/products/thumb/product-photo-915022023155044.jpg " alt="product-photo-915022023155044.jpg "  class="img-fluid " ><div class="themeBGPrime"><div class="px-2 py-2 d-flex align-items-center justify-content-center"><h4 class="semiBold semiMedium text-white">No dust gaj lakshami</h4></div></div><div class="content-details fadeIn-bottom"><img src="images/icons/view.png" class="img-fluid"  title="View Product" /></div></a></div></div><div class"col-md-3"><div class="content border"><a href="" class="text-decoration-none"><div class="content-overlay"></div><img src="http://localhost:58104/upload/products/thumb/product-photo-813022023161851.jpg " alt="product-photo-813022023161851.jpg "  class="img-fluid " ><div class="themeBGPrime"><div class="px-2 py-2 d-flex align-items-center justify-content-center"><h4 class="semiBold semiMedium text-white">Plastic Supali</h4></div></div><div class="content-details fadeIn-bottom"><img src="images/icons/view.png" class="img-fluid"  title="View Product" /></div></a></div></div><div class"col-md-3"><div class="content border"><a href="" class="text-decoration-none"><div class="content-overlay"></div><img src="http://localhost:58104/upload/products/thumb/product-photo-710022023111315.jpeg " alt="product-photo-710022023111315.jpeg "  class="img-fluid " ><div class="themeBGPrime"><div class="px-2 py-2 d-flex align-items-center justify-content-center"><h4 class="semiBold semiMedium text-white">Spare Product Name</h4></div></div><div class="content-details fadeIn-bottom"><img src="images/icons/view.png" class="img-fluid"  title="View Product" /></div></a></div></div><div class"col-md-3"><div class="content border"><a href="" class="text-decoration-none"><div class="content-overlay"></div><div class="themeBGPrime"><div class="px-2 py-2 d-flex align-items-center justify-content-center"><h4 class="semiBold semiMedium text-white">Spare Product Name</h4></div></div><div class="content-details fadeIn-bottom"><img src="images/icons/view.png" class="img-fluid"  title="View Product" /></div></a></div></div><div class"col-md-3"><div class="content border"><a href="" class="text-decoration-none"><div class="content-overlay"></div><img src="http://localhost:58104/upload/products/thumb/product-photo-410022023110626.jpg " alt="product-photo-410022023110626.jpg "  class="img-fluid " ><div class="themeBGPrime"><div class="px-2 py-2 d-flex align-items-center justify-content-center"><h4 class="semiBold semiMedium text-white">Jumbo Broom</h4></div></div><div class="content-details fadeIn-bottom"><img src="images/icons/view.png" class="img-fluid"  title="View Product" /></div></a></div></div><div class"col-md-3"><div class="content border"><a href="" class="text-decoration-none"><div class="content-overlay"></div><img src="http://localhost:58104/upload/products/thumb/product-photo-109022023173014.jpg " alt="product-photo-109022023173014.jpg "  class="img-fluid " ><div class="themeBGPrime"><div class="px-2 py-2 d-flex align-items-center justify-content-center"><h4 class="semiBold semiMedium text-white">Cloth Drying stand</h4></div></div><div class="content-details fadeIn-bottom"><img src="images/icons/view.png" class="img-fluid"  title="View Product" /></div></a></div></div>--%>

                 


                <%--<div class="col-md-3">
                    <div class="content border">
                        <a href="#" data-bs-toggle="modal" data-bs-target="#exampleModal" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="content border">
                        <a href="#" class="text-decoration-none" target="_blank">
                            <div class="content-overlay"></div>
                            <img class="content-image" src="images/brooms.jpg" alt="">
                            <div class="themeBGPrime">
                                <div class="px-2 py-2 d-flex align-items-center justify-content-center">
                                    <h4 class="semiBold semiMedium text-white">Plastic Spinner Bucket</h4>
                                </div>
                            </div>
                            <div class="content-details fadeIn-bottom">
                                <img src="images/icons/view.png" class="img-fluid" title="View Product" />
                            </div>
                        </a>
                    </div>
                </div>--%>
            
                <%--<img src="images/bgproduct.jpg" />--%>
        </div>
        </div>
    </div>
    <%-- Products end --%>
    <span class="space30"></span>


    <script>
        var swiper = new Swiper(".mySwiper", {
            effect: "cube",
            grabCursor: true,
            cubeEffect: {
                shadow: true,
                slideShadows: true,
                shadowOffset: 20,
                shadowScale: 0.94,
            },
            pagination: {
                el: ".swiper-pagination",
            },

            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });
    </script>

</asp:Content>

