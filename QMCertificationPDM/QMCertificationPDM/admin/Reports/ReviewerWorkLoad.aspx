<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewerWorkLoad.aspx.cs" Inherits="admin_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - Reviewer Work Load</title>
    <!-- Bootstrap Core CSS -->
    <link href="~/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="~/css/main.css" rel="stylesheet" type="text/css" />
    <link href="~/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="~/css/animated.css" rel="stylesheet" type="text/css" />
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
						<li><a href="../default.aspx"><span class="glyphicon glyphicon-home"></span> Home</a></li>
                        <li><a href="../CourseManagement.aspx"> Courses</a></li>
                		<li><a href="../Report.aspx"> Reports </a></li>
						<li><a href="../UserManagement.aspx"> Users</a></li>
                        <li><a href="../Trainings.aspx"> Trainings</a></li>						
						<li><a href="../CodeManagement.aspx"> Codes</a></li>		
					    <li><asp:LinkButton id="logoutLink" OnClick="lnkLogout_Click" CausesValidation="False" runat="server"> <span class="glyphicon glyphicon-user"></span> Log-out</asp:LinkButton></li>
                    </ul>
            </div>

        </div>
        <!-- /.container -->
    </nav>
	
        
	<asp:SqlDataSource ID="SqlDashboard" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT DISTINCT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS REVIEWERNAME, COUNT(IR.COURSE_ISN) AS IR, COUNT(ER.COURSE_ISN) AS ER, COUNT(IR.COURSE_ISN) + COUNT(ER.COURSE_ISN) AS TOTAL FROM COURSEDETAIL INNER JOIN CODE AS REVIEWESTATUS ON COURSEDETAIL.DEVELOPMENT_STATUS_ISN = REVIEWESTATUS.CODE_ISN INNER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN INNER JOIN USERPROFILE ON PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN = USERPROFILE.USER_ISN OR PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN = USERPROFILE.USER_ISN OR PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN = USERPROFILE.USER_ISN OR PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN = USERPROFILE.USER_ISN OR PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN = USERPROFILE.USER_ISN OR PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN = USERPROFILE.USER_ISN LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY AS IR ON IR.IR_CHAIR_ISN = USERPROFILE.USER_ISN OR IR.IR_REVIEWER2_ISN = USERPROFILE.USER_ISN OR IR.IR_REVIEWER3_ISN = USERPROFILE.USER_ISN LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY AS ER ON ER.OR_CHAIR_ISN = USERPROFILE.USER_ISN OR ER.OR_REVIEWER2_ISN = USERPROFILE.USER_ISN OR ER.OR_REVIEWER3_ISN = USERPROFILE.USER_ISN WHERE (REVIEWESTATUS.CODE_ID = 'IR') OR (REVIEWESTATUS.CODE_ID = 'ER') GROUP BY USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, ER.COURSE_ISN, IR.COURSE_ISN ORDER BY REVIEWERNAME" OnSelected="SqlDashboard_Selected"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlReviewer" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT COURSEDETAIL.COURSE_SUBJECT + ' ( ' + COURSEDETAIL.COURSE_NUMBER + ')' AS COURSE, COURSEDETAIL.COURSE_TITLE, DEVELOPMENTSTATUS.CODE_DESCRIPTION, COORDINATOR.LAST_NAME + ', ' + COORDINATOR.FIRST_NAME AS COORDINATOR_NAME FROM COURSEDETAIL INNER JOIN CODE AS REVIEWESTATUS ON COURSEDETAIL.DEVELOPMENT_STATUS_ISN = REVIEWESTATUS.CODE_ISN INNER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN INNER JOIN USERPROFILE ON PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN = @USER OR PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN = @USER OR PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN = @USER OR PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN = @USER OR PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN = @USER OR PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN = @USER LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY AS IR ON IR.IR_CHAIR_ISN = @USER OR IR.IR_REVIEWER2_ISN = @USER OR IR.IR_REVIEWER3_ISN = @USER LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY AS ER ON ER.OR_CHAIR_ISN = @USER OR ER.OR_REVIEWER2_ISN = @USER OR ER.OR_REVIEWER3_ISN = @USER LEFT OUTER JOIN USERPROFILE AS COORDINATOR ON COORDINATOR.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN CODE AS DEVELOPMENTSTATUS ON DEVELOPMENTSTATUS.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN WHERE (REVIEWESTATUS.CODE_ID = @STATUS) GROUP BY COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, DEVELOPMENTSTATUS.CODE_DESCRIPTION, COORDINATOR.LAST_NAME, COORDINATOR.FIRST_NAME" OnSelected="SqlReviewer_Selected">
            <SelectParameters>
                <asp:Parameter Name="USER" />
                <asp:Parameter Name="STATUS" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />
                <asp:ScriptManager ID="smITC" runat="server" />

                <asp:UpdatePanel ID="upITC" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">
<center><asp:Label ID="lblDashboard" font-size="16pt" Text="Course(s) [In-progress] count for each reviewer" runat="server"></asp:Label></center>
        <br />
              <center> <asp:Label ID="totalUser" runat="server" Text="Number of reviewer(s) found:  "> </asp:Label>
                       <asp:Label ID="totalUserValue" Font-Bold="true" runat="server" ></asp:Label>
              </center>
              <br />
        <center>
            <asp:GridView ID="gvITCs" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="70%" PageSize="9" DataSourceID="SqlDashboard" DataKeyNames="USER_ISN,REVIEWERNAME" CellPadding="4" 
				ForeColor="#333333" CssClass="table-responsive" >
				<Columns>
				    <asp:BoundField DataField="REVIEWERNAME" HeaderText="Reviewer" ReadOnly="True" SortExpression="REVIEWERNAME" />
                    <asp:TemplateField HeaderText="Total IR" SortExpression="IR">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkIR" runat="server" Enabled='<%# (Int32)Eval("IR") < 1 ? false : true %>' ToolTip="Internal Review(s)" OnClick="lnkIR_Click" CausesValidation="false" Text='<%# Bind("IR") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total ER" SortExpression="ER">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkER" runat="server" Enabled='<%# (Int32)Eval("ER") < 1 ? false : true %>' ToolTip="External Review(s)" OnClick="lnkER_Click" CausesValidation="false" Text='<%# Bind("ER") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="TOTAL" HeaderText="Total" ReadOnly="True" SortExpression="TOTAL">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
				</Columns>
                    <PagerSettings Position="TopAndBottom" Visible="true" 
                        FirstPageText="First Page" LastPageText="Last Page" 
                        Mode="NumericFirstLast" />
                    <PagerStyle CssClass="pager-row" BackColor="#284775" HorizontalAlign="Center" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                    <HeaderStyle CssClass="header" BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" 
                        Font-Bold="True" BorderStyle="None" />                
                    <AlternatingRowStyle BackColor="White" ForeColor="Black" />
                    <AlternatingRowStyle BackColor="#D3D3D3" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
			</asp:GridView>
            
		</center>
        <br/>
        <center><asp:Label ID="DetailLabel" Text="<strong>IR</strong> - Internal Review, <strong>ER</strong> - External Review" runat="server"></asp:Label></center></div><br /></ContentTemplate></asp:UpdatePanel>

       <!-- Modal -->

    <div id="reviewerModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-lg">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times</button> 
                    <center><h4 style="color:white" class="modal-title"> Total Course(s) List </h4></center>

                </div>
                <asp:UpdatePanel ID="upTotalCourse" runat="server">
                    <ContentTemplate>
                <div id="ITCtotaldiv" class="modal-body" align="center" runat="server">
                    <div role="form" >
                        <center><b><asp:Label ID="lblTotalCourseCount" runat="server" ></asp:Label></b><asp:Label ID="lblCourseHeading" runat="server" align="right" Text=" course(s) found for &nbsp;" Width="130"></asp:Label><asp:Label ID="lblDevelopmentStatus" runat="server" ></asp:Label></center>
                        <br />
                        <div class="form-inline" >
                            <asp:GridView ID="gvReviewerModal" Font-Size="10pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%"  PageSize="15" DataSourceID="SqlReviewer" CellPadding="4"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                  
                    <asp:BoundField DataField="COURSE" HeaderText="Course" ReadOnly="True" SortExpression="COURSE" />
                        <asp:BoundField DataField="COURSE_TITLE" HeaderText="Course title" SortExpression="COURSE_TITLE" />
                        <asp:BoundField DataField="CODE_DESCRIPTION" HeaderText="Development status" SortExpression="CODE_DESCRIPTION" />
                        <asp:BoundField DataField="COORDINATOR_NAME" HeaderText="Coordinator name" ReadOnly="True" SortExpression="COORDINATOR_NAME" />
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
								<center> <asp:Button ID="btnTotalCourseClose" runat="server" CssClass="btn btn-primary btn-sm" data-dismiss="modal" CausesValidation="false" Height="30px" Text="Close" Width="75px" /></center>
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
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/scrolling-nav.js" type="text/javascript"></script>
    <script src="../../js/jquery.easing.min.js" type="text/javascript"></script>
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
