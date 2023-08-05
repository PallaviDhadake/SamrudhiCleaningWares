<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="add-events-photos.aspx.cs" Inherits="adminpanel_add_events_photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .closeAnch{background:url(../images/App/icons/deleteIco.png) no-repeat center center; display:block; height:20px; width:20px; position:absolute; top:5px; right:5px  }
        .imgBox{ float:left;position:relative }
        .imgContainer{ height:200px !important; width:200px; overflow:hidden !important; }
        .w100{ width:100% }
        .pad-5{ padding:5px }
        .border1{ border:1px solid #ececec }
		.titlecolor{color:#5f3232; font-size:20px; font-weight:600;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Add Events Photos </h2>
    <span class="titlecolor"><%= eventtitle %></span> 
    <span class="space10"></span>
    <div id="editinfo" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title"><%=pgTitle %></h3>
            </div>
            
            <div class="form-group col-md-6">
                <span class="space20"></span>
                <label>Events Image:*</label>
                <asp:FileUpload ID="fuImg" runat="server" CssClass="form-control-file" />
                <span class="space10"></span>
                <%= eventPhoto %><span class="space5"></span>
                <%--<asp:Button ID="btnRemove" runat="server" CssClass="btn btn-secondary" Text="Remove Photo" OnClientClick="return confirm('Are you sure to remove photo?');" OnClick="btnRemove_Click" />--%>
            </div>

        </div>
          <!-- Button controls starts -->
        <span class="space10"></span>
        <span class="space10"></span>
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
        <span class="space30"></span>
        <%=photoMarkup %>
    </div>
</asp:Content>

