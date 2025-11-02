using System;
using System.Linq;
using System.Windows.Forms;
using LivroManager.Controllers;
using LivroManager.Data;
using LivroManager.Models;

namespace LivroManager.Views
{
    public partial class MainForm : Form
    {
        private readonly LivroController _livroController;
        private readonly User _user;

        public MainForm(User loggedUser)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _livroController = new LivroController(context);
            _user = loggedUser;
            LoadLivros();
        }

        private void LoadLivros()
        {
            var livros = _livroController.ListarLivros(_user.UserId);
            dgvLivros.DataSource = livros.Select(l => new
            {
                l.LivroId,
                l.Titulo,
                l.Autor,
                l.DataPublicacao,
                l.Categoria
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var livroForm = new LivroForm(_livroController, _user);
            livroForm.ShowDialog();
            LoadLivros();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLivros.SelectedRows.Count > 0)
            {
                int livroId = (int)dgvLivros.SelectedRows[0].Cells["LivroId"].Value;
                var livro = _livroController.GetLivro(livroId, _user.UserId);
                if (livro != null)
                {
                    var livroForm = new LivroForm(_livroController, _user, livro);
                    livroForm.ShowDialog();
                    LoadLivros();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLivros.SelectedRows.Count > 0)
            {
                int livroId = (int)dgvLivros.SelectedRows[0].Cells["LivroId"].Value;
                var confirm = MessageBox.Show("Tem certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _livroController.DeletarLivro(livroId, _user.UserId);
                    LoadLivros();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvLivros.SelectedRows.Count > 0)
            {
                int livroId = (int)dgvLivros.SelectedRows[0].Cells["LivroId"].Value;
                var livro = _livroController.GetLivro(livroId, _user.UserId);
                if (livro != null)
                {
                    var detailsForm = new LivroDetailsForm(livro);
                    detailsForm.ShowDialog();
                }
            }
        }
    }
}
