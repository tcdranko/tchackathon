<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="RateAndFeedback.aspx.cs" Inherits="TCRateAndFeedback.RateAndFeedback" MaintainScrollPositionOnPostback="true"  %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TC Rate and Review</title>
    <link rel="stylesheet" runat="server" media="screen" href="/css/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>TC Rate and Review</h2>

        Choose rating:<br />
        <asp:DropDownList ID="ddlRating" runat="server"></asp:DropDownList><br /><br />
        Leave a comment (max. 250 characters):<br />
        <asp:TextBox ID="txtComment" runat="server" MaxLength="250" TextMode="MultiLine" Rows="5" Width="300px"></asp:TextBox><br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Review" OnClick="btnSubmit_Click" /><br /><br />
        
        <asp:Label ID="lblMessage" runat="server" Visible="false" Text="Thank you for submitting your review. It has been appended to the rest of the reviews below."></asp:Label><br /><br /><br />
        <asp:Panel ID="ReviewsPanel" runat="server"></asp:Panel>
        
    </form>
    <script type="text/javascript" src="/scripts/script.js"></script>
</body>
</html>
