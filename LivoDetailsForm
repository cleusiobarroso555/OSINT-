using System;
using System.Windows.Forms;
using LivroManager.Models;

namespace LivroManager.Views
{
    public partial class LivroDetailsForm : Form
    {
        public LivroDetailsForm(Livro livro)
        {
            InitializeComponent();
            lblTitulo.Text = livro.Titulo;
            lblAutor.Text = livro.Autor;
            lblData.Text = livro.DataPublicacao.ToShortDateString();
            lblCategoria.Text = livro.Categoria;
            txtDescricao.Text = livro.Descricao;
        }
    }
}
