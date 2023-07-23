using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace pro_webhook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
                MessageBox.Show("O campo Url deve ser preenchido", "Erro !", MessageBoxButtons.OK);
            if(numericUpDown1.Value == 0)
                MessageBox.Show("O Tempo em segundos por sequisição deve ser maior que 0", "Erro !", MessageBoxButtons.OK);
            if (numericUpDown1.Value > 0 && textBox1.Text != "")
            {
                button1.Enabled = false;
                button2.Enabled = true;
                iniciarRequisicoes();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private void iniciarRequisicoes()
        {
            Form1.ActiveForm.Enabled = true;
            var timeSleep = numericUpDown1.Value > 0 ? numericUpDown1.Value : 50;
            var methodRequest = radioButton1.Text;
            for (var i = 0; i < numericUpDown2.Value; i++)
            {
                Task.Delay((int)timeSleep).Wait();
                listBox1.Items.Add("["+i+"] " + methodRequest + " \t\t " + textBox1.Text + "\t\t" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                if (button2.Enabled == false)
                    break;
                else
                    continue;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private async void post(string url, string body)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", "Bearer {{User-Access-Token}}");
            var content = new StringContent("");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var teste = await response.Content.ReadAsStringAsync();
        }
        private void get(string url)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}