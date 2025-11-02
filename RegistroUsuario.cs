using System;
using System.Windows.Forms;
using LivroManager.Controllers;
using LivroManager.Data;

namespace LivroManager.Views
{
    public partial class RegisterForm : Form
    {
        private readonly UserController _userController;

        public RegisterForm()
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _userController = new UserController(context);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtSenha.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            var success = _userController.Register(nome, email, password);
            if (success)
            {
                MessageBox.Show("Registro realizado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Email já cadastrado.");
            }
        }
    }
}
