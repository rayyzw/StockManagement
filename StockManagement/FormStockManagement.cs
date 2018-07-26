using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Resources;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class FormStockManagement : Form
    {
        public static MySqlConnection mysqlConn;
        public static DataSet data;
        public static MySqlDataAdapter da;
        DateTime max_record_time;
        string windowsUserName;
        public FormStockManagement()
        {
            InitializeComponent();
            windowsUserName = Environment.UserName;
            label1.Text = "Windows user: " + windowsUserName;
            string connStr = "";
            using (ResXResourceSet resxSet = new ResXResourceSet(@".\Properties\Resources.resx"))
            {
                resxSet.GetString("mysql_server_ip");
                resxSet.GetString("mysql_user_name");
                resxSet.GetString("mysql_password");
                resxSet.GetString("mysql_database_name");
                connStr = "Server=" + resxSet.GetString("mysql_server_ip")
                    + ";UserId=" + resxSet.GetString("mysql_user_name")
                    + ";Password=" + resxSet.GetString("mysql_password")
                    + ";Database=" + resxSet.GetString("mysql_database_name")
                    + ";port=" + resxSet.GetString("mysql_port");
            }
            try
            {
                mysqlConn = new MySqlConnection(connStr);
                mysqlConn.Open();
            }
            catch (MySqlException ex)
            {
                if (mysqlConn != null)
                    mysqlConn.Close();
                mysqlConn = null;
                throw ex;
            }
            try
            {
                data = new DataSet();
                da = new MySqlDataAdapter("select * from user order by name", mysqlConn);
                da.Fill(data, "users");
                int userIndex = -1;
                foreach (DataRow dr in data.Tables["users"].Rows)
                {
                    listBoxUser.Items.Add(dr["name"].ToString() + "                            is_admin=" + dr["is_admin"].ToString());
                    if (windowsUserName.Contains(dr["name"].ToString()))
                    {
                        userIndex = listBoxUser.Items.Count - 1;
                    }
                }
                if(userIndex>-1)
                {
                    listBoxUser.Hide();
                }
                listBoxUser.SelectedIndex = userIndex;
                refreshData();
            }
            catch (Exception ex)
            {

                if (mysqlConn != null)
                    mysqlConn.Close();
                mysqlConn = null;
                throw ex;
            }
            buttonProcess.Hide();
            textBoxTrackingNo.Hide();
            labelTrackingNo.Hide();
            buttonReturn.Hide();
            buttonRequest.Hide();
            textBoxName.Hide();
            buttonAddStock.Hide();
            buttonAddStockType.Hide();
            buttonDelete.Hide();
            buttonOderList.Hide();
            da.SelectCommand.CommandText = "select max(record_time) as max_record_time from record";
            da.Fill(data, "max(record_time)");
            foreach (DataRow dr1 in data.Tables["max(record_time)"].Rows)
            {
                max_record_time = (DateTime)dr1["max_record_time"];
            }
            treeViewStock.MouseDoubleClick += treeViewStock_MouseDoubleClick;
        }

        private void treeViewStock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxUser.SelectedItem != null && treeViewStock.SelectedNode != null && treeViewStock.SelectedNode.Name != null && !treeViewStock.SelectedNode.Name.Equals(""))
            {
                string stock_id = treeViewStock.SelectedNode.Name;
                da.SelectCommand.CommandText = "select * from stock where id=" + stock_id;
                data.Clear();
                da.Fill(data, "stock" + stock_id);

                foreach (DataRow dr2 in data.Tables["stock" + stock_id].Rows)
                {
                    string name = dr2["name"].ToString();
                    string location1 = dr2["location_1"].ToString();
                    int location2 = (int)dr2["location_2"];
                    int location3 = (int)dr2["location_3"];
                    int amount = (int)dr2["amount"];
                    int orderCycle = (int)dr2["order_cycle"];
                    if (listBoxUser.SelectedItem != null && listBoxUser.SelectedItem.ToString().Contains("is_admin=1"))
                    {
                        new FormShowLocation(name, dr2["id"].ToString(), location1, location2, location3, amount, orderCycle, mysqlConn).ShowDialog();
                    }
                    else
                    {
                        new FormShowLocation(name,location1, location2, location3).ShowDialog();
                    }

                }
                if (listBoxUser.SelectedItem != null && listBoxUser.SelectedItem.ToString().Contains("is_admin=1"))
                {
                    refreshData();
                }
            }
        }

        void refreshData()
        {
            treeViewStock.Nodes.Clear();
            checkedListBoxRecord.Items.Clear();
            data.Clear();
            da.SelectCommand.CommandText = "select * from stock_type where super_id=0";
            da.Fill(data, "stock_type");
            foreach (DataRow dr in data.Tables["stock_type"].Rows)
            {
                TreeNode treeNode = new TreeNode(dr["name"].ToString());
                treeNode.Tag = dr["id"].ToString();
                treeViewStock.Nodes.Add(treeNode);
                fillTreeViewStock(dr["id"].ToString(), treeNode);
            }
            da.SelectCommand.CommandText = "select record.id as record_id,record.user_name as user_name,stock.name as name,record.amount as amount,stock.id as stock_id from record,stock where is_processed=0 and record.stock_id=stock.id";
            da.Fill(data, "record");
            foreach (DataRow dr in data.Tables["record"].Rows)
            {
                if ((int)dr["amount"] == -1)
                {
                    checkedListBoxRecord.Items.Add(dr["user_name"] + " request " + dr["name"] + " record_id=" + dr["record_id"], false);
                }
                else if ((int)dr["amount"] == 1)
                {
                    checkedListBoxRecord.Items.Add(dr["user_name"] + " return " + dr["name"] + " record_id=" + dr["record_id"], false);
                }
            }

        }

        void fillTreeViewStock(string stock_type_id, TreeNode treeNode)
        {
            da.SelectCommand.CommandText = "select * from stock_type where super_id=" + stock_type_id;
            da.Fill(data, "stock_type" + stock_type_id);

            foreach (DataRow dr1 in data.Tables["stock_type" + stock_type_id].Rows)
            {
                TreeNode treeNode1 = new TreeNode(dr1["name"].ToString());
                treeNode1.Tag = dr1["id"].ToString();
                treeNode.Nodes.Add(treeNode1);
                fillTreeViewStock(dr1["id"].ToString(), treeNode1);
            }

            da.SelectCommand.CommandText = "select * from stock where stock_type_id=" + stock_type_id;
            da.Fill(data, "stock" + stock_type_id);
            foreach (DataRow dr1 in data.Tables["stock" + stock_type_id].Rows)
            {
                TreeNode treeNode1 = new TreeNode(dr1["name"].ToString() + "      " + dr1["amount"].ToString());
                treeNode1.Name = dr1["id"].ToString();
                treeNode.Nodes.Add(treeNode1);
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (mysqlConn != null)
                mysqlConn.Close();
            mysqlConn = null;
            base.OnFormClosing(e);
        }

        private void buttonRequest_Click(object sender, EventArgs e)
        {
            if(listBoxUser.SelectedItem != null && treeViewStock.SelectedNode.Name != null && !treeViewStock.SelectedNode.Name.Equals(""))
            {
                MySqlCommand comm = mysqlConn.CreateCommand();
                comm.CommandText = "INSERT INTO `record` (`user_name`, `stock_id`, `is_processed`,`amount`) VALUES ('" + listBoxUser.SelectedItem.ToString().Replace("                            is_admin=0","") + "', '" + treeViewStock.SelectedNode.Name + "', '0', '-1')";
                comm.ExecuteNonQuery();
                refreshData();
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (listBoxUser.SelectedItem != null && treeViewStock.SelectedNode != null && treeViewStock.SelectedNode.Name != null && !treeViewStock.SelectedNode.Name.Equals(""))
            {
                MySqlCommand comm = mysqlConn.CreateCommand();
                comm.CommandText = "INSERT INTO `record` (`user_name`, `stock_id`, `is_processed`,`amount`) VALUES ('" + listBoxUser.SelectedItem.ToString().Replace("                            is_admin=0", "") + "', '" + treeViewStock.SelectedNode.Name + "', '0', '1')";
                comm.ExecuteNonQuery();
                refreshData();
            }

        }

        private void listBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxUser.SelectedItem == null)
            {
                buttonProcess.Hide();
                textBoxTrackingNo.Hide();
                labelTrackingNo.Hide();
                buttonReturn.Hide();
                buttonRequest.Hide();
                textBoxName.Hide();
                buttonAddStock.Hide();
                buttonAddStockType.Hide();
                buttonDelete.Hide();
                buttonOderList.Hide();
            }
            else if (listBoxUser.SelectedItem.ToString().Contains("is_admin=0"))
            {
                buttonProcess.Hide();
                textBoxTrackingNo.Hide();
                labelTrackingNo.Hide();
                textBoxName.Hide();
                buttonAddStock.Hide();
                buttonAddStockType.Hide();
                buttonDelete.Hide();
                buttonOderList.Hide();
                buttonReturn.Show();
                buttonRequest.Show();
            }
            else if (listBoxUser.SelectedItem.ToString().Contains("is_admin=1"))
            {
                buttonProcess.Show();
                textBoxTrackingNo.Show();
                labelTrackingNo.Show();
                textBoxName.Show();
                buttonAddStock.Show();
                buttonAddStockType.Show();
                buttonDelete.Show();
                buttonOderList.Show();
                buttonReturn.Hide();
                buttonRequest.Hide();
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            foreach (string record in checkedListBoxRecord.CheckedItems)
            {
                MySqlCommand comm = mysqlConn.CreateCommand();
                comm.CommandText = "UPDATE `record` SET `is_processed` = '1',`process_user_name` = '" 
                    + listBoxUser.SelectedItem.ToString().Replace("                            is_admin=1", "") 
                    + "',`tracking_number` = '" 
                    + textBoxTrackingNo.Text
                    + "' WHERE (`id` = '" 
                    + record.Substring(record.IndexOf("record_id=") + 10) + "')";
                comm.ExecuteNonQuery();
                textBoxTrackingNo.Text = "";
                string record_id = record.Substring(record.IndexOf("record_id=") + 10);
                if (record.Contains("request"))
                {
                    da.SelectCommand.CommandText = "select * from record where id=" + record_id;
                    da.Fill(data, "record" + record_id);

                    foreach (DataRow dr1 in data.Tables["record" + record_id].Rows)
                    {
                        comm.CommandText = "UPDATE `stock` SET `amount` = `amount`-1 WHERE (`id` = '" + dr1["stock_id"] + "')";
                        comm.ExecuteNonQuery();
                    }
                }
                else if (record.Contains("return"))
                {
                    da.SelectCommand.CommandText = "select * from record where id=" + record_id;
                    da.Fill(data, "record" + record_id);

                    foreach (DataRow dr1 in data.Tables["record" + record_id].Rows)
                    {
                        comm.CommandText = "UPDATE `stock` SET `amount` = `amount`+1 WHERE (`id` = '" + dr1["stock_id"] + "')";
                        comm.ExecuteNonQuery();
                    }
                }
            }
            refreshData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            da.SelectCommand.CommandText = "select max(record_time) as max_record_time from record";
            da.Fill(data, "max(record_time)");
            bool need_refresh = false;
            foreach (DataRow dr1 in data.Tables["max(record_time)"].Rows)
            {
                if (max_record_time != null && max_record_time.CompareTo((DateTime)dr1["max_record_time"]) < 0)
                {
                    max_record_time = (DateTime)dr1["max_record_time"];
                    need_refresh = true;
                }
                else if (max_record_time == null)
                {
                    max_record_time = (DateTime)dr1["max_record_time"];
                }
            }

            if(need_refresh)refreshData();
        }

        private void buttonShowLocation_Click(object sender, EventArgs e)
        {
            foreach (string record in checkedListBoxRecord.SelectedItems)
            {
                string record_id = record.Substring(record.IndexOf("record_id=") + 10);
                if(data.Tables["record" + record_id] != null)data.Tables["record" + record_id].Clear();
                da.SelectCommand.CommandText = "select * from record where id=" + record_id;
                da.Fill(data, "record" + record_id);

                foreach (DataRow dr1 in data.Tables["record" + record_id].Rows)
                {
                    string stock_id = dr1["stock_id"].ToString();
                    if (data.Tables["stock" + stock_id] != null) data.Tables["stock" + stock_id].Clear();
                    da.SelectCommand.CommandText = "select * from stock where id=" + stock_id;
                    da.Fill(data, "stock" + stock_id);

                    foreach (DataRow dr2 in data.Tables["stock" + stock_id].Rows)
                    {
                        string name = dr2["name"].ToString();
                        string location1 = dr2["location_1"].ToString();
                        int location2 = (int)dr2["location_2"];
                        int location3 = (int)dr2["location_3"];
                        int amount = (int)dr2["amount"];
                        int orderCycle = (int)dr2["order_cycle"];
                        if (listBoxUser.SelectedItem != null && listBoxUser.SelectedItem.ToString().Contains("is_admin=1"))
                        {
                            new FormShowLocation(name, dr2["id"].ToString(), location1, location2, location3,amount, orderCycle, mysqlConn).ShowDialog();
                        }
                        else
                        {
                            new FormShowLocation(name, location1, location2, location3).ShowDialog();
                        }

                    }
                }
            }
        }

        private void buttonAddStockType_Click(object sender, EventArgs e)
        {
            if (listBoxUser.SelectedItem != null && treeViewStock.SelectedNode != null && treeViewStock.SelectedNode.Tag != null && !treeViewStock.SelectedNode.Tag.Equals("") && textBoxName.Text != null && !textBoxName.Text.Equals(""))
            {
                MySqlCommand comm = mysqlConn.CreateCommand();
                comm.CommandText = "INSERT INTO `stock_type` (`name`, `super_id`) VALUES ('" + textBoxName.Text + "', '" + treeViewStock.SelectedNode.Tag + "')";
                comm.ExecuteNonQuery();
                refreshData();
                textBoxName.Text = "";
            }
            else if(listBoxUser.SelectedItem != null && textBoxName.Text != null && !textBoxName.Text.Equals(""))
            {
                MySqlCommand comm = mysqlConn.CreateCommand();
                comm.CommandText = "INSERT INTO `stock_type` (`name`, `super_id`) VALUES ('" + textBoxName.Text + "', '0')";
                comm.ExecuteNonQuery();
                refreshData();
                textBoxName.Text = "";

            }
        }

        private void buttonAddStock_Click(object sender, EventArgs e)
        {
            if (listBoxUser.SelectedItem != null && treeViewStock.SelectedNode != null && treeViewStock.SelectedNode.Tag != null && !treeViewStock.SelectedNode.Tag.Equals("") && textBoxName.Text != null && !textBoxName.Text.Equals(""))
            {
                MySqlCommand comm = mysqlConn.CreateCommand();
                comm.CommandText = "INSERT INTO `stock` (`name`, `stock_type_id`,`location_1`,`location_2`,`location_3`,`amount`,`order_cycle`) VALUES ('"
                    + textBoxName.Text + "', '" 
                    + treeViewStock.SelectedNode.Tag + "','',0,0,0,7)";
                comm.ExecuteNonQuery();
                refreshData();
                textBoxName.Text = "";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxUser.SelectedItem != null && treeViewStock.SelectedNode != null && treeViewStock.SelectedNode.Tag != null && !treeViewStock.SelectedNode.Tag.Equals(""))
            {

                da.SelectCommand.CommandText = "select count(*) as count_child from stock_type where super_id = " + treeViewStock.SelectedNode.Tag 
                    + " union all select count(*) as count_child from stock where stock_type_id = " + treeViewStock.SelectedNode.Tag;
                da.Fill(data, "count_child");
                int countChild = 0;
                foreach (DataRow dr in data.Tables["count_child"].Rows)
                {
                    countChild += int.Parse(dr["count_child"].ToString());
                }
                if(countChild == 0)
                {
                    MySqlCommand comm = mysqlConn.CreateCommand();
                    comm.CommandText = "delete from stock_type where id=" + treeViewStock.SelectedNode.Tag;
                    comm.ExecuteNonQuery();
                    refreshData();
                }
                else
                {
                    MessageBox.Show("can not delect because it has child nodes in database");
                }
                data.Tables["count_child"].Clear();
            }
            else if (listBoxUser.SelectedItem != null && treeViewStock.SelectedNode != null && treeViewStock.SelectedNode.Name != null && !treeViewStock.SelectedNode.Name.Equals(""))
            {
                da.SelectCommand.CommandText = "select count(*) as count_child from record where stock_id = " + treeViewStock.SelectedNode.Name;
                da.Fill(data, "count_child");
                int countChild = 0;
                foreach (DataRow dr in data.Tables["count_child"].Rows)
                {
                    countChild += int.Parse(dr["count_child"].ToString());
                }
                if (countChild == 0)
                {
                    MySqlCommand comm = mysqlConn.CreateCommand();
                    comm.CommandText = "delete from stock where id=" + treeViewStock.SelectedNode.Name + " and amount<1";
                    comm.ExecuteNonQuery();
                    refreshData();
                }
                else
                {
                    MessageBox.Show("can not delect because it has records in database");
                }
                data.Tables["count_child"].Clear();
            }

        }

        private void buttonOderList_Click(object sender, EventArgs e)
        {
            data.Clear();
            da.SelectCommand.CommandText = "select id,name,amount as stock_amount,amount as consumed_amount,order_cycle from stock";
            da.Fill(data, "all_stock");
            DataTable dataTable = data.Tables["all_stock"].Clone();
            foreach (DataRow dr in data.Tables["all_stock"].Rows)
            {
                DateTime dateTime = DateTime.Now;
                dateTime = dateTime.AddDays(0 - int.Parse(dr["order_cycle"].ToString()));
                da.SelectCommand.CommandText = "select stock_id as id,sum(amount) as consumed_amount,'" + dr["name"].ToString() + "' as name,'" + dr["stock_amount"].ToString() + "' as stock_amount,'" + dr["order_cycle"].ToString() + "' as order_cycle from record where stock_id='" + dr["id"].ToString() + "' and record_time>'" + dateTime + "'";
                da.Fill(data, "consumed_amount" + dr["id"].ToString());
                foreach (DataRow dr1 in data.Tables["consumed_amount" + dr["id"].ToString()].Rows)
                {
                    try
                    {
                        if (int.Parse(dr1["consumed_amount"].ToString()) + int.Parse(dr["stock_amount"].ToString()) < 0)
                        {
                            dataTable.ImportRow(dr1);
                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            new FormOrderList(dataTable).ShowDialog();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(data.Tables["stockSearch"] != null) data.Tables["stockSearch"].Clear();
                da.SelectCommand.CommandText = "select * from stock where name like '%" + textBoxSearch.Text + "%'";
                da.Fill(data, "stockSearch");
                foreach (DataRow dr in data.Tables["stockSearch"].Rows)
                {
                    treeViewStock.SelectedNode = treeViewStock.Nodes.Find(dr["id"].ToString(), true)[0];
                    treeViewStock.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
