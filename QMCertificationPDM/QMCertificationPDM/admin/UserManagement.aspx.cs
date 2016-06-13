using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UserManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
    }
    		
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        txtaddLastName.Text = string.Empty;
        txtaddFirstName.Text = string.Empty;
        txtaddMiddleInitial.Text = string.Empty;
        txtaddEmail.Text = string.Empty;
        txtaddContactNumber.Text = string.Empty;
        txtaddExtension.Text = string.Empty;
        txtaddNote.Text = string.Empty;
        adderror.Text = string.Empty;
        rbaddActiveList.SelectedIndex = 0;
        ckaddCoordinator.Checked = false; ckaddDeveloper.Checked = false; ckaddInternalReviewer.Checked = false; ckaddMasterReviewer.Checked = false; ckaddOfficialReviewer.Checked = false;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }


    protected void gvUserProfile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

         DataControlRowType rtype = e.Row.RowType;
        if (rtype == DataControlRowType.Header)
        {
            e.Row.Cells[6].ToolTip = "Middle Initial";
            e.Row.Cells[9].ToolTip = "Phone Number";
            e.Row.Cells[12].ToolTip = "Master Reviewer";
            e.Row.Cells[13].ToolTip = "Internal Reviewer";
            e.Row.Cells[14].ToolTip = "Official Reviewer";
            e.Row.Cells[15].ToolTip = "Developer";
            e.Row.Cells[16].ToolTip = "Coordinator";
        } 
    }

    DataControlFieldCell GetCellByBoundFieldName(GridViewRow row, string fieldName)
    {
        foreach (DataControlFieldCell cell in row.Cells)
        {
            BoundField bf = cell.ContainingField as BoundField;
            if (bf != null)
            {
                if (bf.DataField == fieldName)
                {
                    return cell;
                }
            }
        }
        return null;
    }


    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            editError.Text = string.Empty;
            ImageButton lnk = (ImageButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            Int32 Key = Convert.ToInt32(gvUserProfile.DataKeys[index].Value.ToString());
            string strkey = Convert.ToString(Key);
            SqlData.SelectCommand = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, ISNULL(USERPROFILE.MIDDLE_INITIAL,'') AS MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, ISNULL(USERPROFILE.PHONE_NUMBER,'')AS PHONE_NUMBER, ISNULL(USERPROFILE.EXTENSION_NUMBER,'') AS EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, ISNULL(USERPROFILE.NOTE,'') AS NOTE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, ISNULL(CODE.CODE_DESCRIPTION,'') AS COLLEGE, ISNULL(CODE_1.CODE_DESCRIPTION,'') AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE USER_ISN =" + strkey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            string strLastName = Convert.ToString(dvData[0].Row["LAST_NAME"]);
            string strFirstName = (string)dvData[0].Row["FIRST_NAME"];
            string strMiddleInitial = (string)dvData[0].Row["MIDDLE_INITIAL"];
            string strEmail = (string)dvData[0].Row["EMAIL"];
            string strPhoneNumber = (string)dvData[0].Row["PHONE_NUMBER"];
            string strExtn = (string)dvData[0].Row["EXTENSION_NUMBER"];
            string strUserStatus = Convert.ToString(dvData[0].Row["USER_STATUS"]);
            string strMR = Convert.ToString(dvData[0].Row["IS_MASTER_REVIEWER"]);
            string strIR = Convert.ToString(dvData[0].Row["IS_INTERNAL_REVIEWER"]);
            string strOR = Convert.ToString(dvData[0].Row["IS_OFFICIAL_REVIEWER"]);
            string strDevr = Convert.ToString(dvData[0].Row["IS_DEVELOPER"]);
            string strCoordinator = Convert.ToString(dvData[0].Row["IS_COORDINATOR"]);
            string strAddedBy = (string)dvData[0].Row["Added_By"];
            string strAddedDate = Convert.ToString(dvData[0].Row["Added_Date"]);
            string strUpdatedBy = (string)dvData[0].Row["Updated_By"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["Updated_Date"]);
            string strCollege = (string)dvData[0].Row["College"];
            string strDepartment = (string)dvData[0].Row["Department"];
            string strNote = (string)dvData[0].Row["Note"];
            userisn.Value = strkey;
            txtLastName.Text = strLastName;
            txtFirstName.Text = strFirstName;
            txtMiddleInitial.Text = strMiddleInitial == "&nbsp;" ? "" : strMiddleInitial;
            txtEmail.Text = strEmail;
            SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION  = '" + strCollege + "'";
            DataView dvCodeId = (DataView)SqlData.Select(dsArguments);
            string StrISN;
            if (dvCodeId.Count > 0)
            {
                StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
                dropCollege.SelectedValue = StrISN;
            }
            else
                dropCollege.SelectedValue = "-1";
            
            if (dropCollege.SelectedValue != "-1")
            {


                SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION  = '" + strDepartment + "'";
                dsArguments = new DataSourceSelectArguments();
                dvCodeId = (DataView)SqlData.Select(dsArguments);
                if (dvCodeId.Count > 0)
                {
                    StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
                    dropDepartment.SelectedValue = StrISN;
                }
                else
                    dropDepartment.SelectedValue = "-1";
            }
            txtContactNumber.Text = strPhoneNumber == "&nbsp;" ? "" : strPhoneNumber;
            txtExtension.Text = strExtn == "&nbsp;" ? "" : strExtn;
            rbUserlist.SelectedIndex = Convert.ToByte(strUserStatus == "True" ? "0" : "1");
            ckMasterReviewer.Checked = Convert.ToBoolean(strMR);
            ckInternalReviewer.Checked = Convert.ToBoolean(strIR);
            ckOfficialReviewer.Checked = Convert.ToBoolean(strOR);
            ckDeveloper.Checked = Convert.ToBoolean(strDevr);
            ckCoordinator.Checked = Convert.ToBoolean(strCoordinator);
            txtNote.Text = strNote == "&nbsp;" ? "" : strNote;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditShowModalScript", sb.ToString(), false);
        }
    }

    protected void lnkDisplay_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            ImageButton lnk = (ImageButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            Int32 Key = Convert.ToInt32(gvUserProfile.DataKeys[index].Value.ToString());
            string strkey = Convert.ToString(Key);
            SqlData.SelectCommand = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, ISNULL(USERPROFILE.MIDDLE_INITIAL,'') AS MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, ISNULL(USERPROFILE.PHONE_NUMBER,'')AS PHONE_NUMBER, ISNULL(USERPROFILE.EXTENSION_NUMBER,'') AS EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, ISNULL(USERPROFILE.NOTE,'') AS NOTE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, ISNULL(CODE.CODE_DESCRIPTION,'') AS COLLEGE, ISNULL(CODE_1.CODE_DESCRIPTION,'') AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE USER_ISN =" + strkey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            string strLastName = Convert.ToString(dvData[0].Row["LAST_NAME"]);
            string strFirstName = (string)dvData[0].Row["FIRST_NAME"];
            string strMiddleInitial = (string)dvData[0].Row["MIDDLE_INITIAL"];
            string strEmail = (string)dvData[0].Row["EMAIL"];
            string strPhoneNumber = (string)dvData[0].Row["PHONE_NUMBER"];
            string strExtn = (string)dvData[0].Row["EXTENSION_NUMBER"];
            string strUserStatus = Convert.ToString(dvData[0].Row["USER_STATUS"]);
            string strMR = Convert.ToString(dvData[0].Row["IS_MASTER_REVIEWER"]);
            string strIR = Convert.ToString(dvData[0].Row["IS_INTERNAL_REVIEWER"]);
            string strOR = Convert.ToString(dvData[0].Row["IS_OFFICIAL_REVIEWER"]);
            string strDevr = Convert.ToString(dvData[0].Row["IS_DEVELOPER"]);
            string strCoordinator = Convert.ToString(dvData[0].Row["IS_COORDINATOR"]);
            string strAddedBy = (string)dvData[0].Row["Added_By"];
            string strAddedDate = Convert.ToString(dvData[0].Row["Added_Date"]);
            string strUpdatedBy = (string)dvData[0].Row["Updated_By"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["Updated_Date"]);
            string strCollege = (string)dvData[0].Row["College"];
            string strDepartment = (string)dvData[0].Row["Department"];
            string strNote = (string)dvData[0].Row["Note"];

            txtdisplayLastName.Text = strLastName;
            txtdisplayFirstName.Text = strFirstName;
            txtdisplayMiddleInitial.Text = strMiddleInitial;
            txtdisplayEmail.Text = strEmail;
            txtdisplayCollege.Text = strCollege;
            txtdisplayDepartment.Text = strDepartment;
            txtdisplayContactNumber.Text = strPhoneNumber;
            txtdisplayExtension.Text = strExtn;
            rbdisplayActiveList.SelectedIndex = Convert.ToByte(strUserStatus == "True" ? "0" : "1");
            ckdisplayMasterReviewer.Checked = Convert.ToBoolean(strMR);
            ckdisplayInternalReviewer.Checked = Convert.ToBoolean(strIR);
            ckdisplayOfficialReviewer.Checked = Convert.ToBoolean(strOR);
            ckdisplayDeveloper.Checked = Convert.ToBoolean(strDevr);
            ckdisplayCoordinator.Checked = Convert.ToBoolean(strCoordinator);
            txtdisplayNote.Text = strNote;
            txtdisplayAddedBy.Text = strAddedBy;
            txtdisplayAddedDate.Text = strAddedDate;
            txtdisplayUpdatedBy.Text = strUpdatedBy;
            txtdisplayUpdatedDate.Text = strUpdatedDate;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#displayModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayShowModalScript", sb.ToString(), false);
        }
    }

    protected void btnaddSave_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();

        
        SqlAddUser.SelectParameters["Email"].DefaultValue = txtaddEmail.Text.ToUpper().Trim();


        DataView dvUserExists = new DataView();

        dvUserExists = (DataView)SqlAddUser.Select(dsArguments);

        if (dvUserExists.Count >= 1)
        {
            txtaddLastName.Text = string.Empty;
            txtaddFirstName.Text = string.Empty;
            txtaddMiddleInitial.Text = string.Empty;
            txtaddEmail.Text = string.Empty;
            txtaddContactNumber.Text = string.Empty;
            txtaddExtension.Text = string.Empty;
            txtaddNote.Text = string.Empty;
            rbaddActiveList.SelectedIndex = -1;
            ckaddCoordinator.Checked = false; ckaddDeveloper.Checked = false; ckaddInternalReviewer.Checked = false; ckaddMasterReviewer.Checked = false; ckaddOfficialReviewer.Checked = false;
            adderror.ForeColor = System.Drawing.Color.Red;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('User profile can not be added because email already exists in the system.');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddErrorModalScript", sb.ToString(), false);
        }
        else
        {
            SqlUserProfile.InsertParameters["Last_Name"].DefaultValue = txtaddLastName.Text.ToUpper().Trim();
            SqlUserProfile.InsertParameters["First_Name"].DefaultValue = txtaddFirstName.Text.ToUpper().Trim();
            SqlUserProfile.InsertParameters["Middle_Initial"].DefaultValue = txtaddMiddleInitial.Text.ToUpper().Trim();
            SqlUserProfile.InsertParameters["Email"].DefaultValue = txtaddEmail.Text.ToUpper().Trim();

            if (addDropCollege.SelectedValue != "-1")
            {
                SqlUserProfile.InsertParameters["COLL_CODE_ISN"].DefaultValue = addDropCollege.SelectedValue;
                if (addDropDepartment.SelectedValue != "-1")
                    SqlUserProfile.InsertParameters["DEPT_CODE_ISN"].DefaultValue = addDropDepartment.SelectedValue;
                else
                    SqlUserProfile.InsertParameters["DEPT_CODE_ISN"].DefaultValue = null;
            }
            else
            {
                SqlUserProfile.InsertParameters["COLL_CODE_ISN"].DefaultValue = null;
                SqlUserProfile.InsertParameters["DEPT_CODE_ISN"].DefaultValue = null;
            }
            
            SqlUserProfile.InsertParameters["Phone_Number"].DefaultValue = txtaddContactNumber.Text;
            SqlUserProfile.InsertParameters["Extension_Number"].DefaultValue = txtaddExtension.Text.Trim();
            SqlUserProfile.InsertParameters["USER_STATUS"].DefaultValue = rbaddActiveList.SelectedValue;
            SqlUserProfile.InsertParameters["Is_Master_Reviewer"].DefaultValue = ckaddMasterReviewer.Checked == true ? "true" : "false";
            SqlUserProfile.InsertParameters["Is_Internal_Reviewer"].DefaultValue = ckaddInternalReviewer.Checked == true ? "true" : "false";
            SqlUserProfile.InsertParameters["Is_Official_Reviewer"].DefaultValue = ckaddOfficialReviewer.Checked == true ? "true" : "false";
            SqlUserProfile.InsertParameters["Is_Developer"].DefaultValue = ckaddDeveloper.Checked == true ? "true" : "false";
            SqlUserProfile.InsertParameters["Is_Coordinator"].DefaultValue = ckaddCoordinator.Checked == true ? "true" : "false";
            SqlUserProfile.InsertParameters["Note"].DefaultValue = txtaddNote.Text.ToUpper().Trim();

            string UserName = (string)Session["commonname"];
            string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

            SqlUserProfile.InsertParameters["ADDED_BY"].DefaultValue = UserName.ToUpper().Trim();
            SqlUserProfile.InsertParameters["ADDED_DATE"].DefaultValue = CurrentDate;
            SqlUserProfile.InsertParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();
            SqlUserProfile.InsertParameters["UPDATED_DATE"].DefaultValue = CurrentDate;
            try
            {
                SqlUserProfile.Insert();
                txtaddLastName.Text = string.Empty;
                txtaddFirstName.Text = string.Empty;
                txtaddMiddleInitial.Text = string.Empty;
                txtaddEmail.Text = string.Empty;
                txtaddContactNumber.Text = string.Empty;
                txtaddExtension.Text = string.Empty;
                txtaddNote.Text = string.Empty;
                adderror.Text = string.Empty;
                rbaddActiveList.SelectedIndex = -1;
                ckaddCoordinator.Checked = false; ckaddDeveloper.Checked = false; ckaddInternalReviewer.Checked = false; ckaddMasterReviewer.Checked = false; ckaddOfficialReviewer.Checked = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('User Added Successfully');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                gvUserProfile.DataBind();
                UserProfileSearch.AppendDataBoundItems = false;
                upUserProfile.Update();

            }
            catch
            {
                adderror.Text = "An error has occured while adding a user please contact administrator";
                adderror.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

            }
        }
    }

    protected void btnUpdateUser_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        string UserName = (string)Session["commonname"];
        string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        SqlUserProfile.UpdateParameters["USER_ISN"].DefaultValue = userisn.Value;
        SqlUserProfile.UpdateParameters["Last_Name"].DefaultValue = txtLastName.Text.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["First_Name"].DefaultValue = txtFirstName.Text.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["Middle_Initial"].DefaultValue = txtMiddleInitial.Text.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["Email"].DefaultValue = txtEmail.Text.ToUpper().Trim();
        if (dropCollege.SelectedValue != "-1")
        {
            SqlUserProfile.UpdateParameters["COLL_CODE_ISN"].DefaultValue = dropCollege.SelectedValue;
            if (dropDepartment.SelectedValue != "-1")
                SqlUserProfile.UpdateParameters["DEPT_CODE_ISN"].DefaultValue = dropDepartment.SelectedValue;
            else
                SqlUserProfile.UpdateParameters["DEPT_CODE_ISN"].DefaultValue = null;
        }
        else
        {
            SqlUserProfile.UpdateParameters["COLL_CODE_ISN"].DefaultValue = null;
            SqlUserProfile.UpdateParameters["DEPT_CODE_ISN"].DefaultValue = null;
        }
        
        SqlUserProfile.UpdateParameters["Phone_Number"].DefaultValue = txtContactNumber.Text.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["Extension_Number"].DefaultValue = txtExtension.Text.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["USER_STATUS"].DefaultValue = rbUserlist.SelectedValue;
        SqlUserProfile.UpdateParameters["Is_Master_Reviewer"].DefaultValue = ckMasterReviewer.Checked == true ? "true" : "false";
        SqlUserProfile.UpdateParameters["Is_Internal_Reviewer"].DefaultValue = ckInternalReviewer.Checked == true ? "true" : "false";
        SqlUserProfile.UpdateParameters["Is_Official_Reviewer"].DefaultValue = ckOfficialReviewer.Checked == true ? "true" : "false";
        SqlUserProfile.UpdateParameters["Is_Developer"].DefaultValue = ckDeveloper.Checked == true ? "true" : "false";
        SqlUserProfile.UpdateParameters["Is_Coordinator"].DefaultValue = ckCoordinator.Checked == true ? "true" : "false";
        SqlUserProfile.UpdateParameters["Note"].DefaultValue = txtNote.Text.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();
        SqlUserProfile.UpdateParameters["UPDATED_DATE"].DefaultValue =  CurrentDate;
        
        try
        {
            SqlUserProfile.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('User Profile Updated Successfully');");
            sb.Append("$('#editModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            gvUserProfile.DataBind();
            upUserProfile.Update();
            
        }
        catch
        {
            editError.Text = "Error: Record NOT updated.";
            editError.ForeColor = System.Drawing.Color.Red;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }
        
    }

    protected void gvUserProfile_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        } 

        if (e.Row.RowType == DataControlRowType.Pager)
        {
            TableCell tc = new TableCell();
            tc.Text = "Page &nbsp;";
            TableRow tr = (TableRow)e.Row.Cells[0].Controls[0].Controls[0];
            tr.Cells.AddAt(0, tc);
        }
    }
    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        String LastName = UserProfileSearch.SelectedValue ;
        if (LastName != "%")
        {
            SqlUserProfile.SelectCommand = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Disabled' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE USERPROFILE.LAST_NAME ='"+ LastName + "' ";
        }
        gvUserProfile.DataBind();

    }
    protected void btnUserClear_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        Response.Redirect("UserManagement.aspx");
    }
	
    
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }
    protected void SqlUserProfile_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        totalUserValue.Text = e.AffectedRows.ToString();
    }
    protected void lnkTrainings_Click(object sender, ImageClickEventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            ImageButton lnk = (ImageButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            Int32 Key = Convert.ToInt32(gvUserProfile.DataKeys[index].Value.ToString());
            string strkey = Convert.ToString(Key);
            SqlData.SelectCommand = "SELECT LAST_NAME + ', ' + FIRST_NAME AS NAME FROM USERPROFILE WHERE USER_ISN =" + Key;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvCodeId = (DataView)SqlData.Select(dsArguments);
            string Name = (string)dvCodeId[0].Row["NAME"];
            lblUserName.Text = Name;
            SqlTrainingHistory.SelectParameters["USER_ISN"].DefaultValue = strkey;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#trainingModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "trainingShowModalScript", sb.ToString(), false);
        }
    }
    protected void gvTrainings_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        if (e.Row.RowType == DataControlRowType.Pager)
        {
            TableCell tc = new TableCell();
            tc.Text = "Page &nbsp;";
            TableRow tr = (TableRow)e.Row.Cells[0].Controls[0].Controls[0];
            tr.Cells.AddAt(0, tc);
        }
    }
    protected void SqlTrainingHistory_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblTotalTrainingsCount.Text = e.AffectedRows.ToString();
    }
}