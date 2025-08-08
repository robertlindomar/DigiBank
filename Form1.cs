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
            painelPrincipal.Controls.Clear(); // Limpa o painel

            DashBoard telaDashboard = new DashBoard();
            telaDashboard.TopLevel = false; // 🔹 Faz o form não ser janela principal
            telaDashboard.FormBorderStyle = FormBorderStyle.None; // 🔹 Remove bordas
            telaDashboard.Dock = DockStyle.Fill; // 🔹 Faz ocupar todo o painel

            painelPrincipal.Controls.Add(telaDashboard); // Adiciona no painel
            telaDashboard.Show(); // Mostra o form

        }
    }
}
