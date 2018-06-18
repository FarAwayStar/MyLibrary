using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyLibrary
{
    public partial class dlu : Form
    {
        public dlu()
        {
            InitializeComponent();
        }

        DBAccess user = new DBAccess();
        SqlConnection sqlcon = DBAccess.GetConnection();//建立连接

        private void loginButton_Click(object sender, EventArgs e)
        {
            string SQLstr = "select * from dbo.ylduser where 用户ID='" +
                nameTextBox.Text.Trim() + "'and 密码='" + codeTextBox.Text.Trim() + "'";
            SqlCommand sqlCommand = sqlcon.CreateCommand();  //创建一个SqlCommand对象，用于执行sql语句
            sqlCommand.CommandText = SQLstr;                        //获取指定的sql语句
            SqlDataReader temDR = sqlCommand.ExecuteReader();       //执行sql语句名，生成一个sqldatareader对象
            bool bReaded = temDR.Read();
            if (bReaded)
            {
                MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlcon.Close();   //关闭数据库的连接
                sqlcon.Dispose();   //释放My_con变量的所有空间
                Hide();
                //MainWindow sb = new MainWindow();
                //sb.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("登录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTextBox.Text = "";
                codeTextBox.Text = "";
                nameTextBox.Focus();
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            sqlcon.Close();
            sqlcon.Dispose();
            Application.Exit();
        }
    }
}
