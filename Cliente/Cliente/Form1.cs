using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{
    // conecta com um servidor
    public partial class Form1 : Form
    {
        private Thread threadLeitura;

        private NetworkStream fluxoDeRede;
        private BinaryWriter escritor;
        private BinaryReader leitor;

        private string mensagem = "";

        public Form1()
        {
            InitializeComponent();

            threadLeitura = new Thread(new ThreadStart(rodarCliente));
            threadLeitura.Start();
        }

        // conecta com o servidor e exibe o texto gerado por ele
        public void rodarCliente()
        {
            TcpClient cliente;

            // instancia TcpClient para enviar dados para o servidor
            try
            {
                // Passo 1: cria TcpClient e conecta com o servidor
                IPAddress endereco = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                cliente.Connect(endereco, 9900);

                // Passo 2: obtém NetworkStream associado a TcpClient
                fluxoDeRede = cliente.GetStream();

                // cria objetos para escrever e ler por meio de fluxo
                escritor = new BinaryWriter(fluxoDeRede);
                leitor = new BinaryReader(fluxoDeRede);

                // repete até que o servidor sinalize o término
                do
                {

                    // Passo 3: fase de processamento
                    try
                    {
                        // lê mensagem do servidor
                        mensagem = leitor.ReadString();
                        this.ImprimeTexto(mensagem);
                    }

                    // trata exceção se houver erro ao ler dados do servidor
                    catch (Exception)
                    {
                        System.Environment.Exit(
                           System.Environment.ExitCode);
                    }
                } while (mensagem != "SERVIDOR>>> ENCERRAR");

                this.ImprimeTexto(textBoxReceber.Text + "\r\nEncerrando conexão.\r\n");

                // Passo 4: fecha a conexão
                escritor.Close();
                leitor.Close();
                fluxoDeRede.Close();
                cliente.Close();
                Application.Exit();
            }

            // trata exceção se houver erro ao estabelecer conexão
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        } // fim do método rodarCliente

        delegate void ConfiguraTexto(string text);

        private void ImprimeTexto(string text)
        {
            if (this.textBoxReceber.InvokeRequired)
            {
                ConfiguraTexto d = new ConfiguraTexto(ImprimeTexto);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBoxReceber.Text = text;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void cmRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(celsiusRadio.Checked)
            {
                unidadeLabel.Text = "°C";
                escritor.Write("celsius");
            }
        }

        private void inRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (fahrenheitRadio.Checked)
            {
                unidadeLabel.Text = "°F";
                escritor.Write("fahrenheit");
            }
        }

        private void hv41Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (kelvinRadio.Checked)
            {
                unidadeLabel.Text = "K";
                escritor.Write("kelvin");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
