<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewSQLQuery.aspx.cs" Inherits="MultipleDBChangesTool.PreviewSQLQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL Query Preview | Rahul Sharma</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        pre {
            background-color: #f4f4f4;
            padding: 10px;
            border: 1px solid #ccc;
            overflow: scroll;
            width: fit-content;
        }

        button {
            margin-top: 10px;
            padding: 10px 20px;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>SQL Query Preview | Rahul Sharma</h2>
            <pre id="sqlContent"></pre>
            <button onclick="window.close()">Close</button>
        </div>
    </form>
</body>
</html>
