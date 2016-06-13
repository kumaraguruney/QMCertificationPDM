<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="admin_Report" %>

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
        <div class="container"  style="margin-top:100px; overflow:auto;" align="center">
            <br />
            <br /> <br />
        <asp:LinkButton runat="server" ID="Coursebycollege"  OnClick="Coursebycollege_Click" CssClass="btn btn-primary btn-lg" Text="Course(s) by College / Program" /> &nbsp; &nbsp;
            <asp:LinkButton runat="server" ID="Usersbycollege"  OnClick="Usersbycollege_Click" CssClass="btn btn-primary btn-lg" Text="User(s) by College / Program" /> &nbsp; &nbsp; <br /> <br />
            <asp:LinkButton runat="server" ID="usersbytrainingtype"  OnClick="usersbytrainingtype_Click" CssClass="btn btn-primary btn-lg" Text="User(s) by Training Type / College / Department" /> &nbsp; &nbsp;
            <asp:LinkButton runat="server" ID="Paymentstatus"  OnClick="Paymentstatus_Click" CssClass="btn btn-primary btn-lg" Text="Payment Status Report" /> &nbsp; &nbsp; <br /> <br />
            <asp:LinkButton runat="server" ID="reviewersbycoursesinprogress"  OnClick="reviewersbycoursesinprogress_Click" CssClass="btn btn-primary btn-lg" Text="Reviewers Work Load by Courses In-Progress" /> &nbsp; &nbsp;
            <asp:LinkButton runat="server" ID="reviewersbycourses"  OnClick="reviewersbycourses_Click" CssClass="btn btn-primary btn-lg" Text="Reviewers Work Load by Courses Till date" /> &nbsp; &nbsp;
        </div>
    </form>
</body>
</html>
