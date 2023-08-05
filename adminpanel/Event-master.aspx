<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="Event-master.aspx.cs" Inherits="adminpanel_Event_master" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script>
		$(document).ready(function () {
            $('[id$=gvEvents]').DataTable({
                columnDefs: [
                    { orderable: false, targets: [0, 1, 2, 3, 4, 5]}
				],
				order: [[0, 'desc']]
			});
		});
     </script>
    <script type="text/javascript">
        window.onload = function () {
            //alert("window load");

            duDatepicker('#<%= txtDate.ClientID %>', {
                auto: true, inline: true, format: 'dd/mm/yyyy',
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Events Master</h2>
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
                    <div class="form-group col-md-6">
                        <label>Date:*</label>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="100%" ></asp:TextBox>
                    </div>

                     <div class="form-group col-md-6">
                        <label>Events Category:*</label>
                        <asp:DropDownList ID="ddrevntcat" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">-- Select Events Category --</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                     <div class="form-group col-md-6">
                        <label>Event Title:*</label>
                        <asp:TextBox ID="txtEventTitle" runat="server" CssClass="form-control" Width="100%" MaxLength="50"></asp:TextBox>
                    </div>

                     <div class="form-group col-md-6">
                        <label>Event Video:</label>
                        <asp:TextBox ID="txtEventVideo" runat="server" CssClass="form-control" Width="100%" MaxLength="50"></asp:TextBox>
                         <span class="space15"></span>
                         <%=videoPreview %>
                    </div>

                    <div class="form-group col-md-6">
                        <label>Event Description:*</label>
                        <asp:TextBox ID="txtEventDesc" runat="server" CssClass="form-control" Width="100%" MaxLength="200" Height="200" Rows="2" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <%--<div class="form-group col-md-6">
                        <label>Event Title:*</label>
                        <asp:TextBox ID="txtEventTitle" runat="server" CssClass="form-control" Width="100%" MaxLength="50"></asp:TextBox>
                    </div>--%>
                  <%--  <div class="form-group col-md-6">
                        <label>Event Description:*</label>
                        <asp:TextBox ID="txtEventDesc" runat="server" CssClass="form-control" Width="100%" MaxLength="80" TextMode="MultiLine" Height="200"></asp:TextBox>
                    </div>--%>
                    
                     <div class="form-group col-md-6">
                        <label>Event Image:*</label>
                         <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= eventPhoto %><span class="space5"></span>
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
        <a href="Event-master.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
        <span class="space20"></span>
        <div class="formPanel table-responsive-md">
            <asp:GridView ID="gvEvents" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvEvents_RowDataBound" >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="EvntId">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
                     <asp:BoundField DataField="EvntDate" HeaderText="Date">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					 <asp:BoundField DataField="EvntTitle" HeaderText="Event Title">
						<ItemStyle Width="20%" />
					</asp:BoundField>

                    <asp:TemplateField HeaderText="Video">
                        <ItemStyle Width="3%" />
                        <ItemTemplate>
                            <asp:Literal ID="litVideoLink" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

					<asp:TemplateField>
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAnch" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>  
                    
                    <asp:TemplateField>
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAnchphto" runat="server"></asp:Literal>
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

