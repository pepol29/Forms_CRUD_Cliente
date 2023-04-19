using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using WindowsFormsAppCRUD.model;

namespace WindowsFormsAppCRUD
{
    public partial class FormCliente : Form
    {

        public FormCliente()
        {
            InitializeComponent();
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModelDB context = new ModelDB())
                {
                    // Adicionando um novo objeto
                    Cliente myEntity = new Cliente();
                    myEntity.NOME = txtNome.Text;
                    myEntity.EMAIL = txtEmail.Text;
                    myEntity.DATA_NASC = Convert.ToDateTime(txtData.Text);
                    myEntity.CPF = Convert.ToInt64(txtCPF.Text); 
                    myEntity.RG = Convert.ToInt64(txtRG.Text);
                    context.Cliente.Add(myEntity);
                    context.SaveChanges();
                    MessageBox.Show("Objeto inserido com sucesso!");

                }

                MessageBox.Show("Deu tudo certo");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModelDB context = new ModelDB())
                {
                    var entityToUpdate = context.Cliente.FirstOrDefault(x => x.EMAIL == EmailAtu.Text);
                    if (entityToUpdate != null)
                    {
                        entityToUpdate.NOME = txtNome.Text;
                        context.SaveChanges();
                        MessageBox.Show("Objeto alterado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Objeto não encontrado");
                    }
                    

                }

                MessageBox.Show("Deu tudo certo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                using (ModelDB context = new ModelDB())
                {

                    var entityToDelete = context.Cliente.FirstOrDefault(x => x.EMAIL == EmailAtu.Text);
                    if (entityToDelete != null)
                    {
                        context.Cliente.Remove(entityToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Objeto removido com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Objeto não encontrado");
                    }


                }

                MessageBox.Show("Deu tudo certo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (ModelDB context = new ModelDB())
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    clienteBindingSource.DataSource = context.Cliente.Where(x => x.EMAIL.Contains(EmailAtu.Text)).ToList();
                }

                MessageBox.Show("Deu tudo certo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
               
            ModelDB context = new ModelDB();
            clienteBindingSource.DataSource = context.Cliente.ToList();


        }
    }
        
}

