using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;

namespace cribrn
{
    public partial class FrmAgenda : Form
    {
        public FrmAgenda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();

            agenda.DataAgenda = dateTimePicker1.Value;
            agenda.Descricao = txtAssunto.Text;
            
            PessoalNegocios pessoalNegocios = new PessoalNegocios();
            string retorno = pessoalNegocios.InserirAgenda(agenda);

            try
            {
                int id = Convert.ToInt32(retorno);
                MessageBox.Show("Agenda inserida com sucesso: " + id.ToString());
                this.DialogResult = DialogResult.Yes;

            }
            catch
            {
                MessageBox.Show(
               "Não foi possível Inserir. Detalhes: " + retorno,
               "Erro",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
