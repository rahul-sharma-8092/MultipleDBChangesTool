<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExecuteScript.aspx.cs" Inherits="MultipleDBChangesTool.ExecuteScript" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Database Script Execution</h5>
            </div>
            <div class="card-body">
                <div class="row mb-3">
                    <div class="col-md-3">
                        <asp:Label Text="Script Name" runat="server" CssClass="form-label" />
                        <asp:TextBox ID="txtScriptName" runat="server" Text="" Enabled="false" CssClass="form-control" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-3">
                        <asp:Label Text="Server Name" runat="server" CssClass="form-label" />
                        <asp:TextBox ID="txtServerName" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-3">
                        <asp:Label Text="Authentication" runat="server" CssClass="form-label" />
                        <asp:DropDownList ID="ddlAuthentication" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Window Authentication" Value="1" />
                            <asp:ListItem Text="SQL Server Authentication" Value="2" Selected="True" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <asp:Label Text="Login" runat="server" CssClass="form-label" />
                        <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-3">
                        <asp:Label Text="Password" runat="server" CssClass="form-label" />
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-3">
                        <asp:Button ID="btnExecuteScript" Text="Execute Script" runat="server" CssClass="btn btn-success" />
                    </div>
                    <div class="col-md-3"></div>
                    <div class="col-md-3"></div>

                    <div class="col-md-3 d-flex justify-content-end">
                        <asp:Button ID="btnTestConn" OnClick="btnTestConn_Click" Text="Test Connection" runat="server" CssClass="btn btn-primary btn-block me-3" />
                    </div>
                </div>
            </div>

            <!-- Databases List with Checkboxes -->
            <div class="card-body">
                <div class="row mb-3">
                    <div class="col-md-12">
                        <asp:Label Text="Select Databases" runat="server" CssClass="form-label" />
                        <asp:CheckBoxList ID="chkDatabaseList" runat="server" CssClass="form-check">
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
        </div>
    </main>

    <asp:HiddenField ID="hdnScriptID" runat="server" />
    <asp:HiddenField ID="hdnName" runat="server" />
    <asp:HiddenField ID="hdnPhysicalPath" runat="server" />
    <asp:HiddenField ID="hdnServerPath" runat="server" />

</asp:Content>
