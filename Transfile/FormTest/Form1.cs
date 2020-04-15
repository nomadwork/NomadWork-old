

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTransfile;
namespace FormTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var userData = new UserData();
			try
			{
				var list = new List<string>();
				foreach (var user in userData.ListUsers())
				{
					list.Add(user.UserId + " | " + user.UserName + "\n");
				}

				MessageBox.Show(list.ToString());


			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}




		}
	}	
}
