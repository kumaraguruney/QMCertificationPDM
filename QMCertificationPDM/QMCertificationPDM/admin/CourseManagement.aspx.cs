using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_CourseManagement : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
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
            Int32 courseKey = Convert.ToInt32(gvCourseDetail.DataKeys[index].Value.ToString());
            string strcoursekey = Convert.ToString(courseKey);
            SqlData.SelectCommand = "SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, ISNULL(COURSEDETAIL.YEAR_TAUGHT, '') AS YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, ISNULL(COURSEDETAIL.DATE_TO_START_REVIEW, '') AS DATE_TO_START_REVIEW, ISNULL(COURSEDETAIL.QM_CERTIFIED_DATE, '') AS QM_CERTIFIED_DATE, ISNULL(COURSEDETAIL.NOTE,'') AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, '') AS FIRST_PAYMENT_DATE , PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, '') AS SECOND_PAYMENT_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_START_DATE, '') AS IR_START_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_END_DATE,'') AS IR_END_DATE, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, '') AS IR_CHAIR_ESTIMATED_PAYMENT_DATE , PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, ISNULL (PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, '') AS IR_REVIEWER2_ESTIMATED_PAYMENT_DATE , PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, '') AS IR_REVIEWER3_ESTIMATED_PAYMENT_DATE , ISNULL(PAYMENTPAPERWORKHISTORY.OR_START_DATE, '') AS OR_START_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.OR_END_DATE, '') AS OR_END_DATE, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, '') AS OR_CHAIR_ESTIMATED_PAYMENT_DATE , PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, '') AS OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, '')AS OR_REVIEWER3_ESTIMATED_PAYMENT_DATE , PAYMENTPAPERWORKHISTORY.NOTE, PAYMENTPAPERWORKHISTORY.ADDED_BY, PAYMENTPAPERWORKHISTORY.ADDED_DATE, PAYMENTPAPERWORKHISTORY.UPDATED_BY, PAYMENTPAPERWORKHISTORY.UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, ISNULL(CODE_2.CODE_DESCRIPTION,'') AS SEMESTER, ISNULL(CODE_3.CODE_DESCRIPTION, '') AS COLLEGE, ISNULL(CODE_4.CODE_DESCRIPTION, '') AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN WHERE COURSEDETAIL.COURSE_ISN =" + strcoursekey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);

            string strCourseTitle = Convert.ToString(dvData[0].Row["COURSE_TITLE"]);
            string strCourseSubject = (string)dvData[0].Row["COURSE_SUBJECT"];
            string strCourseNo = (string)dvData[0].Row["COURSE_NUMBER"];
            string strCollege = (string)dvData[0].Row["College"];
            string strDegree = (string)dvData[0].Row["Degree"];
            string strSemesterTaught = (string)dvData[0].Row["Semester"];
            string strYearTaught = Convert.ToString(dvData[0].Row["Year_Taught"]);
            string strDeveloper = Convert.ToString(dvData[0].Row["DEVELOPER"]);
            string strCoordinator = Convert.ToString(dvData[0].Row["COORDINATOR"]);
            string strCourseType = Convert.ToString(dvData[0].Row["CODE_TYPE"]);
            string strCourseStatus = Convert.ToString(dvData[0].Row["COURSE_STATUS"]);
            string strReviewStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["DATE_TO_START_REVIEW"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["DATE_TO_START_REVIEW"]).ToShortDateString());
            string strCourseDevelopmentStatus = Convert.ToString(dvData[0].Row["DEVELOPMENT_STATUS"]);
            string strCourseDetailNote = (string)dvData[0].Row["COURSEDETAIL_NOTE"];
            string strIRChair = Convert.ToString(dvData[0].Row["IR_CHAIR"]);
            string strIRReviewer2 = Convert.ToString(dvData[0].Row["IR_REVIEWER2"]);
            string strIRReviewer3 = Convert.ToString(dvData[0].Row["IR_REVIEWER3"]);
            string strIRStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_START_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_START_DATE"]).ToShortDateString());
            string strIREndDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_END_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_END_DATE"]).ToShortDateString());
            string strORChair = Convert.ToString(dvData[0].Row["OR_CHAIR"]);
            string strORReviewer2 = Convert.ToString(dvData[0].Row["OR_REVIEWER2"]);
            string strORReviewer3 = Convert.ToString(dvData[0].Row["OR_REVIEWER3"]);
            string strORStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_START_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_START_DATE"]).ToShortDateString());
            string strOREndDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_END_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_END_DATE"]).ToShortDateString());
            string strQMCertifiedDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["QM_CERTIFIED_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["QM_CERTIFIED_DATE"]).ToShortDateString());
            string strAddedBy = (string)dvData[0].Row["COURSEDETAIL_ADDED_BY"];
            string strAddedDate = Convert.ToString(dvData[0].Row["COURSEDETAIL_ADDED_DATE"]);
            string strUpdatedBy = (string)dvData[0].Row["COURSEDETAIL_UPDATED_BY"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["COURSEDETAIL_UPDATED_DATE"]);

            txtdisplayCourseTitle.Text = strCourseTitle;
            txtdisplayCourseSubject.Text = strCourseSubject;
            txtdisplayCourseNo.Text = strCourseNo;
            txtdisplayCollege.Text = strCollege;
            txtdisplayDepartment.Text = strDegree;
            txtdisplaySemesterTaught.Text = strSemesterTaught;
            if (strYearTaught == "0")
                txtdisplayYearTaught.Text = "";
            else
                txtdisplayYearTaught.Text = strYearTaught;
            txtdisplaydeveloper.Text = strDeveloper;
            txtdisplaycoordinator.Text = strCoordinator;
            txtdisplayCourseType.Text = strCourseType;
            rbdisplayEnableList.SelectedIndex = Convert.ToByte(strCourseStatus == "True" ? "0" : "1");
            txtdisplayreviewstartdate.Text = strReviewStartDate;
            txtdisplaydevelopmentstatus.Text = strCourseDevelopmentStatus;
            txtdisplayNote.Text = strCourseDetailNote == "&nbsp;" ? "" : strCourseDetailNote;
            txtdisplayIRChair.Text = strIRChair == "&nbsp;" ? "" : strIRChair;
            txtdisplayIRReviewer2.Text = strIRReviewer2 == "&nbsp;" ? "" : strIRReviewer2;
            txtdisplayIRReviewer3.Text = strIRReviewer3 == "&nbsp;" ? "" : strIRReviewer3;
            txtdisplayIRStartDate.Text = strIRStartDate == "&nbsp;" ? "" : strIRStartDate;
            txtdisplayIREndDate.Text = strIREndDate == "&nbsp;" ? "" : strIREndDate;
            txtdisplayORChair.Text = strORChair == "&nbsp;" ? "" : strORChair;
            txtdisplayORReviewer2.Text = strORReviewer2 == "&nbsp;" ? "" : strORReviewer2;
            txtdisplayORReviewer3.Text = strORReviewer3 == "&nbsp;" ? "" : strORReviewer3;
            txtdisplayORStartDate.Text = strORStartDate == "" ? "" : strORStartDate;
            txtdisplayOREndDate.Text = strOREndDate == "" ? "" : strOREndDate;
            txtdisplayQMCertifiedDate.Text = strQMCertifiedDate;
            txtdisplayAddedBy.Text = strAddedBy;
            txtdisplayAddedDate.Text = strAddedDate;
            txtdisplayUpdatedBy.Text= strUpdatedBy;
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
            ImageButton lnk = (ImageButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            Int32 courseKey = Convert.ToInt32(gvCourseDetail.DataKeys[index].Value.ToString());
            string strcoursekey = Convert.ToString(courseKey);
            SqlData.SelectCommand = "SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, ISNULL(COURSEDETAIL.YEAR_TAUGHT, '') AS YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, ISNULL(COURSEDETAIL.DATE_TO_START_REVIEW,'') AS DATE_TO_START_REVIEW, ISNULL(COURSEDETAIL.QM_CERTIFIED_DATE, '') AS QM_CERTIFIED_DATE, ISNULL(COURSEDETAIL.NOTE, '') AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, '') AS FIRST_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, '') AS SECOND_PAYMENT_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_START_DATE, '') AS IR_START_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_END_DATE, '') AS IR_END_DATE, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN,                          PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM,                          PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, '') AS IR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM,                          PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, '') AS IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, '') AS IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.OR_START_DATE, '') AS OR_START_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.OR_END_DATE, '') AS OR_END_DATE, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, '') AS OR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, '') AS OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE,'') AS OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.NOTE, PAYMENTPAPERWORKHISTORY.ADDED_BY, PAYMENTPAPERWORKHISTORY.ADDED_DATE, PAYMENTPAPERWORKHISTORY.UPDATED_BY, PAYMENTPAPERWORKHISTORY.UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, ISNULL(CODE_2.CODE_DESCRIPTION, '') AS SEMESTER, ISNULL(CODE_3.CODE_DESCRIPTION, '') AS COLLEGE, ISNULL(CODE_4.CODE_DESCRIPTION, '') AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN WHERE COURSEDETAIL.COURSE_ISN =" + strcoursekey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);

            string strCourseTitle = Convert.ToString(dvData[0].Row["COURSE_TITLE"]);
            string strCourseSubject = (string)dvData[0].Row["COURSE_SUBJECT"];
            string strCourseNo = (string)dvData[0].Row["COURSE_NUMBER"];
            string strCollege = (string)dvData[0].Row["College"];
            string strDegree = (string)dvData[0].Row["Degree"];
            string strSemesterTaught = (string)dvData[0].Row["Semester"];
            string strYearTaught = Convert.ToString(dvData[0].Row["Year_Taught"]);
            string strDeveloper = Convert.ToString(dvData[0].Row["DEVELOPER"]);
            string strCoordinator = Convert.ToString(dvData[0].Row["COORDINATOR"]);
            string strCourseType = Convert.ToString(dvData[0].Row["CODE_TYPE"]);
            string strCourseStatus = Convert.ToString(dvData[0].Row["COURSE_STATUS"]);
            string strReviewStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["DATE_TO_START_REVIEW"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["DATE_TO_START_REVIEW"]).ToShortDateString());
            string strCourseDevelopmentStatus = Convert.ToString(dvData[0].Row["DEVELOPMENT_STATUS"]);
            string strCourseDetailNote = (string)dvData[0].Row["COURSEDETAIL_NOTE"];
            string strIRChair = Convert.ToString(dvData[0].Row["IR_CHAIR"]);
            string strIRReviewer2 = Convert.ToString(dvData[0].Row["IR_REVIEWER2"]);
            string strIRReviewer3 = Convert.ToString(dvData[0].Row["IR_REVIEWER3"]);
            string strIRStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_START_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_START_DATE"]).ToShortDateString());
            string strIREndDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_END_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_END_DATE"]).ToShortDateString());
            string strORChair = Convert.ToString(dvData[0].Row["OR_CHAIR"]);
            string strORReviewer2 = Convert.ToString(dvData[0].Row["OR_REVIEWER2"]);
            string strORReviewer3 = Convert.ToString(dvData[0].Row["OR_REVIEWER3"]);
            string strORStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_START_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_START_DATE"]).ToShortDateString());
            string strOREndDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_END_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_END_DATE"]).ToShortDateString());
            string strQMCertifiedDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["QM_CERTIFIED_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["QM_CERTIFIED_DATE"]).ToShortDateString());
            string strAddedBy = (string)dvData[0].Row["COURSEDETAIL_ADDED_BY"];
            string strAddedDate = Convert.ToString(dvData[0].Row["COURSEDETAIL_ADDED_DATE"]);
            string strUpdatedBy = (string)dvData[0].Row["COURSEDETAIL_UPDATED_BY"];
            string strUpdatedDate = Convert.ToString(dvData[0].Row["COURSEDETAIL_UPDATED_DATE"]);

            courseisn.Value = strcoursekey;
              txteditCourseTitle.Text = strCourseTitle;
              txteditCourseSubject.Text = strCourseSubject;
              txteditCourseNo.Text = strCourseNo;
              SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION  = '" + strCollege + "'";
              dsArguments = new DataSourceSelectArguments();
              DataView dvCodeId = (DataView)SqlData.Select(dsArguments);
              string StrISN;
              if (dvCodeId.Count > 0)
              {
                  StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
                  editdropCollege.SelectedValue = StrISN;
              }
              

              if (editdropCollege.SelectedValue != "-1")
              {


                  SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION  = '" + strDegree + "'";
                  dsArguments = new DataSourceSelectArguments();
                  dvCodeId = (DataView)SqlData.Select(dsArguments);
                  if (dvCodeId.Count > 0)
                  {
                      StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
                      editdropDepartment.SelectedValue = StrISN;
                  }
                  else
                      editdropDepartment.SelectedValue = "-1";
              }

              if (strSemesterTaught != "")
              {
                  SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION = '" + strSemesterTaught + "'";
                  dsArguments = new DataSourceSelectArguments();
                  dvCodeId = (DataView)SqlData.Select(dsArguments);
                  StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
                  editdropSemesterTaught.SelectedValue = StrISN;
              }
              else
                  editdropSemesterTaught.SelectedValue = "-1";
            if(strYearTaught == "0")
              txteditYearTaught.Text = "";
            else
                txteditYearTaught.Text = strYearTaught;
              SqlData.SelectCommand = "SELECT USER_ISN FROM USERPROFILE WHERE LAST_NAME + ', ' + FIRST_NAME  ='" + strDeveloper + "'";
              dsArguments = new DataSourceSelectArguments();
              dvCodeId = (DataView)SqlData.Select(dsArguments);
              StrISN = dvCodeId[0].Row["USER_ISN"].ToString();
              editdropDeveloper.SelectedValue = StrISN;
              SqlData.SelectCommand = "SELECT USER_ISN FROM USERPROFILE WHERE LAST_NAME + ', ' + FIRST_NAME  ='" + strCoordinator + "'";
              dsArguments = new DataSourceSelectArguments();
              dvCodeId = (DataView)SqlData.Select(dsArguments);
              StrISN = dvCodeId[0].Row["USER_ISN"].ToString();
              editdropCoordinator.SelectedValue = StrISN;
              rbleditCourseEnabled.SelectedIndex = Convert.ToByte(strCourseStatus == "True" ? "0" : "1");
              if (strReviewStartDate != "")
              {
                  ceeditReviewStartDate.SelectedDate = DateTime.Parse(strReviewStartDate);
                  txteditReviewStartDate.Text = strReviewStartDate;
              }
              SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION  ='" + strCourseDevelopmentStatus + "'";
              dsArguments = new DataSourceSelectArguments();
              dvCodeId = (DataView)SqlData.Select(dsArguments);
              StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
              editdropDevelopementStatus.SelectedValue = StrISN;
              SqlData.SelectCommand = "SELECT CODE_ISN FROM CODE WHERE CODE_DESCRIPTION  ='" + strCourseType + "'";
              dsArguments = new DataSourceSelectArguments();
              dvCodeId = (DataView)SqlData.Select(dsArguments);
              StrISN = dvCodeId[0].Row["CODE_ISN"].ToString();
              editdropCourseType.SelectedValue = StrISN;
              if (strQMCertifiedDate != "")
              {
                  cetxteditQMCertifiedDate.SelectedDate = DateTime.Parse(strQMCertifiedDate);
                  txteditQMCertifiedDate.Text = strQMCertifiedDate;
              }
              txteditNote.Text = strCourseDetailNote == "&nbsp;" ? "" : strCourseDetailNote;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditShowModalScript", sb.ToString(), false);
        }
    }

        
    protected void btnUpdateCourse_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        string UserName = (string)Session["commonname"];
        string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        SqlCourseDetailspecific.UpdateParameters["COURSE_ISN"].DefaultValue = courseisn.Value;
        SqlCourseDetailspecific.UpdateParameters["COURSE_TYPE_ISN"].DefaultValue = editdropCourseType.SelectedValue;
        SqlCourseDetailspecific.UpdateParameters["DEVELOPMENT_STATUS_ISN"].DefaultValue = editdropDevelopementStatus.SelectedValue;
        SqlCourseDetailspecific.UpdateParameters["COURSE_SUBJECT"].DefaultValue = txteditCourseSubject.Text.ToUpper().Trim();
        SqlCourseDetailspecific.UpdateParameters["COURSE_NUMBER"].DefaultValue = txteditCourseNo.Text.ToUpper().Trim();
        SqlCourseDetailspecific.UpdateParameters["COURSE_TITLE"].DefaultValue = txteditCourseTitle.Text.ToUpper().Trim();
        SqlCourseDetailspecific.UpdateParameters["COURSE_STATUS"].DefaultValue = rbleditCourseEnabled.SelectedValue;
        
       
        SqlCourseDetailspecific.UpdateParameters["DEVELOPER_ISN"].DefaultValue = editdropDeveloper.SelectedValue;
        SqlCourseDetailspecific.UpdateParameters["COORDINATOR_ISN"].DefaultValue = editdropCoordinator.SelectedValue;
        SqlCourseDetailspecific.UpdateParameters["COLL_CODE_ISN"].DefaultValue = editdropCollege.SelectedValue;

        if (editdropDepartment.SelectedValue == "-1")
            SqlCourseDetailspecific.UpdateParameters["DEGREE_PROGRAM_CODE_ISN"].DefaultValue = null;
        else
            SqlCourseDetailspecific.UpdateParameters["DEGREE_PROGRAM_CODE_ISN"].DefaultValue = editdropDepartment.SelectedValue;

        

        if (adddropSemesterTaugt.SelectedValue == "-1")
            SqlCourseDetailspecific.UpdateParameters["SEMESTER_TAUGHT_ISN"].DefaultValue = null;
        else
            SqlCourseDetailspecific.UpdateParameters["SEMESTER_TAUGHT_ISN"].DefaultValue = editdropSemesterTaught.SelectedValue;

        if (txteditYearTaught.Text.Trim() == "" || txteditYearTaught.Text.Trim() == " ")
            SqlCourseDetailspecific.UpdateParameters["YEAR_TAUGHT"].DefaultValue = null;
        else
            SqlCourseDetailspecific.UpdateParameters["YEAR_TAUGHT"].DefaultValue = txteditYearTaught.Text.Trim();

        if(txteditReviewStartDate.Text != null || txteditReviewStartDate.Text != " ")
            SqlCourseDetailspecific.UpdateParameters["DATE_TO_START_REVIEW"].DefaultValue = txteditReviewStartDate.Text;
        else
            SqlCourseDetailspecific.UpdateParameters["DATE_TO_START_REVIEW"].DefaultValue = null;
               
        if (txteditQMCertifiedDate.Text != null || txteditQMCertifiedDate.Text != " ")
            SqlCourseDetailspecific.UpdateParameters["QM_CERTIFIED_DATE"].DefaultValue = txteditQMCertifiedDate.Text;
        else
            SqlCourseDetailspecific.UpdateParameters["QM_CERTIFIED_DATE"].DefaultValue = null;

        SqlCourseDetailspecific.UpdateParameters["NOTE"].DefaultValue = txteditNote.Text.ToUpper().Trim();

        SqlCourseDetailspecific.UpdateParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();

        SqlCourseDetailspecific.UpdateParameters["UPDATED_DATE"].DefaultValue = CurrentDate;

        try
        {
            SqlCourseDetailspecific.Update();
            System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
            strbuilder.Append(@"<script type='text/javascript'>");
            strbuilder.Append("alert('Course Updated Successfully');");
            strbuilder.Append("$('#editModal').modal('hide');");
            strbuilder.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", strbuilder.ToString(), false);
            gvCourseDetail.DataBind();
            upCourseDetail.Update();

        }
        catch
        {
            editError.Text = "An error has occured in updation of Record";
            editError.ForeColor = System.Drawing.Color.Red;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }

        
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }

    protected void btnCourseClear_Click(object sender, EventArgs e)
    {
        SqlCourseDetail.SelectCommand = "SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, COURSEDETAIL.YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, COURSEDETAIL.DATE_TO_START_REVIEW, COURSEDETAIL.QM_CERTIFIED_DATE, COURSEDETAIL.NOTE AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_START_DATE, PAYMENTPAPERWORKHISTORY.IR_END_DATE, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_START_DATE, PAYMENTPAPERWORKHISTORY.OR_END_DATE, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.NOTE, PAYMENTPAPERWORKHISTORY.ADDED_BY, PAYMENTPAPERWORKHISTORY.ADDED_DATE, PAYMENTPAPERWORKHISTORY.UPDATED_BY, PAYMENTPAPERWORKHISTORY.UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, CODE_2.CODE_DESCRIPTION AS SEMESTER, CODE_3.CODE_DESCRIPTION AS COLLEGE, CODE_4.CODE_DESCRIPTION AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN ORDER BY COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER";
        SqlCourseDetail.DataBind();
        gvCourseDetail.DataBind();
        CourseSearch.SelectedIndex = -1;
    }
    protected void btnAddCourse_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }
        addError.Text = string.Empty;
        txtaddCourseNumber.Text = string.Empty;
        txtaddCourseSubject.Text = string.Empty;
        txtaddCourseTitle.Text = string.Empty;
        txtaddNote.Text = string.Empty;
        txtaddQMCertifiedDate.Text = string.Empty;
        txtaddReviewStartDate.Text = string.Empty;
        txtaddYearTaught.Text = string.Empty;
        adddropCollege.SelectedIndex = -1;
        adddropCoordinator.SelectedIndex = -1;
        adddropCourseType.SelectedIndex = -1;
        adddropDegree.SelectedIndex = -1;
        adddropDeveloper.SelectedIndex = -1;
        adddropDevelopmentStatus.SelectedIndex = -1;
        adddropSemesterTaugt.SelectedIndex = -1;
        rbaddCourseEnabled.SelectedIndex = 0;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append("$document.getElementById('txtaddCourseTitle').focus();");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    protected void btnCourseSearch_Click(object sender, EventArgs e)
    {
        if (CourseSearch.SelectedValue != "%")
        {
            SqlCourseDetail.SelectCommand = "SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, COURSEDETAIL.YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, COURSEDETAIL.DATE_TO_START_REVIEW, COURSEDETAIL.QM_CERTIFIED_DATE, COURSEDETAIL.NOTE AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_START_DATE, PAYMENTPAPERWORKHISTORY.IR_END_DATE, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_START_DATE, PAYMENTPAPERWORKHISTORY.OR_END_DATE, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.NOTE, PAYMENTPAPERWORKHISTORY.ADDED_BY, PAYMENTPAPERWORKHISTORY.ADDED_DATE, PAYMENTPAPERWORKHISTORY.UPDATED_BY, PAYMENTPAPERWORKHISTORY.UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, CODE_2.CODE_DESCRIPTION AS SEMESTER, CODE_3.CODE_DESCRIPTION AS COLLEGE, CODE_4.CODE_DESCRIPTION AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN  where Coursedetail.Course_ISN ='" + CourseSearch.SelectedValue + "' ORDER BY COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER";
            SqlCourseDetail.DataBind();
            gvCourseDetail.DataBind();
        }
        else
        {
            SqlCourseDetail.SelectCommand = "SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, COURSEDETAIL.YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, COURSEDETAIL.DATE_TO_START_REVIEW, COURSEDETAIL.QM_CERTIFIED_DATE, COURSEDETAIL.NOTE AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_START_DATE, PAYMENTPAPERWORKHISTORY.IR_END_DATE, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_START_DATE, PAYMENTPAPERWORKHISTORY.OR_END_DATE, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, PAYMENTPAPERWORKHISTORY.NOTE, PAYMENTPAPERWORKHISTORY.ADDED_BY, PAYMENTPAPERWORKHISTORY.ADDED_DATE, PAYMENTPAPERWORKHISTORY.UPDATED_BY, PAYMENTPAPERWORKHISTORY.UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, CODE_2.CODE_DESCRIPTION AS SEMESTER, CODE_3.CODE_DESCRIPTION AS COLLEGE, CODE_4.CODE_DESCRIPTION AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN ORDER BY COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER";
            SqlCourseDetail.DataBind();
            gvCourseDetail.DataBind();
        }
    }
    
    protected void SqlCourseSearch_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        totalCourseValue.Text = e.AffectedRows.ToString();
    }


    protected void lnkPayment_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            dropPPIRChair.Enabled = false; dropPPIRChair.BorderStyle = BorderStyle.None;
            dropPPIRReviewer2.Enabled = false; dropPPIRReviewer2.BorderStyle = BorderStyle.None;
            dropPPIRReviewer3.Enabled = false; dropPPIRReviewer3.BorderStyle = BorderStyle.None;
            dropPPORChair.Enabled = false; dropPPORChair.BorderStyle = BorderStyle.None;
            dropPPORReviewer2.Enabled = false; dropPPORReviewer2.BorderStyle = BorderStyle.None;
            dropPPORReviewer3.Enabled = false; dropPPORReviewer3.BorderStyle = BorderStyle.None;
            ImageButton lnk = (ImageButton)sender;
            int index = ((GridViewRow)lnk.NamingContainer).RowIndex;
            Int32 coursePaymentKey = Convert.ToInt32(gvCourseDetail.DataKeys[index].Value.ToString());

            Session["CP"] = coursePaymentKey;

            string strcoursePaymentkey = Convert.ToString(coursePaymentKey);

            CoursePaymentisn.Value = strcoursePaymentkey;

            DataSourceSelectArguments dcArguments = new DataSourceSelectArguments();


            SqlPaymentaddCheck.SelectParameters["COURSE_ISN"].DefaultValue = strcoursePaymentkey;

            DataView dvCodeExists = new DataView();

            dvCodeExists = (DataView)SqlPaymentaddCheck.Select(dcArguments);

            if (dvCodeExists.Count >= 1)
            {
                SqlIRChair.SelectParameters["USER_STATUS"].DefaultValue = "2";
                SqlIRChair.DataBind();
                dropPPIRChair.DataBind();
                SqlIRReviewer1.SelectParameters["USER_STATUS"].DefaultValue = "2";
                SqlIRReviewer1.DataBind();
                dropPPIRReviewer2.DataBind();
                SqlIRReviewer2.SelectParameters["USER_STATUS"].DefaultValue = "2";
                SqlIRReviewer2.DataBind();
                dropPPIRReviewer3.DataBind();
                SqlORChair.SelectParameters["USER_STATUS"].DefaultValue = "2";
                SqlORChair.DataBind();
                dropPPORChair.DataBind();
                SqlORReviewer1.SelectParameters["USER_STATUS"].DefaultValue = "2";
                SqlORReviewer1.DataBind();
                dropPPORReviewer2.DataBind();
                SqlORReviewer2.SelectParameters["USER_STATUS"].DefaultValue = "2";
                SqlORReviewer2.DataBind();
                dropPPORReviewer3.DataBind();
            }
            else
            {

                SqlIRChair.SelectParameters["USER_STATUS"].DefaultValue = "1";
                SqlIRChair.DataBind();
                dropPPIRChair.DataBind();
                SqlIRReviewer1.SelectParameters["USER_STATUS"].DefaultValue = "1";
                SqlIRReviewer1.DataBind();
                dropPPIRReviewer2.DataBind();
                SqlIRReviewer2.SelectParameters["USER_STATUS"].DefaultValue = "1";
                SqlIRReviewer2.DataBind();
                dropPPIRReviewer3.DataBind();
                SqlORChair.SelectParameters["USER_STATUS"].DefaultValue = "1";
                SqlORChair.DataBind();
                dropPPORChair.DataBind();
                SqlORReviewer1.SelectParameters["USER_STATUS"].DefaultValue = "1";
                SqlORReviewer1.DataBind();
                dropPPORReviewer2.DataBind();
                SqlORReviewer2.SelectParameters["USER_STATUS"].DefaultValue = "1";
                SqlORReviewer2.DataBind();
                dropPPORReviewer3.DataBind();
               
            }

            SqlData.SelectCommand = "SELECT COURSEDETAIL.COURSE_ISN AS COURSEDETAIL_COURSE_ISN, COURSEDETAIL.COURSE_TYPE_ISN, COURSEDETAIL.COURSE_STATUS, COURSEDETAIL.DEVELOPMENT_STATUS_ISN, COURSEDETAIL.COURSE_SUBJECT, COURSEDETAIL.COURSE_NUMBER, COURSEDETAIL.COURSE_TITLE, COURSEDETAIL.COLL_CODE_ISN, COURSEDETAIL.SEMESTER_TAUGHT_ISN, COURSEDETAIL.YEAR_TAUGHT, COURSEDETAIL.DEVELOPER_ISN AS COURSEDETAIL_DEVELOPER_ISN, COURSEDETAIL.COORDINATOR_ISN, ISNULL(COURSEDETAIL.DATE_TO_START_REVIEW, '') AS DATE_TO_START_REVIEW, ISNULL(COURSEDETAIL.QM_CERTIFIED_DATE, '') AS QM_CERTIFIED_DATE, ISNULL(COURSEDETAIL.NOTE,'') AS COURSEDETAIL_NOTE, COURSEDETAIL.ADDED_BY AS COURSEDETAIL_ADDED_BY, COURSEDETAIL.ADDED_DATE AS COURSEDETAIL_ADDED_DATE, COURSEDETAIL.UPDATED_BY AS COURSEDETAIL_UPDATED_BY, COURSEDETAIL.UPDATED_DATE AS COURSEDETAIL_UPDATED_DATE, PAYMENTPAPERWORKHISTORY.COURSE_ISN AS PAYMENTPAPERWORKHISTORY_COURSE_ISN, PAYMENTPAPERWORKHISTORY.STATEMENT_OF_INTENT, PAYMENTPAPERWORKHISTORY.PROCEDURES_AND_AGREEMENT, PAYMENTPAPERWORKHISTORY.SERVICE_CONTRACT, PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.FIRST_PAYMENT_DATE, '') AS FIRST_PAYMENT_DATE , PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.SECOND_PAYMENT_DATE, '') AS SECOND_PAYMENT_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_START_DATE, '') AS IR_START_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_END_DATE,'') AS IR_END_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN, '') AS IR_CHAIR_ISN, ISNULL(PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN, '') AS IR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.IR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.IR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.IR_CHAIR_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_CHAIR_ESTIMATED_PAYMENT_DATE, '') AS IR_CHAIR_ESTIMATED_PAYMENT_DATE , ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN, '') AS IR_REVIEWER2_ISN, ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN,'') AS IR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_PAYMENT_AMOUNT, ISNULL (PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ESTIMATED_PAYMENT_DATE, '') AS IR_REVIEWER2_ESTIMATED_PAYMENT_DATE , ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN, '') AS IR_REVIEWER3_ISN, ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN, '') AS IR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ESTIMATED_PAYMENT_DATE, '') AS IR_REVIEWER3_ESTIMATED_PAYMENT_DATE , ISNULL(PAYMENTPAPERWORKHISTORY.OR_START_DATE, '') AS OR_START_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.OR_END_DATE, '') AS OR_END_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN, '') AS OR_CHAIR_ISN, ISNULL(PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN, '') AS OR_CHAIR_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_CHAIR_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1099, PAYMENTPAPERWORKHISTORY.OR_CHAIR_1042_S, PAYMENTPAPERWORKHISTORY.OR_CHAIR_W_9, PAYMENTPAPERWORKHISTORY.OR_CHAIR_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_CHAIR_ESTIMATED_PAYMENT_DATE, '') AS OR_CHAIR_ESTIMATED_PAYMENT_DATE , ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN, '') AS OR_REVIEWER2_ISN, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN, '') AS OR_REVIEWER2_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ESTIMATED_PAYMENT_DATE, '') AS OR_REVIEWER2_ESTIMATED_PAYMENT_DATE ,  ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN, '') AS OR_REVIEWER3_ISN, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN, '') AS OR_REVIEWER3_CONTRACT_TYPE_ISN, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1099, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_1042_S, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_W_9, PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_PAYMENT_AMOUNT, ISNULL(PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ESTIMATED_PAYMENT_DATE, '')AS OR_REVIEWER3_ESTIMATED_PAYMENT_DATE , ISNULL(PAYMENTPAPERWORKHISTORY.NOTE, '') AS NOTE, ISNULL(PAYMENTPAPERWORKHISTORY.ADDED_BY, '') AS ADDED_BY, ISNULL(PAYMENTPAPERWORKHISTORY.ADDED_DATE,'') AS ADDED_DATE, ISNULL(PAYMENTPAPERWORKHISTORY.UPDATED_BY, '') AS UPDATED_BY, ISNULL(PAYMENTPAPERWORKHISTORY.UPDATED_DATE, '') AS UPDATED_DATE, CODE.CODE_DESCRIPTION AS CODE_TYPE, CODE_1.CODE_DESCRIPTION AS DEVELOPMENT_STATUS, CODE_2.CODE_DESCRIPTION AS SEMESTER, ISNULL(CODE_3.CODE_DESCRIPTION, '') AS COLLEGE, ISNULL(CODE_4.CODE_DESCRIPTION, '') AS DEGREE, USERPROFILE.LAST_NAME + ', ' + USERPROFILE.FIRST_NAME AS DEVELOPER, USERPROFILE_1.LAST_NAME + ', ' + USERPROFILE_1.FIRST_NAME AS COORDINATOR, USERPROFILE_2.LAST_NAME + ', ' + USERPROFILE_2.FIRST_NAME AS IR_CHAIR, CODE_5.CODE_DESCRIPTION AS IR_CHAIR_CONTRACT_TYPE, USERPROFILE_3.LAST_NAME + ', ' + USERPROFILE_3.FIRST_NAME AS IR_REVIEWER2, CODE_6.CODE_DESCRIPTION AS IR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_4.LAST_NAME + ', ' + USERPROFILE_4.FIRST_NAME AS IR_REVIEWER3, CODE_7.CODE_DESCRIPTION AS IR_REVIEWER3_CONTRACT_TYPE, USERPROFILE_5.LAST_NAME + ', ' + USERPROFILE_5.FIRST_NAME AS OR_CHAIR, CODE_8.CODE_DESCRIPTION AS OR_CHAIR_CONTRACT_TYPE, USERPROFILE_6.LAST_NAME + ', ' + USERPROFILE_6.FIRST_NAME AS OR_REVIEWER2, CODE_9.CODE_DESCRIPTION AS OR_REVIEWER2_CONTRACT_TYPE, USERPROFILE_7.LAST_NAME + ', ' + USERPROFILE_7.FIRST_NAME AS OR_REVIEWER3, CODE_10.CODE_DESCRIPTION AS OR_REVIEWER3_CONTRACT_TYPE, COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN FROM COURSEDETAIL LEFT OUTER JOIN PAYMENTPAPERWORKHISTORY ON PAYMENTPAPERWORKHISTORY.COURSE_ISN = COURSEDETAIL.COURSE_ISN LEFT OUTER JOIN CODE ON CODE.CODE_ISN = COURSEDETAIL.COURSE_TYPE_ISN LEFT OUTER JOIN CODE AS CODE_1 ON CODE_1.CODE_ISN = COURSEDETAIL.DEVELOPMENT_STATUS_ISN LEFT OUTER JOIN CODE AS CODE_2 ON CODE_2.CODE_ISN = COURSEDETAIL.SEMESTER_TAUGHT_ISN LEFT OUTER JOIN CODE AS CODE_3 ON CODE_3.CODE_ISN = COURSEDETAIL.COLL_CODE_ISN LEFT OUTER JOIN CODE AS CODE_4 ON CODE_4.CODE_ISN = COURSEDETAIL.DEGREE_PROGRAM_CODE_ISN LEFT OUTER JOIN USERPROFILE ON USERPROFILE.USER_ISN = COURSEDETAIL.DEVELOPER_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_1 ON USERPROFILE_1.USER_ISN = COURSEDETAIL.COORDINATOR_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_2 ON USERPROFILE_2.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_5 ON CODE_5.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_3 ON USERPROFILE_3.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_6 ON CODE_6.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_4 ON USERPROFILE_4.USER_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_7 ON CODE_7.CODE_ISN = PAYMENTPAPERWORKHISTORY.IR_REVIEWER3_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_5 ON USERPROFILE_5.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_ISN LEFT OUTER JOIN CODE AS CODE_8 ON CODE_8.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_CHAIR_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_6 ON USERPROFILE_6.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_ISN LEFT OUTER JOIN CODE AS CODE_9 ON CODE_9.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER2_CONTRACT_TYPE_ISN LEFT OUTER JOIN USERPROFILE AS USERPROFILE_7 ON USERPROFILE_7.USER_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_ISN LEFT OUTER JOIN CODE AS CODE_10 ON CODE_10.CODE_ISN = PAYMENTPAPERWORKHISTORY.OR_REVIEWER3_CONTRACT_TYPE_ISN WHERE COURSEDETAIL.COURSE_ISN =" + strcoursePaymentkey;
            DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();
            DataView dvData = (DataView)SqlData.Select(dsArguments);
            // Title
            string strCourseTitle = Convert.ToString(dvData[0].Row["COURSE_TITLE"]);
            string strCourseSubject = (string)dvData[0].Row["COURSE_SUBJECT"];
            string strCourseNo = (string)dvData[0].Row["COURSE_NUMBER"];
            // Developer
            string strDeveloper = Convert.ToString(dvData[0].Row["DEVELOPER"]);
            string strSOI = Convert.ToString(dvData[0].Row["STATEMENT_OF_INTENT"]);
            string strPofA = Convert.ToString(dvData[0].Row["PROCEDURES_AND_AGREEMENT"]);
            string strSC = Convert.ToString(dvData[0].Row["SERVICE_CONTRACT"]);
            string strDeveloperPaymentAmount1 = Convert.ToString(dvData[0].Row["FIRST_PAYMENT_AMOUNT"]);
            string strDeveloperPaymentDate1 = Convert.ToString(Convert.ToDateTime(dvData[0].Row["FIRST_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["FIRST_PAYMENT_DATE"]).ToShortDateString());
            string strDeveloperPaymentAmount2 = Convert.ToString(dvData[0].Row["SECOND_PAYMENT_AMOUNT"]);
            string strDeveloperPaymentDate2 = Convert.ToString(Convert.ToDateTime(dvData[0].Row["SECOND_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["SECOND_PAYMENT_DATE"]).ToShortDateString());
            // IR
            string strIRStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_START_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_START_DATE"]).ToShortDateString());
            string strIREndDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_END_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_END_DATE"]).ToShortDateString());
            // IR Chair
            string strIRChair = Convert.ToString(dvData[0].Row["IR_CHAIR_ISN"]);
            string strIRChairPaperworkType = Convert.ToString(dvData[0].Row["IR_CHAIR_CONTRACT_TYPE_ISN"]);
            string strIRChairPayrollform = Convert.ToString(dvData[0].Row["IR_CHAIR_SUPPLEMENT_PAYROLL_FORM"]);
            string strIRChair1099 = Convert.ToString(dvData[0].Row["IR_CHAIR_1099"]);
            string strIRChair1042 = Convert.ToString(dvData[0].Row["IR_CHAIR_1042_S"]);
            string strIRChairW9 = Convert.ToString(dvData[0].Row["IR_CHAIR_W_9"]);
            string strIRChairPaymentAmount = Convert.ToString(dvData[0].Row["IR_CHAIR_PAYMENT_AMOUNT"]);
            string strIRChairEstimatedPaymentDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_CHAIR_ESTIMATED_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_CHAIR_ESTIMATED_PAYMENT_DATE"]).ToShortDateString());
            // IR Reviewer2
            string strIRReviewer2 = Convert.ToString(dvData[0].Row["IR_REVIEWER2_ISN"]);
            string strIRReviewer2PaperworkType = Convert.ToString(dvData[0].Row["IR_REVIEWER2_CONTRACT_TYPE_ISN"]);
            string strIRReviewer2Payrollform = Convert.ToString(dvData[0].Row["IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM"]);
            string strIRReviewer21099 = Convert.ToString(dvData[0].Row["IR_REVIEWER2_1099"]);
            string strIRReviewer21042 = Convert.ToString(dvData[0].Row["IR_REVIEWER2_1042_S"]);
            string strIRReviewer2W9 = Convert.ToString(dvData[0].Row["IR_REVIEWER2_W_9"]);
            string strIRReviewer2PaymentAmount = Convert.ToString(dvData[0].Row["IR_REVIEWER2_PAYMENT_AMOUNT"]);
            string strIRReviewer2EstimatedPaymentDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_REVIEWER2_ESTIMATED_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_REVIEWER2_ESTIMATED_PAYMENT_DATE"]).ToShortDateString());
            // IR Reviewer3
            string strIRReviewer3 = Convert.ToString(dvData[0].Row["IR_REVIEWER3_ISN"]);
            string strIRReviewer3PaperworkType = Convert.ToString(dvData[0].Row["IR_REVIEWER3_CONTRACT_TYPE_ISN"]);
            string strIRReviewer3Payrollform = Convert.ToString(dvData[0].Row["IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM"]);
            string strIRReviewer31099 = Convert.ToString(dvData[0].Row["IR_REVIEWER3_1099"]);
            string strIRReviewer31042 = Convert.ToString(dvData[0].Row["IR_REVIEWER3_1042_S"]);
            string strIRReviewer3W9 = Convert.ToString(dvData[0].Row["IR_REVIEWER3_W_9"]);
            string strIRReviewer3PaymentAmount = Convert.ToString(dvData[0].Row["IR_REVIEWER3_PAYMENT_AMOUNT"]);
            string strIRReviewer3EstimatedPaymentDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["IR_REVIEWER3_ESTIMATED_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["IR_REVIEWER3_ESTIMATED_PAYMENT_DATE"]).ToShortDateString());
            // OR
            string strORStartDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_START_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_START_DATE"]).ToShortDateString());
            string strOREndDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_END_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_END_DATE"]).ToShortDateString());

            // OR Chair
            string strORChair = Convert.ToString(dvData[0].Row["OR_CHAIR_ISN"]);
            string strORChairPaperworkType = Convert.ToString(dvData[0].Row["OR_CHAIR_CONTRACT_TYPE_ISN"]);
            string strORChairPayrollform = Convert.ToString(dvData[0].Row["OR_CHAIR_SUPPLEMENT_PAYROLL_FORM"]);
            string strORChair1099 = Convert.ToString(dvData[0].Row["OR_CHAIR_1099"]);
            string strORChair1042 = Convert.ToString(dvData[0].Row["OR_CHAIR_1042_S"]);
            string strORChairW9 = Convert.ToString(dvData[0].Row["OR_CHAIR_W_9"]);
            string strORChairPaymentAmount = Convert.ToString(dvData[0].Row["OR_CHAIR_PAYMENT_AMOUNT"]);
            string strORChairEstimatedPaymentDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_CHAIR_ESTIMATED_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_CHAIR_ESTIMATED_PAYMENT_DATE"]).ToShortDateString());
            // OR Reviewer2
            string strORReviewer2 = Convert.ToString(dvData[0].Row["OR_REVIEWER2_ISN"]);
            string strORReviewer2PaperworkType = Convert.ToString(dvData[0].Row["OR_REVIEWER2_CONTRACT_TYPE_ISN"]);
            string strORReviewer2Payrollform = Convert.ToString(dvData[0].Row["OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM"]);
            string strORReviewer21099 = Convert.ToString(dvData[0].Row["OR_REVIEWER2_1099"]);
            string strORReviewer21042 = Convert.ToString(dvData[0].Row["OR_REVIEWER2_1042_S"]);
            string strORReviewer2W9 = Convert.ToString(dvData[0].Row["OR_REVIEWER2_W_9"]);
            string strORReviewer2PaymentAmount = Convert.ToString(dvData[0].Row["OR_REVIEWER2_PAYMENT_AMOUNT"]);
            string strORReviewer2EstimatedPaymentDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_REVIEWER2_ESTIMATED_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_REVIEWER2_ESTIMATED_PAYMENT_DATE"]).ToShortDateString());
            // OR Reviewer3
            string strORReviewer3 = Convert.ToString(dvData[0].Row["OR_REVIEWER3_ISN"]);
            string strORReviewer3PaperworkType = Convert.ToString(dvData[0].Row["OR_REVIEWER3_CONTRACT_TYPE_ISN"]);
            string strORReviewer3Payrollform = Convert.ToString(dvData[0].Row["OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM"]);
            string strORReviewer31099 = Convert.ToString(dvData[0].Row["OR_REVIEWER3_1099"]);
            string strORReviewer31042 = Convert.ToString(dvData[0].Row["OR_REVIEWER3_1042_S"]);
            string strORReviewer3W9 = Convert.ToString(dvData[0].Row["OR_REVIEWER3_W_9"]);
            string strORReviewer3PaymentAmount = Convert.ToString(dvData[0].Row["OR_REVIEWER3_PAYMENT_AMOUNT"]);
            string strORReviewer3EstimatedPaymentDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["OR_REVIEWER3_ESTIMATED_PAYMENT_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["OR_REVIEWER3_ESTIMATED_PAYMENT_DATE"]).ToShortDateString());

            string strPaymentNote = Convert.ToString(dvData[0].Row["NOTE"]);
            string strPaymentAddedBy = (string)dvData[0].Row["ADDED_BY"];
            string strPaymentAddedDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["ADDED_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["ADDED_DATE"]).ToString());
            string strPaymentUpdatedBy = (string)dvData[0].Row["UPDATED_BY"];
            string strPaymentUpdatedDate = Convert.ToString(Convert.ToDateTime(dvData[0].Row["UPDATED_DATE"]).ToShortDateString() == "1/1/1900" ? "" : Convert.ToDateTime(dvData[0].Row["UPDATED_DATE"]).ToString());

            SqlData.SelectCommand = "SELECT CODE_DESCRIPTION AS IRPAYMENTAMOUNT FROM CODE WHERE (CODE_TYPE = 'PYMTAMT') AND (CODE_ID = 'IR')";
            DataSourceSelectArguments dvArguments = new DataSourceSelectArguments();
            DataView dsData = (DataView)SqlData.Select(dvArguments);

            string strIRPaymentAmount = Convert.ToString(dsData[0].Row["IRPAYMENTAMOUNT"]);

            SqlData.SelectCommand = "SELECT CODE_DESCRIPTION AS ORPAYMENTAMOUNT FROM CODE WHERE (CODE_TYPE = 'PYMTAMT') AND (CODE_ID = 'OR')";
            dvArguments = new DataSourceSelectArguments();
            dsData = (DataView)SqlData.Select(dvArguments);

            string strORPaymentAmount = Convert.ToString(dsData[0].Row["ORPAYMENTAMOUNT"]);

            SqlData.SelectCommand = "SELECT CODE_DESCRIPTION AS ORCHAIRPAYMENTAMOUNT FROM CODE WHERE (CODE_TYPE = 'PYMTAMT') AND (CODE_ID = 'ORCHAIR')";
            dvArguments = new DataSourceSelectArguments();
            dsData = (DataView)SqlData.Select(dvArguments);

            string strORChairMaxPaymentAmount = Convert.ToString(dsData[0].Row["ORCHAIRPAYMENTAMOUNT"]);

            lbPaperworkandPaymentHeader.Text = strCourseNo;
            txtPPCoursetitle.Text = strCourseTitle;
            txtPPCourseSubject.Text = strCourseSubject;
            txtPPCourseNo.Text = strCourseNo;
            txtPPDeveloper.Text = strDeveloper;
            cbPPSofI.Checked = Convert.ToBoolean(strSOI == "" ? "False" : strSOI);
            cbPPPA.Checked = Convert.ToBoolean(strPofA == "" ? "False" : strPofA);
            cbPPSC.Checked = Convert.ToBoolean(strSC == "" ? "False" : strSC);
            txtPPDeveloperPayment1.Text = strDeveloperPaymentAmount1;
            txtPPDeveloperEstimatedPayDate1.Text = strDeveloperPaymentDate1;
            txtPPDeveloperPayment2.Text = strDeveloperPaymentAmount2;
            txtPPDeveloperEstimatedPayDate2.Text = strDeveloperPaymentDate2;

            // Internal Reviewer Section

            txtPPIRStartDate.Text = strIRStartDate;
            txtPPIREndDate.Text = strIREndDate;

            //IR Chair
            dropPPIRChair.SelectedValue = strIRChair == "0" ? "-1" : strIRChair;
            paymentdropIRChairPaperwork.SelectedValue = strIRChairPaperworkType == "0" ? "-1" : strIRChairPaperworkType;
            paymentdropIRChairPaperwork_SelectedIndexChanged(null, null);
            cbPPIRChairSupplementPayrollForm.Checked = Convert.ToBoolean(strIRChairPayrollform == "" ? "False" : strIRChairPayrollform);
            cbPPIRChair1099.Checked = Convert.ToBoolean(strIRChair1099 == "" ? "False" : strIRChair1099);
            cbPPIRChair1042.Checked = Convert.ToBoolean(strIRChair1042 == "" ? "False" : strIRChair1042);
            cbPPIRChairW9.Checked = Convert.ToBoolean(strIRChairW9 == "" ? "False" : strIRChairW9);
            txtPPIRChairPayment.Text = strIRPaymentAmount;
            txtPPIRChairPaymentAmount.Text = strIRChairPaymentAmount;
            txtPPIRChairEstimatedPayDate.Text = strIRChairEstimatedPaymentDate;

            //IR Reviewer2
            dropPPIRReviewer2.SelectedValue = strIRReviewer2 == "0" ? "-1" : strIRReviewer2;
            paymentdropIRReviewer2PaperworkType.SelectedValue = strIRReviewer2PaperworkType == "0" ? "-1" : strIRReviewer2PaperworkType;
            paymentdropIRReviewer2PaperworkType_SelectedIndexChanged(null, null);
            cbPPIRReviewer2PayrollForm.Checked = Convert.ToBoolean(strIRReviewer2Payrollform == "" ? "False" : strIRReviewer2Payrollform);
            cbPPIRReviewer21099.Checked = Convert.ToBoolean(strIRReviewer21099 == "" ? "False" : strIRReviewer21099);
            cbPPIRReviewer21042.Checked = Convert.ToBoolean(strIRReviewer21042 == "" ? "False" : strIRReviewer21042);
            cbPPIRReviewer2W9.Checked = Convert.ToBoolean(strIRReviewer2W9 == "" ? "False" : strIRReviewer2W9);
            txtPPIRReviewer2Payment.Text = strIRPaymentAmount;
            txtPPIRReviewer2PaymentAmount.Text = strIRReviewer2PaymentAmount;
            txtPPIRReviewer2EstimatedPaymentDate.Text = strIRReviewer2EstimatedPaymentDate;
            //IR Reviewer3
            dropPPIRReviewer3.SelectedValue = strIRReviewer3 == "0" ? "-1" : strIRReviewer3;
            dropPPIRReviwer3PaperworkType.SelectedValue = strIRReviewer3PaperworkType == "0" ? "-1" : strIRReviewer3PaperworkType;
            dropPPIRReviwer3PaperworkType_SelectedIndexChanged(null, null);
            cbPPIRReviwer3PayrollForm.Checked = Convert.ToBoolean(strIRReviewer3Payrollform == "" ? "False" : strIRReviewer3Payrollform);
            cbPPIRReviewer31099.Checked = Convert.ToBoolean(strIRReviewer31099 == "" ? "False" : strIRReviewer31099);
            cbPPIRReviewer31042.Checked = Convert.ToBoolean(strIRReviewer31042 == "" ? "False" : strIRReviewer31042);
            cbPPIRReviewer3W9.Checked = Convert.ToBoolean(strIRReviewer3W9 == "" ? "False" : strIRReviewer3W9);
            txtPPIRReviewer3MaxPaymentAmount.Text = strIRPaymentAmount;
            txtPPIRReviewer3PaymentAmount.Text = strIRReviewer3PaymentAmount;
            txtPPIRReviewer3EstimatedPaymentDate.Text = strIRReviewer3EstimatedPaymentDate;

            // Official Reviewer Section
            txtPPORStartDate.Text = strORStartDate;
            txtPPOREndDate.Text = strOREndDate;
            //OR Chair
            dropPPORChair.SelectedValue = strORChair == "0" ? "-1" : strORChair;
            dropPPORChairPaperworkType.SelectedValue = strORChairPaperworkType == "0" ? "-1" : strORChairPaperworkType;
            dropPPORChairPaperworkType_SelectedIndexChanged(null, null);
            cbPPORChairPayroll.Checked = Convert.ToBoolean(strORChairPayrollform == "" ? "False" : strORChairPayrollform);
            cbPPORChair1099.Checked = Convert.ToBoolean(strORChair1099 == "" ? "False" : strORChair1099); 
            cbPPORChair1042.Checked = Convert.ToBoolean(strORChair1042 == "" ? "False" : strORChair1042);
            cbPPORChairW9.Checked = Convert.ToBoolean(strORChairW9 == "" ? "False" : strORChairW9);
            txtORchairMaxPayment.Text = strORChairMaxPaymentAmount;
            txtORChairPaymentAmount.Text = strORChairPaymentAmount;
            txtORChairEstimatedPaymentDate.Text = strORChairEstimatedPaymentDate;
            //OR Reviewer2
            dropPPORReviewer2.SelectedValue = strORReviewer2 == "0" ? "-1" : strORReviewer2;
            dropPPORReviewer2PaperworkType.SelectedValue = strORReviewer2PaperworkType == "0" ? "-1" : strORReviewer2PaperworkType;
            dropPPORReviewer2PaperworkType_SelectedIndexChanged(null, null);
            cbPPORReviewer2Payroll.Checked = Convert.ToBoolean(strORReviewer2Payrollform == "" ? "False" : strORReviewer2Payrollform);
            cbPPORReviewer21042.Checked = Convert.ToBoolean(strORReviewer21042 == "" ? "False" : strORReviewer21042);
            cbPPORReviewer2W9.Checked = Convert.ToBoolean(strORReviewer2W9 == "" ? "False" : strORReviewer2W9);
            txtPPORReviewer2MaxPaymentAmount.Text = strORPaymentAmount;
            txtPPORReviewer2PaymentAmount.Text = strORReviewer2PaymentAmount;
            txtPPORReviewer2EstimatedPaymentDate.Text = strORReviewer2EstimatedPaymentDate;

            //OR Reviewer3
            dropPPORReviewer3.SelectedValue = strORReviewer3 == "0" ? "-1" : strORReviewer3;
            dropPPORReviewer3PaperworkType.SelectedValue = strORReviewer3PaperworkType == "0" ? "-1" : strORReviewer3PaperworkType;
            dropPPORReviewer3PaperworkType_SelectedIndexChanged(null, null);
            cbPPORReviewer3Payroll.Checked = Convert.ToBoolean(strORReviewer3Payrollform == "" ? "False" : strORReviewer3Payrollform);
            cbPPORReviewer31099.Checked = Convert.ToBoolean(strORReviewer31099 == "" ? "False" : strORReviewer31099);
            cbPPORReviewer31042.Checked = Convert.ToBoolean(strORReviewer31042 == "" ? "False" : strORReviewer31042);
            cbPPORReviewer3W9.Checked = Convert.ToBoolean(strORReviewer3W9 == "" ? "False" : strORReviewer3W9);
            txtPPORReviewer3MaxPaymentAmount.Text = strORPaymentAmount;
            txtPPORReviewer3PaymentAmount.Text = strORReviewer3PaymentAmount;
            txtPPORReviewer3EstimatedPaymentDate.Text = strORReviewer3EstimatedPaymentDate;

            txtPPNote.Text = strPaymentNote;
            txtPPaddedby.Text = strPaymentAddedBy;
            txtPPaddeddate.Text = strPaymentAddedDate;
            txtPPupdatedby.Text = strPaymentUpdatedBy;
            txtPPupdateddate.Text = strPaymentUpdatedDate;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#paymentModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }
    }
    protected void paymentdropIRChairPaperwork_SelectedIndexChanged(object sender, EventArgs e)
    {
        string contractType = paymentdropIRChairPaperwork.SelectedItem.Text;
        if (contractType == "SERVICE")
        {
            PanelPPIRChairService.Visible = true;
            PanelPPIRChairIndependent.Visible = false;
            cbPPIRChair1099.Checked = false; cbPPIRChair1042.Checked = false; cbPPIRChairW9.Checked = false;

        }
        else if (contractType == "INDEPENDENT")
        {
            PanelPPIRChairIndependent.Visible = true;
            PanelPPIRChairService.Visible = false;
            cbPPIRChairSupplementPayrollForm.Checked = false;
        }
        else if (contractType == "-- PAPERWORK TYPE --")
        {
            PanelPPIRChairService.Visible = false;
            PanelPPIRChairIndependent.Visible = false;
            cbPPIRChair1099.Checked = false; cbPPIRChair1042.Checked = false; cbPPIRChairW9.Checked = false; cbPPIRChairSupplementPayrollForm.Checked = false;
        }

    }
    protected void btnaddSaveCourse_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

         DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();

        SqlCourseaddCheck.SelectCommand = " SELECT * FROM COURSEDETAIL WHERE COURSE_SUBJECT = @COURSE_SUBJECT  AND COURSE_NUMBER = @COURSE_NUMBER ";

        SqlCourseaddCheck.SelectParameters["COURSE_SUBJECT"].DefaultValue = txtaddCourseSubject.Text.Trim();
        SqlCourseaddCheck.SelectParameters["COURSE_NUMBER"].DefaultValue = txtaddCourseNumber.Text.Trim();

        DataView dvCodeExists = new DataView();

        dvCodeExists = (DataView)SqlCourseaddCheck.Select(dsArguments);

        if (dvCodeExists.Count >= 1)
        {
            addError.Text = "Course Already Exist !!! Please Enter another Course";
            addError.ForeColor = System.Drawing.Color.Red;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "ConfirmUser('Course already exists!!! Are you sure to continue with the same course?');", true);
        
        }
        else
        {

            string UserName = (string)Session["commonname"];
            string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            SqlCourseDetailspecific.InsertParameters["COURSE_TYPE_ISN"].DefaultValue = adddropCourseType.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["DEVELOPMENT_STATUS_ISN"].DefaultValue = adddropDevelopmentStatus.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["COURSE_SUBJECT"].DefaultValue = txtaddCourseSubject.Text.ToUpper().Trim();
            SqlCourseDetailspecific.InsertParameters["COURSE_NUMBER"].DefaultValue = txtaddCourseNumber.Text.ToUpper().Trim();
            SqlCourseDetailspecific.InsertParameters["COURSE_TITLE"].DefaultValue = txtaddCourseTitle.Text.ToUpper().Trim();
            SqlCourseDetailspecific.InsertParameters["COURSE_STATUS"].DefaultValue = rbaddCourseEnabled.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["DEVELOPER_ISN"].DefaultValue = adddropDeveloper.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["COORDINATOR_ISN"].DefaultValue = adddropCoordinator.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["COLL_CODE_ISN"].DefaultValue = adddropCollege.SelectedValue;

            if (adddropSemesterTaugt.SelectedValue == "-1")
                SqlCourseDetailspecific.InsertParameters["SEMESTER_TAUGHT_ISN"].DefaultValue = null;
            else
                SqlCourseDetailspecific.InsertParameters["SEMESTER_TAUGHT_ISN"].DefaultValue = adddropSemesterTaugt.SelectedValue;

            if (txtaddYearTaught.Text.Trim() == "" || txtaddYearTaught.Text.Trim() == " ")
                SqlCourseDetailspecific.InsertParameters["YEAR_TAUGHT"].DefaultValue = null;
            else
                SqlCourseDetailspecific.InsertParameters["YEAR_TAUGHT"].DefaultValue = txtaddYearTaught.Text.Trim();
            
            if(adddropDegree.SelectedValue == "-1")
                SqlCourseDetailspecific.InsertParameters["DEGREE_PROGRAM_CODE_ISN"].DefaultValue = null;
            else
                SqlCourseDetailspecific.InsertParameters["DEGREE_PROGRAM_CODE_ISN"].DefaultValue = adddropDegree.SelectedValue;

            if (txtaddReviewStartDate.Text != null || txtaddReviewStartDate.Text != " ")
                SqlCourseDetailspecific.InsertParameters["DATE_TO_START_REVIEW"].DefaultValue = txtaddReviewStartDate.Text;
            else
                SqlCourseDetailspecific.InsertParameters["DATE_TO_START_REVIEW"].DefaultValue = null;

            if (txtaddQMCertifiedDate.Text != null || txtaddQMCertifiedDate.Text != " ")
                SqlCourseDetailspecific.InsertParameters["QM_CERTIFIED_DATE"].DefaultValue = txtaddQMCertifiedDate.Text;
            else
                SqlCourseDetailspecific.InsertParameters["QM_CERTIFIED_DATE"].DefaultValue = null;

            SqlCourseDetailspecific.InsertParameters["NOTE"].DefaultValue = txtaddNote.Text.ToUpper().Trim();

            SqlCourseDetailspecific.InsertParameters["ADDED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlCourseDetailspecific.InsertParameters["ADDED_DATE"].DefaultValue = CurrentDate;

            SqlCourseDetailspecific.InsertParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlCourseDetailspecific.InsertParameters["UPDATED_DATE"].DefaultValue = CurrentDate;

            try
            {
                SqlCourseDetailspecific.Insert();
                System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                strbuilder.Append(@"<script type='text/javascript'>");
                strbuilder.Append("alert('Course Added Successfully');");
                strbuilder.Append("$('#addModal').modal('hide');");
                strbuilder.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "addHideModalScript", strbuilder.ToString(), false);
                gvCourseDetail.DataBind();
                upCourseDetail.Update();
                txtaddCourseNumber.Text = string.Empty;
                txtaddCourseSubject.Text = string.Empty;
                txtaddCourseTitle.Text = string.Empty;
                txtaddNote.Text = string.Empty;
                txtaddQMCertifiedDate.Text = string.Empty;
                txtaddReviewStartDate.Text = string.Empty;
                txtaddYearTaught.Text = string.Empty;
                adddropCollege.SelectedIndex = -1;
                adddropCoordinator.SelectedIndex = -1;
                adddropCourseType.SelectedIndex = -1;
                adddropDegree.SelectedIndex = -1;
                adddropDeveloper.SelectedIndex = -1;
                adddropDevelopmentStatus.SelectedIndex = -1;
                adddropSemesterTaugt.SelectedIndex = -1;

            }
            catch
            {
                editError.Text = "An error has occured in updation of Record";
                editError.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
            }
        }
    }

    

    protected void paymentdropIRReviewer2PaperworkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string contractType = paymentdropIRReviewer2PaperworkType.SelectedItem.Text;
        if (contractType == "SERVICE")
        {
            PanelIRReviewer2Service.Visible = true;
            PanelPPIRReviewer2Independent.Visible = false;
            cbPPIRReviewer21042.Checked = false; cbPPIRReviewer21042.Checked = false; cbPPIRReviewer2W9.Checked = false; 
        }
        else if (contractType == "INDEPENDENT")
        {
            PanelPPIRReviewer2Independent.Visible = true;
            PanelIRReviewer2Service.Visible = false;
            cbPPIRReviewer2PayrollForm.Checked = false;
        }
        else if (contractType == "-- PAPERWORK TYPE --")
        {
            PanelIRReviewer2Service.Visible = false;
            PanelPPIRReviewer2Independent.Visible = false;
            cbPPIRReviewer21042.Checked = false; cbPPIRReviewer21042.Checked = false; cbPPIRReviewer2W9.Checked = false; cbPPIRReviewer2PayrollForm.Checked = false;
        }
    }
    protected void dropPPIRReviwer3PaperworkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string contractType = dropPPIRReviwer3PaperworkType.SelectedItem.Text;
        if (contractType == "SERVICE")
        {
            PanelPPIRReviewer3Service.Visible = true;
            PanelPPIRReviewer3Independent.Visible = false;
            cbPPIRReviewer31099.Checked = false; cbPPIRReviewer31042.Checked = false; cbPPIRReviewer3W9.Checked = false;
        }
        else if (contractType == "INDEPENDENT")
        {
            PanelPPIRReviewer3Independent.Visible = true;
            PanelPPIRReviewer3Service.Visible = false;
            cbPPIRReviwer3PayrollForm.Checked = false;
        }
        else if (contractType == "-- PAPERWORK TYPE --")
        {
            PanelPPIRReviewer3Service.Visible = false;
            PanelPPIRReviewer3Independent.Visible = false;
            cbPPIRReviwer3PayrollForm.Checked = false; cbPPIRReviewer31099.Checked = false; cbPPIRReviewer31042.Checked = false; cbPPIRReviewer3W9.Checked = false;
        }
    }
    protected void dropPPORChairPaperworkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string contractType = dropPPORChairPaperworkType.SelectedItem.Text;
        if (contractType == "SERVICE")
        {
            PanelPPORChairService.Visible = true;
            PanelPPORChairIndependent.Visible = false;
            cbPPORChair1099.Checked = false; cbPPORChair1042.Checked = false; cbPPORChairW9.Checked = false;
        }
        else if (contractType == "INDEPENDENT")
        {
            PanelPPORChairIndependent.Visible = true;
            PanelPPORChairService.Visible = false;
            cbPPORChairPayroll.Checked = false;
        }
        else if (contractType == "-- PAPERWORK TYPE --")
        {
            PanelPPORChairService.Visible = false;
            PanelPPORChairIndependent.Visible = false;
            cbPPORChairPayroll.Checked = false; cbPPORChair1099.Checked = false; cbPPORChair1042.Checked = false; cbPPORChairW9.Checked = false;
        }
    }
    protected void dropPPORReviewer2PaperworkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string contractType = dropPPORReviewer2PaperworkType.SelectedItem.Text;
        if (contractType == "SERVICE")
        {
            PanelPPORReviewer2Service.Visible = true;
            PanelPPORReviewer2Independent.Visible = false;
            cbPPORReviewer21099.Checked = false; cbPPORReviewer21042.Checked = false; cbPPORReviewer2W9.Checked = false;
        }
        else if (contractType == "INDEPENDENT")
        {
            PanelPPORReviewer2Independent.Visible = true;
            PanelPPORReviewer2Service.Visible = false;
            cbPPORReviewer2Payroll.Checked = false;
        }
        else if (contractType == "-- PAPERWORK TYPE --")
        {
            PanelPPORReviewer2Service.Visible = false;
            PanelPPORReviewer2Independent.Visible = false;
            cbPPORReviewer21099.Checked = false; cbPPORReviewer21042.Checked = false; cbPPORReviewer2W9.Checked = false; cbPPORReviewer2Payroll.Checked = false;
        }
    }
    protected void dropPPORReviewer3PaperworkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string contractType = dropPPORReviewer3PaperworkType.SelectedItem.Text;
        if (contractType == "SERVICE")
        {
            PanelPPORReviewer3Service.Visible = true;
            PanelPPORReviewer3Independent.Visible = false;
            cbPPORReviewer31099.Checked = false; cbPPORReviewer31042.Checked = false; cbPPORReviewer3W9.Checked = false;
        }
        else if (contractType == "INDEPENDENT")
        {
            PanelPPORReviewer3Independent.Visible = true;
            PanelPPORReviewer3Service.Visible = false;
            cbPPIRReviwer3PayrollForm.Checked = false;
        }
        else if (contractType == "-- PAPERWORK TYPE --")
        {
            PanelPPORReviewer3Service.Visible = false;
            PanelPPORReviewer3Independent.Visible = false;
            cbPPORReviewer31099.Checked = false; cbPPORReviewer31042.Checked = false; cbPPORReviewer3W9.Checked = false; cbPPIRReviwer3PayrollForm.Checked = false;
        }
    }

    protected void btnPPEdit_Click(object sender, EventArgs e)
    {

        

        editPanel.Visible = false; savePanel.Visible = true; addedandupdatedPanel.Visible = false;
        cbPPSofI.Enabled = true; cbPPSofI.CssClass = "form-control"; cbPPPA.Enabled = true; cbPPPA.CssClass = "form-control"; cbPPSC.Enabled = true; cbPPSC.CssClass = "form-control";
       txtPPDeveloperPayment1.Enabled = true; txtPPDeveloperPayment1.ReadOnly = false; txtPPDeveloperPayment1.CssClass = "form-control"; txtPPDeveloperPayment1.BackColor = System.Drawing.Color.White; txtPPDeveloperPayment1.BorderStyle = BorderStyle.Groove;
        txtPPDeveloperEstimatedPayDate1.Enabled = true; txtPPDeveloperEstimatedPayDate1.ReadOnly = false; txtPPDeveloperEstimatedPayDate1.CssClass = "form-control"; txtPPDeveloperEstimatedPayDate1.BackColor = System.Drawing.Color.White; txtPPDeveloperEstimatedPayDate1.BorderStyle = BorderStyle.Groove;
        imgPPDeveloperEstimatedPayDate1.Visible = true; cePPDeveloperEstimatedPayDate1.Enabled = true;
        txtPPDeveloperPayment2.Enabled = true; txtPPDeveloperPayment2.ReadOnly = false; txtPPDeveloperPayment2.CssClass = "form-control"; txtPPDeveloperPayment2.BackColor = System.Drawing.Color.White; txtPPDeveloperPayment2.BorderStyle = BorderStyle.Groove;
        txtPPDeveloperEstimatedPayDate2.Enabled = true; txtPPDeveloperEstimatedPayDate2.ReadOnly = false; txtPPDeveloperEstimatedPayDate2.CssClass = "form-control"; txtPPDeveloperEstimatedPayDate2.BackColor = System.Drawing.Color.White; txtPPDeveloperEstimatedPayDate2.BorderStyle = BorderStyle.Groove;
        imgPPDeveloperEstimatedPayDate2.Visible = true; cePPDeveloperEstimatedPayDate2.Enabled = true;

        // Internal Reviewer
        txtPPIRStartDate.Enabled = true; txtPPIRStartDate.ReadOnly = false; txtPPIRStartDate.CssClass = "form-control"; txtPPIRStartDate.BackColor = System.Drawing.Color.White; txtPPIRStartDate.BorderStyle = BorderStyle.Groove;
        imgPPIRStartDate.Visible = true; cePPIRStartDate.Enabled = true;
        txtPPIREndDate.Enabled = true; txtPPIREndDate.ReadOnly = false; txtPPIREndDate.CssClass = "form-control"; txtPPIREndDate.BackColor = System.Drawing.Color.White; txtPPIREndDate.BorderStyle = BorderStyle.Groove;
        imgPPIREndDate.Visible = true; cePPIREndDate.Enabled = true;
        // IR Chair
        dropPPIRChair.Enabled = true; dropPPIRChair.CssClass = "form-control"; dropPPIRChair.BorderStyle = BorderStyle.Groove;
        paymentdropIRChairPaperwork.Enabled = true; paymentdropIRChairPaperwork.CssClass = "form-control"; paymentdropIRChairPaperwork.BorderStyle = BorderStyle.Groove;
        cbPPIRChairSupplementPayrollForm.Enabled = true; cbPPIRChairSupplementPayrollForm.CssClass = "form-control"; cbPPIRChairSupplementPayrollForm.BorderStyle = BorderStyle.Groove;
        cbPPIRChair1099.Enabled = true; cbPPIRChair1099.CssClass = "form-control"; cbPPIRChair1099.BorderStyle = BorderStyle.Groove;
        cbPPIRChair1042.Enabled = true; cbPPIRChair1042.CssClass = "form-control"; cbPPIRChair1042.BorderStyle = BorderStyle.Groove;
        cbPPIRChairW9.Enabled = true; cbPPIRChairW9.CssClass = "form-control"; cbPPIRChairW9.BorderStyle = BorderStyle.Groove;
        txtPPIRChairEstimatedPayDate.Enabled = true; txtPPIRChairEstimatedPayDate.ReadOnly = false; txtPPIRChairEstimatedPayDate.CssClass = "form-control"; txtPPIRChairEstimatedPayDate.BackColor = System.Drawing.Color.White; txtPPIRChairEstimatedPayDate.BorderStyle = BorderStyle.Groove;
        imgPPIRChairEstimatedPayDate.Visible = true; cePPIRChairEstimatedPayDate.Enabled = true;
        txtPPIRChairPaymentAmount.Enabled = true; txtPPIRChairPaymentAmount.ReadOnly = false; txtPPIRChairPaymentAmount.CssClass = "form-control"; txtPPIRChairPaymentAmount.BackColor = System.Drawing.Color.White; txtPPIRChairPaymentAmount.BorderStyle = BorderStyle.Groove;
        // IR Reviewer 2
        dropPPIRReviewer2.Enabled = true; dropPPIRReviewer2.CssClass = "form-control"; dropPPIRReviewer2.BorderStyle = BorderStyle.Groove;
        paymentdropIRReviewer2PaperworkType.Enabled = true; paymentdropIRReviewer2PaperworkType.CssClass = "form-control"; paymentdropIRReviewer2PaperworkType.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer2PayrollForm.Enabled = true; cbPPIRReviewer2PayrollForm.CssClass = "form-control"; cbPPIRReviewer2PayrollForm.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer21099.Enabled = true; cbPPIRReviewer21099.CssClass = "form-control"; cbPPIRReviewer21099.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer21042.Enabled = true; cbPPIRReviewer21042.CssClass = "form-control"; cbPPIRReviewer21042.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer2W9.Enabled = true; cbPPIRReviewer2W9.CssClass = "form-control"; cbPPIRReviewer2W9.BorderStyle = BorderStyle.Groove;
        txtPPIRReviewer2EstimatedPaymentDate.Enabled = true; txtPPIRReviewer2EstimatedPaymentDate.ReadOnly = false; txtPPIRReviewer2EstimatedPaymentDate.CssClass = "form-control"; txtPPIRReviewer2EstimatedPaymentDate.BackColor = System.Drawing.Color.White; txtPPIRReviewer2EstimatedPaymentDate.BorderStyle = BorderStyle.Groove;
        imgPPIRReviewer2EstimatedPaymentDate.Visible = true; cePPIRReviewer2EstimatedPaymentDate.Enabled = true;
        txtPPIRReviewer2PaymentAmount.Enabled = true; txtPPIRReviewer2PaymentAmount.ReadOnly = false; txtPPIRReviewer2PaymentAmount.CssClass = "form-control"; txtPPIRReviewer2PaymentAmount.BackColor = System.Drawing.Color.White; txtPPIRReviewer2PaymentAmount.BorderStyle = BorderStyle.Groove;
        // IR Reviewer 3
        dropPPIRReviewer3.Enabled = true; dropPPIRReviewer3.CssClass = "form-control"; dropPPIRReviewer3.BorderStyle = BorderStyle.Groove;
        dropPPIRReviwer3PaperworkType.Enabled = true; dropPPIRReviwer3PaperworkType.CssClass = "form-control"; dropPPIRReviwer3PaperworkType.BorderStyle = BorderStyle.Groove;
        cbPPIRReviwer3PayrollForm.Enabled = true; cbPPIRReviwer3PayrollForm.CssClass = "form-control"; cbPPIRReviwer3PayrollForm.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer31099.Enabled = true; cbPPIRReviewer31099.CssClass = "form-control"; cbPPIRReviewer31099.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer31042.Enabled = true; cbPPIRReviewer31042.CssClass = "form-control"; cbPPIRReviewer31042.BorderStyle = BorderStyle.Groove;
        cbPPIRReviewer3W9.Enabled = true; cbPPIRReviewer3W9.CssClass = "form-control"; cbPPIRReviewer3W9.BorderStyle = BorderStyle.Groove;
        txtPPIRReviewer3EstimatedPaymentDate.Enabled = true; txtPPIRReviewer3EstimatedPaymentDate.ReadOnly = false; txtPPIRReviewer3EstimatedPaymentDate.CssClass = "form-control"; txtPPIRReviewer3EstimatedPaymentDate.BackColor = System.Drawing.Color.White; txtPPIRReviewer3EstimatedPaymentDate.BorderStyle = BorderStyle.Groove;
        imgPPIRReviewer3EstimatedPaymentDate.Visible = true; cePPIRReviewer3EstimatedPaymentDate.Enabled = true;
        txtPPIRReviewer3PaymentAmount.Enabled = true; txtPPIRReviewer3PaymentAmount.ReadOnly = false; txtPPIRReviewer3PaymentAmount.CssClass = "form-control"; txtPPIRReviewer3PaymentAmount.BackColor = System.Drawing.Color.White; txtPPIRReviewer3PaymentAmount.BorderStyle = BorderStyle.Groove;

        // Official Reviewer
        txtPPORStartDate.Enabled = true; txtPPORStartDate.ReadOnly = false; txtPPORStartDate.CssClass = "form-control"; txtPPORStartDate.BackColor = System.Drawing.Color.White; txtPPORStartDate.BorderStyle = BorderStyle.Groove;
        imgPPORStartDate.Visible = true; cePPORStartDate.Enabled = true;
        txtPPOREndDate.Enabled = true; txtPPOREndDate.ReadOnly = false; txtPPOREndDate.CssClass = "form-control"; txtPPOREndDate.BackColor = System.Drawing.Color.White; txtPPOREndDate.BorderStyle = BorderStyle.Groove;
        imgPPOREndDate.Visible = true; cePPOREndDate.Enabled = true;
        // OR Chair
        dropPPORChair.Enabled = true; dropPPORChair.CssClass = "form-control"; dropPPORChair.BorderStyle = BorderStyle.Groove;
        dropPPORChairPaperworkType.Enabled = true; dropPPORChairPaperworkType.CssClass = "form-control"; dropPPORChairPaperworkType.BorderStyle = BorderStyle.Groove;
        cbPPORChairPayroll.Enabled = true; cbPPORChairPayroll.CssClass = "form-control"; cbPPORChairPayroll.BorderStyle = BorderStyle.Groove;
        cbPPORChair1099.Enabled = true; cbPPORChair1099.CssClass = "form-control"; cbPPORChair1099.BorderStyle = BorderStyle.Groove;
        cbPPORChair1042.Enabled = true; cbPPORChair1042.CssClass = "form-control"; cbPPORChair1042.BorderStyle = BorderStyle.Groove;
        cbPPORChairW9.Enabled = true; cbPPORChairW9.CssClass = "form-control"; cbPPORChairW9.BorderStyle = BorderStyle.Groove;
        txtORChairEstimatedPaymentDate.Enabled = true; txtORChairEstimatedPaymentDate.ReadOnly = false; txtORChairEstimatedPaymentDate.CssClass = "form-control"; txtORChairEstimatedPaymentDate.BackColor = System.Drawing.Color.White; txtORChairEstimatedPaymentDate.BorderStyle = BorderStyle.Groove;
        imgORChairEstimatedPaymentDate.Visible = true; ceORChairEstimatedPaymentDate.Enabled = true;
        txtORChairPaymentAmount.Enabled = true; txtORChairPaymentAmount.ReadOnly = false; txtORChairPaymentAmount.CssClass = "form-control"; txtORChairPaymentAmount.BackColor = System.Drawing.Color.White; txtORChairPaymentAmount.BorderStyle = BorderStyle.Groove;
        // OR Reviewer 2
        dropPPORReviewer2.Enabled = true; dropPPORReviewer2.CssClass = "form-control"; dropPPORReviewer2.BorderStyle = BorderStyle.Groove;
        dropPPORReviewer2PaperworkType.Enabled = true; dropPPORReviewer2PaperworkType.CssClass = "form-control"; dropPPORReviewer2PaperworkType.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer2Payroll.Enabled = true; cbPPORReviewer2Payroll.CssClass = "form-control"; cbPPORReviewer2Payroll.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer21099.Enabled = true; cbPPORReviewer21099.CssClass = "form-control"; cbPPORReviewer21099.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer21042.Enabled = true; cbPPORReviewer21042.CssClass = "form-control"; cbPPORReviewer21042.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer2W9.Enabled = true; cbPPORReviewer2W9.CssClass = "form-control"; cbPPORReviewer2W9.BorderStyle = BorderStyle.Groove;
        txtPPORReviewer2EstimatedPaymentDate.Enabled = true; txtPPORReviewer2EstimatedPaymentDate.ReadOnly = false; txtPPORReviewer2EstimatedPaymentDate.CssClass = "form-control"; txtPPORReviewer2EstimatedPaymentDate.BackColor = System.Drawing.Color.White; txtPPORReviewer2EstimatedPaymentDate.BorderStyle = BorderStyle.Groove;
        imgPPORReviewer2EstimatedPaymentDate.Visible = true; cePPORReviewer2EstimatedPaymentDate.Enabled = true;
        txtPPORReviewer2PaymentAmount.Enabled = true; txtPPORReviewer2PaymentAmount.ReadOnly = false; txtPPORReviewer2PaymentAmount.CssClass = "form-control"; txtPPORReviewer2PaymentAmount.BackColor = System.Drawing.Color.White; txtPPORReviewer2PaymentAmount.BorderStyle = BorderStyle.Groove;
        // OR Reviewer 3
        dropPPORReviewer3.Enabled = true; dropPPORReviewer3.CssClass = "form-control"; dropPPORReviewer3.BorderStyle = BorderStyle.Groove;
        dropPPORReviewer3PaperworkType.Enabled = true; dropPPORReviewer3PaperworkType.CssClass = "form-control"; dropPPORReviewer3PaperworkType.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer3Payroll.Enabled = true; cbPPORReviewer3Payroll.CssClass = "form-control"; cbPPORReviewer3Payroll.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer31099.Enabled = true; cbPPORReviewer31099.CssClass = "form-control"; cbPPORReviewer31099.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer31042.Enabled = true; cbPPORReviewer31042.CssClass = "form-control"; cbPPORReviewer31042.BorderStyle = BorderStyle.Groove;
        cbPPORReviewer3W9.Enabled = true; cbPPORReviewer3W9.CssClass = "form-control"; cbPPORReviewer3W9.BorderStyle = BorderStyle.Groove;
        txtPPORReviewer3EstimatedPaymentDate.Enabled = true; txtPPORReviewer3EstimatedPaymentDate.ReadOnly = false; txtPPORReviewer3EstimatedPaymentDate.CssClass = "form-control"; txtPPORReviewer3EstimatedPaymentDate.BackColor = System.Drawing.Color.White; txtPPORReviewer3EstimatedPaymentDate.BorderStyle = BorderStyle.Groove;
        imgPPORReviewer3EstimatedPaymentDate.Visible = true; cePPORReviewer3EstimatedPaymentDate.Enabled = true;
        txtPPORReviewer3PaymentAmount.Enabled = true; txtPPORReviewer3PaymentAmount.ReadOnly = false; txtPPORReviewer3PaymentAmount.CssClass = "form-control"; txtPPORReviewer3PaymentAmount.BackColor = System.Drawing.Color.White; txtPPORReviewer3PaymentAmount.BorderStyle = BorderStyle.Groove;

        //Note
        txtPPNote.Enabled = true; txtPPNote.ReadOnly = false; txtPPNote.CssClass = "form-control"; txtPPNote.BackColor = System.Drawing.Color.White; txtPPNote.BorderStyle = BorderStyle.Groove;
    }

    protected void btnPPUpdate_Click(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["access"] != "ADMIN")
        {
            Response.Redirect("../index.aspx");
        }

        DataSourceSelectArguments dsArguments = new DataSourceSelectArguments();

        if ( Convert.ToInt32(CoursePaymentisn.Value) == 0)
            SqlPaymentaddCheck.SelectParameters["COURSE_ISN"].DefaultValue = (string)Session["CP"];
        else
            SqlPaymentaddCheck.SelectParameters["COURSE_ISN"].DefaultValue = CoursePaymentisn.Value;

        DataView dvCodeExists = new DataView();

        dvCodeExists = (DataView)SqlPaymentaddCheck.Select(dsArguments);

        if (dvCodeExists.Count >= 1)
        {

            string UserName = (string)Session["commonname"];
            string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            if(Convert.ToInt32(CoursePaymentisn.Value) == 0)
                SqlPaymentAndPaperWorkHistory.UpdateParameters["COURSE_ISN"].DefaultValue = (string)Session["CP"];
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["COURSE_ISN"].DefaultValue = CoursePaymentisn.Value;
            SqlPaymentAndPaperWorkHistory.UpdateParameters["STATEMENT_OF_INTENT"].DefaultValue = cbPPSofI.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["PROCEDURES_AND_AGREEMENT"].DefaultValue = cbPPPA.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["SERVICE_CONTRACT"].DefaultValue = cbPPSC.Checked.ToString();

            if (txtPPDeveloperPayment1.Text != " ")
            {
                if (txtPPDeveloperPayment1.Text != "")
                {
                    decimal firstPaymentAmount = Convert.ToDecimal(txtPPDeveloperPayment1.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["FIRST_PAYMENT_AMOUNT"].DefaultValue = firstPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["FIRST_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["FIRST_PAYMENT_AMOUNT"].DefaultValue = null;

            

            if (txtPPDeveloperEstimatedPayDate1.Text != null || txtPPDeveloperEstimatedPayDate1.Text != " " || txtPPDeveloperEstimatedPayDate1.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["FIRST_PAYMENT_DATE"].DefaultValue = txtPPDeveloperEstimatedPayDate1.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["FIRST_PAYMENT_DATE"].DefaultValue = null;

            if (txtPPDeveloperPayment2.Text != " ")
            {
                if (txtPPDeveloperPayment2.Text != "")
                {
                    decimal secondPaymentAmount = Convert.ToDecimal(txtPPDeveloperPayment2.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["SECOND_PAYMENT_AMOUNT"].DefaultValue = secondPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["SECOND_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["SECOND_PAYMENT_AMOUNT"].DefaultValue = null;

            

            if (txtPPDeveloperEstimatedPayDate2.Text != null || txtPPDeveloperEstimatedPayDate2.Text != " " || txtPPDeveloperEstimatedPayDate2.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["SECOND_PAYMENT_DATE"].DefaultValue = txtPPDeveloperEstimatedPayDate1.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["SECOND_PAYMENT_DATE"].DefaultValue = null;

            // IR

            if (txtPPIRStartDate.Text != null || txtPPIRStartDate.Text != " " || txtPPIRStartDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_START_DATE"].DefaultValue = txtPPIRStartDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_START_DATE"].DefaultValue = null;

            if (txtPPIREndDate.Text != null || txtPPIREndDate.Text != " " || txtPPIREndDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_END_DATE"].DefaultValue = txtPPIREndDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_END_DATE"].DefaultValue = null;

            // IR Chair
            if (dropPPIRChair.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_ISN"].DefaultValue = dropPPIRChair.SelectedValue;

            if (paymentdropIRChairPaperwork.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = paymentdropIRChairPaperwork.SelectedValue;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPIRChairSupplementPayrollForm.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_1099"].DefaultValue = cbPPIRChair1099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_1042_S"].DefaultValue = cbPPIRChair1042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_W_9"].DefaultValue = cbPPIRChairW9.Checked.ToString();


            if (txtPPIRChairPaymentAmount.Text != " ")
            {
                if (txtPPIRChairPaymentAmount.Text != "")
                {
                    decimal IRchairPaymentAmount = Convert.ToDecimal(txtPPIRChairPaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = IRchairPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;

            if (txtPPIRChairEstimatedPayDate.Text != null || txtPPIRChairEstimatedPayDate.Text != " " || txtPPIRChairEstimatedPayDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPIRChairEstimatedPayDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            //IR Reviewer2
            if (dropPPIRReviewer2.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_ISN"].DefaultValue = dropPPIRReviewer2.SelectedValue;

            if (paymentdropIRReviewer2PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = paymentdropIRReviewer2PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPIRReviewer2PayrollForm.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_1099"].DefaultValue = cbPPIRReviewer21099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_1042_S"].DefaultValue = cbPPIRReviewer21042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_W_9"].DefaultValue = cbPPIRReviewer2W9.Checked.ToString();


            if (txtPPIRReviewer2PaymentAmount.Text != " ")
            {
                if (txtPPIRReviewer2PaymentAmount.Text != "")
                {
                    decimal IRReviewer2PaymentAmount = Convert.ToDecimal(txtPPIRReviewer2PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = IRReviewer2PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;

            if (txtPPIRReviewer2EstimatedPaymentDate.Text != null || txtPPIRReviewer2EstimatedPaymentDate.Text != " " || txtPPIRReviewer2EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPIRReviewer2EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            //IR Reviewer3
            if (dropPPIRReviewer3.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_ISN"].DefaultValue = dropPPIRReviewer3.SelectedValue;

            if (dropPPIRReviwer3PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = dropPPIRReviwer3PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPIRReviwer3PayrollForm.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_1099"].DefaultValue = cbPPIRReviewer31099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_1042_S"].DefaultValue = cbPPIRReviewer31042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_W_9"].DefaultValue = cbPPIRReviewer3W9.Checked.ToString();

            if (txtPPIRReviewer3PaymentAmount.Text != " ")
            {
                if (txtPPIRReviewer2PaymentAmount.Text != "")
                {
                    decimal IRReviewer3PaymentAmount = Convert.ToDecimal(txtPPIRReviewer3PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = IRReviewer3PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;


            if (txtPPIRReviewer3EstimatedPaymentDate.Text != null || txtPPIRReviewer3EstimatedPaymentDate.Text != " " || txtPPIRReviewer3EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPIRReviewer3EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            // OR

            if (txtPPORStartDate.Text != null || txtPPORStartDate.Text != " " || txtPPORStartDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_START_DATE"].DefaultValue = txtPPORStartDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_START_DATE"].DefaultValue = null;

            if (txtPPOREndDate.Text != null || txtPPOREndDate.Text != " " || txtPPOREndDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_END_DATE"].DefaultValue = txtPPOREndDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_END_DATE"].DefaultValue = null;

            // OR Chair
            if (dropPPORChair.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_ISN"].DefaultValue = dropPPORChair.SelectedValue;

            if (dropPPORChairPaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = dropPPORChairPaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPORChairPayroll.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_1099"].DefaultValue = cbPPORChair1099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_1042_S"].DefaultValue = cbPPORChair1042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_W_9"].DefaultValue = cbPPORChairW9.Checked.ToString();

            if (txtPPIRReviewer3PaymentAmount.Text != " ")
            {
                if (txtPPIRReviewer3PaymentAmount.Text != "")
                {
                    decimal ORchairPaymentAmount = Convert.ToDecimal(txtORChairPaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = ORchairPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;

            

            if (txtORChairEstimatedPaymentDate.Text != null || txtORChairEstimatedPaymentDate.Text != " " || txtORChairEstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtORChairEstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            //OR Reviewer2
            if (dropPPORReviewer2.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_ISN"].DefaultValue = dropPPORReviewer2.SelectedValue;

            if (dropPPORReviewer2PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = dropPPORReviewer2PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPORReviewer2Payroll.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_1099"].DefaultValue = cbPPORReviewer21099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_1042_S"].DefaultValue = cbPPORReviewer21042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_W_9"].DefaultValue = cbPPORReviewer2W9.Checked.ToString();

            if (txtPPORReviewer2PaymentAmount.Text != " ")
            {
                if (txtPPORReviewer2PaymentAmount.Text != "")
                {
                    decimal ORReviewer2PaymentAmount = Convert.ToDecimal(txtPPORReviewer2PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = ORReviewer2PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;

            

            if (txtPPORReviewer2EstimatedPaymentDate.Text != null || txtPPORReviewer2EstimatedPaymentDate.Text != " " || txtPPORReviewer2EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPORReviewer2EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            //OR Reviewer3
            if (dropPPORReviewer3.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_ISN"].DefaultValue = dropPPORReviewer3.SelectedValue;

            if (dropPPORReviewer3PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = dropPPORReviewer3PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPORReviewer3Payroll.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_1099"].DefaultValue = cbPPORReviewer31099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_1042_S"].DefaultValue = cbPPORReviewer31042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_W_9"].DefaultValue = cbPPORReviewer3W9.Checked.ToString();

            if (txtPPORReviewer3PaymentAmount.Text != " ")
            {
                if (txtPPORReviewer2PaymentAmount.Text != "")
                {
                    decimal ORReviewer3PaymentAmount = Convert.ToDecimal(txtPPORReviewer3PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = ORReviewer3PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;


            if (txtPPORReviewer3EstimatedPaymentDate.Text != null || txtPPORReviewer3EstimatedPaymentDate.Text != " " || txtPPORReviewer3EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPORReviewer3EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["OR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            SqlPaymentAndPaperWorkHistory.UpdateParameters["NOTE"].DefaultValue = txtPPNote.Text.ToUpper().Trim();

       

            SqlPaymentAndPaperWorkHistory.UpdateParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlPaymentAndPaperWorkHistory.UpdateParameters["UPDATED_DATE"].DefaultValue = CurrentDate;

            try
            {
                SqlPaymentAndPaperWorkHistory.Update();
                btnPPCancel_Click(null, null);
                System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                strbuilder.Append(@"<script type='text/javascript'>");
                strbuilder.Append("alert('Course Updated Successfully');");
                strbuilder.Append("$('#paymentModal').modal('show');");
                strbuilder.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", strbuilder.ToString(), false);
                gvCourseDetail.DataBind();
                upCourseDetail.Update();

            }
            catch
            {
                paymentError.Text = "An error has occured in updation of Record";
                paymentError.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#paymentModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
            }

        }
        else
        {
            string UserName = (string)Session["commonname"];
            string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            if (Convert.ToInt32(CoursePaymentisn.Value) == 0)
                SqlPaymentAndPaperWorkHistory.InsertParameters["COURSE_ISN"].DefaultValue = (string)Session["CP"];
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["COURSE_ISN"].DefaultValue = CoursePaymentisn.Value;
            SqlPaymentAndPaperWorkHistory.InsertParameters["STATEMENT_OF_INTENT"].DefaultValue = cbPPSofI.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["PROCEDURES_AND_AGREEMENT"].DefaultValue = cbPPPA.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["SERVICE_CONTRACT"].DefaultValue = cbPPSC.Checked.ToString();

            if (txtPPDeveloperPayment1.Text != " ")
            {
                if (txtPPDeveloperPayment1.Text != "")
                {
                    decimal firstPaymentAmount = Convert.ToDecimal(txtPPDeveloperPayment1.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["FIRST_PAYMENT_AMOUNT"].DefaultValue = firstPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["FIRST_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["FIRST_PAYMENT_AMOUNT"].DefaultValue = null;

            if (txtPPDeveloperEstimatedPayDate1.Text != null || txtPPDeveloperEstimatedPayDate1.Text != " " || txtPPDeveloperEstimatedPayDate1.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["FIRST_PAYMENT_DATE"].DefaultValue = txtPPDeveloperEstimatedPayDate1.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["FIRST_PAYMENT_DATE"].DefaultValue = null;
            
            if (txtPPDeveloperPayment2.Text != " ")
            {
                if (txtPPDeveloperPayment2.Text != "")
                {
                    decimal secondPaymentAmount = Convert.ToDecimal(txtPPDeveloperPayment2.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["SECOND_PAYMENT_AMOUNT"].DefaultValue = secondPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["SECOND_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["SECOND_PAYMENT_AMOUNT"].DefaultValue = null;

            if (txtPPDeveloperEstimatedPayDate2.Text != null || txtPPDeveloperEstimatedPayDate2.Text != " " || txtPPDeveloperEstimatedPayDate2.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["SECOND_PAYMENT_DATE"].DefaultValue = txtPPDeveloperEstimatedPayDate1.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["SECOND_PAYMENT_DATE"].DefaultValue = null;

            // IR

            if (txtPPIRStartDate.Text != null || txtPPIRStartDate.Text != " " || txtPPIRStartDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_START_DATE"].DefaultValue = txtPPIRStartDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_START_DATE"].DefaultValue = null;

            if (txtPPIREndDate.Text != null || txtPPIREndDate.Text != " " || txtPPIREndDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_END_DATE"].DefaultValue = txtPPIREndDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_END_DATE"].DefaultValue = null;

            // IR Chair
            if (dropPPIRChair.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_ISN"].DefaultValue = dropPPIRChair.SelectedValue;

            if (paymentdropIRChairPaperwork.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = paymentdropIRChairPaperwork.SelectedValue;

            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPIRChairSupplementPayrollForm.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_1099"].DefaultValue = cbPPIRChair1099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_1042_S"].DefaultValue = cbPPIRChair1042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_W_9"].DefaultValue = cbPPIRChairW9.Checked.ToString();


            if (txtPPIRChairPaymentAmount.Text != " ")
            {
                if (txtPPIRChairPaymentAmount.Text != "")
                {
                    decimal IRchairPaymentAmount = Convert.ToDecimal(txtPPIRChairPaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = IRchairPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;
            
            if (txtPPIRChairEstimatedPayDate.Text != null || txtPPIRChairEstimatedPayDate.Text != " " || txtPPIRChairEstimatedPayDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPIRChairEstimatedPayDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

          
            //IR Reviewer2
            if (dropPPIRReviewer2.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_ISN"].DefaultValue = dropPPIRReviewer2.SelectedValue;

            if (paymentdropIRReviewer2PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = paymentdropIRReviewer2PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPIRReviewer2PayrollForm.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_1099"].DefaultValue = cbPPIRReviewer21099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_1042_S"].DefaultValue = cbPPIRReviewer21042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_W_9"].DefaultValue = cbPPIRReviewer2W9.Checked.ToString();

            if (txtPPIRReviewer2PaymentAmount.Text != " ")
            {
                if (txtPPIRReviewer2PaymentAmount.Text != "")
                {
                    decimal IRReviewer2PaymentAmount = Convert.ToDecimal(txtPPIRReviewer2PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = IRReviewer2PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.UpdateParameters["IR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;

            if (txtPPIRReviewer2EstimatedPaymentDate.Text != null || txtPPIRReviewer2EstimatedPaymentDate.Text != " " || txtPPIRReviewer2EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPIRReviewer2EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;


            //IR Reviewer3
            if (dropPPIRReviewer3.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_ISN"].DefaultValue = dropPPIRReviewer3.SelectedValue;

            if (dropPPIRReviwer3PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = dropPPIRReviwer3PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPIRReviwer3PayrollForm.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_1099"].DefaultValue = cbPPIRReviewer31099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_1042_S"].DefaultValue = cbPPIRReviewer31042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_W_9"].DefaultValue = cbPPIRReviewer3W9.Checked.ToString();

            if (txtPPIRReviewer3PaymentAmount.Text != " ")
            {
                if (txtPPIRReviewer3PaymentAmount.Text != "")
                {
                    decimal IRReviewer3PaymentAmount = Convert.ToDecimal(txtPPIRReviewer3PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = IRReviewer3PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;

            
            if (txtPPIRReviewer3EstimatedPaymentDate.Text != null || txtPPIRReviewer3EstimatedPaymentDate.Text != " " || txtPPIRReviewer3EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPIRReviewer3EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["IR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;


            // OR

            if (txtPPORStartDate.Text != null || txtPPORStartDate.Text != " " || txtPPORStartDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_START_DATE"].DefaultValue = txtPPORStartDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_START_DATE"].DefaultValue = null;

            if (txtPPOREndDate.Text != null || txtPPOREndDate.Text != " " || txtPPOREndDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_END_DATE"].DefaultValue = txtPPOREndDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_END_DATE"].DefaultValue = null;

            // OR Chair
            if (dropPPORChair.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_ISN"].DefaultValue = dropPPORChair.SelectedValue;

            if (dropPPORChairPaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_CONTRACT_TYPE_ISN"].DefaultValue = dropPPORChairPaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPORChairPayroll.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_1099"].DefaultValue = cbPPORChair1099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_1042_S"].DefaultValue = cbPPORChair1042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_W_9"].DefaultValue = cbPPORChairW9.Checked.ToString();


            if (txtORChairPaymentAmount.Text != " ")
            {
                if (txtORChairPaymentAmount.Text != "")
                {
                    decimal ORchairPaymentAmount = Convert.ToDecimal(txtORChairPaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = ORchairPaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_PAYMENT_AMOUNT"].DefaultValue = null;
            
            if (txtORChairEstimatedPaymentDate.Text != null || txtORChairEstimatedPaymentDate.Text != " " || txtORChairEstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtORChairEstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_CHAIR_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;


            //OR Reviewer2
            if (dropPPORReviewer2.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_ISN"].DefaultValue = dropPPORReviewer2.SelectedValue;

            if (dropPPORReviewer2PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_CONTRACT_TYPE_ISN"].DefaultValue = dropPPORReviewer2PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPORReviewer2Payroll.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_1099"].DefaultValue = cbPPORReviewer21099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_1042_S"].DefaultValue = cbPPORReviewer21042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_W_9"].DefaultValue = cbPPORReviewer2W9.Checked.ToString();


            if (txtPPORReviewer2PaymentAmount.Text != " ")
            {
                if (txtPPORReviewer2PaymentAmount.Text != "")
                {
                    decimal ORReviewer2PaymentAmount = Convert.ToDecimal(txtPPORReviewer2PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = ORReviewer2PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_PAYMENT_AMOUNT"].DefaultValue = null;

            

            if (txtPPORReviewer2EstimatedPaymentDate.Text != null || txtPPORReviewer2EstimatedPaymentDate.Text != " " || txtPPORReviewer2EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPORReviewer2EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER2_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;


            //OR Reviewer3
            if (dropPPORReviewer3.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_ISN"].DefaultValue = dropPPORReviewer3.SelectedValue;

            if (dropPPORReviewer3PaperworkType.SelectedValue == "-1")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = null;
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_CONTRACT_TYPE_ISN"].DefaultValue = dropPPORReviewer3PaperworkType.SelectedValue;

            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_SUPPLEMENT_PAYROLL_FORM"].DefaultValue = cbPPORReviewer3Payroll.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_1099"].DefaultValue = cbPPORReviewer31099.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_1042_S"].DefaultValue = cbPPORReviewer31042.Checked.ToString();
            SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_W_9"].DefaultValue = cbPPORReviewer3W9.Checked.ToString();


            if (txtPPORReviewer3PaymentAmount.Text != " ")
            {
                if (txtPPORReviewer3PaymentAmount.Text != "")
                {
                    decimal ORReviewer3PaymentAmount = Convert.ToDecimal(txtPPORReviewer3PaymentAmount.Text, System.Globalization.CultureInfo.CurrentCulture);
                    SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = ORReviewer3PaymentAmount.ToString();
                }
                else
                    SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;
            }
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_PAYMENT_AMOUNT"].DefaultValue = null;

            
            if (txtPPORReviewer3EstimatedPaymentDate.Text != null || txtPPORReviewer3EstimatedPaymentDate.Text != " " || txtPPORReviewer3EstimatedPaymentDate.Text != "&nbsp;")
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = txtPPORReviewer3EstimatedPaymentDate.Text.ToUpper().Trim();
            else
                SqlPaymentAndPaperWorkHistory.InsertParameters["OR_REVIEWER3_ESTIMATED_PAYMENT_DATE"].DefaultValue = null;

            SqlPaymentAndPaperWorkHistory.InsertParameters["NOTE"].DefaultValue = txtPPNote.Text.ToUpper().Trim();

            SqlPaymentAndPaperWorkHistory.InsertParameters["ADDED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlPaymentAndPaperWorkHistory.InsertParameters["ADDED_DATE"].DefaultValue = CurrentDate;

            SqlPaymentAndPaperWorkHistory.InsertParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlPaymentAndPaperWorkHistory.InsertParameters["UPDATED_DATE"].DefaultValue = CurrentDate;

            try
            {
                SqlPaymentAndPaperWorkHistory.Insert();
                btnPPCancel_Click(null, null);
                System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                strbuilder.Append(@"<script type='text/javascript'>");
                strbuilder.Append("alert('Course Updated Successfully');");
                strbuilder.Append("$('#paymentModal').modal('show');");
                strbuilder.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", strbuilder.ToString(), false);
                gvCourseDetail.DataBind();
                upCourseDetail.Update();

            }
            catch
            {
                paymentError.Text = "An error has occured in updation of Record";
                paymentError.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#paymentModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
            }
    
    }

    }
    protected void btnPPCancel_Click(object sender, EventArgs e)
    {
        editPanel.Visible = true; savePanel.Visible = false; addedandupdatedPanel.Visible = true;
        cbPPSofI.Enabled = false; cbPPSofI.CssClass = "none"; cbPPPA.Enabled = false; cbPPPA.CssClass = "none"; cbPPSC.Enabled = false; cbPPSC.CssClass = "none";
        txtPPDeveloperPayment1.Enabled = false; txtPPDeveloperPayment1.ReadOnly = true; txtPPDeveloperPayment1.CssClass = "none"; txtPPDeveloperPayment1.BackColor = System.Drawing.Color.Transparent; txtPPDeveloperPayment1.BorderStyle = BorderStyle.None;
        txtPPDeveloperEstimatedPayDate1.Enabled = false; txtPPDeveloperEstimatedPayDate1.ReadOnly = true; txtPPDeveloperEstimatedPayDate1.CssClass = "none"; txtPPDeveloperEstimatedPayDate1.BackColor = System.Drawing.Color.Transparent; txtPPDeveloperEstimatedPayDate1.BorderStyle = BorderStyle.None;
        imgPPDeveloperEstimatedPayDate1.Visible = false; cePPDeveloperEstimatedPayDate1.Enabled = false;
        txtPPDeveloperPayment2.Enabled = false; txtPPDeveloperPayment2.ReadOnly = true; txtPPDeveloperPayment2.CssClass = "none"; txtPPDeveloperPayment2.BackColor = System.Drawing.Color.Transparent; txtPPDeveloperPayment2.BorderStyle = BorderStyle.None;
        txtPPDeveloperEstimatedPayDate2.Enabled = false; txtPPDeveloperEstimatedPayDate2.ReadOnly = true; txtPPDeveloperEstimatedPayDate2.CssClass = "none"; txtPPDeveloperEstimatedPayDate2.BackColor = System.Drawing.Color.Transparent; txtPPDeveloperEstimatedPayDate2.BorderStyle = BorderStyle.None;
        imgPPDeveloperEstimatedPayDate2.Visible = false; cePPDeveloperEstimatedPayDate2.Enabled = false;

        // Internal Reviewer
        txtPPIRStartDate.Enabled = false; txtPPIRStartDate.ReadOnly = true; txtPPIRStartDate.CssClass = "none"; txtPPIRStartDate.BackColor = System.Drawing.Color.Transparent; txtPPIRStartDate.BorderStyle = BorderStyle.None;
        imgPPIRStartDate.Visible = false; cePPIRStartDate.Enabled = false;
        txtPPIREndDate.Enabled = false; txtPPIREndDate.ReadOnly = true; txtPPIREndDate.CssClass = "none"; txtPPIREndDate.BackColor = System.Drawing.Color.Transparent; txtPPIREndDate.BorderStyle = BorderStyle.None;
        imgPPIREndDate.Visible = false; cePPIREndDate.Enabled = false;
        // IR Chair
        dropPPIRChair.Enabled = false; dropPPIRChair.CssClass = "none"; dropPPIRChair.BorderStyle = BorderStyle.None;
        paymentdropIRChairPaperwork.Enabled = false; paymentdropIRChairPaperwork.CssClass = "none"; paymentdropIRChairPaperwork.BorderStyle = BorderStyle.None;
        cbPPIRChairSupplementPayrollForm.Enabled = false; cbPPIRChairSupplementPayrollForm.CssClass = "none"; cbPPIRChairSupplementPayrollForm.BorderStyle = BorderStyle.None;
        cbPPIRChair1099.Enabled = false; cbPPIRChair1099.CssClass = "none"; cbPPIRChair1099.BorderStyle = BorderStyle.None;
        cbPPIRChair1042.Enabled = false; cbPPIRChair1042.CssClass = "none"; cbPPIRChair1042.BorderStyle = BorderStyle.None;
        cbPPIRChairW9.Enabled = false; cbPPIRChairW9.CssClass = "none"; cbPPIRChairW9.BorderStyle = BorderStyle.None;
        txtPPIRChairEstimatedPayDate.Enabled = false; txtPPIRChairEstimatedPayDate.ReadOnly = true; txtPPIRChairEstimatedPayDate.CssClass = "none"; txtPPIRChairEstimatedPayDate.BackColor = System.Drawing.Color.Transparent; txtPPIRChairEstimatedPayDate.BorderStyle = BorderStyle.None;
        imgPPIRChairEstimatedPayDate.Visible = false; cePPIRChairEstimatedPayDate.Enabled = false;
        txtPPIRChairPaymentAmount.Enabled = false; txtPPIRChairPaymentAmount.ReadOnly = true; txtPPIRChairPaymentAmount.CssClass = "none"; txtPPIRChairPaymentAmount.BackColor = System.Drawing.Color.Transparent; txtPPIRChairPaymentAmount.BorderStyle = BorderStyle.None;
        // IR Reviewer 2
        dropPPIRReviewer2.Enabled = false; dropPPIRReviewer2.CssClass = "none"; dropPPIRReviewer2.BorderStyle = BorderStyle.None;
        paymentdropIRReviewer2PaperworkType.Enabled = false; paymentdropIRReviewer2PaperworkType.CssClass = "none"; paymentdropIRReviewer2PaperworkType.BorderStyle = BorderStyle.None;
        cbPPIRReviewer2PayrollForm.Enabled = false; cbPPIRReviewer2PayrollForm.CssClass = "None"; cbPPIRReviewer2PayrollForm.BorderStyle = BorderStyle.None;
        cbPPIRReviewer21099.Enabled = false; cbPPIRReviewer21099.CssClass = "none"; cbPPIRReviewer21099.BorderStyle = BorderStyle.None;
        cbPPIRReviewer21042.Enabled = false; cbPPIRReviewer21042.CssClass = "none"; cbPPIRReviewer21042.BorderStyle = BorderStyle.None;
        cbPPIRReviewer2W9.Enabled = false; cbPPIRReviewer2W9.CssClass = "none"; cbPPIRReviewer2W9.BorderStyle = BorderStyle.None;
        txtPPIRReviewer2EstimatedPaymentDate.Enabled = false; txtPPIRReviewer2EstimatedPaymentDate.ReadOnly = true; txtPPIRReviewer2EstimatedPaymentDate.CssClass = "none"; txtPPIRReviewer2EstimatedPaymentDate.BackColor = System.Drawing.Color.Transparent; txtPPIRReviewer2EstimatedPaymentDate.BorderStyle = BorderStyle.None;
        imgPPIRReviewer2EstimatedPaymentDate.Visible = false; cePPIRReviewer2EstimatedPaymentDate.Enabled = false;
        txtPPIRReviewer2PaymentAmount.Enabled = false; txtPPIRReviewer2PaymentAmount.ReadOnly = true; txtPPIRReviewer2PaymentAmount.CssClass = "none"; txtPPIRReviewer2PaymentAmount.BackColor = System.Drawing.Color.Transparent; txtPPIRReviewer2PaymentAmount.BorderStyle = BorderStyle.None;
        // IR Reviewer 3
        dropPPIRReviewer3.Enabled = false; dropPPIRReviewer3.CssClass = "none"; dropPPIRReviewer3.BorderStyle = BorderStyle.None;
        dropPPIRReviwer3PaperworkType.Enabled = false; dropPPIRReviwer3PaperworkType.CssClass = "none"; dropPPIRReviwer3PaperworkType.BorderStyle = BorderStyle.None;
        cbPPIRReviwer3PayrollForm.Enabled = false; cbPPIRReviwer3PayrollForm.CssClass = "none"; cbPPIRReviwer3PayrollForm.BorderStyle = BorderStyle.None;
        cbPPIRReviewer31099.Enabled = false; cbPPIRReviewer31099.CssClass = "none"; cbPPIRReviewer31099.BorderStyle = BorderStyle.None;
        cbPPIRReviewer31042.Enabled = false; cbPPIRReviewer31042.CssClass = "none"; cbPPIRReviewer31042.BorderStyle = BorderStyle.None;
        cbPPIRReviewer3W9.Enabled = false; cbPPIRReviewer3W9.CssClass = "none"; cbPPIRReviewer3W9.BorderStyle = BorderStyle.None;
        txtPPIRReviewer3EstimatedPaymentDate.Enabled = false; txtPPIRReviewer3EstimatedPaymentDate.ReadOnly = true; txtPPIRReviewer3EstimatedPaymentDate.CssClass = "none"; txtPPIRReviewer3EstimatedPaymentDate.BackColor = System.Drawing.Color.Transparent; txtPPIRReviewer3EstimatedPaymentDate.BorderStyle = BorderStyle.None;
        imgPPIRReviewer3EstimatedPaymentDate.Visible = false; cePPIRReviewer3EstimatedPaymentDate.Enabled = false;
        txtPPIRReviewer3PaymentAmount.Enabled = false; txtPPIRReviewer3PaymentAmount.ReadOnly = true; txtPPIRReviewer3PaymentAmount.CssClass = "none"; txtPPIRReviewer3PaymentAmount.BackColor = System.Drawing.Color.Transparent; txtPPIRReviewer3PaymentAmount.BorderStyle = BorderStyle.None;

        // Official Reviewer
        txtPPORStartDate.Enabled = false; txtPPORStartDate.ReadOnly = true; txtPPORStartDate.CssClass = "none"; txtPPORStartDate.BackColor = System.Drawing.Color.Transparent; txtPPORStartDate.BorderStyle = BorderStyle.None;
        imgPPORStartDate.Visible = false; cePPORStartDate.Enabled = false;
        txtPPOREndDate.Enabled = false; txtPPOREndDate.ReadOnly = true; txtPPOREndDate.CssClass = "none"; txtPPOREndDate.BackColor = System.Drawing.Color.Transparent; txtPPOREndDate.BorderStyle = BorderStyle.None;
        imgPPOREndDate.Visible = false; cePPOREndDate.Enabled = false;
        // OR Chair
        dropPPORChair.Enabled = false; dropPPORChair.CssClass = "none"; dropPPORChair.BorderStyle = BorderStyle.None;
        dropPPORChairPaperworkType.Enabled = false; dropPPORChairPaperworkType.CssClass = "none"; dropPPORChairPaperworkType.BorderStyle = BorderStyle.None;
        cbPPORChairPayroll.Enabled = false; cbPPORChairPayroll.CssClass = "none"; cbPPORChairPayroll.BorderStyle = BorderStyle.None;
        cbPPORChair1099.Enabled = false; cbPPORChair1099.CssClass = "none"; cbPPORChair1099.BorderStyle = BorderStyle.None;
        cbPPORChair1042.Enabled = false; cbPPORChair1042.CssClass = "none"; cbPPORChair1042.BorderStyle = BorderStyle.None;
        cbPPORChairW9.Enabled = false; cbPPORChairW9.CssClass = "none"; cbPPORChairW9.BorderStyle = BorderStyle.None;
        txtORChairEstimatedPaymentDate.Enabled = false; txtORChairEstimatedPaymentDate.ReadOnly = true; txtORChairEstimatedPaymentDate.CssClass = "none"; txtORChairEstimatedPaymentDate.BackColor = System.Drawing.Color.Transparent; txtORChairEstimatedPaymentDate.BorderStyle = BorderStyle.None;
        imgORChairEstimatedPaymentDate.Visible = false; ceORChairEstimatedPaymentDate.Enabled = false;
        txtORChairPaymentAmount.Enabled = false; txtORChairPaymentAmount.ReadOnly = true; txtORChairPaymentAmount.CssClass = "none"; txtORChairPaymentAmount.BackColor = System.Drawing.Color.Transparent; txtORChairPaymentAmount.BorderStyle = BorderStyle.None;
        // OR Reviewer 2
        dropPPORReviewer2.Enabled = false; dropPPORReviewer2.CssClass = "none"; dropPPORReviewer2.BorderStyle = BorderStyle.None;
        dropPPORReviewer2PaperworkType.Enabled = false; dropPPORReviewer2PaperworkType.CssClass = "none"; dropPPORReviewer2PaperworkType.BorderStyle = BorderStyle.None;
        cbPPORReviewer2Payroll.Enabled = false; cbPPORReviewer2Payroll.CssClass = "none"; cbPPORReviewer2Payroll.BorderStyle = BorderStyle.None;
        cbPPORReviewer21099.Enabled = false; cbPPORReviewer21099.CssClass = "none"; cbPPORReviewer21099.BorderStyle = BorderStyle.None;
        cbPPORReviewer21042.Enabled = false; cbPPORReviewer21042.CssClass = "none"; cbPPORReviewer21042.BorderStyle = BorderStyle.None;
        cbPPORReviewer2W9.Enabled = false; cbPPORReviewer2W9.CssClass = "none"; cbPPORReviewer2W9.BorderStyle = BorderStyle.None;
        txtPPORReviewer2EstimatedPaymentDate.Enabled = false; txtPPORReviewer2EstimatedPaymentDate.ReadOnly = true; txtPPORReviewer2EstimatedPaymentDate.CssClass = "none"; txtPPORReviewer2EstimatedPaymentDate.BackColor = System.Drawing.Color.Transparent; txtPPORReviewer2EstimatedPaymentDate.BorderStyle = BorderStyle.None;
        imgPPORReviewer2EstimatedPaymentDate.Visible = false; cePPORReviewer2EstimatedPaymentDate.Enabled = false;
        txtPPORReviewer2PaymentAmount.Enabled = false; txtPPORReviewer2PaymentAmount.ReadOnly = true; txtPPORReviewer2PaymentAmount.CssClass = "none"; txtPPORReviewer2PaymentAmount.BackColor = System.Drawing.Color.Transparent; txtPPORReviewer2PaymentAmount.BorderStyle = BorderStyle.None;
        // OR Reviewer 3
        dropPPORReviewer3.Enabled = false; dropPPORReviewer3.CssClass = "none"; dropPPORReviewer3.BorderStyle = BorderStyle.None;
        dropPPORReviewer3PaperworkType.Enabled = false; dropPPORReviewer3PaperworkType.CssClass = "none"; dropPPORReviewer3PaperworkType.BorderStyle = BorderStyle.None;
        cbPPORReviewer3Payroll.Enabled = false; cbPPORReviewer3Payroll.CssClass = "none"; cbPPORReviewer3Payroll.BorderStyle = BorderStyle.None;
        cbPPORReviewer31099.Enabled = false; cbPPORReviewer31099.CssClass = "none"; cbPPORReviewer31099.BorderStyle = BorderStyle.None;
        cbPPORReviewer31042.Enabled = false; cbPPORReviewer31042.CssClass = "none"; cbPPORReviewer31042.BorderStyle = BorderStyle.None;
        cbPPORReviewer3W9.Enabled = false; cbPPORReviewer3W9.CssClass = "none"; cbPPORReviewer3W9.BorderStyle = BorderStyle.None;
        txtPPORReviewer3EstimatedPaymentDate.Enabled = false; txtPPORReviewer3EstimatedPaymentDate.ReadOnly = true; txtPPORReviewer3EstimatedPaymentDate.CssClass = "none"; txtPPORReviewer3EstimatedPaymentDate.BackColor = System.Drawing.Color.Transparent; txtPPORReviewer3EstimatedPaymentDate.BorderStyle = BorderStyle.None;
        imgPPORReviewer3EstimatedPaymentDate.Visible = false; cePPORReviewer3EstimatedPaymentDate.Enabled = false;
        txtPPORReviewer3PaymentAmount.Enabled = false; txtPPORReviewer3PaymentAmount.ReadOnly = true; txtPPORReviewer3PaymentAmount.CssClass = "none"; txtPPORReviewer3PaymentAmount.BackColor = System.Drawing.Color.Transparent; txtPPORReviewer3PaymentAmount.BorderStyle = BorderStyle.None;

        //Note
        txtPPNote.Enabled = false; txtPPNote.ReadOnly = true; txtPPNote.CssClass = "none"; txtPPNote.BackColor = System.Drawing.Color.Transparent; txtPPNote.BorderStyle = BorderStyle.None;
    
    }


    protected void btnaddcheck_Click(object sender, EventArgs e)
    {
        if (hiddenField1.Value == "true")
        {
            string UserName = (string)Session["commonname"];
            string CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            SqlCourseDetailspecific.InsertParameters["COURSE_TYPE_ISN"].DefaultValue = adddropCourseType.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["DEVELOPMENT_STATUS_ISN"].DefaultValue = adddropDevelopmentStatus.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["COURSE_SUBJECT"].DefaultValue = txtaddCourseSubject.Text.ToUpper().Trim();
            SqlCourseDetailspecific.InsertParameters["COURSE_NUMBER"].DefaultValue = txtaddCourseNumber.Text.ToUpper().Trim();
            SqlCourseDetailspecific.InsertParameters["COURSE_TITLE"].DefaultValue = txtaddCourseTitle.Text.ToUpper().Trim();
            SqlCourseDetailspecific.InsertParameters["COURSE_STATUS"].DefaultValue = rbaddCourseEnabled.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["SEMESTER_TAUGHT_ISN"].DefaultValue = adddropSemesterTaugt.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["YEAR_TAUGHT"].DefaultValue = txtaddYearTaught.Text.Trim();
            SqlCourseDetailspecific.InsertParameters["DEVELOPER_ISN"].DefaultValue = adddropDeveloper.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["COORDINATOR_ISN"].DefaultValue = adddropCoordinator.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["COLL_CODE_ISN"].DefaultValue = adddropCollege.SelectedValue;
            SqlCourseDetailspecific.InsertParameters["DEGREE_PROGRAM_CODE_ISN"].DefaultValue = adddropDegree.SelectedValue;

            if (txtaddReviewStartDate.Text != null || txtaddReviewStartDate.Text != " ")
                SqlCourseDetailspecific.InsertParameters["DATE_TO_START_REVIEW"].DefaultValue = txtaddReviewStartDate.Text;
            else
                SqlCourseDetailspecific.InsertParameters["DATE_TO_START_REVIEW"].DefaultValue = null;

            if (txtaddQMCertifiedDate.Text != null || txtaddQMCertifiedDate.Text != " ")
                SqlCourseDetailspecific.InsertParameters["QM_CERTIFIED_DATE"].DefaultValue = txtaddQMCertifiedDate.Text;
            else
                SqlCourseDetailspecific.InsertParameters["QM_CERTIFIED_DATE"].DefaultValue = null;

            SqlCourseDetailspecific.InsertParameters["NOTE"].DefaultValue = txtaddNote.Text.ToUpper().Trim();

            SqlCourseDetailspecific.InsertParameters["ADDED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlCourseDetailspecific.InsertParameters["ADDED_DATE"].DefaultValue = CurrentDate;

            SqlCourseDetailspecific.InsertParameters["UPDATED_BY"].DefaultValue = UserName.ToUpper().Trim();

            SqlCourseDetailspecific.InsertParameters["UPDATED_DATE"].DefaultValue = CurrentDate;

            try
            {
                SqlCourseDetailspecific.Insert();
                SqlCourseSearch.DataBind();
                adddropCourseType.SelectedIndex = -1;
                adddropDevelopmentStatus.SelectedIndex = -1;
                txtaddCourseSubject.Text = string.Empty;
                txtaddCourseNumber.Text = string.Empty;
                txtaddCourseTitle.Text = string.Empty;
                rbaddCourseEnabled.SelectedIndex = -1;
                adddropSemesterTaugt.SelectedIndex = -1;
                txtaddYearTaught.Text = string.Empty;
                adddropDeveloper.SelectedIndex = -1;
                adddropCoordinator.SelectedIndex = -1;
                adddropCollege.SelectedIndex = -1;
                txtaddReviewStartDate.Text = string.Empty;
                txtaddQMCertifiedDate.Text = string.Empty;
                txtaddNote.Text = string.Empty;
                System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                strbuilder.Append(@"<script type='text/javascript'>");
                strbuilder.Append("alert('Course Updated Successfully');");
                strbuilder.Append("$('#addModal').modal('hide');");
                strbuilder.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "addHideModalScript", strbuilder.ToString(), false);
                gvCourseDetail.DataBind();
                upCourseDetail.Update();

            }
            catch
            {
                editError.Text = "An error has occured in updation of Record";
                editError.ForeColor = System.Drawing.Color.Red;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
            }


        }
        else
        {
            adddropCourseType.SelectedIndex = -1;
            adddropDevelopmentStatus.SelectedIndex = -1;
            txtaddCourseSubject.Text = string.Empty;
            txtaddCourseNumber.Text = string.Empty;
            txtaddCourseTitle.Text = string.Empty;
            rbaddCourseEnabled.SelectedIndex = -1;
            adddropSemesterTaugt.SelectedIndex = -1;
            txtaddYearTaught.Text = string.Empty;
            adddropDeveloper.SelectedIndex = -1;
            adddropCoordinator.SelectedIndex = -1;
            adddropCollege.SelectedIndex = -1;
            txtaddReviewStartDate.Text = string.Empty;
            txtaddQMCertifiedDate.Text = string.Empty;
            txtaddNote.Text = string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }
    }
}