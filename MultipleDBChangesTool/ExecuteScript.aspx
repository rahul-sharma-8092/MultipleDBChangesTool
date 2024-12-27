<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExecuteScript.aspx.cs" Inherits="MultipleDBChangesTool.ExecuteScript" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table#MainContent_chkDatabaseList label { margin: 5px 10px; font-size: 16px; font-weight: 600;}
        table#MainContent_chkDatabaseList input { vertical-align: middle; width: 16px; height: 16px; }
        #chkSelectAll{ width: 17px; height: 17px; }
        span.form-check-input{ border: none; margin-left: 25px; }
        label.form-check-label{ line-height: 1; vertical-align: middle; margin-top: -11px; font-weight: 600; user-select: none; }
    </style>

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
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-3">
                        <asp:Button ID="btnExecuteScript" OnClick="btnExecuteScript_Click" Text="Execute Script" runat="server" Enabled="false" CssClass="btn btn-success" />
                    </div>
                    <div class="col-md-3"></div>
                    <div class="col-md-3"></div>

                    <div class="col-md-3 d-flex justify-content-end">
                        <asp:Button ID="btnTestConn" OnClick="btnTestConn_Click" Text="Test Connection" runat="server" CssClass="btn btn-primary btn-block me-3" />
                    </div>
                </div>
            </div>

            <!-- Database List -->
            <div class="card-footer bg-light p-4 rounded-bottom-4" runat="server" id="divListDB" visible="false">
                <h5 class="fw-bold text-primary mb-3 ps-4">Select Databases</h5>
                <div class="row">
                    <div class="col-md-12">
                        <asp:CheckBox ID="chkSelectAll" runat="server" ClientIDMode="Static" CssClass="form-check-input" onclick="toggleSelectAll(this);" />
                        <label for="chkSelectAll" class="form-check-label">Select All</label>
                        <asp:CheckBoxList ID="chkDatabaseList" runat="server" CssClass="form-check" >

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

    <script type="text/javascript">
    
        function toggleSelectAll(selectAllCheckbox) {
            var checkBoxList = document.querySelectorAll("#<%= chkDatabaseList.ClientID %> input[type='checkbox']");
            checkBoxList.forEach(function (checkbox) {
                checkbox.checked = selectAllCheckbox.checked;
            });
        }
    </script>


</asp:Content>
