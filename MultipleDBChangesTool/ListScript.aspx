<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListScript.aspx.cs" Inherits="MultipleDBChangesTool.ListScript" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0">Scripts Management</h5>
                <button class="btn btn-light btn-sm"><a runat="server" class="btn btn-sm" href="~/AddScript.aspx"><i class="fas fa-plus"></i>&nbsp;&nbsp;Add New Script</a></button>
            </div>
            <div class="card-body">
                <asp:Repeater ID="rptScripts" runat="server" OnItemCommand="rptScripts_ItemCommand">
                    <HeaderTemplate>
                        <div class="table-responsive">
                            <table class="table table-hover align-middle">
                                <thead class="table-primary">
                                    <tr>
                                        <th scope="col">Script Name</th>
                                        <th scope="col">Created At</th>
                                        <th scope="col" class="text-center">View Preview</th>
                                        <th scope="col" class="text-center">Execute</th>
                                        <th scope="col" class="text-center">Delete Script</th>
                                    </tr>
                                </thead>
                                <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("CreatedAT", "{0:dd-MM-yyyy HH:mm}") %></td>
                            <td class="text-center">
                                <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-primary btn-sm" Text="Preview" OnClientClick='<%# "return openPreview(\"" + Eval("ID") + "\", \"" + Eval("ServerPath") + "\")" %>' />
                            </td>
                            <td class="text-center">
                                <asp:Button ID="btnExecute" runat="server" CssClass="btn btn-primary btn-sm" CommandArgument='<%# Eval("ID") %>' CommandName="ExecuteScript" Text="Execute" />
                            </td>
                            <td class="text-center">
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("ID") + "|" + Eval("PhySicalPath") %>'  CommandName="DeleteScript" Text="Delete" />
                            </td>
                        </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>
</asp:Content>
