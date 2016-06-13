<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Trainings.aspx.cs" Inherits="admin_Trainings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>CDMS - Admin - Training Management</title>
       <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/animated.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,400,600,700'
        rel='stylesheet' type='text/css' />
    <link href="/../netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet" />
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
    
	
	
	<asp:SqlDataSource ID="SqlTrainingHistory" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>"
		InsertCommand="INSERT INTO TRAININGHISTORY(USER_ISN, TRAINING_CODE_ISN, TRAINING_DATE, NOTE, ADDED_BY, ADDED_DATE, UPDATED_BY, UPDATED_DATE, TRAINING_STATUS_ISN, TRAINING_TYPE_ISN) VALUES (@USER_ISN, @TRAINING_CODE_ISN, @TRAINING_DATE, @NOTE, @ADDED_BY, @ADDED_DATE, @UPDATED_BY, @UPDATED_DATE, @TRAINING_STATUS_ISN, @TRAINING_TYPE_ISN)"
		SelectCommand="SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, TRAININGHISTORY.NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN ORDER BY USERPROFILE.LAST_NAME, TRAININGHISTORY.TRAINING_DATE DESC"
		UpdateCommand="UPDATE TRAININGHISTORY SET USER_ISN = @USER_ISN, TRAINING_CODE_ISN = @TRAINING_CODE_ISN, TRAINING_DATE = @TRAINING_DATE, NOTE = @NOTE, UPDATED_BY = @UPDATED_BY, UPDATED_DATE = @UPDATED_DATE, TRAINING_STATUS_ISN = @TRAINING_STATUS_ISN, TRAINING_TYPE_ISN = @TRAINING_TYPE_ISN WHERE (TRAINING_ISN = @TRAINING_ISN)" OnSelected="SqlTrainingHistory_Selected" DeleteCommand="DELETE FROM [TRAININGHISTORY] WHERE [TRAINING_ISN] = @TRAINING_ISN">
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
                <asp:Parameter Name="TRAINING_STATUS_ISN" Type="String" />
                <asp:Parameter Name="TRAINING_TYPE_ISN" Type="String" />
            </InsertParameters>
			<UpdateParameters>
                <asp:Parameter Name="USER_ISN" Type="Int32" />
                <asp:Parameter Name="TRAINING_CODE_ISN" Type="Int32"/>
                <asp:Parameter Name="TRAINING_DATE" Type="DateTime" />
                <asp:Parameter Name="NOTE" Type="String" />
                <asp:Parameter Name="UPDATED_BY" Type="String" />
				<asp:Parameter Name="UPDATED_DATE" Type="DateTime" />
                <asp:Parameter Name="TRAINING_STATUS_ISN" Type="String" />
                <asp:Parameter Name="TRAINING_TYPE_ISN" Type="String" />
                <asp:Parameter Name="TRAINING_ISN" Type="Int32" />
			</UpdateParameters>
	</asp:SqlDataSource>
			
       		
        <asp:SqlDataSource ID="SqlUsers" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN ORDER BY USERPROFILE.LAST_NAME">
        </asp:SqlDataSource>

		 <asp:SqlDataSource ID="SqlTrainings" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE.CODE_ISN, CODE.CODE_STATUS, CODE.CODE_TYPE, CODE.CODE_ID, CODE.CODE_DESCRIPTION, CODE.ADDED_BY, CODE.ADDED_DATE, CODE.UPDATED_BY, CODE.UPDATED_DATE, CODE.CODE_DESCRIPTION + ' ( ' + CODE.CODE_ID + ')' AS TRAININGS FROM CODE INNER JOIN CODE AS TRAININGTYPE ON CODE.CODE_TYPE = 'TRAIN' + TRAININGTYPE.CODE_ID WHERE (TRAININGTYPE.CODE_ISN = @CODE_TYPE) ORDER BY CODE.CODE_DESCRIPTION">
             <SelectParameters>
                 <asp:ControlParameter ControlID="dropaddTrainingType" Name="CODE_TYPE" PropertyName="SelectedValue" Type="String" />
             </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlTrainingedit" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE.CODE_ISN, CODE.CODE_STATUS, CODE.CODE_TYPE, CODE.CODE_ID, CODE.CODE_DESCRIPTION, CODE.ADDED_BY, CODE.ADDED_DATE, CODE.UPDATED_BY, CODE.UPDATED_DATE, CODE.CODE_DESCRIPTION + ' ( ' + CODE.CODE_ID + ')' AS TRAININGS FROM CODE INNER JOIN CODE AS TRAININGTYPE ON CODE.CODE_TYPE = 'TRAIN' + TRAININGTYPE.CODE_ID WHERE (TRAININGTYPE.CODE_ISN = @CODE_TYPE) ORDER BY CODE.CODE_DESCRIPTION">
             <SelectParameters>
                 <asp:ControlParameter ControlID="dropTrainingType" Name="CODE_TYPE" PropertyName="SelectedValue" Type="String" />
             </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlTraining" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_ISN, CODE_STATUS, CODE_TYPE, CODE_ID, CODE_DESCRIPTION, ADDED_BY, ADDED_DATE, UPDATED_BY, UPDATED_DATE, CODE_DESCRIPTION + ' ( ' + CODE_ID + ')' AS TRAININGS FROM CODE WHERE (CODE_TYPE = 'TRAINAC')  OR (CODE_TYPE = 'TRAINQM') ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlTrainingType" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_ISN, CODE_STATUS, CODE_TYPE, CODE_ID, CODE_DESCRIPTION, ADDED_BY, ADDED_DATE, UPDATED_BY, UPDATED_DATE, CODE_DESCRIPTION + ' ( ' + CODE_ID + ')' AS TRAININGS FROM CODE WHERE (CODE_TYPE = @CODE_TYPE) ORDER BY CODE_DESCRIPTION">
             <SelectParameters>
                 <asp:Parameter DefaultValue="TRAINTYP" Name="CODE_TYPE" Type="String" />
             </SelectParameters>
        </asp:SqlDataSource>

        

        <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE (CODE_TYPE = 'TRAIN')">
        </asp:SqlDataSource>
	
        <asp:SqlDataSource ID="SqlTrainingStatus" runat="server" ConnectionString="<%$ ConnectionStrings:QMCDMSConnectionString %>" 
            SelectCommand="SELECT CODE_DESCRIPTION, CODE_ISN, CODE_ID FROM CODE WHERE (CODE_TYPE = 'TRAINSTA') ORDER BY CODE_DESCRIPTION">
        </asp:SqlDataSource>
	
       			<br/>
                <asp:ScriptManager ID="smTrainingHistory" runat="server" />

                <asp:UpdatePanel ID="upTrainingHistory" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
          <div class="container"  style="margin-top:100px; overflow:auto;" align="center">

              <div class="form-inline">
                
                <asp:DropDownList ID="UsersSearch" runat="server" CssClass="form-control" DataSourceID="SqlTraining" AutoPostBack="true" EnableViewState="False" OnSelectedIndexChanged="UsersSearch_SelectedIndexChanged" AppendDataBoundItems="True" DataTextField="TRAININGS" DataValueField="CODE_ISN"  Height="30px" Width="300px">
                 <asp:ListItem Text="&nbsp; --- Select a training and Click search --- &nbsp;" Value="%"></asp:ListItem></asp:DropDownList>
                &nbsp;&nbsp;&nbsp;                 
                <asp:DropDownList ID="TrainingStatusSearch" runat="server" ToolTip="select a training to enable" CssClass="form-control" DataSourceID="SqlTrainingStatus" Enabled="false" EnableViewState="False" AppendDataBoundItems="True" DataTextField="CODE_DESCRIPTION" DataValueField="CODE_ISN"  Height="30px" Width="150">
                 <asp:ListItem Text=" --- Status --- " Value="%"></asp:ListItem></asp:DropDownList>
                &nbsp;&nbsp;&nbsp; 
                <asp:Button ID="btnUserSearch" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" OnClick="btnUserSearch_Click" Text="Search" Width="75px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUserClear" runat="server" CssClass="btn btn-primary btn-sm" Height="30px" OnClick="btnUserClear_Click" Text="Clear" Width="75px" />
                &nbsp;&nbsp; | &nbsp; 
                <asp:Button ID="btnAddTraining" ToolTip="Click to add a training to the user." CssClass="btn btn-primary btn-sm" runat="server" CausesValidation="false"  Height="30px" Width="110px" Text="Add Training" Enabled="true"  onclick="btnAddTraining_Click" />
              </div>
		      <br />

              <center> <asp:Label ID="totalTrainings" runat="server" Text="Number of Training(s) found:  "> </asp:Label>
                       <asp:Label ID="totalTrainingValue" Font-Bold="true" runat="server" ></asp:Label>
              </center>
              <br />

			<asp:GridView ID="gvTrainingHistory" Font-Size="12pt" runat="server"  AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
				Height="90%" Width="90%" PageSize="25" DataKeyNames="TRAINING_ISN" DataSourceID="SqlTrainingHistory" CellPadding="4" OnRowCreated="gvTrainingHistory_RowCreated"
				ForeColor="#333333" CssClass="table-responsive">
				<Columns>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkDisplay" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/view.png" AlternateText="View Details" ToolTip="Click to view user's profile." CausesValidation="false" onclick="lnkDisplay_Click" ></asp:ImageButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText = "Edit" ItemStyle-HorizontalAlign="Center" >
					   <ItemTemplate>
						   <asp:ImageButton ID="lnkEdit" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/edit.png" AlternateText="Edit User" CausesValidation="false" ToolTip="Click to edit user's profile." onclick="lnkEdit_Click" ></asp:ImageButton>
						</ItemTemplate>
					    <ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
                    <asp:BoundField DataField="NAME" HeaderText="User" SortExpression="NAME" />
                    <asp:BoundField DataField="TRAINING_DATE" DataFormatString="{0:MM/dd/yyyy}" NullDisplayText=" " HeaderText="Training Date" SortExpression="TRAINING_DATE" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRAININGTYPE" HeaderText="Training Type" SortExpression="TRAININGTYPE"  />
                    <asp:BoundField DataField="CODE_ID" HeaderText="Training" SortExpression="CODE_ID"  />
					
                   					
				    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="CODE_ID" />
					
                   					
				    <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkDelete" runat="server" ImageAlign="AbsMiddle" ImageUrl="../img/delete.png" AlternateText="Delete User" CausesValidation="false" ToolTip="Click to Delete Training." OnClientClick="return confirm('Do you want to delete this training');"  CommandName="Delete" ></asp:ImageButton>
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
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			</asp:GridView>
           </div>
			<br />
			
                        
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvTrainingHistory" EventName="RowCommand" />
						<asp:AsyncPostBackTrigger ControlID="btnAddTraining" EventName="Click" />
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
                        &times</button>
                        <center> <h4 style="color:white" class="modal-title">Edit Training</h4></center>
                </div>
                <asp:UpdatePanel ID="upEditTraining" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div role="form" align="left">
                        <div class="form-group">
							<asp:Label ID="editError" runat="server" /> 
						</div>
                        <div class="form-inline">
                            <asp:HiddenField ID="trainingisn" runat="server" Visible="false"></asp:HiddenField>
                            <b><asp:Label ID="lblUser" runat="server" align="Right" Width="150" Text="*User: "></asp:Label></b>
                            <asp:DropDownList ID="dropUser" CssClass="form-control dropdown-toggle" runat="server" EnableViewState="false" AutoPostBack="true" DataSourceID="SqlUsers" DataValueField="USER_ISN" DataTextField="NAME">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="editvalidation" ID="rfvdropUser" runat="server" ControlToValidate="dropUser"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lblTrainingType" runat="server" align="Right" Width="150" Text="*Training type: "></asp:Label></b>
                            <asp:DropDownList ID="dropTrainingType" CssClass="form-control" Width="350" runat="server" DataSourceID="SqlTrainingType" AutoPostBack="true" DataValueField="CODE_ISN" DataTextField="TRAININGS" AppendDataBoundItems="true" EnableViewState="false">
                                <asp:ListItem Text=" -- Select a Training type -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="editvalidation" ID="rfvdropTrainingType" runat="server" InitialValue="-1" ControlToValidate="dropTrainingType"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>	
                           </div>
						<br />
                        <div class="form-inline">
                            <b><asp:Label ID="lblTraining" runat="server" align="Right" Width="150" Text="*Training: "></asp:Label></b>
                            <asp:DropDownList ID="dropTraining" CssClass="form-control" Width="350" runat="server" AppendDataBoundItems="true" DataSourceID="SqlTrainingedit" DataValueField="CODE_ISN" DataTextField="TRAININGS" EnableViewState="false">
                               <asp:ListItem Text=" -- Select a Training -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="editvalidation" ID="rfvdropTraining" runat="server" InitialValue="-1" ControlToValidate="dropTraining"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>
                        
                        </div>
						<br />
                        <div class="form-inline">
                            <b><asp:Label ID="lblTrainingStatus" runat="server" align="Right" Width="150" Text="*Training Status: "></asp:Label></b>
                            <asp:DropDownList ID="dropTrainingStatus" AppendDataBoundItems="true" CssClass="form-control" Width="350" runat="server" DataSourceID="SqlTrainingStatus" DataValueField="CODE_ISN" DataTextField="CODE_DESCRIPTION" EnableViewState="false">
                                    <asp:ListItem Text=" -- Select a Status -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="editvalidation" ID="rfvdropTrainingStatus" runat="server" InitialValue="-1" ControlToValidate="dropTrainingStatus"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>
                        
                        </div>
						<br />
                        <div class="form-inline">
                                     <asp:Label ID="lblTrainingDate" Font-Bold="true" runat="server" align="Right" Width="150" Text="*Training date: "></asp:Label>
                                    <asp:TextBox ID="txtTrainingDate" ForeColor="Red" CssClass="form-control" runat="server" Width="130" ></asp:TextBox>
                                    <asp:Image ID="imgTrainingDate" runat="server" Width="20" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="ceTrainingDate"  runat="server" TargetControlID="txtTrainingDate" OnClientShowing="ajaxToolkit_CalendarExtenderClientShowing" CssClass="form-control" Format="MM/dd/yyyy" PopupButtonID="imgTrainingDate" />
                            <asp:RequiredFieldValidator ValidationGroup="editvalidation" ID="rfvtxtTrainingDate" runat="server" InitialValue="-1" ControlToValidate="txtTrainingDate"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>
                                    </div>					
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lblNote" runat="server" align="Right" Width="150" Text="Note: "></asp:Label></b>
                            <asp:TextBox ID="txtNote" MaxLength="300" CssClass="form-control" runat="server" Width="300" TextMode="MultiLine"></asp:TextBox>
                        </div>
                         <br />
                        <div class="form-group">
							<div class="modal-footer" >
								<center><asp:Button ID="btnUpdateTraining" ValidationGroup="editvalidation" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="true" OnClick="btnUpdateTraining_Click" Height="30px" Text="Update"  Width="75px" />
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
                        &times </button>
                        <center><h4 style="color:white" class="modal-title">Add Training</h4></center>
                </div>
                <asp:UpdatePanel ID="upAddTrainings" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div role="form" align="left">
                        <div class="form-group">
							<asp:Label ID="adderror" runat="server" /> 
						</div>
                        <div class="form-inline">
                            <b><asp:Label ID="User" runat="server" align="Right" Width="150" Text="*User: "></asp:Label></b>
                            <asp:DropDownList ID="dropaddUser" CssClass="form-control dropdown-toggle" runat="server" AppendDataBoundItems="true" EnableViewState="false" AutoPostBack="true" DataSourceID="SqlUsers" DataValueField="USER_ISN" DataTextField="NAME">
                                <asp:ListItem Text=" -- Select a User -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvdropaddUser" runat="server" InitialValue="-1" ControlToValidate="dropaddUser"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbladdTrainingType" runat="server" align="Right" Width="150" Text="*Training type: "></asp:Label></b>
                            <asp:DropDownList ID="dropaddTrainingType" CssClass="form-control" Width="350" runat="server" DataSourceID="SqlTrainingType" AutoPostBack="true" DataValueField="CODE_ISN" DataTextField="TRAININGS" AppendDataBoundItems="true" EnableViewState="false">
                                <asp:ListItem Text=" -- Select a Training type -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvdropaddTrainingType" runat="server" InitialValue="-1" ControlToValidate="dropaddTrainingType"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>	
                           </div>
						<br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbladdTraining" runat="server" align="Right" Width="150" Text="*Training: "></asp:Label></b>
                            <asp:DropDownList ID="dropaddTraining" CssClass="form-control" Width="350" runat="server" DataSourceID="SqlTrainings" DataValueField="CODE_ISN" DataTextField="TRAININGS" AppendDataBoundItems="true" EnableViewState="false">
                                <asp:ListItem Text=" -- Select a Training -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvaddTraining" runat="server" InitialValue="-1" ControlToValidate="dropaddTraining"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>	
                           </div>
						<br />
                        <div class="form-inline">
                                    <asp:Label ID="lbladdTrainingDate" Font-Bold="true" runat="server" align="Right" Width="150" Text="*Training date: "></asp:Label>
                                    <asp:TextBox ID="txtaddTrainingDate" ForeColor="Red" CssClass="form-control" runat="server" Width="130" ></asp:TextBox>
                                    <asp:Image ID="imgaddTrainingDate" runat="server" Width="20" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="ceaddTrainingDate" runat="server"  TargetControlID="txtaddTrainingDate" OnClientShowing="ajaxToolkit_CalendarExtenderClientShowing" CssClass="form-control" Format="MM/dd/yyyy" PopupButtonID="imgaddTrainingDate" />
                                   	
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvaddTrainingDate" runat="server" ControlToValidate="txtaddTrainingDate"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>	
                             </div>			
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbladdTrainingStatus" runat="server" align="Right" Width="150" Text="*Training Status: "></asp:Label></b>
                            <asp:DropDownList ID="dropaddTrainingStatus" AppendDataBoundItems="true" CssClass="form-control" Width="350" runat="server" DataSourceID="SqlTrainingStatus" DataValueField="CODE_ISN" DataTextField="CODE_DESCRIPTION" EnableViewState="false">
                            <asp:ListItem Text=" -- Select a training status -- " Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="addvalidation" ID="rfvdropaddTrainingStatus" runat="server" InitialValue="-1" ControlToValidate="dropaddTrainingStatus"
								Display="Dynamic" ForeColor="Red" ErrorMessage="required."></asp:RequiredFieldValidator>
                        
                        </div>
						<br />
                        <div class="form-inline">
                            <b><asp:Label ID="lblAddNote" runat="server" align="Right" Width="150" Text="Note: "></asp:Label></b>
                            <asp:TextBox ID="txtAddNote" MaxLength="300" CssClass="form-control" runat="server" Width="300" TextMode="MultiLine"></asp:TextBox>
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
                        &times</button>  
                    <center><h4 style="color:white" class="modal-title"> Training View </h4></center>
                </div>
                     <asp:UpdatePanel ID="upDisplayUser" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div role="form" >
                        
					<div class="form-inline">
                            <b><asp:Label ID="lbldisplayUser" runat="server" align="right" Width="150" Text="User Name: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayUser" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayTrainingType" runat="server" align="right" Width="150" Text="Training Type: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayTrainingType" runat="server" Width="150"  ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                            </div>
                        <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayTraining" runat="server" align="right" Width="150" Text="Training: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayTraining" runat="server" Width="350" TextMode="MultiLine" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                            </div>
                        <br />
                        
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayTrainingDate" runat="server" align="right" Width="150" Text="Training Date: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayTrainingDate" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />

                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayTrainingStatus" runat="server" align="right" Width="150" Text="Training Status: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayTrainingStatus" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>
                        <br />

                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayNote" runat="server" align="right" Width="150" Text="Note: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayNote" NullDisplayText=" " runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent" TextMode="MultiLine"></asp:TextBox>
                        </div>
                         <br />
                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayAddedBy" runat="server" align="right" Width="150" Text="Added by: "></asp:Label></b>
                            <asp:TextBox ID="txtdisplayAddedBy" runat="server" Width="300" ReadOnly="true" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                        </div>

                        <div class="form-inline">
                            <b><asp:Label ID="lbldisplayAddedDate" runat="server" align="right" Width="150" ></asp:Label></b>
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

    <a href="#" class="back-to-top">UP </a>
        
    </form>
</body>
</html>
