<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersbyTrainingType.aspx.cs" Inherits="admin_UserManagement"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - User Management</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/animated.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,400,600,700'
        rel='stylesheet' type='text/css' />
    <link href="/../netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet">
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
    
	
	
	<asp:SqlDataSource ID="SqlUserProfile" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>"
		SelectCommand="SELECT DISTINCT CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name FROM USERPROFILE INNER JOIN TRAININGHISTORY ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGSTATUS ON TRAININGSTATUS.CODE_ID = 'C' AND TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN WHERE (USERPROFILE.COLL_CODE_ISN = @COLL) ORDER BY COLLEGE, DEPARTMENT, NAME" OnSelected="SqlUserProfile_Selected">
        <SelectParameters>
            <asp:ControlParameter ControlID="UserProfileTrainingTypeSearch" DefaultValue="0" Name="COLL" PropertyName="SelectedValue" />
        </SelectParameters>
	</asp:SqlDataSource>
			
        <asp:SqlDataSource ID="SqlAddUser" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT LAST_NAME, FIRST_NAME, EMAIL FROM USERPROFILE WHERE EMAIL = @EMAIL">
       <SelectParameters>
           <asp:Parameter Name="EMAIL" Type="String" />
	   </SelectParameters>
        </asp:SqlDataSource>
		
        <asp:SqlDataSource ID="SqlUserCollegeSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_ISN, CODE_ID, CODE_DESCRIPTION FROM CODE WHERE (CODE_TYPE = 'COLL') ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlUserTrainingSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_ISN, CODE_ID, CODE_DESCRIPTION FROM CODE WHERE (CODE_TYPE = 'TRAINTYP') ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

		 <br />
		
        <asp:SqlDataSource ID="SqlUserDeptSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE.CODE_ISN, CODE.CODE_ID, CODE.CODE_DESCRIPTION FROM CODE INNER JOIN CODE AS DEPT ON CODE.CODE_TYPE = 'USER' + DEPT.CODE_ID WHERE (DEPT.CODE_ISN = @CODE_ISN) ORDER BY CODE.CODE_DESCRIPTION">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserProfileCollegeSearch" Name="CODE_ISN" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>

		 <asp:SqlDataSource ID="SqlCollegeDetails" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE CODE_TYPE = 'COLL'">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE (CODE_TYPE = 'COLL')">
        </asp:SqlDataSource>
	

        <asp:SqlDataSource ID="SqlDepartmentDetails" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE CODE_TYPE = '-1'">
        </asp:SqlDataSource>

	   		
			<br/>
                <asp:ScriptManager ID="smUserProfile" runat="server" />

                <asp:UpdatePanel ID="upUserProfile" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">

              <div class="form-inline">
                
                <asp:DropDownList ID="UserProfileTrainingTypeSearch" runat="server" OnSelectedIndexChanged="UserProfileTrainingTypeSearch_SelectedIndexChanged" AutoPostBack="true" CausesValidation="false" CssClass="form-control" ToolTip="Select a training type and click Search" DataSourceID="SqlUserTrainingSearch" EnableViewState="false" AppendDataBoundItems="true" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text="- Select Training Type - click Search -" Value="-1"></asp:ListItem></asp:DropDownList> &nbsp;
                  <asp:DropDownList ID="UserProfileCollegeSearch" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CausesValidation="false" CssClass="form-control" DataSourceID="SqlUserCollegeSearch" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN" EnableViewState="false" Height="30px" ToolTip="Select a college and click Search" Width="300px">
                      <asp:ListItem Text="- Select a College - click Search -" Value="-1"></asp:ListItem>
                  </asp:DropDownList>
                 &nbsp; 
                  <asp:DropDownList ID="UserProfileDeptSearch" runat="server" CausesValidation="false" CssClass="form-control" ToolTip="Select a department and click search" DataSourceID="SqlUserDeptSearch" EnableViewState="false" AppendDataBoundItems="true" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text="- Select a Department - click Search" Value="-1"></asp:ListItem></asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="btnUserSearch" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Click to search the selected user" Height="30px" OnClick="btnUserSearch_Click" Text="Search" Width="75px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUserClear" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" ToolTip="Click to clear search" OnClick="btnUserClear_Click" Text="Clear" Width="75px" />
                &nbsp;&nbsp;

              </div>
		      <br />

              <center> <asp:Label ID="totalUser" runat="server" Text="Number of user(s) trained:  "> </asp:Label>
                       <asp:Label ID="totalUserValue" Font-Bold="true" runat="server" ></asp:Label>
              </center>
              <br />

			<asp:GridView ID="gvUserProfile" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%" PageSize="25" DataSourceID="SqlUserProfile" CellPadding="4" OnRowCreated="gvUserProfile_RowCreated"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
					<asp:BoundField DataField="COLLEGE" HeaderText="College" SortExpression="COLLEGE" ItemStyle-HorizontalAlign="Left" >
                    </asp:BoundField>
					<asp:BoundField DataField="DEPARTMENT" HeaderText="Department" SortExpression="DEPARTMENT" ItemStyle-HorizontalAlign="Left" >
                    </asp:BoundField>
					<asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
					
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
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			</asp:GridView>
           </div>
			<br />
			
                        
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvUserProfile" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
               

           	
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

    <a href="#" class="back-to-top">UP </a>
        
    </form>
</body>
</html>
