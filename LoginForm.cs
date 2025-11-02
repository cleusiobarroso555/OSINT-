using System;
using System.Windows.Forms;
using LivroManager.Controllers;
using LivroManager.Data;
using LivroManager.Models;

namespace LivroManager.Views
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;
        public User LoggedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _userController = new UserController(context);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtSenha.Text;

            LoggedUser = _userController.Login(email, password);
            if (LoggedUser != null)
            {
                MessageBox.Show($"Bem-vindo, {LoggedUser.Nome}!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
