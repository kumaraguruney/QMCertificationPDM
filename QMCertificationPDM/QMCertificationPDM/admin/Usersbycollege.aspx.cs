using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UserManagement : System.Web.UI.Page
{
    static Int32 Key;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        if (!IsPostBack)
        {
            Session["Userbycollege"] = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN ORDER BY USERPROFILE.LAST_NAME";
            SqlUserProfile.SelectCommand = (string)Session["UserbyTrainingType"];
            SqlUserProfile.DataBind();
        }

        if (IsPostBack)
        {
            SqlUserProfile.SelectCommand = (string)Session["Userbycollege"];
            SqlUserProfile.DataBind();
        }

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
            Key = Convert.ToInt32(gvUserProfile.DataKeys[index].Value.ToString());
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

        if (UserProfileCollegeSearch.SelectedValue == "-1" &&  UserProfileDeptSearch.SelectedValue == "-1")
        {
            Session["Userbycollege"] = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN ORDER BY USERPROFILE.LAST_NAME";
                
            SqlUserProfile.SelectCommand = (string)Session["Userbycollege"];
        }
        else if (UserProfileCollegeSearch.SelectedValue != "-1" && UserProfileDeptSearch.SelectedValue == "-1")
        {
            Session["Userbycollege"] = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE (USERPROFILE.COLL_CODE_ISN = '" + UserProfileCollegeSearch.SelectedValue + "') ORDER BY USERPROFILE.LAST_NAME";
            SqlUserProfile.SelectCommand = (string)Session["Userbycollege"];
        }
        else if (UserProfileCollegeSearch.SelectedValue != "-1" && UserProfileDeptSearch.SelectedValue != "-1")
        {
            Session["Userbycollege"] = "SELECT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME, USERPROFILE.FIRST_NAME, USERPROFILE.MIDDLE_INITIAL, USERPROFILE.EMAIL, USERPROFILE.COLL_CODE_ISN, USERPROFILE.DEPT_CODE_ISN, USERPROFILE.PHONE_NUMBER, USERPROFILE.EXTENSION_NUMBER, USERPROFILE.USER_STATUS, USERPROFILE.IS_MASTER_REVIEWER, USERPROFILE.IS_INTERNAL_REVIEWER, USERPROFILE.IS_OFFICIAL_REVIEWER, USERPROFILE.IS_DEVELOPER, USERPROFILE.IS_COORDINATOR, USERPROFILE.ADDED_BY, USERPROFILE.ADDED_DATE, USERPROFILE.UPDATED_BY, USERPROFILE.UPDATED_DATE, USERPROFILE.NOTE, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT FROM USERPROFILE LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE (USERPROFILE.COLL_CODE_ISN = '" + UserProfileCollegeSearch.SelectedValue + "') AND (USERPROFILE.DEPT_CODE_ISN = '" + UserProfileDeptSearch.SelectedValue + "') ORDER BY USERPROFILE.LAST_NAME";
            SqlUserProfile.SelectCommand = (string)Session["Userbycollege"];
        }
        SqlUserProfile.DataBind();
        gvUserProfile.DataBind();

    }
    protected void btnUserClear_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        Response.Redirect("Usersbycollege.aspx");
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
            Key = Convert.ToInt32(gvUserProfile.DataKeys[index].Value.ToString());
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