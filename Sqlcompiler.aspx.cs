using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Sqlcompiler : System.Web.UI.Page
{
    SqlConnection sqlcn;
    SqlCommand sqlcmd;
    SqlDataAdapter sqlda;
    DataSet ds;

    static string ddLQry; 
    protected void Page_Load(object sender, EventArgs e)
    {
        tbxrespane.Text = null;
        try
        {
            string s = ConfigurationManager.ConnectionStrings["rvtechdbConnectionString"].ToString();
            sqlcn = new SqlConnection(s);

        }
        catch(Exception ex)
        {
            tbxrespane.Text = ex.Message;
        }
    }

   
    protected void gvresultpane_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvresultpane_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvresultpane.PageIndex = e.NewPageIndex;
        uRefreshGridView();
    }
    protected void btnrun_Click(object sender, EventArgs e)
    {
        uRunQuery();
    }
    public void uRunQuery()
    {
        tbxrespane.Text = null;
        gvresultpane.EmptyDataText = null;
        gvresultpane.DataBind();

        string qry = tbxquerypane.Text;
        try
        {
            if(qry.ToLower().StartsWith("select"))
            {
                ddLQry = qry;
                uRefreshGridView();
                return;
            }
            sqlcn.Open();
            sqlcmd = new SqlCommand(qry, sqlcn);

            int i = sqlcmd.ExecuteNonQuery();
            if(i>0)
            {
                tbxrespane.Text = i + " Row(s) Affected";
            }
            else
            {
                tbxrespane.Text = "Command(s) Complete Successfully";
            }
            sqlcn.Close();
        }
        catch(Exception e)
        {
            tbxrespane.Text = e.Message;
        }
    }
    public void uRefreshGridView()
    {
        tbxrespane.Text = null;
        gvresultpane.DataSource = null;
        gvresultpane.DataBind();
        try
        {
            sqlcn.Open();
            sqlcmd = new SqlCommand(ddLQry, sqlcn);
            sqlda = new SqlDataAdapter(sqlcmd);

            ds = new DataSet();
            sqlda.Fill(ds);
            sqlcn.Close();

            gvresultpane.DataSource = ds;
            gvresultpane.DataBind();
            tbxrespane.Text= "Command(s) Complete Successfully";
        }
        catch(Exception e)
        {

            tbxrespane.Text = e.Message;
        }
    }

}