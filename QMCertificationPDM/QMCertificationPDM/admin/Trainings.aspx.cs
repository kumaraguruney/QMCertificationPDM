using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Trainings : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }


        if (!IsPostBack)
        {
            Session["mainselect"] = "SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, TRAININGHISTORY.NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN ORDER BY USERPROFILE.LAST_NAME, TRAININGHISTORY.TRAINING_DATE DESC";
            SqlTrainingHistory.SelectCommand = (string)Session["mainselect"];
            SqlTrainingHistory.DataBind();
        }

        if (IsPostBack)
        {
            SqlTrainingHistory.SelectCommand = (string)Session["mainselect"];
            SqlTrainingHistory.DataBind();
        }


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
            Int32 Key = Convert.ToInt32(gvTrainingHistory.DataKeys[index].Value.ToString());
            string strkey = Convert.ToString(Key);
            SqlData.SelectCommand = "SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, ISNULL(TRAININGHISTORY.NOTE,'') AS NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN WHERE TRAININGHISTORY.TRAINING_ISN=" + strkey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            string strUserISN = Convert.ToString(dvData[0].Row["USER_ISN"]);
            string strTrainigISN = Convert.ToString(dvData[0].Row["TRAINING_CODE_ISN"]);
            string strTrainigStatusISN = Convert.ToString(dvData[0].Row["TRAINING_STATUS_ISN"]);
            string strTrainingTypeISN = Convert.ToString(dvData[0].Row["TRAINING_TYPE_ISN"]);
            string strtrainingdate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["TRAINING_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["TRAINING_DATE"]).ToShortDateString());
            if (strtrainingdate != "")
            {
                ceTrainingDate.SelectedDate = DateTime.Parse(strtrainingdate);
                txtTrainingDate.Text = strtrainingdate;
            }
            string strNote = (string)dvData[0].Row["NOTE"];
            string strAddedBy = (string)dvData[0].Row["Added_By"];
            string strAddedDate = Convert.ToString(dvData[0].Row["Added_Date"]);
            string strUpdatedBy = (string)dvData[0].Row["Updated_By"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["Updated_Date"]);

            trainingisn.Value = strkey;
            dropTrainingType.SelectedValue = strTrainingTypeISN;
            dropTrainingStatus.SelectedValue = strTrainigStatusISN;
            dropUser.SelectedValue = strUserISN;
            dropTraining.SelectedValue = strTrainigISN;
            txtTrainingDate.Text = strtrainingdate;
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
            Int32 Key = Convert.ToInt32(gvTrainingHistory.DataKeys[index].Value.ToString());
            string strkey = Convert.ToString(Key);
            SqlData.SelectCommand = "SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, ISNULL(TRAININGHISTORY.NOTE,'') AS NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN WHERE TRAININGHISTORY.TRAINING_ISN=" + strkey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            string strName = Convert.ToString(dvData[0].Row["NAME"]);
            string strTraining = (string)dvData[0].Row["CODE_ID"];
            string strTrainingtype = (string)dvData[0].Row["TRAININGTYPEDESCRIPTION"];
            string strTrainingdesc = (string)dvData[0].Row["CODE_DESCRIPTION"];
            string strTrainingID = (string)dvData[0].Row["CODE_ID"];
            string strTrainigStatus = Convert.ToString(dvData[0].Row["TRAINING_STATUS"]);
            string strtrainingdate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["TRAINING_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["TRAINING_DATE"]).ToShortDateString());
            string strNote = (string)dvData[0].Row["NOTE"];
            string strAddedBy = (string)dvData[0].Row["Added_By"];
            string strAddedDate = Convert.ToString(dvData[0].Row["Added_Date"]);
            string strUpdatedBy = (string)dvData[0].Row["Updated_By"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["Updated_Date"]);

            txtdisplayUser.Text = strName;
            txtdisplayTrainingType.Text = strTrainingtype;
            txtdisplayTraining.Text = strTrainingdesc + " ( " + strTrainingID.Trim() + " ) " ;
            txtdisplayTrainingDate.Text = strtrainingdate;
            txtdisplayNote.Text = strNote;
            txtdisplayAddedBy.Text = strAddedBy;
            txtdisplayAddedDate.Text = strAddedDate;
            txtdisplayUpdatedBy.Text = strUpdatedBy;
            txtdisplayUpdatedDate.Text = strUpdatedDate;
            txtdisplayTrainingStatus.Text = strTrainigStatus;
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
        
            SqlTrainingHistory.InsertParameters["USER_ISN"].DefaultValue = dropaddUser.SelectedValue;
            SqlTrainingHistory.InsertParameters["TRAINING_CODE_ISN"].DefaultValue = dropaddTraining.SelectedValue;
            SqlTrainingHistory.InsertParameters["TRAINING_DATE"].DefaultValue = txtaddTrainingDate.Text.Trim();
            SqlTrainingHistory.InsertParameters["TRAINING_TYPE_ISN"].DefaultValue = dropaddTrainingType.SelectedValue;
            SqlTrainingHistory.InsertParameters["NOTE"].DefaultValue = txtAddNote.Text.ToUpper().Trim();
            string UserName = (string)Session["commonname"];
            string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            SqlTrainingHistory.InsertParameters["TRAINING_STATUS_ISN"].DefaultValue = dropaddTrainingStatus.SelectedValue;
            SqlTrainingHistory.InsertParameters["ADDED_BY"].DefaultValue = UserName.ToUpper().Trim();
            SqlTrainingHistory.InsertParameters["ADDED_DATE"].DefaultValue = CurrentDate;
            SqlTrainingHistory.InsertParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();
            SqlTrainingHistory.InsertParameters["UPDATED_DATE"].DefaultValue = CurrentDate;
            try
            {
                SqlTrainingHistory.Insert();
                txtaddTrainingDate.Text = string.Empty;
                txtAddNote.Text = string.Empty;
                adderror.Text = string.Empty;
                dropaddUser.SelectedIndex = -1;
                dropTraining.SelectedIndex = -1;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Training Added Successfully.');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                gvTrainingHistory.DataBind();
                upTrainingHistory.Update();

            }
            catch
            {
                adderror.Text = "An error has occurred while adding a training.";
                adderror.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

            }
        }

    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        String Userisn = UsersSearch.SelectedValue;
        if (Userisn == "%" && TrainingStatusSearch.SelectedValue == "%")
        {
            Session["mainselect"] = "SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, TRAININGHISTORY.NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN ORDER BY USERPROFILE.LAST_NAME, TRAININGHISTORY.TRAINING_DATE DESC";
            SqlTrainingHistory.SelectCommand = (string)Session["mainselect"];
        }
        else if (Userisn != "%" && TrainingStatusSearch.SelectedValue == "%")
        {
            Session["mainselect"] = "SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, TRAININGHISTORY.NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN  WHERE TRAININGHISTORY.TRAINING_CODE_ISN ='" + UsersSearch.SelectedValue + "' ORDER BY USERPROFILE.LAST_NAME, TRAININGHISTORY.TRAINING_DATE DESC ";
            SqlTrainingHistory.SelectCommand = (string)Session["mainselect"];
        }
        else if (Userisn != "%" && TrainingStatusSearch.SelectedValue != "%")
        {
            Session["mainselect"] = "SELECT TRAININGHISTORY.TRAINING_ISN, TRAININGHISTORY.TRAINING_TYPE_ISN, TRAININGHISTORY.USER_ISN, TRAININGHISTORY.TRAINING_CODE_ISN, TRAININGHISTORY.TRAINING_DATE, TRAININGHISTORY.NOTE, TRAININGHISTORY.ADDED_BY, TRAININGHISTORY.ADDED_DATE, TRAININGHISTORY.UPDATED_BY, TRAININGHISTORY.UPDATED_DATE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS NAME, CODE.CODE_DESCRIPTION, CODE.CODE_ID, TRAININGSTATUS.CODE_DESCRIPTION AS TRAINING_STATUS, TRAININGSTATUS.CODE_ID AS STATUS, TRAININGHISTORY.TRAINING_STATUS_ISN, TRAININGTYPE.CODE_ID AS TRAININGTYPE, TRAININGTYPE.CODE_DESCRIPTION AS TRAININGTYPEDESCRIPTION FROM TRAININGHISTORY INNER JOIN USERPROFILE ON TRAININGHISTORY.USER_ISN = USERPROFILE.USER_ISN INNER JOIN CODE AS TRAININGTYPE ON TRAININGTYPE.CODE_ISN = TRAININGHISTORY.TRAINING_TYPE_ISN INNER JOIN CODE ON CODE.CODE_ISN = TRAININGHISTORY.TRAINING_CODE_ISN LEFT OUTER JOIN CODE AS TRAININGSTATUS ON TRAININGHISTORY.TRAINING_STATUS_ISN = TRAININGSTATUS.CODE_ISN WHERE TRAININGHISTORY.TRAINING_CODE_ISN ='" + UsersSearch.SelectedValue + "' AND TRAININGHISTORY.TRAINING_STATUS_ISN ='" + TrainingStatusSearch.SelectedValue + "' ORDER BY USERPROFILE.LAST_NAME, TRAININGHISTORY.TRAINING_DATE DESC ";
            SqlTrainingHistory.SelectCommand = (string)Session["mainselect"];
        }
       
        gvTrainingHistory.DataBind();
        

    }
    protected void btnUserClear_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        Response.Redirect("Trainings.aspx");
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }
    protected void SqlTrainingHistory_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        totalTrainingValue.Text = e.AffectedRows.ToString();
    }
    protected void btnAddTraining_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        txtaddTrainingDate.Text = string.Empty;
        txtAddNote.Text = string.Empty;
        adderror.Text = string.Empty;
        dropaddUser.SelectedIndex = -1;
        dropaddTraining.SelectedIndex = -1;
        dropaddTrainingStatus.SelectedIndex = -1;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    protected void gvTrainingHistory_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void btnUpdateTraining_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        string UserName = (string)Session["commonname"];
        string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        SqlTrainingHistory.UpdateParameters["TRAINING_ISN"].DefaultValue = trainingisn.Value;
        SqlTrainingHistory.UpdateParameters["USER_ISN"].DefaultValue = dropUser.SelectedValue;
        SqlTrainingHistory.UpdateParameters["NOTE"].DefaultValue = txtNote.Text;
        SqlTrainingHistory.UpdateParameters["TRAINING_TYPE_ISN"].DefaultValue = dropTrainingType.SelectedValue;
        SqlTrainingHistory.UpdateParameters["TRAINING_CODE_ISN"].DefaultValue = dropTraining.SelectedValue;
        SqlTrainingHistory.UpdateParameters["TRAINING_STATUS_ISN"].DefaultValue = dropTrainingStatus.SelectedValue;
        SqlTrainingHistory.UpdateParameters["TRAINING_DATE"].DefaultValue = txtTrainingDate.Text.Trim();
        SqlTrainingHistory.UpdateParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();
        SqlTrainingHistory.UpdateParameters["UPDATED_DATE"].DefaultValue = CurrentDate;

        try
        {
            SqlTrainingHistory.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Training Profile Updated Successfully');");
            sb.Append("$('#editModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            gvTrainingHistory.DataBind();
            upTrainingHistory.Update();

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
    protected void UsersSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        TrainingStatusSearch.Enabled = true;
    }
    protected void dropaddTrainingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        dropaddTraining.Items.Clear();
        dropaddTraining.Items.Add(new ListItem("-- Select a Training --","-1"));
        string codetype = dropaddTrainingType.SelectedValue;

        SqlData.SelectCommand = "SELECT CODE_ID FROM CODE WHERE CODE_ISN = " + codetype;
        DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
        DataView dvData = (DataView)SqlData.Select(dsArguments);
        string strCodeType = Convert.ToString(dvData[0].Row["CODE_ID"]);

        SqlTrainings.SelectParameters["CODE_TYPE"].DefaultValue = strCodeType.Trim();

    }
}