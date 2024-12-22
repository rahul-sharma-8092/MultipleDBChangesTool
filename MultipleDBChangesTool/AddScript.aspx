<%@ Page Title="Add Script" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddScript.aspx.cs" Inherits="MultipleDBChangesTool.AddScript" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-5">
        <div class="text-center mb-4">
            <h1 class="display-4">Add Script</h1>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control mb-3" />
                        <asp:Button ID="btnUploadBtn" Text="Upload Script" runat="server" CssClass="btn btn-primary w-100" OnClick="btnUploadBtn_Click" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

