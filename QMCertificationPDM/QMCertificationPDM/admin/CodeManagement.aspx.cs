using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_CodeManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        if (!IsPostBack)
        {
            Session["codemainselect"] = "SELECT *  FROM [CODE] ORDER BY [CODE_TYPE], [CODE_ID]";
            SqlCode.SelectCommand = (string)Session["codemainselect"];
            SqlCode.DataBind();
        }
        if (IsPostBack)
        {
            SqlCode.SelectCommand = (string) Session["codemainselect"];
            SqlCode.DataBind();
        }
 
            
    }
    protected void btnCodeFilter_Click(object sender, EventArgs e)
    {
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        
        string codeType = CodeTypeSearch.SelectedValue.Trim();
        string codeId = CodeIdSearch.SelectedValue.Trim();
        if (codeType == "%" && codeId == "%")
        {
            Session["codemainselect"] = "SELECT *  FROM [CODE] ORDER BY [CODE_TYPE], [CODE_ID]";
            SqlCode.SelectCommand = (string)Session["codemainselect"];
            gvCode.DataBind();
        }
        else if (codeType != "%" && codeId == "%")
        {
            Session["codemainselect"] =  "SELECT * FROM [CODE] WHERE CODE_TYPE = '" + codeType + "' ORDER BY CODE_TYPE, CODE_ID";
            SqlCode.SelectCommand = (string)Session["codemainselect"];
            gvCode.DataBind();
        }
        else if (codeType != "%" && codeId != "%")
        {
            Session["codemainselect"] = "SELECT * FROM [CODE] WHERE CODE_TYPE = '" + codeType + "' AND CODE_ID = '" + codeId + "' ORDER BY CODE_TYPE, CODE_ID";
            SqlCode.SelectCommand = (string)Session["codemainselect"];
            SqlCode.DataBind();
            gvCode.DataBind();
        }

    }
    protected void btnCodeClear_Click(object sender, EventArgs e)
    {
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        Response.Redirect("CodeManagement.aspx");
    }
    protected void btnAddCode_Click(object sender, EventArgs e)
    {
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        addError.Text = string.Empty;
        txtaddCodeType.Text = string.Empty;
        txtaddCodeId.Text = string.Empty;
        txtaddCodeDescription.Text = string.Empty;
        rbaddEnableList.SelectedIndex = 0;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        addError.Text = string.Empty;
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }

    protected void gvCode_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void lnkDisplay_Click(object sender, ImageClickEventArgs e)
    {
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            ImageButton lnk = (ImageButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            Int32 codeKey = Convert.ToInt32(gvCode.DataKeys[index].Value.ToString());
            string strcodekey = Convert.ToString(codeKey);
            SqlData.SelectCommand = "SELECT * FROM CODE WHERE CODE_ISN =" + strcodekey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            string strCodeStatus = Convert.ToString(dvData[0].Row["Code_Status"]);
            string strCodeType = (string)dvData[0].Row["Code_Type"];
            string strCodeID = (string)dvData[0].Row["Code_ID"];
            string strCodeDescription = (string)dvData[0].Row["Code_Description"];
            string strAddedBy = (string)dvData[0].Row["Added_By"];
            string strAddedDate = Convert.ToString(dvData[0].Row["Added_Date"]);
            string strUpdatedBy = (string)dvData[0].Row["Updated_By"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["Updated_Date"]);
            txtdisplayCodeType.Text = strCodeType;
            txtdisplayCodeId.Text = strCodeID;
            txtdisplayCodeDescription.Text = strCodeDescription;
            rbdisplayEnableList.SelectedIndex = Convert.ToByte(strCodeStatus == "True" ? "0" : "1");
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
    protected void lnkEdit_Click(object sender, ImageClickEventArgs e)
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
            Int32 codeKey = Convert.ToInt32(gvCode.DataKeys[index].Value.ToString());
            string strcodekey = Convert.ToString(codeKey);
            SqlData.SelectCommand = "SELECT * FROM CODE WHERE CODE_ISN =" + strcodekey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            string strCodeStatus = Convert.ToString(dvData[0].Row["Code_Status"]);
            string strCodeType = (string)dvData[0].Row["Code_Type"];
            string strCodeID = (string)dvData[0].Row["Code_ID"];
            string strCodeDescription = (string)dvData[0].Row["Code_Description"];
            string strAddedBy = (string)dvData[0].Row["Added_By"];
            string strAddedDate = Convert.ToString(dvData[0].Row["Added_Date"]);
            string strUpdatedBy = (string)dvData[0].Row["Updated_By"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["Updated_Date"]);
            codeisn.Value = strcodekey;
            txtCodeType.Text = strCodeType;
			txtCodeType.Enabled = false;
            txtCodeId.Text = strCodeID;
			txtCodeId.Enabled = false;			
            txtCodeDescription.Text = strCodeDescription;
            rbCodeEnablelist.SelectedIndex = Convert.ToByte(strCodeStatus == "True" ? "0" : "1");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditShowModalScript", sb.ToString(), false);
        }
    }
    protected void btnUpdateCode_Click(object sender, EventArgs e)
    {
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
		
		string UserName = (string)Session["commonname"];
		string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        SqlCode.UpdateParameters["CODE_ISN"].DefaultValue = codeisn.Value;
        SqlCode.UpdateParameters["CODE_TYPE"].DefaultValue = txtCodeType.Text;
        SqlCode.UpdateParameters["CODE_ID"].DefaultValue = txtCodeId.Text;
        SqlCode.UpdateParameters["CODE_DESCRIPTION"].DefaultValue = txtCodeDescription.Text;
        SqlCode.UpdateParameters["CODE_STATUS"].DefaultValue = rbCodeEnablelist.SelectedValue;
		SqlCode.UpdateParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();
		SqlCode.UpdateParameters["UPDATED_DATE"].DefaultValue = CurrentDate;
        
        try
        {
            SqlCode.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Record Updated Successfully');");
            sb.Append("$('#editModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            gvCode.DataBind();
            upCode.Update();

        }
        catch
        {
            editError.Text = "An error has occured in updation of Record";
            editError.ForeColor = System.Drawing.Color.Red;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        }
    }
    protected void btnaddSave_Click(object sender, EventArgs e)
    {
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();

        SqlAddCode.SelectCommand = " SELECT * FROM CODE WHERE CODE_TYPE = @CODE_TYPE  AND CODE_ID = @CODE_ID ";

        SqlAddCode.SelectParameters["CODE_TYPE"].DefaultValue = txtaddCodeType.Text.Trim();
        SqlAddCode.SelectParameters["CODE_ID"].DefaultValue = txtaddCodeId.Text.Trim();

        DataView dvCodeExists = new DataView();

        dvCodeExists = (DataView)SqlAddCode.Select(dsArguments);

        if (dvCodeExists.Count >= 1)
        {
            txtaddCodeType.Text = string.Empty;
            txtaddCodeId.Text = string.Empty;
            txtaddCodeDescription.Text = string.Empty;
            rbaddEnableList.SelectedIndex = -1;
            addError.Text = "CODE Already Exist !!! Please Enter another CODE";
            addError.ForeColor = System.Drawing.Color.Red;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('CODE Already Exist !!! Please Enter another CODE');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddErrorModalScript", sb.ToString(), false);
        }
        else
        {
			string UserName = (string)Session["commonname"];
			string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            SqlCode.InsertParameters["CODE_TYPE"].DefaultValue = txtaddCodeType.Text;
            SqlCode.InsertParameters["CODE_ID"].DefaultValue = txtaddCodeId.Text;
            SqlCode.InsertParameters["CODE_DESCRIPTION"].DefaultValue = txtaddCodeDescription.Text;
            SqlCode.InsertParameters["CODE_STATUS"].DefaultValue = rbaddEnableList.SelectedValue;
			SqlCode.InsertParameters["ADDED_BY"].DefaultValue = UserName.ToUpper().Trim();
			SqlCode.InsertParameters["ADDED_DATE"].DefaultValue = CurrentDate;
			SqlCode.InsertParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();
			SqlCode.InsertParameters["UPDATED_DATE"].DefaultValue = CurrentDate;
            
            try
            {
                SqlCode.Insert();
                txtaddCodeId.Text = string.Empty;
                txtaddCodeType.Text = string.Empty;
                txtaddCodeDescription.Text = string.Empty;
                addError.Text = string.Empty;
                rbaddEnableList.SelectedIndex = -1;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Code added successfully.');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                gvCode.DataBind();
                CodeTypeSearch.AppendDataBoundItems = false;
                upCode.Update();

            }
            catch
            {
                addError.Text = "An error has occured while adding a user please contact administrator";
                addError.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

            }
        }
    }
	
	protected void CodeTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        CodeIdSearch.Enabled = true;
	}
    
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }
    protected void SqlCode_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        totalCodeValue.Text = e.AffectedRows.ToString();
    }
}