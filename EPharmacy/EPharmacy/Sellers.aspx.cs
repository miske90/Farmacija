using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPharmacy
{
    public partial class Sellers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowSellers();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-N1T3EGP\SQLEXPRESS;Initial Catalog=EPharmacyDB;Integrated Security=True");

        private void ShowSellers()
        {
            Con.Open();
            string Query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerGV.DataSource = ds.Tables[0];
            SellerGV.DataBind();
            Con.Close();
        }

        private void DeleteSeller()
        {
            if (SellerGV.SelectedRow.Cells[1].Text=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Selected Seller to be deleted');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from SellerTbl where SNum=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SKey", SellerGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Seller Deleted');", true);
                    Con.Close();
                    ShowSellers();

                }
                catch (Exception)
                {


                }
            }
        }

        private void EditSeller ()
        {
            if (SName.Value == "" || SGen.SelectedIndex == -1 || SPhone.Value == "" || SAddress.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update SellerTbl set SName=@SN,SDOB=@SD,SPhone=@SP,SAdd=@SA,SGen=@SG,SPass=@SPa where SNum=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", SName.Value);
                    cmd.Parameters.AddWithValue("@SD", SDOB.Value);
                    cmd.Parameters.AddWithValue("@SP", SPhone.Value);
                    cmd.Parameters.AddWithValue("@SA", SAddress.Value);
                    cmd.Parameters.AddWithValue("@SG", SGen.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SPa", SPassword.Value);
                    cmd.Parameters.AddWithValue("@SKey",SellerGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Seller Updated in Stock');", true);
                    Con.Close();
                    ShowSellers();

                }
                catch (Exception)
                {


                }
            }
        }

        private void InsertSeller()
        {
            if (SName.Value == "" || SGen.SelectedIndex == -1 || SPhone.Value == "" || SAddress.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into SellerTbl(SName,SDOB,SPhone,SAdd,SGen,SPass) values(@SN,@SD,@SP,@SA,@SG,@SPa)", Con);
                    cmd.Parameters.AddWithValue("@SN", SName.Value);
                    cmd.Parameters.AddWithValue("@SD", SDOB.Value);
                    cmd.Parameters.AddWithValue("@SP", SPhone.Value);
                    cmd.Parameters.AddWithValue("@SA", SAddress.Value);
                    cmd.Parameters.AddWithValue("@SG", SGen.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SPa", SPassword.Value);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Seller Added ');", true);
                    Con.Close();
                    ShowSellers();

                }
                catch (Exception)
                {


                }
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertSeller();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteSeller();
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditSeller();
        }

        int Key = 0;
        protected void SellerGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SName.Value = SellerGV.SelectedRow.Cells[2].Text;
            SDOB.Value = SellerGV.SelectedRow.Cells[3].Text;
            SPhone.Value = SellerGV.SelectedRow.Cells[4].Text;
            SAddress.Value = SellerGV.SelectedRow.Cells[5].Text;
            SGen.Text = SellerGV.SelectedRow.Cells[6].Text;
            SPassword.Value = SellerGV.SelectedRow.Cells[7].Text;

            if (SName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellerGV.SelectedRow.Cells[1].Text);
            }
        }
    }
}