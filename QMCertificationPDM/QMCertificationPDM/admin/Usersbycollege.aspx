<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usersbycollege.aspx.cs" Inherits="admin_UserManagement"%>

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
						<li><a href="CodeManagement.aspx"> CoCodes</a></li>		
					    <li><asp:LinkButton id="logoutLink" OnClick="lnkLogout_Click" CausesValidation="False" runat="server"> <span class="glyphicon glyphicon-user"></span> Log-out</asp:LinkButton></li>
                    </ul>
            </div>

        </div>
        <!-- /.container -->
    </nav>
    
	
	
	<asp:SqlDataSource ID="SqlUserProfile" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>"
		InsertCommand="INSERT INTO USERPROFILE(LAST_NAME, FIRST_NAME, MIDDLE_INITIAL, EMAIL, COLL_CODE_ISN, DEPT_CODE_ISN, PHONE_NUMBER, EXTENSION_NUMBER, USER_STATUS, IS_MASTER_REVIEWER, IS_INTERNAL_REVIEWER, IS_OFFICIAL_REVIEWER, IS_DEVELOPER, IS_COORDINATOR, ADDED_BY, ADDED_DATE, UPDATED_BY, UPDATED_DATE, NOTE) 
		VALUES (@LAST_NAME, @FIRST_NAME, @MIDDLE_INITIAL, @EMAIL, @COLL_CODE_ISN, @DEPT_CODE_ISN, @PHONE_NUMBER, @EXTENSION_NUMBER, @USER_STATUS, @IS_MASTER_REVIEWER, @IS_INTERNAL_REVIEWER, @IS_OFFICIAL_REVIEWER, @IS_DEVELOPER, @IS_COORDINATOR, @ADDED_BY, @ADDED_DATE, @UPDATED_BY, @UPDATED_DATE, @NOTE)"
		SelectCommand="SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN ORDER BY USERPROFILE.LAST_NAME"
		UpdateCommand="UPDATE USERPROFILE SET LAST_NAME = @LAST_NAME, FIRST_NAME = @FIRST_NAME, MIDDLE_INITIAL = @MIDDLE_INITIAL, EMAIL = @EMAIL, COLL_CODE_ISN = @COLL_CODE_ISN, DEPT_CODE_ISN = @DEPT_CODE_ISN, PHONE_NUMBER = @PHONE_NUMBER, EXTENSION_NUMBER = @EXTENSION_NUMBER, USER_STATUS = @USER_STATUS, IS_MASTER_REVIEWER = @IS_MASTER_REVIEWER, IS_INTERNAL_REVIEWER = @IS_INTERNAL_REVIEWER, IS_OFFICIAL_REVIEWER = @IS_OFFICIAL_REVIEWER, IS_DEVELOPER = @IS_DEVELOPER, IS_COORDINATOR = @IS_COORDINATOR, UPDATED_BY = @UPDATED_BY, UPDATED_DATE = @UPDATED_DATE, NOTE = @NOTE WHERE USER_ISN = @USER_ISN" OnSelected="SqlUserProfile_Selected">
         <InsertParameters>
                <asp:Parameter Name="LAST_NAME" Type="String" />
                <asp:Parameter Name="FIRST_NAME" Type="String" />
                <asp:Parameter Name="MIDDLE_INITIAL" Type="String" />
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="COLL_CODE_ISN" Type="String" />
                <asp:Parameter Name="DEPT_CODE_ISN" Type="String" />
                <asp:Parameter Name="PHONE_NUMBER" Type="String" />
				<asp:Parameter Name="EXTENSION_NUMBER" Type="String" />
                <asp:Parameter Name="USER_STATUS" Type="Boolean" />
                <asp:Parameter Name="IS_MASTER_REVIEWER" Type="Boolean" />
                <asp:Parameter Name="IS_INTERNAL_REVIEWER" Type="Boolean" />
                <asp:Parameter Name="IS_OFFICIAL_REVIEWER" Type="Boolean" />
                <asp:Parameter Name="IS_DEVELOPER" Type="Boolean" />
                <asp:Parameter Name="IS_COORDINATOR" Type="Boolean" />
                 <asp:Parameter Name="ADDED_BY" Type="String" />
                <asp:Parameter Name="ADDED_DATE" Type="DateTime" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
				<asp:Parameter Name="NOTE" Type="String" />
            </InsertParameters>
			<UpdateParameters>
                <asp:Parameter Name="LAST_NAME" Type="String" />
                <asp:Parameter Name="FIRST_NAME" Type="String" />
                <asp:Parameter Name="MIDDLE_INITIAL" Type="String" />
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="COLL_CODE_ISN" Type="String"/>
                <asp:Parameter Name="DEPT_CODE_ISN" Type="String" />
                <asp:Parameter Name="PHONE_NUMBER" Type="String" />
				<asp:Parameter Name="EXTENSION_NUMBER" Type="String" />
                <asp:Parameter Name="USER_STATUS" Type="Boolean" />
                <asp:Parameter Name="IS_MASTER_REVIEWER" Type="Boolean" />
                <asp:Parameter Name="IS_INTERNAL_REVIEWER" Type="Boolean" />
                <asp:Parameter Name="IS_OFFICIAL_REVIEWER" Type="Boolean" />
                <asp:Parameter Name="IS_DEVELOPER" Type="Boolean" />
                <asp:Parameter Name="IS_COORDINATOR" Type="Boolean" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
				<asp:Parameter Name="NOTE" Type="String" />
                <asp:Parameter Name="USER_ISN" Type="Int32" />
			</UpdateParameters>
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

		 <br />
		
        <asp:SqlDataSource ID="SqlUserDeptSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE.CODE_ISN, CODE.CODE_ID, CODE.CODE_DESCRIPTION FROM CODE INNER JOIN CODE AS DEPT ON CODE.CODE_TYPE = 'USER' + DEPT.CODE_ID WHERE (DEPT.CODE_ISN = @CODE_ISN) ORDER BY CODE_DESCRIPTION">
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

	
	
	<asp:SqlDataSource ID="SqlTrainingHistory" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>"
		InsertCommand="INSERT INTO TRAININGHISTORY(USER_ISN, TRAINING_CODE_ISN, TRAINING_DATE, NOTE, ADDED_BY, ADDED_DATE, UPDATED_BY, UPDATED_DATE) VALUES (@USER_ISN, @TRAINING_CODE_ISN, @TRAINING_DATE, @NOTE, @ADDED_BY, @ADDED_DATE, @UPDATED_BY, @UPDATED_DATE)"
		SelectCommand="SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, TRAININGHISTORY.NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, CODE.CODE_DESCRIPTION + ' ( ' + CODE.CODE_ID + ')' AS TRAININGS FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN WHERE (TRAININGHISTORY.USER_ISN = @USER_ISN) ORDER BY TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_DATE DESC, TRAININGHISTORY.TRAINING_CODE_ISN"
		UpdateCommand="UPDATE TRAININGHISTORY SET USER_ISN = @USER_ISN, TRAINING_CODE_ISN = @TRAINING_CODE_ISN, TRAINING_DATE = @TRAINING_DATE, NOTE = @NOTE, UPDATED_BY = @UPDATED_BY, UPDATED_DATE = @UPDATED_DATE WHERE (TRAINING_ISN = @TRAINING_ISN)" OnSelected="SqlTrainingHistory_Selected" DeleteCommand="DELETE FROM [TRAININGHISTORY] WHERE [TRAINING_ISN] = @TRAINING_ISN">
         <DeleteParameters>
             <asp:Parameter Name="TRAINING_ISN" Type="Int32" />
         </DeleteParameters>
         <InsertParameters>
                <asp:Parameter Name="USER_ISN" Type="Int32" />
                <asp:Parameter Name="TRAINING_CODE_ISN" Type="Int32" />
                <asp:Parameter Name="TRAINING_DATE" Type="DateTime" />
                <asp:Parameter Name="NOTE" Type="String" />
                <asp:Parameter Name="ADDED_BY" Type="String" />
                <asp:Parameter Name="ADDED_DATE" Type="DateTime" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
            </InsertParameters>
			<UpdateParameters>
                <asp:Parameter Name="USER_ISN" Type="Int32" />
                <asp:Parameter Name="TRAINING_CODE_ISN" Type="Int32"/>
                <asp:Parameter Name="TRAINING_DATE" Type="DateTime" />
                <asp:Parameter Name="NOTE" Type="String" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
                <asp:Parameter Name="TRAINING_ISN" Type="Int32" />
			</UpdateParameters>
        <SelectParameters>
            <asp:Parameter Name="USER_ISN" Type="String" />
        </SelectParameters>
	</asp:SqlDataSource>
			
       		
			<br/>
                <asp:ScriptManager ID="smUserProfile" runat="server" />

                <asp:UpdatePanel ID="upUserProfile" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">

              <div class="form-inline">
                
                <asp:DropDownList ID="UserProfileCollegeSearch" runat="server" AutoPostBack="true" CausesValidation="false" CssClass="form-control" ToolTip="Select a College and click Search" DataSourceID="SqlUserCollegeSearch" EnableViewState="false" AppendDataBoundItems="true" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text=" &nbsp; --- Select a College --- &nbsp;" Value="-1"></asp:ListItem></asp:DropDownList>
                 &nbsp; 
                  <asp:DropDownList ID="UserProfileDeptSearch" runat="server" CausesValidation="false" CssClass="form-control" ToolTip="Select a College to enable" DataSourceID="SqlUserDeptSearch" EnableViewState="false" AppendDataBoundItems="true" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text=" &nbsp; --- Select a Department --- &nbsp;" Value="-1"></asp:ListItem></asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="btnUserSearch" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Click to search the selected user" Height="30px" OnClick="btnUserSearch_Click" Text="Search" Width="75px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUserClear" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" ToolTip="Click to clear search" OnClick="btnUserClear_Click" Text="Clear" Width="75px" />
                &nbsp;&nbsp;

              </div>
		      <br />

              <center> <asp:Label ID="totalUser" runat="server" Text="Number of user(s) found:  "> </asp:Label>
                       <asp:Label ID="totalUserValue" Font-Bold="true" runat="server" ></asp:Label>
              </center>
              <br />

			<asp:GridView ID="gvUserProfile" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%" PageSize="25" DataKeyNames="USER_ISN" DataSourceID="SqlUserProfile" CellPadding="4" OnRowDataBound="gvUserProfile_RowDataBound" OnRowCreated="gvUserProfile_RowCreated"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkDisplay" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/view.png" AlternateText="View Details" ToolTip="Click to view user's profile." CausesValidation="false" onclick="lnkDisplay_Click" ></asp:ImageButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Status" SortExpression="USER_STATUS" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <asp:CheckBox ID="chEnabled" runat="server" Checked='<%# Bind("USER_STATUS") %>' Style="display: none" Enabled="false"  />
                             <asp:Image ID="imEnabled" Runat="server" ImageUrl='<%# Eval("USER_STATUS").Equals(true) ? "../img/y.gif" : "../img/x.gif" %>' AlternateText="CODE ENABLED" Visible="true" />
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
					<asp:BoundField DataField="USER_ISN" HeaderText="USER_ISN" InsertVisible="False" Visible="false" ReadOnly="True" SortExpression="USER_ISN" />
                    <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" SortExpression="LAST_NAME" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
					<asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" SortExpression="FIRST_NAME" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
					<asp:BoundField DataField="MIDDLE_INITIAL" HeaderText="M.I." NullDisplayText=" " SortExpression="MIDDLE_INITIAL" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="COLLEGE" HeaderText="COLLEGE" SortExpression="COLLEGE" NullDisplayText=" " ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
					<asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" NullDisplayText=" " SortExpression="DEPARTMENT" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

					 <asp:BoundField DataField="PHONE_NUMBER" HeaderText="PH. #" NullDisplayText=" " HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" SortExpression="PHONE_NUMBER" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
					<asp:BoundField DataField="EXTENSION_NUMBER" HeaderText="Extn. #" SortExpression="EXTENSION_NUMBER" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" NullDisplayText=" " ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="M.R." SortExpression="IS_MASTER_REVIEWER" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chMasterReviewer" runat="server" Checked='<%# Bind("IS_MASTER_REVIEWER") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="I.R." SortExpression="IS_INTERNAL_REVIEWER" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chInternalReviewer" runat="server" Checked='<%# Bind("IS_INTERNAL_REVIEWER") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="O.R." SortExpression="IS_OFFICIAL_REVIEWER" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chOfficialReviewer" runat="server" Checked='<%# Bind("IS_OFFICIAL_REVIEWER") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEVR." SortExpression="IS_DEVELOPER" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chDeveloper" runat="server" Checked='<%# Bind("IS_DEVELOPER") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ITC" SortExpression="IS_COORDINATOR" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chCoordinator" runat="server" Checked='<%# Bind("IS_COORDINATOR") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
					<asp:BoundField DataField="ADDED_BY" HeaderText="ADDED_BY" SortExpression="ADDED_BY" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
					<asp:BoundField DataField="ADDED_DATE" HeaderText="ADDED_DATE" SortExpression="ADDED_DATE" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
					<asp:BoundField DataField="UPDATED_BY" HeaderText="UPDATED_BY" SortExpression="UPDATED_BY" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
					<asp:BoundField DataField="UPDATED_DATE" HeaderText="UPDATED_DATE" SortExpression="UPDATED_DATE" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
					<asp:BoundField DataField="NOTE" HeaderText="NOTE" NullDisplayText=" " SortExpression="NOTE" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText = "Training(s)" ItemStyle-HorizontalAlign="Center" >
					   <ItemTemplate>
						   <asp:ImageButton ID="lnkTrainings" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/training.png" AlternateText="User Trainings" CausesValidation="false" ToolTip="Click to trainings completed by user." onclick="lnkTrainings_Click" ></asp:ImageButton>
						</ItemTemplate>
					    <ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					
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
                        <asp:AsyncPostBackTrigger ControlID="gvUserProfile" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
               

           <!-- Modal -->


 <!-- Modal -->

    <div id="displayModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-xs">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &timesbutton>  
                    <center><h4 style="color:white" class="modal-title">View User Profile</h4></center>
                </div>
                     <asp:UpdatePanel ID="upDisplayUser" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div role="form" >
                        <div class="form-inline" >
                            <b><asp:Label ID="lbldisplayActive" runat="server" align="right" Width="150" Text="Status: "></asp:Label></b>
                            <asp:RadioButtonList ID="rbdisplayActiveList" CssClass="radio" RepeatDirection="Horizontal" Enabled="false" runat="server" Width="200">
                                                    <asp:ListItem>&nbsp; Available &nbsp;&nbsp; </asp:ListItem>
                                                    <asp:ListItem>&nbsp; Unavailable</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <br />
					<div class="form-inline">
                            <b><asp:Label ID="lbldisplayLastName" runat="server" align="right" Width="150" Text="Last name: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayLastName" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayFirstName" runat="server" align="right" Width="150" Text="First name: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayFirstName" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayMiddleInitial" runat="server" align="right" Width="150"  Text="Middle initial: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayMiddleInitial" runat="server" Width="50" NullDisplayText=" " ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
						</div>
                         <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayEmail" runat="server" align="right" Width="150" Text="Email: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayEmail" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
						 <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayCollege" runat="server" align="right" Width="150" Text="College: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayCollege" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayDepartment" runat="server" align="right" Width="150" Text="Department: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayDepartment" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
						 <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayContactNumber" runat="server" align="right" Width="150" Text="Phone number: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayContactNumber" runat="server"  Width="180" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                            <b><asp:Label ID="lbldisplayExtension" runat="server" align="right" Text="Ext. #: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayExtension" NullDisplayText=" " runat="server" Width="90" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayRole" runat="server" align="right" Width="150" Text="Role: "></asp:Label></b>
                            <asp:CheckBox ID="ckdisplayMasterReviewer" CssClass="checkbox" runat="server" Enabled="false" /> 
                            <asp:Label ID="lbldisplayMasterReviewer" runat="server" align="left" Text="M.R." Width="30"></asp:Label> &nbsp;
                            <asp:CheckBox ID="ckdisplayInternalReviewer" CssClass="checkbox" runat="server"  Enabled="false" />
                            <asp:Label ID="lbldisplayInternalReviewer" runat="server" align="left" Text="I.R." Width="30"></asp:Label> &nbsp;
                            <asp:CheckBox ID="ckdisplayOfficialReviewer" CssClass="checkbox" runat="server" Enabled="false" />
                            <asp:Label ID="lbldisplayOfficialReviewer" runat="server" align="left" Text="O.R." Width="30"></asp:Label> &nbsp;
                            <asp:CheckBox ID="ckdisplayDeveloper" CssClass="checkbox" runat="server" Enabled="false" />
                            <asp:Label ID="lbldisplayDeveloper" runat="server" align="left" Text="DEVR." Width="40"></asp:Label> &nbsp;
                            <asp:CheckBox ID="ckdisplayCoordinator" CssClass="checkbox" runat="server" Enabled="false" />
                            <asp:Label ID="lbldisplayCoordinator" runat="server" align="left" Text="ITC" Width="30"></asp:Label>
                        </div>
                        <br />
                        <div class="form-inline" text-align:right;>
                            <b><asp:Label ID="lbldisplayNote" runat="server" align="right" Width="150" Text="Note: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayNote" NullDisplayText=" " runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent" TextMode="MultiLine"></asp:TextBox>
                        </div>
                         <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayAddedBy" runat="server" align="right" Width="150" Text="Added by: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayAddedBy" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>

                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayAddedDate" runat="server" align="right" Width="150"></asp:Label></b>
                            <asp:TextBox ID="txtdisplayAddedDate" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayUpdatedBy" runat="server" align="right" Width="150" Text="Updated by: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayUpdatedBy" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>

                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayUpdatedDate" runat="server" align="right" Width="150"></asp:Label></b>
                            <asp:TextBox ID="txtdisplayUpdatedDate" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-group">
							<div class="modal-footer" >
								<center> <asp:Button ID="btndisplayClose" runat="server" CssClass="btn btn-primary btn-sm" data-dismiss="modal" CausesValidation="false" Height="30px" Text="Close" Width="75px" /></center>
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

    <div id="trainingModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-xs">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times </button>  
                    <center><h4 style="color:white" class="modal-title">Trainings History</h4></center>
                </div>
                     <asp:UpdatePanel ID="upTrainings" runat="server">
                    <ContentTemplate>
                <div class="modal-body" align="center" runat="server">
                    <div role="form" >
                        <center><b><asp:Label ID="lblTotalTrainingsCount" runat="server" ></asp:Label></b><asp:Label ID="lblUserNameHeading" runat="server" align="right" Text=" training(s) found for " Width="150"></asp:Label>
                            <asp:Label ID="lblUserName" runat="server" ></asp:Label>
                        </center>
                        <br />
                        <div class="form-inline" >
                            <asp:GridView ID="gvTrainings" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%" PageSize="15" DataKeyNames="TRAINING_ISN" DataSourceID="SqlTrainingHistory" CellPadding="4" OnRowCreated="gvTrainings_RowCreated"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                    
                    <asp:BoundField DataField="TRAINING_DATE" DataFormatString="{0:MM/dd/yyyy}" NullDisplayText=" " HeaderText="Training Date" SortExpression="TRAINING_DATE" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRAININGS" HeaderText="Training Description" SortExpression="TRAININGS"  />
					
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
                        <div class="form-group">
							<div class="modal-footer" >
								<center> <asp:Button ID="btntrainingClose" runat="server" CssClass="btn btn-primary btn-sm" data-dismiss="modal" CausesValidation="false" Height="30px" Text="Close" Width="75px" /></center>
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

    <a href="#" class="back-to-top">UP </a>
        
    </form>
</body>
</html>
