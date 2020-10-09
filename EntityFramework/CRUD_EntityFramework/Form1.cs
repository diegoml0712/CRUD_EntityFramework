using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    if ((txtNome.Text == "") || (txtFone.Text == "") ||(txtCep.Text == ""))
                    {
                        MessageBox.Show("Não pode conter campos em branco!");
                    }
                    else
                    {
                        tb.ObjetoAgenda.Add(new Agenda { Nome = txtNome.Text, Telefone = txtFone.Text, Cep = txtCep.Text });
                        tb.SaveChanges();
                        limpacampos();
                        AtualizaGrid();
                        MessageBox.Show("Adicionado com sucesso", "Adicionar");
                    }                   
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void limpacampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtNome.Focus();
            txtFone.Clear();
            txtCep.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    var objeto = tb.ObjetoAgenda.Find(Convert.ToInt32(txtId.Text));
                    objeto.Nome = txtNome.Text;
                    objeto.Telefone = txtFone.Text;
                    objeto.Cep = txtCep.Text;

                    tb.Entry(objeto).State = EntityState.Modified;
                    tb.SaveChanges();
                    MessageBox.Show("Alterado com sucesso", "Alterado");
                    AtualizaGrid();
                    limpacampos();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }


        public void AtualizaGrid()
        {
            using (var tb = new Contexto())
            {
                grid.DataSource = null;
                grid.DataSource = tb.ObjetoAgenda.ToList();
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtFone.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtCep.Text = grid.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    var objeto = tb.ObjetoAgenda.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoAgenda.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Excluido com sucesso", "Excluir");
                    limpacampos();
                    AtualizaGrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
