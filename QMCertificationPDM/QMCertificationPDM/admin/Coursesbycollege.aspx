<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Coursesbycollege.aspx.cs" Inherits="admin_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - Course Management</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/animated.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,400,600,700'
        rel='stylesheet' type='text/css' />
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet" />
    <link href="../css/datepicker.css" rel="stylesheet" />
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
       label{margin-left: 20px;}
        #datepicker{width:180px; margin: 0 20px 20px 20px;}
        #datepicker > span:hover{cursor: pointer;}

        .form-control .ajax__calendar_active

        {

             color:blue;

        }

        .form-control .ajax__calendar_hover

        {

                background-color:gray;

        }           

   </style>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">
    <form id="form1" runat="server">
    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <!-- /.navbar-collapse -->
            <center><h4 style="color:white; font-size:25px">Course Development Management System </h4></center>			
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
    
        <asp:SqlDataSource ID="SqlCourseDetail" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, COURSEDETAIL.YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, COURSEDETAIL.DATE_TO_START_REVIEW, COURSEDETAIL.QM_CERTIFIED_DATE, COURSEDETAIL.NOTE AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_START_DATE, PAYMENTPAPERWORKHISTORY.IR_END_DATE, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_START_DATE, PAYMENTPAPERWORKHISTORY.OR_END_DATE, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.NOTE, PAYMENTPAPERWORKHISTORY.ADDED_BY, PAYMENTPAPERWORKHISTORY.ADDED_DATE, PAYMENTPAPERWORKHISTORY.UPDATED_BY, PAYMENTPAPERWORKHISTORY.UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, CODE_2.CODE_DESCRIPTION AS SEMESTER, CODE_3.CODE_DESCRIPTION AS COLLEGE, CODE_4.CODE_DESCRIPTION AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN ORDER BY COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER" OnSelected="SqlCourseSearch_Selected">
        </asp:SqlDataSource>
	
        <asp:SqlDataSource ID="SqlCollegeSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT DISTINCT COURSEDETAIL.COLL_CODE_ISN, CODE_3.CODE_DESCRIPTION AS COLLEGE FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN ORDER BY COLLEGE">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlProgramSearch" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE.CODE_ISN, CODE.CODE_STATUS, CODE.CODE_TYPE, CODE.CODE_ID, CODE.CODE_DESCRIPTION, CODE.ADDED_BY, CODE.ADDED_DATE, CODE.UPDATED_BY, CODE.UPDATED_DATE FROM CODE INNER JOIN CODE AS DEGREE ON DEGREE.CODE_ISN = @CODE_ISN AND CODE.CODE_TYPE = 'DEPT' + DEGREE.CODE_ID ORDER BY CODE.CODE_DESCRIPTION">
            <SelectParameters>
                <asp:ControlParameter ControlID="CollegeSearch" Name="CODE_ISN" PropertyName="SelectedValue" DefaultValue="0" />
            </SelectParameters>
        </asp:SqlDataSource>

         <asp:SqlDataSource ID="SqlContracttype" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_ISN, CODE_DESCRIPTION FROM CODE WHERE CODE_TYPE = 'CONTTYPE' AND CODE_STATUS = 'TRUE' ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

		<asp:SqlDataSource ID="SqlCollegeDetails" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE CODE_TYPE = 'COLL' AND CODE_STATUS = 'TRUE' ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>
		
        <asp:SqlDataSource ID="SqlDepartments" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE CODE_STATUS = 'TRUE' ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

		        <asp:SqlDataSource ID="SqlDepartmentDetails" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE CODE_TYPE = '-1' ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDeveloperDetail" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT LAST_NAME + ', ' + FIRST_NAME AS NAME, USER_ISN FROM USERPROFILE WHERE (IS_DEVELOPER = 'TRUE') AND (USER_STATUS = 'TRUE') ORDER BY LAST_NAME">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlCoordinatorDetail" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT LAST_NAME + ', ' + FIRST_NAME AS NAME, USER_ISN FROM USERPROFILE WHERE (IS_COORDINATOR = 'TRUE') AND (USER_STATUS = 'TRUE') ORDER BY LAST_NAME">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDevelopmentStatus" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN FROM CODE WHERE (CODE_TYPE = 'STATUS') AND CODE_STATUS = 'TRUE'  ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlSemesterTaught" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN FROM CODE WHERE (CODE_TYPE = 'SEMESTER') AND CODE_STATUS = 'TRUE' ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

        
         <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT COURSE_ISN, COURSE_STATUS, COURSE_TYPE_ISN, DEVELOPMENT_STATUS_ISN, COURSE_SUBJECT, COURSE_NUMBER, COURSE_TITLE, COLL_CODE_ISN, DEGREE_PROGRAM_CODE_ISN, SEMESTER_TAUGHT_ISN, YEAR_TAUGHT, DEVELOPER_ISN, COORDINATOR_ISN, DATE_TO_START_REVIEW, QM_CERTIFIED_DATE, NOTE, ADDED_BY, ADDED_DATE, UPDATED_BY, UPDATED_DATE FROM COURSEDETAIL">
        </asp:SqlDataSource>

        
        <asp:SqlDataSource ID="SqlCourseType" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE (CODE_TYPE = 'CRSETYPE') ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

        <br />
                <asp:ScriptManager ID="smCourseDetail" runat="server" EnablePageMethods="True" />

                <asp:UpdatePanel ID="upCourseDetail" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">

              <div class="form-inline">
                <asp:DropDownList ID="CollegeSearch" runat="server" CausesValidation="false" AutoPostBack="true" CssClass="form-control" DataSourceID="SqlCollegeSearch" EnableViewState="false" OnSelectedIndexChanged="CollegeSearch_SelectedIndexChanged" AppendDataBoundItems="true" DataTextField="COLLEGE" DataValueField="COLL_CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text="--- Select a college ---" Value="-1"></asp:ListItem></asp:DropDownList>
                 &nbsp;&nbsp; 
                  <asp:DropDownList ID="ProgramSearch" runat="server" Enabled="false" CausesValidation="false" CssClass="form-control" DataSourceID="SqlProgramSearch" EnableViewState="false" AppendDataBoundItems="true" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text="--- Select a program ---" Value="-1"></asp:ListItem></asp:DropDownList>
                  &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCourseSearch" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Click to search the course" Height="30px" OnClick="btnCourseSearch_Click" Text="Search" Width="75px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCourseClear" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" ToolTip="Click to clear search" OnClick="btnCourseClear_Click" Text="Clear" Width="75px" />
                &nbsp;&nbsp;
		      <br /><br />

              <center> <asp:Label ID="totalCourse" runat="server" Text="Number of course(s) found: "> </asp:Label>
                       <asp:Label ID="totalCourseValue" Font-Bold="true" runat="server" ></asp:Label>
              </center>
              <br />

              
			<asp:GridView ID="gvCourseDetail" Font-Size="10pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="100%" Width="100%" PageSize="25" DataKeyNames="COURSEDETAIL_COURSE_ISN" DataSourceID="SqlCourseDetail" CellPadding="4" 
                				ForeColor="#333333" CssClass="table-responsive">
				<Columns>

                    <asp:TemplateField HeaderText="Status" SortExpression="COURSE_STATUS" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                             <asp:CheckBox ID="chEnabled" runat="server" Checked='<%# Bind("COURSE_STATUS") %>' Style="display: none" Enabled="false"  />
                             <asp:Image ID="imEnabled" Runat="server" ImageUrl='<%# Eval("COURSE_STATUS").Equals(true) ? "../img/y.gif" : "../img/x.gif" %>' AlternateText="CODE ENABLED" Visible="true" />
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

					<asp:BoundField DataField="DEVELOPMENT_STATUS" HeaderText="Development Status" SortExpression="DEVELOPMENT_STATUS" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="COURSE_SUBJECT" HeaderText="Subject" SortExpression="COURSE_SUBJECT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

					<asp:BoundField DataField="COURSE_NUMBER" HeaderText="Course #" SortExpression="COURSE_NUMBER" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

					<asp:BoundField DataField="COURSE_TITLE" HeaderText="Title" SortExpression="COURSE_TITLE" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DEVELOPER" HeaderText="Developer" SortExpression="DEVELOPER" ItemStyle-HorizontalAlign="Center" ReadOnly="True" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

					<asp:BoundField DataField="COORDINATOR" HeaderText="Coordinator" SortExpression="COORDINATOR" ItemStyle-HorizontalAlign="Center" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
					
                    <asp:BoundField DataField="CODE_TYPE" HeaderText="Course Type" SortExpression="CODE_TYPE" />					
                    
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
                        <asp:AsyncPostBackTrigger ControlID="gvCourseDetail" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>

    <!-- Script -->
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/scrolling-nav.js" type="text/javascript"></script>
    <script src="../js/jquery.easing.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            var offset = 220;
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
        
        <script type="text/javascript">
            function onCalendarShown() {

                var cal = $find("cal");
                //Setting the default mode to year
                cal._switchMode("years", true);

                //Iterate every year Item and attach click event to it
                if (cal._yearsBody) {
                    for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                        var row = cal._yearsBody.rows[i];
                        for (var j = 0; j < row.cells.length; j++) {
                            Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                        }
                    }
                }
            }

            function onCalendarHidden() {
                var cal = $find("cal");
                //Iterate every month Item and remove click event from it
                if (cal._yearsBody) {
                    for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                        var row = cal._yearsBody.rows[i];
                        for (var j = 0; j < row.cells.length; j++) {
                            Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                        }
                    }
                }
            }

            function call(eventElement) {
                var target = eventElement.target;
                switch (target.mode) {
                    case "year":
                        var cal = $find("cal");
                        cal._visibleDate = target.date;
                        cal.set_selectedDate(target.date);
                        cal._switchMonth(target.date);
                        cal._blur.post(true);
                        cal.raiseDateSelectionChanged();
                        break;
                }
            }
        </script>

        <script type="text/javascript">
            function ajaxToolkit_CalendarExtenderClientShowing(e) {
                if (!e.get_selectedDate() || !e.get_element().value)
                    e._selectedDate = (new Date()).getDateOnly();
            }
            </script>

        <script type="text/javascript">
            function onCalendarShown() {

                var cal = $find("calen");
                //Setting the default mode to year
                cal._switchMode("years", true);

                //Iterate every year Item and attach click event to it
                if (cal._yearsBody) {
                    for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                        var row = cal._yearsBody.rows[i];
                        for (var j = 0; j < row.cells.length; j++) {
                            Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                        }
                    }
                }
            }

            function onCalendarHidden() {
                var cal = $find("calen");
                //Iterate every month Item and remove click event from it
                if (cal._yearsBody) {
                    for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                        var row = cal._yearsBody.rows[i];
                        for (var j = 0; j < row.cells.length; j++) {
                            Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                        }
                    }
                }
            }

            function call(eventElement) {
                var target = eventElement.target;
                switch (target.mode) {
                    case "year":
                        var cal = $find("calen");
                        cal._visibleDate = target.date;
                        cal.set_selectedDate(target.date);
                        cal._switchMonth(target.date);
                        cal._blur.post(true);
                        cal.raiseDateSelectionChanged();
                        break;
                }
            }

        </script>


    <a href="#" class="back-to-top"> UP </a>
        
        
    </form>
</body>
</html>
