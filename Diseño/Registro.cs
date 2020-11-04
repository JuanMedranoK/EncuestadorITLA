using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Services.EntitiesRepository;

namespace Diseño
{
    public partial class Registro : Form
    {
        User user = new User();
        UserServices userServices = new UserServices();
        public Registro()
        {
            InitializeComponent();
        }
        private bool Existe(string Username)
        {
            DataTable dt = new DataTable();
            dt = userServices.getSpecific("SELECT * FROM USERS WHERE USERNAME = '" + Username + "'");
            try
            {
                if (dt != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private void agregar()
        {
            user.NAME = txtNombre.Text;
            user.LASTNAME = txtApellido.Text;
            user.USER_NAME = txtUsuario.Text;
            user.PASSWORD = txtContra.Text;
            if (userServices.addUser(user))
            {
                MessageBox.Show("Usuario agregado correctamente");
            }
            else
                MessageBox.Show("No se pudo agregar el usuario");
        }
        private void btnNC_Click(object sender, EventArgs e)
        {
            if (txtContra.Text != "" | txtConContra.Text != "")
            {
                if (txtContra.Text != txtConContra.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
                else
                {
                    if (txtNombre.Text != "" | txtApellido.Text != "" | txtUsuario.Text != "")
                    {

                        agregar();
                     
                    }
                    else
                    {
                        MessageBox.Show("Debe llenar todos los campos");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }
    }
}
