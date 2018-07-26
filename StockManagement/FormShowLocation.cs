using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class FormShowLocation : Form
    {
        bool isMouseDown = false;
        private Point startPoint;
        MySqlConnection mysqlConn;
        string stock_id;
        public FormShowLocation()
        {
            InitializeComponent();
        }
        public FormShowLocation(string name, string stock_id, string location1, int location2, int location3, int amount, int orderCycle, MySqlConnection mysqlConn)
        {
            InitializeComponent();
            this.mysqlConn = mysqlConn;
            this.stock_id = stock_id;
            pictureBox1.ImageLocation = location1.Replace(@".\location",Directory.GetCurrentDirectory() + @"\location");
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            label1.Location = new System.Drawing.Point(location2, location3);
            label1.MouseDown += label1_MouseDown;
            label1.MouseMove += label1_MouseMove;
            label1.MouseUp += label1_MouseUp;
            textBoxAmount.Text = amount.ToString();
            textBoxOrderCycle.Text = orderCycle.ToString();
            this.Text = name;
            label1.Parent = pictureBox1;
            Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\location\arrow.png");
            label1.Size = new Size(image.Width, image.Height);
            label1.Image = image;
            label1.Text = "";
        }
        public FormShowLocation(string name, string location1, int location2, int location3)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = location1;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            label1.Location = new System.Drawing.Point(location2, location3);
            buttonLocation1.Hide();
            textBoxOrderCycle.Hide();
            textBoxAmount.Hide();
            buttonSetAmount.Hide();
            label2.Hide();
            label3.Hide();
            this.Text = name;
            label1.Parent = pictureBox1;
            Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\location\arrow.png");
            label1.Size = new Size(image.Width, image.Height);
            label1.Image = image;
            label1.Text = "";
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isMouseDown = true;
                label1.BringToFront();
                startPoint = e.Location;
            }
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            MySqlCommand comm = mysqlConn.CreateCommand();
            comm.CommandText = "update stock set location_2=" + label1.Left + ", location_3=" + label1.Top + " where id=" + stock_id;
            comm.ExecuteNonQuery();

        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                label1.Left = e.X + label1.Left - startPoint.X;
                label1.Top = e.Y + label1.Top - startPoint.Y;
            }
        }

        private void buttonLocation1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + @"\location";
            MySqlCommand comm = mysqlConn.CreateCommand();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                comm.CommandText = "update stock set location_1='" + openFileDialog1.FileName.Replace(Directory.GetCurrentDirectory() + @"\location",@".\location").Replace(@"\",@"\\") + "' where id=" + stock_id;
                comm.ExecuteNonQuery();
            }
        }

        private void buttonSetAmount_Click(object sender, EventArgs e)
        {
            if (textBoxAmount.Text != null && !textBoxAmount.Text.Equals(""))
            {
                try
                {
                    int amount = int.Parse(textBoxAmount.Text);
                    int orderCycle = int.Parse(textBoxOrderCycle.Text);
                    MySqlCommand comm = mysqlConn.CreateCommand();
                    comm.CommandText = "update stock set amount=" + amount + ", order_cycle=" + orderCycle + " where id=" + stock_id;
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("incorrect input");
                }

            }
        }
    }

}
