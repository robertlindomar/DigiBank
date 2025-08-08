using DigiBank.controllers;
using DigiBank.models;
using DigiBank.repositories;
using DigiBank.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank
{
    public partial class Form1 : Form
    {

        private readonly ClienteController clienteController;
        public Form1()
        {
            InitializeComponent();
            clienteController = new ClienteController();
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            List<Cliente> lista = clienteController.BuscarTodos(); // ou sua função

            dataGridView1.DataSource = lista;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente novoCliente = new Cliente();

            if (textNome.Text != null && textCPF.Text != null)
            {
                novoCliente.Nome = textNome.Text;
                novoCliente.Cpf = textCPF.Text;


                clienteController.criar(novoCliente);




                MessageBox.Show("Usuario Cadastrado com Sucesso ");
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
