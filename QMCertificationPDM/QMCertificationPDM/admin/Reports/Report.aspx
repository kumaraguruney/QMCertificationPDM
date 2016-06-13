<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="admin_Reports_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - Payment and Paperwork Report</title>
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
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">
    
    <form id="form2" runat="server">
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
                        <li><a href="../Report.aspx"> Reports</a></li>
						<li><a href="../UserManagement.aspx"> Users</a></li>		
                        <li><a href="../Trainings.aspx"> Trainings</a></li>										
						<li><a href="../CodeManagement.aspx"> Codes</a></li>		
					    <li><asp:LinkButton id="logoutLink" OnClick="lnkLogout_Click" CausesValidation="False" runat="server"> <span class="glyphicon glyphicon-user"></span> Log-out</asp:LinkButton></li>
                    </ul>
            </div>

        </div>
        
        <!-- /.container -->
    </nav>
    <div class="container"  style="margin-top:100px; overflow:auto;" align="center">
        <asp:ScriptManager ID="smReport" runat="server"/>
        <br /> 
        <asp:Label ID="paymentstatuslabel" Font-Bold="true" runat="server" Text="Payment Status Report"></asp:Label>
        <br />
        <rsweb:ReportViewer ID="PaymentReportViewer" runat="server" Font-Names="Arial" Font-Size="12pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px" Width="1150px">
            <localreport reportpath="admin\Reports\PAYMENT.rdlc">
                <datasources>
                    <rsweb:ReportDataSource DataSourceId="SqlPaymentReport" Name="Payment" />
                </datasources>
            </localreport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlPaymentReport" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" SelectCommand="SELECT PAYMENTPAPERWORKHISTORY.COURSE_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COORDINATOR.LAST_NAME + ', ' + COORDINATOR.FIRST_NAME AS COORDINAOTORNAME, DEVELOPMENTSTATUS.CODE_ID AS DEVELOPMENTSTATUS, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPERNAME, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, 103) AS FIRST_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, 103) AS SECOND_PAYMENT_DATE, CONVERT (date, PAYMENTPAPERWORKHISTORY.IR_START_DATE, 103) AS IR_START_DATE, CONVERT (date, PAYMENTPAPERWORKHISTORY.IR_END_DATE, 103) AS IR_END_DATE, IRCHAIR.LAST_NAME + ', ' + IRCHAIR.FIRST_NAME AS IRCHAIR, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, 103) AS IR_CHAIR_ESTIMATED_PAYMENT_DATE, IRREVIEWER2.LAST_NAME + ', ' + IRREVIEWER2.FIRST_NAME AS IRREVIEWER2, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, 103) AS IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, IRREVIEWER3.LAST_NAME + ', ' + IRREVIEWER3.FIRST_NAME AS IRREVIEWER3, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, 103) AS IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, CONVERT (date, PAYMENTPAPERWORKHISTORY.OR_START_DATE, 103) AS OR_START_DATE, CONVERT (date, PAYMENTPAPERWORKHISTORY.OR_END_DATE, 103) AS OR_END_DATE, ORCHAIR.LAST_NAME + ', ' + ORCHAIR.FIRST_NAME AS ORCHAIR, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, 103) AS OR_CHAIR_ESTIMATED_PAYMENT_DATE, ORREVIEWER2.LAST_NAME + ', ' + ORREVIEWER2.FIRST_NAME AS ORREVIEWER2, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, 103) AS OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, ORREVIEWER3.LAST_NAME + ', ' + ORREVIEWER3.FIRST_NAME AS OR_REVIEWER3, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, CONVERT (date, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, 103) AS OR_REVIEWER3_ESTIMATED_PAYMENT_DATE FROM PAYMENTPAPERWORKHISTORY INNER JOIN COURSEDETAIL ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN INNER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN INNER JOIN USERPROFILE AS COORDINATOR ON COORDINATOR.USER_ISN = COURSEDETAIL.COORDINATOR_ISN INNER JOIN CODE AS DEVELOPMENTSTATUS ON DEVELOPMENTSTATUS.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN USERPROFILE AS IRCHAIR ON IRCHAIR.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN USERPROFILE AS IRREVIEWER2 ON IRREVIEWER2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN USERPROFILE AS IRREVIEWER3 ON IRREVIEWER3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN USERPROFILE AS ORCHAIR ON ORCHAIR.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN USERPROFILE AS ORREVIEWER2 ON ORREVIEWER2.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN USERPROFILE AS ORREVIEWER3 ON ORREVIEWER3.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
