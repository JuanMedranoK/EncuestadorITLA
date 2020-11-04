using Services;
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
using System.Configuration;

namespace Diseño
{
    public partial class Login : Form
    {
        SqlConnection connection;
        User user = new User();
        UserServices userServices = new UserServices();
        public Login()
        {
            
            InitializeComponent();

        }
        private void login()
        {
            DataTable dt = new DataTable();
            dt = userServices.getSpecific("SELECT * FROM USERS WHERE USERNAME = '" + txtUser.Text + "' AND PASSWORD = '" + txtPassword.Text +"'");
            if (dt.Rows.Count == 1)
            {
                user.ID_USER = Convert.ToInt32(dt.Rows[0]["ID_USER"].ToString());
                user.NAME = dt.Rows[0]["NAME"].ToString();
                user.LASTNAME = dt.Rows[0]["LASTNAME"].ToString();
                user.USER_NAME = dt.Rows[0]["USERNAME"].ToString();
                user.PASSWORD = dt.Rows[0]["PASSWORD"].ToString();
                UserLogged.Instance.user = user;
                Principal principal = new Principal();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos Erroneos");
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "" | txtPassword.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                login();
            }
        }

        private void btnNC_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
