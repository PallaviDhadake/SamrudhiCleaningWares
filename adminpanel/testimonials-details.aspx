<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="testimonials-details.aspx.cs" Inherits="adminpanel_testimonials_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Testimonials Details</h2>
	<span class="space15"></span>
	<div id="Div1" runat="server">
   <div class="card card-primary">
			<div class="card-header">
				<h3 class="card-title">Testimonials Details</h3>
			</div>
			<%-- Card Body --%>
			<div class="card-body">
				<div class="colorLightBlue">
					<%--<span>Id</span>--%>
					<asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
				</div>
				<span class="space15"></span>
				<%-- From Row Start --%>
				<div class="form-row">
					<div class="form-group col-md-6">

						<label>Person Name:*</label>
						<asp:TextBox ID="txtPersonNm" runat="server" CssClass="form-control" Width="100%" MaxLength="80"></asp:TextBox>
					</div>
					
					<%--<div class="form-group col-md-6">
						<label>Date:*</label>
						<asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="200" ></asp:TextBox>
					</div>--%>

					 <div class="form-group col-md-6">
						<label>Email:*</label>
						<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="30" ></asp:TextBox>
					</div>

					  <div class="form-group col-md-6">
						<label>City :*</label>
						<asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="30" ></asp:TextBox>
					</div>

					 <div class="form-group col-md-6">
						<label>Rating:*</label>
						<asp:TextBox ID="txtRating" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="5" ></asp:TextBox>
					</div>
					<%--<asp:CheckBox ID="Approveflag" runat="server" Test="ApproveFlag" />--%>
					<div class="form-group col-md-6">
						<label>Testimonails Description :*</label>
						<asp:TextBox ID="txtTesDesc" runat="server" CssClass="form-control textarea" Height="200px" Width="100%"  textmode="MultiLine"></asp:TextBox>
					</div>
				</div>
			</div>
		</div>
	</div>
	<asp:Button ID="btnApprove" runat="server" CssClass="btn btn-sm btn-info" Text="Approve" OnClick="btnApprove_Click" />
	<asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-secondary" Text="Update" OnClick="btnUpdate_Click"  />
	<asp:Button ID="btnBack" runat="server" CssClass="btn btn-sm btn-outline-dark" Text="Back" OnClick="btnBack_Click"   />
	<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-sm btn-dark" Text="Delete" OnClick="btnDelete_Click"  />
</asp:Content>

