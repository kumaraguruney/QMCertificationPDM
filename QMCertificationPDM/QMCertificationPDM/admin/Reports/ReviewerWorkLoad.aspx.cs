using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("~/index.aspx");
        }


    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }

    protected void SqlDashboard_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        totalUserValue.Text = e.AffectedRows.ToString();
    }
    protected void SqlReviewer_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblTotalCourseCount.Text = e.AffectedRows.ToString();
    }
    protected void lnkIR_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strUserISN = gvITCs.DataKeys[index].Value.ToString();
            string strReviewerName = gvITCs.DataKeys[index].Values[1].ToString();
            lblDevelopmentStatus.Text = strReviewerName;
            SqlReviewer.SelectParameters["USER"].DefaultValue = strUserISN;
            SqlReviewer.SelectParameters["STATUS"].DefaultValue = "IR";
            SqlReviewer.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#reviewerModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
    protected void lnkER_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strUserISN = gvITCs.DataKeys[index].Value.ToString();
            string strReviewerName = gvITCs.DataKeys[index].Values[1].ToString();
            lblDevelopmentStatus.Text = strReviewerName;
            SqlReviewer.SelectParameters["USER"].DefaultValue = strUserISN;
            SqlReviewer.SelectParameters["STATUS"].DefaultValue = "ER";
            SqlReviewer.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#reviewerModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dipShowModalScript", sb.ToString(), false);
        }
    }
}