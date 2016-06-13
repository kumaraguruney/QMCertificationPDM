<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Course Development Management System - TAMIU - E-learning - OIT</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/animated.css" rel="stylesheet" type="text/css" />
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
    <form id="form1" runat="server">
    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->

            <center><h4 style="color:white; font-size:25px">Course Development Management System</h4></center>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    
        <div class="container">

             <div class="col-md-4 col-md-offset-0">
                <div class="banner-text text-center">
                    <br/><br/><br /><br />
                    <div class="panel-default">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon-lock"></span><strong>Login</strong></div>
                <div class="panel-body">
                    <form class="form-horizontal" role="form">
						
						<div class="form-group">
                            <div class="col-sm-10">
                                <br />
							<asp:Label ID="badlogin" runat="server" /> 
                                </div>
						</div>
						
                        <div class="form-group">
                            <div class="col-sm-3 control-label">
							
							<asp:Label ID="lblNetID" runat="server" CssClass="affix" align="left" Text="NetID: "/> <asp:LinkButton ID="lnkbtn" align="center" Width="95" CausesValidation="false" runat="server" OnMouseOver="showImage();" OnMouseOut="hideImage();"><i class="glyphicon glyphicon-question-sign"></i></asp:LinkButton>
                            </div>
                            <div class="col-sm-9">
                                <img src="" id="image" alt="" width="200px" height="200px" style="display:none;" align="left"/>
                                <asp:TextBox ID="txtUsername" runat="server" placeholder="NetID" CssClass="form-control" autofocus></asp:TextBox>
							    <asp:RequiredFieldValidator ID="rfEmail" runat="server" ControlToValidate="txtUsername"
								    Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                       
                        <div class="form-group">
                             
                            <div class="col-sm-3 control-label">
                                <br />
                            <asp:Label ID="lblPassword" runat="server" Text="Password: " align="right"></asp:Label>
                                </div>
                            <div class="col-sm-9">
                                <br />
                                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" onkeypress="capLock(event)" TextMode="Password" CssClass="form-control"></asp:TextBox>
							    <asp:RequiredFieldValidator ID="rfPassword" runat="server" ControlToValidate="txtPassword"
								    Display="Dynamic" ForeColor="Red" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>
						

                    <div class="form-group last">
                        <div class="col-sm-offset-2 col-sm-9">
                            <br />
                            <strong><asp:Button ID="btnSumbit" CssClass="btn btn-info btn-block" runat="server" OnClick="btnSumbit_Click" Text="Login" /></strong>
                        </div>
                    </div>
                        
                                <div id="divMayus" style="visibility:hidden;color:red">Caps Lock is on.</div>
                    </form>
                </div>
                <div class="panel-footer">
                    <a href="https://dusty.tamiu.edu/passwordreset/welcome.aspx" target="_blank"><strong><u>Forgot password?</u></strong></a></div>
            </div>
                </div><!-- banner text -->
                 <br/><br/>
            </div>

        <div class="col-md-4 col-md-offset-0">
                <div class="banner-text text-center">
                    <br/><br/><br/><br/><br /><br />
                    <asp:Image runat="server" ImageUrl="~/img/banner.jpg" AlternateText="Texas A&M International University Quality Matters"></asp:Image>
                </div><!-- banner text -->
            </div>

          <div class="col-md-4 col-md-offset-0">
                <div class="banner-text text-right">
                    <br/><br/><br/><br/><br/><br/>
                   <h3>Quick Links</h3>
                    <a href="http://www.tamiu.edu/qm/" target="_blank">Quality Matters @ TAMIU</a><br/>
                    <a href="http://www.tamiu.edu/distance/" target="_blank">Distance Education @ TAMIU</a><br/>
                    <a href="https://www.qualitymatters.org/" target="_blank">Quality Matters</a><br/>
                </div><!-- banner text -->
            </div>

    </div>
    <footer class="footer">
        <div class="footer-bottom">
            <div class="container">
                    <p>Office of Information Technology<br /><p />Instructional Technology & Distance Education Services<br /><p />Texas A&M International University<br /><p />Killam Library 259</span><br /><p /><span class="glyphicon glyphicon-phone-alt" > Phone: (956) 326-2792</span><br /><p /><span class="glyphicon glyphicon-envelope" > E-mail: <a href="mailto:elearning@tamiu.edu" target="_blank">elearning@tamiu.edu</a></p>
            </div>
        </div>
    </footer>
    <!-- footer -->
    <!-- Script -->
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/scrolling-nav.js" type="text/javascript"></script>
    <script src="js/jquery.easing.min.js" type="text/javascript"></script>
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
            function showImage() {
                document.getElementById("image").style.display = "inline";
                document.getElementById("image").src = 'img/NetID.jpg';
            }
            function hideImage() {
                document.getElementById("image").style.display = "none";
                document.getElementById("image").src = '';
            }

            function capLock(e) {
                kc = e.keyCode ? e.keyCode : e.which;
                sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);
                if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk))
                    document.getElementById('divMayus').style.visibility = 'visible';
                else
                    document.getElementById('divMayus').style.visibility = 'hidden';
            }

    </script>
    <a href="#" class="back-to-top">UP</a>
    </form>
</body>
</html>
