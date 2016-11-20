using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doware_LicenceServer
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();

            this.Text += Program.Version;
        }

        private void txId_contrato_Leave(object sender, EventArgs e)
        {
            String idInstalacao = Program.GetCPUID();
            string idCliente = txId_cliente.Text;
            string idContrato = txId_contrato.Text;

            txId_instalacao.Text = DateTime.Now.Year + idCliente + idInstalacao + idContrato;
        }

        private void btConfigurar_Click(object sender, EventArgs e)
        {
            LicenceObjects.Licence licence = new LicenceObjects.Licence();

            licence.ID_CLIENTE = txId_cliente.Text.ToCompact();
            licence.ID_CONTRATO = txId_contrato.Text.ToCompact();
            licence.ID_INSTALACAO = txId_instalacao.Text.ToCompact();
            licence.USUARIOS = ("3").ToCompact(); // TODO - PEGAR O NUMERO DE USUÁRIOS DO SITE DA DOWARE
            licence.VENCIMENTO = new DateTime(2016, 11, 20);
            licence.ID_CPU = Program.GetCPUID();
            
            Program.SaveLicence(licence);
        }

        private void Configure_Load(object sender, EventArgs e)
        {

        }
    }
}
