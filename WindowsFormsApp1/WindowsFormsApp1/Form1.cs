using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string URI = "";
        public int codigoUsuario = 1;

        private async void button1_Click(object sender, EventArgs e)
        {
            URI = txtURI.Text;
            gdvDados.DataSource = await ConsomeApi.GetUsuarios(URI);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            BindingSource bsDados = new BindingSource();
            URI = txtURI.Text;
            InputBox();
            if (codigoUsuario != -1)
            {
                URI = txtURI.Text + "/" + codigoUsuario.ToString();
                bsDados.DataSource = await ConsomeApi.GetUsuarioById(URI);
                gdvDados.DataSource = bsDados;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            URI = txtURI.Text;
            Usuario usuario = new Usuario();
            usuario.Nome = "Marcio Luiz";
            usuario.Senha = "Mar1234";
            usuario.Email = "Marcio.luiz@gmail.com";
            ConsomeApi.AddUsuario(URI, usuario);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }  
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputBox()
        {
            string Prompt = "Informe o código do Usuario: ";
            string Titulo = "www.macoratti.net";
            string resultado = Microsoft.VisualBasic.Interaction.InputBox(Prompt, Titulo, "9", 600, 350);
            if (resultado != "")
            {
                codigoUsuario = Convert.ToInt32(resultado);
            }
            else
            {
                codigoUsuario = 1;
            }

        }
    }
}
