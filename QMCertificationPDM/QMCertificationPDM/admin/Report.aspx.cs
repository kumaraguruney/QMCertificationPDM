using System;

public partial class admin_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }
    protected void Coursebycollege_Click(object sender, EventArgs e)
    {
        Response.Redirect("Coursesbycollege.aspx");
    }
    protected void Usersbycollege_Click(object sender, EventArgs e)
    {
        Response.Redirect("Usersbycollege.aspx");
    }
    protected void Paymentstatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports/Report.aspx");
    }
    protected void usersbytrainingtype_Click(object sender, EventArgs e)
    {
        Response.Redirect("usersbytrainingtype.aspx");
    }
    protected void reviewersbycoursesinprogress_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports/ReviewerWorkLoad.aspx");
    }
    protected void reviewersbycourses_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports/TotalReviewes.aspx");
    }
}