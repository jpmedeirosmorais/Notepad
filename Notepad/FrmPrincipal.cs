using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FrmPrincipal : Form
    {
        string CaminhoDocumento = string.Empty;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verifica se o domcumento encontra-se com algo digitado
            if(!string.IsNullOrEmpty(richTextBox1.Text)){
                richTextBox1.Clear();
                Text = "Sem título - Bloco de Notas";
                statusStrip1.Items[0].Text = "Novo documento xriado em " +"-" + DateTime.Now;
            }
            else
            {
                richTextBox1.Clear();
                statusStrip1.Items[0].Text = "Pronto.";
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirDocumento();
        }

        public void AbrirDocumento()
        {
            openFileDialog1.Title = "Procurar documento";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "Arquivo de Texto (*.txt)|*.txt|" + "Todos os Arquivos (*.*)|*.*";
            DialogResult dialogResult = openFileDialog1.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                try
                {
                    FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream);
                    richTextBox1.Text = "";

                    string linha = streamReader.ReadLine();

                    while(linha != null)
                    {
                        richTextBox1.Text += linha + "\n";
                        linha = streamReader.ReadLine();
                    }

                    Text = openFileDialog1.FileName + " - Bloco de Notas";
                    CaminhoDocumento = openFileDialog1.FileName;
                    statusStrip1.Text = "Documento carregado.";
                    streamReader.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
