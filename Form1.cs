using DigiBank.controllers;
using DigiBank.models;
using DigiBank.repositories;
using DigiBank.services;
using DigiBank.views;
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

        public Form1()
        {
            InitializeComponent();
            
        }

        private void CarregarClientes()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // --- Reseta a aparência de todos os botões do menu ---
            ResetarEstiloBotoes();

            // --- Aplica estilo de "selecionado" no Dashboard ---
            btnDashboard.BackColor = Color.LightBlue;
            btnDashboard.ForeColor = Color.Blue;

            // --- Carrega o Dashboard ---
            painelPrincipal.Controls.Clear();

            DashBoard telaDashboard = new DashBoard
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            painelPrincipal.Controls.Add(telaDashboard);
            telaDashboard.Show();
        }

        private void ResetarEstiloBotoes()
        {
            // Aqui você coloca todos os botões do seu menu
            List<Button> botoesMenu = new List<Button> { btnDashboard, /* btnOutro, btnMais... */ };

            foreach (var botao in botoesMenu)
            {
                botao.BackColor = SystemColors.Control; // Cor padrão
                botao.ForeColor = Color.Black;          // Texto preto
            }
        }


        private void painelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
