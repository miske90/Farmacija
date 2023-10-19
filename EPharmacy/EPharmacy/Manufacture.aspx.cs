using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPharmacy
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowManufactures();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-N1T3EGP\SQLEXPRESS;Initial Catalog=EPharmacyDB;Integrated Security=True");

        private void ShowManufactures()
        {
            Con.Open();
            string Query = "select * from ManufacturesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ManGV.DataSource = ds.Tables[0];
            ManGV.DataBind();
            Con.Close();
        }

        private void InsertMan()
        {
            if (MName.Value == "" ||  MPhone.Value == "" || MAdd.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information ');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into ManufacturesTbl(ManName,ManAdd,ManPhone,ManJDate) values(@MN,@MA,@MP,@MJD)", Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MA", MAdd.Value);
                    cmd.Parameters.AddWithValue("@MP", MPhone.Value);
                    cmd.Parameters.AddWithValue("@MJD", MJDate.Value);
                    
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Manufactured Added successfully');", true);
                    Con.Close();
                    ShowManufactures();

                }
                catch (Exception)
                {


                }
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertMan();
        }

        private void DeleteMan()
        {
            if (ManGV.SelectedRow.Cells[1].Text =="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Selected Manufacture to be deleted');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from ManufacturesTbl where ManId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", ManGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Manufacture Deleted');", true);
                    Con.Close();
                    ShowManufactures();

                }
                catch (Exception)
                {


                }
            }
        }

        private void EditMan()
        {
            if (MName.Value == "" || MPhone.Value == "" || MAdd.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ManufacturesTbl set ManName=@MN,ManAdd=@MA,ManPhone=@MP,ManJDate=@MJD where ManId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MA", MAdd.Value);
                    cmd.Parameters.AddWithValue("@MP", MPhone.Value);
                    cmd.Parameters.AddWithValue("@MJD", MJDate.Value);
                    cmd.Parameters.AddWithValue("MKey", ManGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Manufacture Updated Successfully');", true);
                    Con.Close();
                    ShowManufactures();

                }
                catch (Exception)
                {


                }
            }
        }

        int Key = 0;
        protected void ManGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            MName.Value = ManGV.SelectedRow.Cells[2].Text;
            MAdd.Value = ManGV.SelectedRow.Cells[3].Text;
            MPhone.Value = ManGV.SelectedRow.Cells[4].Text;
            MJDate.Value = ManGV.SelectedRow.Cells[5].Text;
            if (MName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ManGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteMan();
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditMan();
        }
    }
}