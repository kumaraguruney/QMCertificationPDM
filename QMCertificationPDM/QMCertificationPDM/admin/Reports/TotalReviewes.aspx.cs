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

    protected void SqlReviewerIR_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblTotalIRCourseCount.Text = e.AffectedRows.ToString();
    }

    protected void SqlReviewerER_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblTotalERCourseCount.Text = e.AffectedRows.ToString();
    } 

    protected void lnkIR_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strReviewerISN = gvReviewerCourse.DataKeys[index].Value.ToString();
            string strReviewerName = gvReviewerCourse.DataKeys[index].Values[1].ToString();
            lblDevelopmentStatus.Text = strReviewerName;
            SqlReviewerIR.SelectParameters["USER"].DefaultValue = strReviewerISN;
            SqlReviewerIR.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#reviewerIRModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowModalScript", sb.ToString(), false);
        }

    }
    protected void lnkER_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnk = (LinkButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            string strReviewerISN = gvReviewerCourse.DataKeys[index].Value.ToString();
            string strReviewerName = gvReviewerCourse.DataKeys[index].Values[1].ToString();
            lblERReviewerName.Text = strReviewerName;
            SqlReviewerER.SelectParameters["USER"].DefaultValue = strReviewerISN;
            SqlReviewerER.DataBind();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#ReviewerERModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ReviewerShowModalScript", sb.ToString(), false);
        }
    }

   
}