using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    Int32 total = 0, totalNA = 0, totalPD = 0, totalDIP = 0, totalPR = 0, totalIR  = 0, totalER = 0, totalQMC = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }


    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }

    protected void gvITCs_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvITCs_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            totalNA += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NA"));
            totalPD += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PD"));
            totalDIP += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DIP"));
            totalPR += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PR"));
            totalIR += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IR"));
            totalER += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ER"));
            totalQMC += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QMC"));
            total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
        }

        ViewState["GrandTotal"] = total; ViewState["TotalNA"] = totalNA; ViewState["TotalPD"] = totalPD; ViewState["TotalDIP"] = totalDIP;
        ViewState["TotalPR"] = totalPR; ViewState["TotalIR"] = totalIR; ViewState["TotalER"] = totalER; ViewState["TotalQMC"] = totalQMC;

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
            lblGrandTotal.Text = ViewState["GrandTotal"].ToString();
            Label lblTotalNA = (Label)e.Row.FindControl("lblTotalNA");
            lblTotalNA.Text = ViewState["TotalNA"].ToString();
            Label lblTotalPD = (Label)e.Row.FindControl("lblTotalPD");
            lblTotalPD.Text = ViewState["TotalPD"].ToString();
            Label lblTotalDIP = (Label)e.Row.FindControl("lblTotalDIP");
            lblTotalDIP.Text = ViewState["TotalDIP"].ToString();
            Label lblTotalPR = (Label)e.Row.FindControl("lblTotalPR");
            lblTotalPR.Text = ViewState["TotalPR"].ToString();
            Label lblTotalIR = (Label)e.Row.FindControl("lblTotalIR");
            lblTotalIR.Text = ViewState["TotalIR"].ToString();
            Label lblTotalER = (Label)e.Row.FindControl("lblTotalER");
            lblTotalER.Text = ViewState["TotalER"].ToString();
            Label lblTotalQMC = (Label)e.Row.FindControl("lblTotalQMC");
            lblTotalQMC.Text = ViewState["TotalQMC"].ToString();
        }
    }

    protected void lblDIP_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Value.ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "DIP";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lblNA_Click(object sender, EventArgs e)
    {

        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Value.ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "NA";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lblPD_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Values[0].ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "PD";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lblPR_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Value.ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "PR";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lblIR_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Value.ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "IR";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lblER_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Value.ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "ER";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lblQMC_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strFirstName = gvITCs.DataKeys[index].Value.ToString();
            string strITCName = gvITCs.DataKeys[index].Values[1].ToString();
            lblITCName.Text = strITCName;
            SqlITCgrid.SelectParameters["FIRSTNAME"].DefaultValue = strFirstName;
            SqlITCgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "QMC";
            SqlITCgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void SqlITCgrid_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblTotalCourseCount.Text = e.AffectedRows.ToString();
    }
    protected void lnktotalPD_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " Pending Development";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "PD";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnktotalNA_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " Not Approved";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "NA";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnktotalDIP_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " Development in Progress";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "DIP";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnktotalPR_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " Pending Review";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "PR";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnktotalIR_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " Internal Review";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "IR";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnktotalER_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " External Review";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "ER";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnktotalQMC_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            lblfooterDevelopmentStatus.Text = " QM Certified";
            SqlITCtotalgrid.SelectParameters["DEVELOPMENT_STATUS"].DefaultValue = "QMC";
            SqlITCtotalgrid.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ITCtotalModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void SqlITCtotalgrid_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblfooterTotalCourseCount.Text = e.AffectedRows.ToString();
    }
}