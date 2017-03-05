using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace database_project
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = "Data Source=AWAIS\\SQLEXPRESS;Initial Catalog=styker;User ID=sa;Password=Centrino1?";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (pname.Text == "")
                {
                    MessageBox.Show("Please provide data");
                    return;
                }


                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "Insert into physician (EmpID,Name,position,SSN) values ('" + pid.Text + "','" + pname.Text + "','" + ppos.Text + "','" + pssn.Text + "')";
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved");
                pid.Text = "";
                pname.Text = "";
                ppos.Text = "";
                pssn.Text = "";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pid.Text == ""|| pname.Text==""||pssn.Text==""||ppos.Text=="")
                {
                    MessageBox.Show("Select a record to delete");
                    return;
                }
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "Delete from Physician Where EmpID='" + pid.Text + "'";
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Deleted");
                pid.Text = "";
                pname.Text = "";
                pssn.Text = "";
                ppos.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ppos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pssn.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        /*
void bindgrid()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=AWAIS-PC;Initial Catalog=hospital;User ID=awais416;Password=asdfgh");
                SqlDataAdapter sda = new SqlDataAdapter("select * from Physician", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         */

private void button4_Click(object sender, EventArgs e)
{
    string constring = "Data Source=AWAIS-PC;Initial Catalog=hospital;User ID=awais416;Password=asdfgh";
    SqlConnection conn = new SqlConnection(constring);
    SqlCommand command = new SqlCommad("Select* from Physician;",con);
    try 

    {
        SqlDataAdapter sda= new SqlDataAdapter();
        sda.SelectCommand= command;
        DataTable dbdataset = new DataTable();
        sda.Fill(dbdataset);
        BindingSource bsource = new BindingSource();
        bsource.DataSource = dbdataset;
        dataGridView1.DataSource=bsource;
        sda.Update(dbdataset);

    }

    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}

private void button1_Click(object sender, EventArgs e)
{
    try
    {
        if (pid.Text == "")
        {
            MessageBox.Show("Select a record to modify");
            return;
        }
        SqlCommand command = new SqlCommand("Data Source=AWAIS-PC;Initial Catalog=hospital;User ID=awais416;Password=asdfgh");
        command.Connection = con;
        command.CommandText = "Update Physician Set Name='" + pname.Text + "' , SSN='" + pssn.Text + "',position='" + ppos.Text + "'where EmpID='" + pid.Text + "'";
        con.Open();
        command.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Data Updated");
        pname.Text = "";
       pid.Text = "";
       
       pssn.Text = "";
       ppos.Text = "";
       
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
      
private void label8_Click(object sender, EventArgs e)
{

}

private void groupBox1_Enter(object sender, EventArgs e)
{

}

       
        
        
        
        
        
        
        
        
  
       
        }

    
    
    
    
    }


