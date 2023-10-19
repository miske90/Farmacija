<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicines.aspx.cs" Inherits="EPharmacy.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <html lang="en">
<head>
    
    <title>Medicines</title>
    <link rel="stylesheet" href="Medicines.css">
    <style>
        

          .table-condesed, .table-condesed tr td{
              border:0px solid #fff;
         }

          tr:nth-child(even){
              background: #f8f7ff;
          }
          tr:nth-child(odd){
              background: #fff;
          }
        .auto-style1 {
            left: 527px;
            top: 9px;
            width: 1020px;
        }
    </style>
</head>
<body>
    <div id="BigCont" style="left: 5%; top: 10%">
        <div id="Ti" style="left: 17%; top: -8px; width: 845px;"><h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Medicines</h3></div>
        <div id="I" style="left: 2%; top: 17px; width: 195px; height: 99px; margin-left: 500px"></div><br><br>
        <div id="Block1" style="left:20%;">
                <input type="text" name="" id="MName" placeholder="Medicine Name" runat="server">
                <asp:DropDownList ID="MType" runat="server">
                        <asp:ListItem Text="Sirop" Value="Sirop"></asp:ListItem>
                        <asp:ListItem Text="Tablets" Value="Tablets"></asp:ListItem>
                        <asp:ListItem Text="Injections" Value="Injections"></asp:ListItem>
                        <asp:ListItem Text="Perfusion" Value="Perfusion"></asp:ListItem>
                </asp:DropDownList> 
                <input type="number" name="" id="MQty" placeholder="Quantity" runat="server">    
                <input type="number" name="" id="MPrice" placeholder="Price" runat="server">   
                <asp:DropDownList ID="MMan" runat="server">
                        <asp:ListItem Text="Shalina" Value="Shalina"></asp:ListItem>
                        <asp:ListItem Text="IndiaMed" Value="IndiaMed"></asp:ListItem>
                        <asp:ListItem Text="KarnaMed" Value="KarnaMed"></asp:ListItem>
                        <asp:ListItem Text="Phizer" Value="Phizer"></asp:ListItem>
                        <asp:ListItem Text="DelphyMed" Value="DelphyMed"></asp:ListItem>
                </asp:DropDownList> 
                   
        </div><br><br>
        <div id="BtDiv" class="auto-style1">
           <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click"   style="background-color:#148b0b;width:100px;color:white;height:30px;border-radius:10px;border:none"/>
           <asp:Button ID="EditBtn" runat="server" Text="Edit" style="background-color:#148b0b;width:100px;color:white;height:30px;border-radius:10px;border:none" OnClick="EditBtn_Click"/>
           <asp:Button ID="DeleteBtn" runat="server" Text="Delete" style="background-color:#148b0b;width:100px;color:white;height:30px;border-radius:10px;border:none" OnClick="DeleteBtn_Click"/>
        </div><br /><br />
        <div id ="GVDiv">
            <asp:GridView ID="MedGV" runat="server" CssClass="table table-condesed table-hover" OnSelectedIndexChanged="MedGV_SelectedIndexChanged" AutoGenerateSelectButton="True" style="left: 1%; top: 0px; width: 1061px">
            </asp:GridView>

        </div>
    </div>
</body>
</html>
</asp:Content>
