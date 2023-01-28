using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class _Default : Page
    {
        public string constr;
        public SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();
            }
        }

        public void connection()
        {
            //Stoting connection string 
            constr = ConfigurationManager.ConnectionStrings["teacher"].ConnectionString;
            con = new SqlConnection(constr);
            con.Open();

        }
        protected void AddProduct_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }

        private void AddDefaultFirstRecord()
        {
            //creating DataTable
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tb";
            //creating columns for DataTable
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("FatherName", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["tb"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void AddNewRecordRowToGrid()
        {
            if (ViewState["tb"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tb"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //Creating new row and assigning values
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Id"] = TextBox1.Text;
                        drCurrentRow["Name"] = TextBox2.Text;
                        drCurrentRow["Email"] = TextBox3.Text;
                        drCurrentRow["FatherName"] = TextBox4.Text;



                    }
                    //Removing initial blank row
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //Added New Record to the DataTable
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //storing DataTable to ViewState
                    ViewState["tb"] = dtCurrentTable;
                    //binding Gridview with New Row
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnsubmitProducts_Click(object sender, EventArgs e)
        {

            BulkInsertToDataBase();

        }

        private void BulkInsertToDataBase()
        {
            DataTable dttb = (DataTable)ViewState["tb"];
            connection();
            //creating object of SqlBulkCopy
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name
            objbulk.DestinationTableName = "tb";
            //Mapping Table column
            objbulk.ColumnMappings.Add("Id", "Id");
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("Email", "Email");
            objbulk.ColumnMappings.Add("FatherName", "FatherName");
            //inserting bulk Records into DataBase 
            objbulk.WriteToServer(dttb);
        }

    }
}