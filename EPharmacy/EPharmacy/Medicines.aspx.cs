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
    public partial class About : Page
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-N1T3EGP\SQLEXPRESS;Initial Catalog=EPharmacyDB;Integrated Security=True");

        private void ShowMedicines()
        {
            Con.Open();
            string Query = "select * from MedicineTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MedGV.DataSource = ds.Tables[0];
            MedGV.DataBind();
            Con.Close();
        }

        private void DeleteMed()
        {
            if (MName.Value == "" || MType.SelectedIndex == -1 || MQty.Value == "" || MPrice.Value == "" || MMan.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Selected Medicines to be deleted');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from MedicineTbl where MedNum=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", MedGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Medicene Deleted');", true);
                    Con.Close();
                    ShowMedicines();

                }
                catch (Exception)
                {


                }
            }
        }

        private void EditMed()
        {
            if (MName.Value == "" || MType.SelectedIndex == -1 || MQty.Value == "" || MPrice.Value == "" || MMan.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update MedicineTbl set MedName=@MN,MedType=@MT,MedQty=@MQ,MedPrice=@MP,MedManufact= @MM where MedNum=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MT", MType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", MQty.Value);
                    cmd.Parameters.AddWithValue("@MP", MPrice.Value);
                    cmd.Parameters.AddWithValue("@MM", MMan.SelectedIndex);
                    cmd.Parameters.AddWithValue("@MKey", MedGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Medicene Updated in Stock');", true);
                    Con.Close();
                    ShowMedicines();

                }
                catch (Exception)
                {


                }
            }
        }

        private void InsertMed()
        {
            if (MName.Value == "" || MType.SelectedIndex == -1 || MQty.Value == "" || MPrice.Value == "" || MMan.SelectedIndex == -1)
            {

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into MedicineTbl(MedName,MedType,MedQty,MedPrice,MedManufact) values(@MN,@MT,@MQ,@MP,@MM)",Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MT", MType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", MQty.Value);
                    cmd.Parameters.AddWithValue("@MP", MPrice.Value);
                    cmd.Parameters.AddWithValue("@MM", MMan.SelectedIndex);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this,this.GetType(),"Script","alert('Medicene Added in Stock');",true);
                    Con.Close();
                    ShowMedicines();

                }
                catch (Exception)
                {

                    
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMedicines();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertMed();
        }

        int Key = 0;
        protected void MedGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            MName.Value = MedGV.SelectedRow.Cells[2].Text;
            MType.Text = MedGV.SelectedRow.Cells[3].Text;
            MQty.Value = MedGV.SelectedRow.Cells[4].Text;
            MPrice.Value = MedGV.SelectedRow.Cells[5].Text;
            MMan.Text = MedGV.SelectedRow.Cells[6].Text;
            if (MName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MedGV.SelectedRow.Cells[1].Text);
            }
        }

        

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditMed();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteMed();
        }
    }
}