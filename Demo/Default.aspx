<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    <form id="form1">
    <h6 style="color:white; font-size:medium; font-weight: bolder;">
       Hello</h6>
<table style="color:White;margin-top:25px" >
   
    <tr style="color:black">
        <th scope="col">Id</th>
        <th scope="col">Name</th>
        <th scope="col">Email</th>
        <th scope="col">Father Name</th>
    </tr>
    <tr style="color:black">
    <td  > 
      <asp:TextBox ID="TextBox1" class="form-control" placeholder="Valid Id" runat="server"></asp:TextBox>
      </td>
     <td> 
     <asp:TextBox ID="TextBox2" class="form-control" placeholder="Valid Name" runat="server"></asp:TextBox>
     </td>
      <td>
      <asp:TextBox ID="TextBox3" class="form-control" placeholder="Valid Email" runat="server"></asp:TextBox>
      </td>
       <td>
       <asp:TextBox ID="TextBox4" class="form-control" placeholder="Valid FatherName" runat="server"></asp:TextBox>
       
       
       </td>
    </tr>
  
      
   </table>  <br/>
        
       <asp:Button ID="AddProduct" runat="server" style="color:White" Text="Add Data" 
            onclick="AddProduct_Click" class="btn btn-primary" />

    
   <div style="margin-top:20px;margin-left:10px;">
   
  
    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="white" />
    <Columns>
    <asp:BoundField  HeaderStyle-Width="120px" HeaderText="Id" DataField="Id"/>
     <asp:BoundField HeaderStyle-Width="120px" HeaderText="Name" DataField="Name"/>
     <asp:BoundField HeaderStyle-Width="120px" HeaderText="Email" DataField="Email"/>
     <asp:BoundField  HeaderStyle-Width="120px" HeaderText="Father Name" DataField="FatherName"/>
    </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
       <br />
    
    <div  style="margin-top:10px;">
    <asp:Button ID="btnsubmit" runat="server" style="color:White" 
            class="btn btn-success" Text="Save Data"  onclick="btnsubmitProducts_Click" />
    </div>
    </form>
</asp:Content>
