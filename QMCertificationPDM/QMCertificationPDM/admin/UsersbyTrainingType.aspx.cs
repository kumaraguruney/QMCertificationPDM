using System;
using System.Web.UI.WebControls;

public partial class admin_UserManagement : System.Web.UI.Page
{

    static string strtypeISN;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        if (!IsPostBack)
        {
            Session["UserbyTrainingType"] = "SELECT DISTINCT CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name FROM USERPROFILE INNER JOIN TRAININGHISTORY ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGSTATUS ON TRAININGSTATUS.CODE_ID = 'C' AND TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN WHERE (USERPROFILE.COLL_CODE_ISN = 0) ORDER BY COLLEGE, DEPARTMENT, NAME";
            SqlUserProfile.SelectCommand = (string)Session["UserbyTrainingType"];
            SqlUserProfile.DataBind();
        }

        if (IsPostBack)
        {
            SqlUserProfile.SelectCommand = (string)Session["UserbyTrainingType"];
            SqlUserProfile.DataBind();
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

        if ( UserProfileTrainingTypeSearch.SelectedValue != "-1" && UserProfileCollegeSearch.SelectedValue == "-1" &&  UserProfileDeptSearch.SelectedValue == "-1")
        {
            Session["UserbyTrainingType"] = "SELECT DISTINCT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT, TRAININGHISTORY.TRAINING_TYPE_ISN FROM USERPROFILE INNER JOIN TRAININGHISTORY ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN AND TRAININGHISTORY.TRAINING_TYPE_ISN = '"+ UserProfileTrainingTypeSearch.SelectedValue +"' INNER JOIN CODE AS TRAININGSTATUS ON TRAININGSTATUS.CODE_ID = 'C' AND TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN ORDER BY COLLEGE, DEPARTMENT, NAME";
            SqlUserProfile.SelectCommand = (string)Session["UserbyTrainingType"];
        }
        else if (UserProfileTrainingTypeSearch.SelectedValue != "-1" && UserProfileCollegeSearch.SelectedValue != "-1" && UserProfileDeptSearch.SelectedValue == "-1")
        {
            Session["UserbyTrainingType"] = "SELECT DISTINCT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT, TRAININGHISTORY.TRAINING_TYPE_ISN FROM USERPROFILE INNER JOIN TRAININGHISTORY ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN AND TRAININGHISTORY.TRAINING_TYPE_ISN = '" + UserProfileTrainingTypeSearch.SelectedValue + "' INNER JOIN CODE AS TRAININGSTATUS ON TRAININGSTATUS.CODE_ID = 'C' AND TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE (USERPROFILE.COLL_CODE_ISN ='" + UserProfileCollegeSearch.SelectedValue + "') ORDER BY COLLEGE, DEPARTMENT, NAME";
            SqlUserProfile.SelectCommand = (string)Session["UserbyTrainingType"];
        }
        else if (UserProfileTrainingTypeSearch.SelectedValue != "-1" && UserProfileCollegeSearch.SelectedValue != "-1" && UserProfileDeptSearch.SelectedValue != "-1")
        {
            Session["UserbyTrainingType"] = "SELECT DISTINCT USERPROFILE.USER_ISN, USERPROFILE.LAST_NAME + ',' + USERPROFILE.FIRST_NAME + '  ' + CASE WHEN USER_STATUS = 1 THEN ' ' ELSE ' - Unavailable' END AS Name, CODE.CODE_DESCRIPTION AS COLLEGE, CODE_1.CODE_DESCRIPTION AS DEPARTMENT, TRAININGHISTORY.TRAINING_TYPE_ISN FROM USERPROFILE INNER JOIN TRAININGHISTORY ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN AND TRAININGHISTORY.TRAINING_TYPE_ISN = '" + UserProfileTrainingTypeSearch.SelectedValue + "' INNER JOIN CODE AS TRAININGSTATUS ON TRAININGSTATUS.CODE_ID = 'C' AND TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = USERPROFILE.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = USERPROFILE.DEPT_CODE_ISN WHERE (USERPROFILE.COLL_CODE_ISN ='" + UserProfileCollegeSearch.SelectedValue + "') AND (USERPROFILE.DEPT_CODE_ISN ='" + UserProfileDeptSearch.SelectedValue + "') ORDER BY COLLEGE, DEPARTMENT, NAME";
            SqlUserProfile.SelectCommand = (string)Session["UserbyTrainingType"];
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
        Response.Redirect("usersbytrainingtype.aspx");
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
    protected void UserProfileTrainingTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (strtypeISN != UserProfileTrainingTypeSearch.SelectedValue)
        {
            UserProfileCollegeSearch.SelectedIndex = -1;
            UserProfileDeptSearch.SelectedIndex = -1;
        }
        strtypeISN = UserProfileTrainingTypeSearch.SelectedValue;
    }
}