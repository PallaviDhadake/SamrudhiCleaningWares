<%@ Page Title="Products Category Master | Samruddhi Cleaning Ware" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="products-catogery.aspx.cs" Inherits="adminpanel_products_catogery" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script>
		$(document).ready(function () {
            $('[id$=gvProducts]').DataTable({
                columnDefs: [
                    { orderable: false, targets: [0, 1, 2]}
				],
				order: [[0, 'desc']]
			});
		});
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2 class="pgTitle">Products Category Master</h2>
    <span class="space10"></span>
	<div id="editinfo" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title"><%=pgTitle %></h3>
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
                    <div class="form-group col-md-12">
                        <label>Product Category:*</label>
                        <asp:TextBox ID="txtProdCat" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                       <%-- <asp:DropDownList ID="ddrProdCat" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">-- Select Product Category --</asp:ListItem>
                            <asp:ListItem Value="1">Broom</asp:ListItem>
                            <asp:ListItem Value="2">Brush</asp:ListItem>
                            <asp:ListItem Value="3">Wiper</asp:ListItem>
                            <asp:ListItem Value="4">Mop</asp:ListItem>
                            <asp:ListItem Value="5">Spin Mop</asp:ListItem>
                            <asp:ListItem Value="6">Spare Accessories</asp:ListItem>
                            <asp:ListItem Value="7">Soap Case</asp:ListItem>
                            <asp:ListItem Value="8">Drying Stand</asp:ListItem>
                            <asp:ListItem Value="9">Wipee</asp:ListItem>
                            <asp:ListItem Value="10">Scrubber</asp:ListItem>
                            <asp:ListItem Value="11">Ladder</asp:ListItem>
                            <asp:ListItem Value="12">Supali</asp:ListItem>
                            <asp:ListItem Value="13">Loofan</asp:ListItem>
                            <asp:ListItem Value="14">Kharata</asp:ListItem>
                            <asp:ListItem Value="15">Rack</asp:ListItem>
                            <asp:ListItem Value="16">Plunger</asp:ListItem>
                            <asp:ListItem Value="17">Liquid</asp:ListItem>
                        </asp:DropDownList>--%>
                    
                    </div>

                    <div class="form-group col-md-12">
                        <label>Product Description:*</label>
                        <asp:TextBox ID="txtProdDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px" Width="100%"></asp:TextBox>
                    </div>
                    
                     <div class="form-group col-md-6">
                        <label>Product Category Cover Image:*</label>
                         <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= prodPhoto %><span class="space5"></span>
						<asp:Button ID="btnRemove" runat="server" CssClass="btn btn-secondary" Text="Remove Photo"  OnClientClick="return confirm('Are you sure to remove photo?');" OnClick="btnRemove_Click" />
                    </div>

                </div>
            </div>
        </div>
        <!-- Button controls starts -->
        <span class="space10"></span>
        <span class="space10"></span>
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-outline-info" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-dark" Text="Cancel" OnClick="btnCancel_Click" />
        <div class="float_clear"></div>
        <!-- Button controls ends -->
        <%--</ContentTemplate>
		</asp:UpdatePanel>--%>
    </div>
     <div id="viewinfo" runat="server">
        <a href="products-catogery.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
        <span class="space20"></span>
        <div class="formPanel table-responsive-md">
            <asp:GridView ID="gvProducts" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvProducts_RowDataBound" >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="ProdCatId">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="ProdCatName" HeaderText="Product Category">
						<ItemStyle Width="20%" />
					</asp:BoundField>

					<asp:TemplateField>
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAnch" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>  
                    
				</Columns>
				<EmptyDataTemplate>
					<span class="warning">Its Empty Here... :(</span>
				</EmptyDataTemplate>
				<PagerStyle CssClass="" />
			</asp:GridView>
        </div>
    </div>
</asp:Content>

