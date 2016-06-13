<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/admin/CodeManagement.aspx.cs" Inherits="admin_CodeManagement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - CODE Management</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/animated.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,400,600,700'
        rel='stylesheet' type='text/css' />
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesnt work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
    <style type="text/css">
       .header { position:static;
       }
   </style>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">
    <form id="form1" runat="server">
    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <!-- /.navbar-collapse -->
            <center><h4 style="color:white; font-size:25px">Course Development Management System</h4></center>			
            <div class="collapse navbar-collapse navbar-right">
                    <ul class="nav navbar-nav">
						<li><a href="default.aspx"><span class="glyphicon glyphicon-home"></span> Home</a></li>
                        <li><a href="CourseManagement.aspx"> Courses</a></li>
                        <li><a href="Report.aspx"> Reports</a></li>
						<li><a href="UserManagement.aspx"> Users</a></li>
                        <li><a href="Trainings.aspx"> Trainings</a></li>						
						<li><a href="CodeManagement.aspx"> Codes</a></li>		
					    <li><asp:LinkButton id="logoutLink" OnClick="lnkLogout_Click" CausesValidation="False" runat="server"> <span class="glyphicon glyphicon-user"></span> Log-out</asp:LinkButton></li>
                    </ul>
            </div>

        </div>
        <!-- /.container -->
    </nav>
	
	<asp:SqlDataSource ID="SqlCode" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>"
		InsertCommand="INSERT INTO [CODE] ([CODE_STATUS], [CODE_TYPE], [CODE_ID], [CODE_DESCRIPTION], [ADDED_BY], [ADDED_DATE], [UPDATED_BY], [UPDATED_DATE]) VALUES (@CODE_STATUS, @CODE_TYPE, @CODE_ID, @CODE_DESCRIPTION, @ADDED_BY, @ADDED_DATE, @UPDATED_BY, @UPDATED_DATE)"
		SelectCommand="SELECT *  FROM [CODE] ORDER BY [CODE_TYPE], [CODE_ID]"
		UpdateCommand="UPDATE [CODE] SET [CODE_STATUS] = @CODE_STATUS, [CODE_TYPE] = @CODE_TYPE, [CODE_ID] = @CODE_ID, [CODE_DESCRIPTION] = @CODE_DESCRIPTION, [UPDATED_BY] = @UPDATED_BY, [UPDATED_DATE] = @UPDATED_DATE WHERE [CODE_ISN] = @CODE_ISN" OnSelected="SqlCode_Selected">
         <InsertParameters>
                <asp:Parameter Name="CODE_STATUS" Type="Boolean" />
                <asp:Parameter Name="CODE_TYPE" Type="String" />
                <asp:Parameter Name="CODE_ID" Type="String" />
                <asp:Parameter Name="CODE_DESCRIPTION" Type="String" />
                <asp:Parameter Name="ADDED_BY" Type="String" />
                <asp:Parameter Name="ADDED_DATE" Type="DateTime" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
            </InsertParameters>
			<UpdateParameters>
                <asp:Parameter Name="CODE_STATUS" Type="Boolean" />
                <asp:Parameter Name="CODE_TYPE" Type="String" />
                <asp:Parameter Name="CODE_ID" Type="String" />
                <asp:Parameter Name="CODE_DESCRIPTION" Type="String" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
                <asp:Parameter Name="CODE_ISN" Type="Int32" />
			</UpdateParameters>
	</asp:SqlDataSource>
			
        <asp:SqlDataSource ID="SqlAddCode" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT * FROM CODE WHERE CODE_TYPE = @CODE_TYPE  AND CODE_ID = @CODE_ID">
       <SelectParameters>
		   <asp:Parameter Name="CODE_TYPE" />
           <asp:Parameter Name="CODE_ID" />
	   </SelectParameters>
        </asp:SqlDataSource>

         <asp:SqlDataSource ID="SqlCodeTypeSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT DISTINCT CODE_TYPE FROM CODE ">
        </asp:SqlDataSource>

         <asp:SqlDataSource ID="SqlCodeIdSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT (CODE_ID + CASE WHEN CODE_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END) AS Name, CODE_ID FROM CODE WHERE CODE_TYPE = @CODE_TYPE">
             <SelectParameters>
				<asp:ControlParameter ControlID="CodeTypeSearch" Name="CODE_TYPE" PropertyName="SelectedValue" Type="String"/>
			</SelectParameters>
        </asp:SqlDataSource>
			
         <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT * FROM CODE "> </asp:SqlDataSource>

        <br />
                <asp:ScriptManager ID="smCode" runat="server" />

                <asp:UpdatePanel ID="upCode" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">

              <div class="form-inline">
                <asp:DropDownList ID="CodeTypeSearch" runat="server" CausesValidation="false" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CodeTypeSearch_SelectedIndexChanged" DataSourceID="SqlCodeTypeSearch" EnableViewState="false" AppendDataBoundItems="true" DataTextField="CODE_TYPE" DataValueField="CODE_TYPE"  Height="30px">
                 <asp:ListItem Text="--- Select a code type and click Search ---" Value="%"></asp:ListItem></asp:DropDownList> &nbsp; 
                    <asp:DropDownList ID="CodeIdSearch" runat="server" CausesValidation="false" CssClass="form-control" DataSourceID="SqlCodeIdSearch"  Enabled="false" EnableViewState="false" AppendDataBoundItems="true" DataTextField="Name" DataValueField="CODE_ID"  Height="30px">
                 <asp:ListItem Text="--- Select a code and click Search ---" Value="%"></asp:ListItem></asp:DropDownList>
                
                </strong> &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCodeFilter" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" OnClick="btnCodeFilter_Click" Text="Search" Width="75px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCodeClear" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" OnClick="btnCodeClear_Click" Text="Clear" Width="75px" />
                &nbsp;&nbsp; | &nbsp 
                <asp:Button ID="btnAddCode" CssClass="btn btn-primary btn-sm" runat="server" CausesValidation="false"  Height="30px" Width="85px" Text="Add Code" Enabled="true"  onclick="btnAddCode_Click" />

              </div>
		      <br />

              <center> <asp:Label ID="totalCode" runat="server" Text="Number of code(s) found: "> </asp:Label>
                       <asp:Label ID="totalCodeValue" Font-Bold="true" runat="server" ></asp:Label>
              </center>
              <br />

			<asp:GridView ID="gvCode" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%" PageSize="25" DataKeyNames="CODE_ISN" DataSourceID="SqlCode" CellPadding="4" OnRowCreated="gvCode_RowCreated"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkDisplay" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/view.png" AlternateText="View Details" CausesValidation="false" onclick="lnkDisplay_Click" ></asp:ImageButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText = "Edit" ItemStyle-HorizontalAlign="Center" >
					   <ItemTemplate>
						   <asp:ImageButton ID="lnkEdit" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/edit.png" AlternateText="Edit User" CausesValidation="false" onclick="lnkEdit_Click" ></asp:ImageButton>
						</ItemTemplate>
					    <ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="CODE_STATUS">
                        <ItemTemplate>
                            <asp:CheckBox ID="chEnabled" runat="server" Checked='<%# Bind("CODE_STATUS") %>' Style="display: none"  Enabled="false" />
                            <asp:Image ID="imEnabled" Runat="server" ImageUrl='<%# Eval("CODE_STATUS").Equals(true) ? "../img/y.gif" : "../img/x.gif" %>' AlternateText="CODE ENABLED" Visible="true" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CODE_TYPE" HeaderText="Code Type" SortExpression="CODE_TYPE" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
					<asp:BoundField DataField="CODE_ID" HeaderText="Code ID" SortExpression="CODE_ID" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
					<asp:BoundField DataField="CODE_DESCRIPTION" HeaderText="Code Description" SortExpression="CODE_DESCRIPTION" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="ADDED_BY" HeaderText="Added By" NullDisplayText=" " SortExpression="ADDED_BY" HeaderStyle-CssClass="hide" >
					<ItemStyle HorizontalAlign="Left" CssClass="hide"/>
                    </asp:BoundField>
					<asp:BoundField DataField="ADDED_DATE" HeaderText="Added Date" NullDisplayText=" " SortExpression="ADDED_DATE" HeaderStyle-CssClass="hide"  >
					<ItemStyle HorizontalAlign="Center" CssClass="hide"/>
                    </asp:BoundField>
					<asp:BoundField DataField="UPDATED_BY" HeaderText="Updated By" NullDisplayText=" " SortExpression="UPDATED_BY"  HeaderStyle-CssClass="hide" >
					<ItemStyle HorizontalAlign="Center" CssClass="hide"/>
                    </asp:BoundField>
					<asp:BoundField DataField="UPDATED_DATE" HeaderText="Updated Date" NullDisplayText=" " SortExpression="UPDATED_DATE" HeaderStyle-CssClass="hide"  >
					<ItemStyle HorizontalAlign="Center" CssClass="hide" />
                    </asp:BoundField>
				</Columns>
                    <PagerSettings Position="TopAndBottom" Visible="true" 
                        FirstPageText="First Page" LastPageText="Last Page" 
                        Mode="NumericFirstLast" />
                    <PagerStyle CssClass="pager-row" BackColor="#284775" HorizontalAlign="Center" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle CssClass="header" BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" 
                        Font-Bold="True" BorderStyle="None" />                
                    <AlternatingRowStyle BackColor="White" ForeColor="Black" />
                    <AlternatingRowStyle BackColor="#D3D3D3" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			</asp:GridView>
           </div>
			<br />
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvCode" EventName="RowCommand" />
						<asp:AsyncPostBackTrigger ControlID="btnAddCode" EventName="Click" />
                        <asp:AsyncPostbackTrigger ControlID="CodeTypeSearch" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

           <!-- Modal -->

        <!-- Modal -->
    <div id="editModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-xs">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times </button>
                        <center><h4 style="color:white" class="modal-title">Edit Code</h4></center>
                </div>
                <asp:UpdatePanel ID="upEditCode" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div role="form" align="left">
                        <div class="form-group">
							<asp:Label ID="editError" runat="server" /> 
						</div>
                        <div class="form-inline">
                            <asp:HiddenField ID="codeisn" runat="server" Visible="false"></asp:HiddenField>
                            <asp:Label ID="lblEnabled" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code status: "></asp:Label>
                            <asp:RadioButtonList ID="rbCodeEnablelist" CssClass="radio" RepeatDirection="Horizontal" runat="server" Width="250">
                                                    <asp:ListItem Text="Available&nbsp;" Value="true"></asp:ListItem>
                                                    <asp:ListItem  Text=" Unavailable" Value="false"></asp:ListItem>
                            </asp:RadioButtonList> 
                        </div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lblCodeType" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code type: "></asp:Label>  
                            <asp:TextBox ID="txtCodeType" runat="server" MaxLength="6" Width="250" CssClass="form-control"></asp:TextBox>
                            </div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lblCodeId" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code id: "></asp:Label>
                            <asp:TextBox ID="txtCodeId" runat="server" Width="250" MaxLength="10" CssClass="form-control"></asp:TextBox>
                            </div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lblCodeDescription" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code description: "></asp:Label>
                            <asp:TextBox ID="txtCodeDescription" runat="server" Width="250" MaxLength="150" TextMode="MultiLine" CssClass="form-control" autofocus="TRUE"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="editvalidation" ID="rfvCodeDescription" runat="server" ControlToValidate="txtCodeDescription"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        <br />
                        
                        <div class="form-group">
							<div class="modal-footer" >
								<center><asp:Button ID="btnUpdateCode" ValidationGroup="editvalidation" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="true" OnClick="btnUpdateCode_Click" Height="30px" Text="Update"  Width="75px" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary btn-sm" data-dismiss="modal" CausesValidation="false" Height="30px" Text="Cancel" Width="75px" /></center>
							</div>
                        </div>
                    </div>
                </div>
                        </ContentTemplate>
                   
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
	<!-- End of Modal Section -->

                <div id="addModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-xs">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times</button>
                        <center><h4 style="color:white" class="modal-title">Add Code</h4></center>
                </div>
                <asp:UpdatePanel ID="upAddCode" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div role="form" align="left">
                        <div class="form-group">
							<asp:Label ID="addError" runat="server" /> 
						</div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lbladdEnable" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code status: "></asp:Label>
                            <asp:RadioButtonList ID="rbaddEnableList" CssClass="radio" RepeatDirection="Horizontal" runat="server" Width="250">
                                                    <asp:ListItem Text="Available &nbsp;" Value="true"></asp:ListItem>
                                                    <asp:ListItem  Text="Unavailable" Value="false"></asp:ListItem>
                            </asp:RadioButtonList> 
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvrbEnabled" runat="server" ControlToValidate="rbaddEnableList"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lbladdCodeType" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code type: "></asp:Label>  
                            <asp:TextBox ID="txtaddCodeType" MaxLength="8" runat="server" Width="250" CssClass="form-control" autofocus="TRUE"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvaddCodeType" runat="server" ControlToValidate="txtaddCodeType"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lbladdCodeId" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code id: "></asp:Label>
                            <asp:TextBox ID="txtaddCodeId" runat="server" MaxLength="10" Width="250" CssClass="form-control"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvaddCodeId" runat="server" ControlToValidate="txtaddCodeId"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        <br />
                        <div class="form-inline">
                            <asp:Label ID="lbladdCodeDescription" runat="server" align="Right" Font-Bold="true" Width="150" Text="*Code description: "></asp:Label>
                            <asp:TextBox ID="txtaddCodeDescription" runat="server" MaxLength="150" Width="250" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvaddCodeDescription" runat="server" ControlToValidate="txtaddCodeDescription"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        
                        <br />
                        <div class="form-group">
							<div class="modal-footer" >
								<center><asp:Button ID="btnaddSave" runat="server" CssClass="btn btn-primary btn-sm" ValidationGroup="addvalidation" CausesValidation="true" OnClick="btnaddSave_Click" Height="30px" Text="Save"  Width="75px" />
                                        <asp:Button ID="btnaddClose" runat="server" CssClass="btn btn-primary btn-sm" data-dismiss="modal" CausesValidation="false" Height="30px" Text="Cancel" Width="75px" /></center>
								</center>
							</div>
                        </div>
                    </div>
                </div>
                        </ContentTemplate>
                   
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
	<!-- End of Modal Section -->

 <!-- Modal -->
    <div id="displayModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-xs">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times
                    </button>
                    <center>
                        <h4 style="color:white" class="modal-title">View Code</h4>
                    </center>
                </div>
                <asp:UpdatePanel ID="upDisplayCode" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div role="form" align="left">
                                 <div class="form-inline">
                                    <asp:Label ID="lbldisplayEnable" runat="server" align="Right" Font-Bold="true" Width="150" Text="Code status: "></asp:Label>
                                    <asp:RadioButtonList ID="rbdisplayEnableList" CssClass="radio" RepeatDirection="Horizontal" Enabled="false" runat="server" Width="200">
                                        <asp:ListItem>&nbsp;Available&nbsp;</asp:ListItem>
                                        <asp:ListItem>&nbsp;Unavailable</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayCodeType" runat="server" align="Right" Font-Bold="true" Width="150" Text="Code type: "></asp:Label>
                                    <asp:TextBox ID="txtdisplayCodeType" runat="server" Width="250" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayCodeId" runat="server" align="Right" Font-Bold="true" Width="150" Text="Code id: "></asp:Label>
                                    <asp:TextBox ID="txtdisplayCodeId" runat="server" Width="250" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayCodeDescription" runat="server" align="Right" Font-Bold="true" Width="150" Text="Code description: "></asp:Label>
                                    <asp:TextBox ID="txtdisplayCodeDescription" runat="server" Width="250" TextMode="MultiLine" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                                <br />
                               
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayAddedBy" runat="server" align="Right" Font-Bold="true" Width="150" Text="Added by: "></asp:Label>
                                    <asp:TextBox ID="txtdisplayAddedBy" runat="server" Width="250" ReadOnly="true" BorderStyle="None" BackColor="Transparent" ></asp:TextBox>
                                </div>
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayAddedDate" runat="server" align="Right" Font-Bold="true" Width="150" Text=""></asp:Label>
                                    <asp:TextBox ID="txtdisplayAddedDate" runat="server" Width="250" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayUpdatedBy" runat="server" align="Right" Font-Bold="true" Width="150" Text="Updated by: "></asp:Label>
                                    <asp:TextBox ID="txtdisplayUpdatedBy" runat="server" Width="250" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                                <div class="form-inline">
                                    <asp:Label ID="lbldisplayUpdatedDate" runat="server" align="Right" Font-Bold="true" Width="150" Text=""></asp:Label>
                                    <asp:TextBox ID="txtdisplayUpdatedDate" runat="server" Width="250" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                                <br />
                                <div class="form-group">
                                    <div class="modal-footer">
                                        <center>
                                            <asp:Button ID="btndisplayClose" runat="server" CssClass="btn btn-primary btn-sm" data-dismiss="modal" CausesValidation="false" Height="30px" Text="Close" Width="75px" /></center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
        </div>
    </div>
	<!-- End of Modal Section -->
            	
    <!-- Script -->
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/scrolling-nav.js" type="text/javascript"></script>
    <script src="../js/jquery.easing.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            var offset = 110;
            var duration = 500;
            jQuery(window).scroll(function () {
                if (jQuery(this).scrollTop() > offset) {
                    jQuery('.back-to-top').fadeIn(duration);
                } else {
                    jQuery('.back-to-top').fadeOut(duration);
                }
            });

            jQuery('.back-to-top').click(function (event) {
                event.preventDefault();
                jQuery('html, body').animate({ scrollTop: 0 }, duration);
                return false;
            })
        });
    </script>

    <a href="#" class="back-to-top"> UP </a>

    </form>
</body>
</html>