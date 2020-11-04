using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class AddQuiz : Form
    {
        public int index { get; set; }
        public string name { get; set; }
        public AddQuiz()
        {
            InitializeComponent();
        }
        #region CRUD
        private void addNew()
        {
            Questions questions = new Questions();
            questions.Quiz_Name = name;
            questions.index = index;
            questions.Show();
            this.Hide();
        }
        
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text == "" | nudCantidad.Value == 0)
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }
            else
            {
                index = Convert.ToInt32(nudCantidad.Value);
                name = txtName.Text;
                addNew();
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Principal principal = new Principal();
                principal.Show();
                this.Hide();
           
        }

        private void AddQuiz_Load(object sender, EventArgs e)
        {
        }
    }
}
