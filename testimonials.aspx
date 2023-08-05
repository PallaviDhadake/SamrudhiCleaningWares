<%@ Page Title="Clients Reviews | Samrudhhi Cleaning Wares" Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="testimonials.aspx.cs" Inherits="testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        ::placeholder{color:#fff !important;}
    </style>
    <script>
        function ValidateForm() {
            let stars = document.getElementsByClassName().value
            if (stars == "") {

                TostTrigger('warning', 'Select Star Rating');
                return false;
            }
        }
    </script>

     <%-- <script type="text/javascript">
        function ValidateForm() {
           

            let name = document.getElementById("txtTestName").value;
            if (name == "") {
                //alert("Please Enter Your Name");
                TostTrigger('warning', 'Please Enter Your Name');
                return false;
            }

            let email = document.getElementById("txtTestEmail").value;
            if (email == "") {
                TostTrigger('warning', 'Please Enter Email Address');
                return false;
            }
            let city = document.getElementById("txtCity").value;
            if (city == "") {
                TostTrigger('warning', 'Please Enter City ');
                return false;
            }

            let review = document.getElementById("txtMsg").value;
            if (review == "") {
                TostTrigger('warning', 'Please Enter Review');
                return false;
            }

            let starrating = document.getElementById("star").value;
            if (starrating == "") {
                alert("star rating");
                TostTrigger('warning', 'Select Star 1 Rating');
                return false;
            }

            //let starrating = document.forms["rating-review"]["rating"].value;
            //if (starrating == "") {
            //    alert("star rating");
            //    TostTrigger('warning', 'Select Star Rating');
            //    return false;
            //}

            //alert("Review data End");

           // set values to testimonials object
            var TestimonialsData = {};
            TestimonialsData.TestPerson = $('#txtTestName').val();
            TestimonialsData.TestEmail = $('#txtTestEmail').val();
            TestimonialsData.TestCity = $('#txtCity').val();
            TestimonialsData.TestInfo = $('#txtMsg').val();
            //TestimonialsData.TestRating = $('#star').val();

            $.ajax({
                type: "POST",
                url: "testimonials.aspx/SaveTestimonials",
                data: '{custinfo: ' + JSON.stringify(TestimonialsData) + '}',
                //alert(data);,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //alert('Testimonials added Successfully!' + response.d);
                    TostTrigger('success', 'Testimonial Submited Successfully!');
                    document.getElementById('txtTestName').value = '';
                    document.getElementById('txtTestEmail').value = '';
                    document.getElementById('txtCity').value = '';
                    document.getElementById('txtTestReview').value = '';
                },
                failure: function (response) {
                   // alert(response.d);
                }
            });
        }

      </script>--%>

    <script type="text/javascript">
        function GetRating(rating) {
            alert("function rating called");
            //alert(rating.value);

            $.ajax({
                type: "POST",
                url: "testimonials.aspx/GetRating",
                data: '{ratingValue: ' + rating.value + '}',
                alert(data);,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //alert('rating ' + response.d);
                },
                failure: function (response) {
                   // alert(response.d);
                }
            });
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Page Header Starts -->
    <%--<span class="space150"></span>--%>
    <%--<span class="space20"></span>--%>
    <div class="pgHeader2" id="pagehead">
        <div class="headerOverlay d-flex align-items-center justify-content-center">
            <div class="container">
                <div class="p-4">
                    <h1 class="pgheadertitle text-uppercase">Reviews</h1>
                    <h2 class="pgsubtitle" data-aos="fade-right" data-aos-duration="1000">What Peoples Says About Us</h2>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Header Ends -->
    <span class="space30"></span>

    <%--Testimonials Satrts--%>
    <div class="container" id="testimonials">
        <div class="p-2">
            <%--<span class="semiBold semiMedium clrdarkgrey">Clients Reviews</span>--%>
           <%-- <span class="fontRegular regular clrGrey line-ht-5">Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos erat ipsum et lorem et sit,</span>--%>
            <span class="space30"></span>

            <a href="#stars" class="rateus text-uppercase">Rate us</a>
            <span class="space30"></span>

            <%= GetTestData() %>
            <span class="space30"></span>

            <div class="row bg-white shadow" id="stars">
                <div class="col-md-6 d-flex align-items-center justify-content-center">
                    <div class="p-4">
                        <img src="images/testimonials.svg" class="img-fluid w-100" />
                    </div>
                </div>
                <div class="col-md-6 conBox">
                    <div class="p-4">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                         <div id="rating-review">
                            <div class="row">
                                <div class="form-group col-md-12">
                                     <asp:TextBox ID="txtName" CssClass="ratTextBox" MaxLength="80" placeholder="Name *" runat="server"></asp:TextBox>

                                    <%--<input type="text" id="txtTestName" class="ratTextBox" placeholder="Name *" maxlength="50" required />--%>

                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <%--<input type="text" id="txtTestEmail" class="ratTextBox" placeholder="Email *" maxlength="50" required />--%>

                                    <asp:TextBox ID="txtEmail" CssClass="ratTextBox" MaxLength="30" placeholder="Email *" runat="server"></asp:TextBox>


                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-12">
                                     <asp:TextBox ID="txtCity" CssClass="ratTextBox" MaxLength="30" placeholder="City *" runat="server"></asp:TextBox>

                                    <%--<input type="text" id="txtCity" class="ratTextBox" placeholder="City *" maxlength="50" required />--%>

                                </div>
                            </div>

                             <div class="stars mt-4 mb-4" id="star" runat="server">
                                 <input type="radio" name="rating" class="star-1" id="start-1" value="1" onclick="GetRating(this);" />
                                 <label class="star-1" for="star-1">1</label>
                                 <input type="radio" name="rating" class="star-2" id="star-2" value="2" onclick="GetRating(this);" />
                                 <label class="star-2" for="star-2">2</label>
                                 <input type="radio" name="rating" class="star-3" id="star-3" value="3" onclick="GetRating(this);" />
                                 <label class="star-3" for="star-3">3</label>
                                 <input type="radio" name="rating" class="star-4" id="star-4" value="4" onclick="GetRating(this);" />
                                 <label class="star-4" for="star-4">4</label>
                                 <input type="radio" name="rating" class="star-5" id="star-5" value="5" onclick="GetRating(this);" />
                                 <label class="star-5" for="star-5">5</label>
                                 <span></span>
                             </div>

                            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtDesc" CssClass="ratTextBox" TextMode="MultiLine" Height="150" runat="server" placeholder="Message *"></asp:TextBox>

                                <%--<textarea id="txtMsg" cols="20" rows="2" class="ratTextBox" placeholder="Message *" required></textarea>--%>

                            </div>
                            <span class="space20"></span>

                             <asp:Button ID="btnSubmit" runat="server" CssClass="ratebtn text-uppercase" Text="SUBMIT" OnClick="btnSubmit_Click"/></div>

                          <%--  <input id="btnSubmit" type="button" value="Submit" class="ratebtn text-uppercase" onclick="return ValidateForm();" />--%>

                         </ContentTemplate>
                    </asp:UpdatePanel>
                      </div>
                    </div>
                </div>
            </div>


             <!--star rating here-->
          
            
            <%--<a href="#" class="nwsmorebtn text-uppercase">Submit</a>--%>


<%--            <div class="stars" id="star">
                <input type="radio" name="rating" class="star-1" id="star-1" value="1" onclick="GetRating(this);" />
                <label class="star-1" for="star-1">1</label>
                <input type="radio" name="rating" class="star-2" id="star-2" value="2" onclick="GetRating(this);" />
                <label class="star-2" for="star-2">2</label>
                <input type="radio" name="rating" class="star-3" id="star-3" value="3" onclick="GetRating(this);" />
                <label class="star-3" for="star-3">3</label>
                <input type="radio" name="rating" class="star-4" id="star-4" value="4" onclick="GetRating(this);" />
                <label class="star-4" for="star-4">4</label>
                <input type="radio" name="rating" class="star-5" id="star-5" value="5" onclick="GetRating(this);" />
                <label class="star-5" for="star-5">5</label>
                <span></span>
            </div>--%>

            <%--<div class="testpad mb-3">
                <div class="reviewquote">
                    <img src="images/icons/test-qoute.png" class="" />
                </div>
            </div>

            <span class="semiBold fontRegular colorPrime">Pallavi Ramesh Dhadake.</span>
            <span class="space5"></span>
            <span class="light clrGrey">Sangli</span>
            <span class="space10"></span>
            <p class="fontRegular light line-ht-7">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
            <span class="greyLine"></span>
            <span class="space15"></span>

           
            <div class="testpad mb-3">
                <div class="reviewquote">
                    <img src="images/icons/test-qoute.png" class="" />
                </div>
            </div>

            <span class="semiBold fontRegular colorPrime">Pallavi Ramesh Dhadake.</span>
            <span class="space5"></span>
            <span class="light clrGrey">Sangli</span>
            <span class="space10"></span>
            <p class="fontRegular light line-ht-7">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
             <span class="greyLine"></span>
            <span class="space15"></span>


            
            <div class="testpad mb-3">
                <div class="reviewquote">
                    <img src="images/icons/test-qoute.png" class="" />
                </div>
            </div>

            <span class="semiBold fontRegular colorPrime">Pallavi Ramesh Dhadake.</span>
            <span class="space5"></span>
            <span class="light clrGrey">Sangli</span>
            <span class="space10"></span>
            <p class="fontRegular light line-ht-7">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>--%>

        </div>
    </div>
    <%--Testimonials end--%>
    <span class="space30"></span>
</asp:Content>

