<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - MAIN Page</title>
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
                		<li><a href="Report.aspx"> Reports </a></li>
						<li><a href="UserManagement.aspx"> Users</a></li>
                        <li><a href="Trainings.aspx"> Trainings</a></li>						
						<li><a href="CodeManagement.aspx"> Codes</a></li>		
					    <li><asp:LinkButton id="logoutLink" OnClick="lnkLogout_Click" CausesValidation="False" runat="server"> <span class="glyphicon glyphicon-user"></span> Log-out</asp:LinkButton></li>
                    </ul>
            </div>

        </div>
        <!-- /.container -->
    </nav>
	
        <asp:SqlDataSource ID="SqlDevelopmentStatus" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT COUNT(COURSEDETAIL.COURSE_ISN) AS TOTAL, CODE.CODE_ID, CODE.CODE_DESCRIPTION FROM COURSEDETAIL INNER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN GROUP BY CODE.CODE_ID, CODE.CODE_DESCRIPTION"></asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDashboard" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT USERPROFILE.FIRST_NAME, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS ITCNAME, COUNT(DS1.COURSE_ISN) AS DIP, COUNT(DS2.COURSE_ISN) AS ER, COUNT(DS3.COURSE_ISN) AS IR, COUNT(DS4.COURSE_ISN) AS NA, COUNT(DS5.COURSE_ISN) AS PD, COUNT(DS6.COURSE_ISN) AS PR, COUNT(DS1.COURSE_ISN) + COUNT(DS2.COURSE_ISN) + COUNT(DS3.COURSE_ISN) + COUNT(DS4.COURSE_ISN) + COUNT(DS5.COURSE_ISN) + COUNT(DS6.COURSE_ISN) AS TOTAL, COUNT(DS7.COURSE_ISN) AS QMC FROM USERPROFILE CROSS JOIN CODE LEFT OUTER JOIN COURSEDETAIL AS DS1 ON DS1.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS1.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'DIP' LEFT OUTER JOIN COURSEDETAIL AS DS2 ON DS2.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS2.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'ER' LEFT OUTER JOIN COURSEDETAIL AS DS3 ON DS3.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS3.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'IR' LEFT OUTER JOIN COURSEDETAIL AS DS4 ON DS4.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS4.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'NA' LEFT OUTER JOIN COURSEDETAIL AS DS5 ON DS5.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS5.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'PD' LEFT OUTER JOIN COURSEDETAIL AS DS6 ON DS6.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS6.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'PR' LEFT OUTER JOIN COURSEDETAIL AS DS7 ON DS7.COORDINATOR_ISN = USERPROFILE.USER_ISN AND DS7.DEVELOPMENT_STATUS_ISN = CODE.CODE_ISN AND CODE.CODE_ID = 'QMC' WHERE (USERPROFILE.IS_COORDINATOR = 1) GROUP BY USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME ORDER BY USERPROFILE.LAST_NAME"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT * FROM [USERPROFILE]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlITCgrid" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT COURSEDETAIL.COURSE_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COORDINATOR.LAST_NAME + ', ' + COORDINATOR.FIRST_NAME AS COORDINATORNAME, DEVELOPER.LAST_NAME + ', ' + DEVELOPER.FIRST_NAME AS DEVELOPERNAME FROM COURSEDETAIL INNER JOIN USERPROFILE AS COORDINATOR ON COORDINATOR.USER_ISN = COURSEDETAIL.COORDINATOR_ISN INNER JOIN USERPROFILE AS DEVELOPER ON DEVELOPER.USER_ISN = COURSEDETAIL.DEVELOPER_ISN INNER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN AND CODE.CODE_ID = @DEVELOPMENT_STATUS WHERE (COORDINATOR.FIRST_NAME = @FIRSTNAME) ORDER BY COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER" OnSelected="SqlITCgrid_Selected" >
            <SelectParameters>
                <asp:Parameter Name="DEVELOPMENT_STATUS" />
                <asp:Parameter Name="FIRSTNAME" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlITCtotalgrid" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT COURSEDETAIL.COURSE_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COORDINATOR.LAST_NAME + ', ' + COORDINATOR.FIRST_NAME AS COORDINATORNAME, DEVELOPER.LAST_NAME + ', ' + DEVELOPER.FIRST_NAME AS DEVELOPERNAME FROM COURSEDETAIL INNER JOIN USERPROFILE AS COORDINATOR ON COORDINATOR.USER_ISN = COURSEDETAIL.COORDINATOR_ISN INNER JOIN USERPROFILE AS DEVELOPER ON DEVELOPER.USER_ISN = COURSEDETAIL.DEVELOPER_ISN INNER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN AND CODE.CODE_ID = @DEVELOPMENT_STATUS ORDER BY COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER" OnSelected="SqlITCtotalgrid_Selected" >
            <SelectParameters>
                <asp:Parameter Name="DEVELOPMENT_STATUS" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
                <asp:ScriptManager ID="smITC" runat="server" />

                <asp:UpdatePanel ID="upITC" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">
<center><asp:Label ID="lblDashboard" font-size="16pt" Text="Course Development at-a-glance." runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:GridView ID="gvITCs" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="70%" PageSize="9" DataKeyNames="FIRST_NAME,ITCNAME" DataSourceID="SqlDashboard" CellPadding="4" 
				ForeColor="#333333" ShowFooter="True" CssClass="table-responsive" OnRowCreated="gvITCs_RowCreated" OnRowDataBound="gvITCs_RowDataBound">
				<Columns>
				    <asp:TemplateField HeaderText="Name" SortExpression="ITCNAME">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("ITCNAME") %>'></asp:Label>
                        </ItemTemplate>
                         <FooterTemplate >
                        <div style="text-align:right"><asp:Label ID="lblTotal" Text="Total" runat="server" /></div>
                    </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NA" SortExpression="NA">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblNA" runat="server" CausesValidation="false" OnClick="lblNA_Click" Enabled='<%# (Int32)Eval("NA") < 1 ? false : true %>' ToolTip="Not approved" Text='<%# Bind("NA") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="text-align:center"  ><asp:LinkButton ID="lnktotalNA" runat="server" ForeColor="White" ToolTip=" total Not approved"  OnClick="lnktotalNA_Click" CausesValidation="false"><asp:Label ID="lblTotalNA" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PD" SortExpression="PD">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblPD" runat="server" Enabled='<%# (Int32)Eval("PD") < 1 ? false : true %>' ToolTip="Pending development" OnClick="lblPD_Click" CausesValidation="false" Text='<%# Bind("PD") %>'></asp:LinkButton></ItemTemplate><FooterTemplate>
                            <div style="text-align:center"  ><asp:LinkButton ID="lnktotalPD" runat="server" ForeColor="White" ToolTip=" total Pending development" OnClick="lnktotalPD_Click" CausesValidation="false"><asp:Label ID="lblTotalPD" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DIP" SortExpression="DIP">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblDIP" ToolTip="Development in progress" Enabled='<%# (Int32)Eval("DIP") < 1 ? false : true %>' CausesValidation="false" OnClick="lblDIP_Click" runat="server" Text='<%# Bind("DIP") %>'></asp:LinkButton></ItemTemplate><FooterTemplate>
                            <div style="text-align:center"  ><asp:LinkButton ID="lnktotalDIP" runat="server" ForeColor="White" ToolTip=" total Development in progress" OnClick="lnktotalDIP_Click" CausesValidation="false"><asp:Label ID="lblTotalDIP" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PR" SortExpression="PR">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblPR" runat="server" ToolTip="Pending review" Enabled='<%# (Int32)Eval("PR") < 1 ? false : true %>' CausesValidation="false" OnClick="lblPR_Click" Text='<%# Bind("PR") %>'></asp:LinkButton></ItemTemplate><FooterTemplate>
                            <div style="text-align:center"  ><asp:LinkButton ID="lnktotalPR" runat="server" ForeColor="White" ToolTip=" total Pending review" OnClick="lnktotalPR_Click" CausesValidation="false"><asp:Label ID="lblTotalPR" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IR" SortExpression="IR">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblIR" runat="server" ToolTip="Internal review" Enabled='<%# (Int32)Eval("IR") < 1 ? false : true %>' CausesValidation="false" OnClick="lblIR_Click" Text='<%# Bind("IR") %>'></asp:LinkButton></ItemTemplate><FooterTemplate>
                        <div style="text-align:center"  ><asp:LinkButton ID="lnktotalIR" runat="server" ForeColor="White" ToolTip=" total Internal review" OnClick="lnktotalIR_Click" CausesValidation="false"><asp:Label ID="lblTotalIR" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ER" SortExpression="ER">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblER" ToolTip="External review" runat="server" Enabled='<%# (Int32)Eval("ER") < 1 ? false : true %>' CausesValidation="false" OnClick="lblER_Click" Text='<%# Bind("ER") %>'></asp:LinkButton></ItemTemplate><FooterTemplate>
                        <div style="text-align:center"  ><asp:LinkButton ID="lnktotalER" runat="server" ForeColor="White" ToolTip=" total External review" OnClick="lnktotalER_Click" CausesValidation="false"><asp:Label ID="lblTotalER" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total" SortExpression="TOTAL">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalvalue" runat="server" Text='<%# Bind("TOTAL") %>'></asp:Label></ItemTemplate><FooterTemplate>
                        <div style="text-align:center" ><asp:Label ID="lblGrandTotal" runat="server" /></div>
                    </FooterTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QMC" SortExpression="QMC">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblQMC" runat="server" ToolTip="QM certified" Enabled='<%# (Int32)Eval("QMC") < 1 ? false : true %>' CausesValidation="false" OnClick="lblQMC_Click" Text='<%# Bind("QMC") %>'></asp:LinkButton></ItemTemplate><FooterTemplate>
                        <div style="text-align:center"  ><asp:LinkButton ID="lnktotalQMC" runat="server" ForeColor="White" ToolTip=" total QM certified" OnClick="lnktotalQMC_Click" CausesValidation="false"><asp:Label ID="lblTotalQMC" runat="server" /></asp:LinkButton></div></FooterTemplate><ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
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
        <center><asp:Label ID="DetailLabel" Text="<strong>NA</strong> - Not Approved, <strong>PD</strong> - Pending Development, <strong>DIP</strong> - Development in Progress, <strong>PR</strong> - Pending Review, <strong>IR</strong> - Internal Review, <strong>ER</strong> - External Review, <strong>QMC</strong> - QM Certified" runat="server"></asp:Label></center></div><br /></ContentTemplate></asp:UpdatePanel><div class="container"  style="overflow:auto;" align="center">
        <rsweb:ReportViewer ID="rvCourseDevelopment" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="884px" Height="785px"><LocalReport ReportPath="admin\Reports\Graph.rdlc"><DataSources><rsweb:ReportDataSource DataSourceId="SqlDashboard" Name="GraphDataset" /><rsweb:ReportDataSource DataSourceId="SqlDevelopmentStatus" Name="DevelopmentStatusDataset" /></DataSources></LocalReport></rsweb:ReportViewer>
            </div>


        <!-- Modal -->
        <div id="ITCModal" class="modal fade in" role="dialog">
  
             <div class="modal-dialog modal-lg">
         
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times   
                    </button>
                    <center>
                        <h4 style="color:white" class="modal-title">Course(s) List </h4></center>

                </div>
                <asp:UpdatePanel ID="upTrainings" runat="server">
                    <ContentTemplate>
                <div id="Div1" class="modal-body" align="center" runat="server">
                    <div role="form" >
                        <center><b><asp:Label ID="lblTotalCourseCount" runat="server" ></asp:Label></b><asp:Label ID="lblCourseHeading" runat="server" align="right" Text=" &nbsp; course(s) found for &nbsp;" Width="140"></asp:Label><asp:Label ID="lblITCName" runat="server" ></asp:Label></center>
                        <br />
                        <div class="form-inline" >
                            <asp:GridView ID="gvITC" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%"   DataSourceID="SqlITCgrid" CellPadding="4"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                  
                    <asp:BoundField DataField="course_subject" HeaderText="Course subject" SortExpression="course_subject"  />
                    <asp:BoundField DataField="course_number" HeaderText="Course #" SortExpression="course_number"  />
                    <asp:BoundField DataField="course_title" HeaderText="Course title" SortExpression="course_title"  />
                    <asp:BoundField DataField="DEVELOPERNAME" HeaderText="Developer" SortExpression="DEVELOPERNAME"  />
                    
					
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
        
        <!-- Modal -->

    <div id="ITCtotalModal" class="modal fade in" role="dialog">
        <div class="modal-dialog modal-lg">
         <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times </button> 
                    <center><h4 style="color:white" class="modal-title"> Total Course(s) List </h4></center>

                </div>
                <asp:UpdatePanel ID="upTotalCourse" runat="server">
                    <ContentTemplate>
                <div id="ITCtotaldiv" class="modal-body" align="center" runat="server">
                    <div role="form" >
                        <center><b><asp:Label ID="lblfooterTotalCourseCount" runat="server" ></asp:Label></b><asp:Label ID="lblfooterCourseHeading" runat="server" align="right" Text=" course(s) found for" Width="130"></asp:Label><asp:Label ID="lblfooterDevelopmentStatus" runat="server" ></asp:Label></center>
                        <br />
                        <div class="form-inline" >
                            <asp:GridView ID="gvtotalITC" Font-Size="10pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%"  PageSize="15" DataSourceID="SqlITCtotalgrid" CellPadding="4"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                  
                    <asp:BoundField DataField="course_subject" HeaderText="Course subject" SortExpression="course_subject"  />
                    <asp:BoundField DataField="course_number" HeaderText="Course #" SortExpression="course_number"  />
                    <asp:BoundField DataField="course_title" HeaderText="Course title" SortExpression="course_title"  />
                    <asp:BoundField DataField="DEVELOPERNAME" HeaderText="Developer" SortExpression="DEVELOPERNAME"  />
					<asp:BoundField DataField="COORDINATORNAME" HeaderText="ITC" SortExpression="COORDINATORNAME"  />
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
