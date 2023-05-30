using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practice
{
    public partial class crud_opration : System.Web.UI.Page
    {
        string mycon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();
                filldata();
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            string firstname = txtname.Text;
            string lastname = txtlname.Text;
            string department = dropdep.SelectedValue;
            string joiningdate = txtjoindt.Text;
            DateTime date2 = Convert.ToDateTime(joiningdate,
            System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            string gender = chkgender.SelectedValue;
            SqlConnection obj = new SqlConnection(mycon);
            obj.Open();
            SqlCommand cmd = new SqlCommand("employeeadd '" + firstname + "','" + lastname + "','" + department + "','" + joiningdate + "','" + gender + "'", obj);
            cmd.ExecuteNonQuery();
            obj.Close();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Successfully Save....')</script>");
            clear();
            filldata();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            string firstname = txtname.Text;
            string lastname = txtlname.Text;
            string department = dropdep.SelectedValue;
            string joiningdate = txtjoindt.Text;
            DateTime date2 = Convert.ToDateTime(joiningdate,
                System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            string gender = chkgender.SelectedValue;
            SqlConnection obj = new SqlConnection(mycon);
            obj.Open();
            SqlCommand cmd = new SqlCommand("employee_Update '"+ id +"','" + firstname + "','" + lastname + "','" + department + "','" + joiningdate + "','" + gender + "'", obj);
            cmd.ExecuteNonQuery();
            obj.Close();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Record Successfully Updated....')</script>");
            clear();
            filldata();

        }
        public void filldata()
        {
            SqlConnection obj = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand("Select * from crudopration", obj);
            obj.Open();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            obj.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            SqlConnection obj = new SqlConnection(mycon);
            obj.Open();
            SqlCommand cmd = new SqlCommand("delete_Emp '" + id + "'", obj);
            cmd.ExecuteNonQuery();
            obj.Close();
            Response.Write("<script LANGUAE='JavaScript' >alert('Record Successfully Deleted....')</script>");
            clear();
            filldata();


        }
        public void clear()
        {
            txtname.Text = "";
            txtlname.Text = "";
            txtjoindt.Text = "";
            dropdep.SelectedIndex = -1;
            chkgender.Items[0].Selected = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            SqlConnection sql = new SqlConnection(mycon);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from crudopration where empid = '" + id + "'", sql);

            SqlDataReader dar = cmd.ExecuteReader();

            while (dar.Read())
            {
                txtname.Text = dar["firstname"].ToString();
                txtlname.Text = dar["Lastname"].ToString();
                dropdep.SelectedValue = dropdep.Items.FindByText(dar["Department"].ToString()).Text;
                txtjoindt.Text = dar["joiningdate"].ToString();
                chkgender.SelectedValue = dar["gender"].ToString();
            }
        }
        public void DataFound()
        {
            string col = "";
            int val = 10;
            SqlConnection sql = new SqlConnection(mycon);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select empid from crudopration where empid = '" + val + "'", sql);

            SqlDataReader dar = cmd.ExecuteReader();


            while (dar.Read())
            {

                col = col + dar["empid"];
            }
            Response.Redirect(col);

        }
    }
}