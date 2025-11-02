using System;
using System.Windows.Forms;
using LivroManager.Controllers;
using LivroManager.Models;

namespace LivroManager.Views
{
    public partial class LivroForm : Form
    {
        private readonly LivroController _controller;
        private readonly User _user;
        private readonly Livro _livro;

        public LivroForm(LivroController controller, User user, Livro livro = null)
        {
            InitializeComponent();
            _controller = controller;
            _user = user;
            _livro = livro;

            if (_livro != null)
            {
                txtTitulo.Text = _livro.Titulo;
                txtAutor.Text = _livro.Autor;
                dtpData.Value = _livro.DataPublicacao;
                txtCategoria.Text = _livro.Categoria;
                txtDescricao.Text = _livro.Descricao;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text) || string.IsNullOrEmpty(txtAutor.Text))
            {
                MessageBox.Show("Título e Autor são obrigatórios.");
                return;
            }

            if (_livro == null)
            {
                var novoLivro = new Livro
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    DataPublicacao = dtpData.Value,
                    Categoria = txtCategoria.Text,
                    Descricao = txtDescricao.Text,
                    UserId = _user.UserId
                };
                _controller.CriarLivro(novoLivro);
            }
            else
            {
                _livro.Titulo = txtTitulo.Text;
                _livro.Autor = txtAutor.Text;
                _livro.DataPublicacao = dtpData.Value;
                _livro.Categoria = txtCategoria.Text;
                _livro.Descricao = txtDescricao.Text;
                _controller.AtualizarLivro(_livro);
            }

            this.Close();
        }
    }
}
