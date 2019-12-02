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

namespace Servidor
{
    // servidor que espera conexões do cliente (uma por vez) e
    // permite uma conversa entre o cliente e o servidor
    public partial class Form1 : Form
    {
        private Socket conexao;
        private Thread threadLeitura;

        private NetworkStream fluxoDeRede;
        private BinaryWriter escritor;
        private BinaryReader leitor;

        private string unidade = "";

        public Form1()
        {
            InitializeComponent();

            foreach (string serial in System.IO.Ports.SerialPort.GetPortNames())
            {
                serialSelect.Items.Add(serial);
            }

            threadLeitura = new Thread(new ThreadStart(rodarServidor));
            threadLeitura.Start();
        }

        public void rodarServidor()
        {
            TcpListener servidor;
            int contador = 1;

            // espera por uma conexão de cliente e exibe o texto
            // que o cliente envia
            try
            {
                // Passo 1: cria TcpListener
                IPAddress endereco = IPAddress.Parse("127.0.0.1");
                servidor = new TcpListener(endereco, 9900);

                // Passo 2: TcpListener espera pela requisição do cliente
                servidor.Start();

                // Passo 3: estabelece a conexão na requisição do cliente
                while (true)
                {
                    this.ImprimeTexto(textBoxReceber.Text + "Aguardando conexão.\r\n");

                    // aceita uma conexão recebida
                    conexao = servidor.AcceptSocket();

                    // cria objeto NetworkStream associado ao soquete
                    fluxoDeRede = new NetworkStream(conexao);

                    // cria objetos para transferir dados por meio de fluxo
                    escritor = new BinaryWriter(fluxoDeRede);
                    leitor = new BinaryReader(fluxoDeRede);

                    this.ImprimeTexto(textBoxReceber.Text + "Conexão " + contador + " recebida.\r\n");

                    //string mensagem = "";

                    // Passo 4: lê dados da string enviada do cliente
                    do
                    {
                        try
                        {
                            if(conexao.ReceiveBufferSize > 0) { 
                                unidade = leitor.ReadString();
                                Console.WriteLine("Unidade: "+unidade);
                                this.ImprimeTexto(textBoxReceber.Text + "\r\nUnidade: " + unidade);
                            }
                        }

                        
                        catch (Exception)
                        {
                            break;
                        }

                    } while (conexao.Connected);

                    this.ImprimeTexto(textBoxReceber.Text + "\r\nUsuário encerrou a conexão.");

                    // Passo 5: fecha a conexão
                    //inputTextBox.ReadOnly = true;
                    escritor.Close();
                    leitor.Close();
                    fluxoDeRede.Close();
                    conexao.Close();

                    ++contador;
                }
            } // fim de try

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        } // fim do método rodarServidor

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

        private void sensorPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int msgSize = sensorPort.BytesToRead;
            byte[] received = new byte[msgSize];
            int cont = 0;
            int valor_sensor = 0;
            while (sensorPort.BytesToRead > 0)
            {
                received[cont++] = Convert.ToByte(sensorPort.ReadByte());
                //Console.WriteLine("recebido: " + received[cont - 1]);
            }

            byte[] checksumArray = BitConverter.GetBytes(checkSum(received));


            if (received[0] == 0x12
                && received[1] == 97
                && received[2] == received.Length
                && received[received.Length - 3] == checksumArray[0]
                && received[received.Length - 2] == checksumArray[1]
                && received[received.Length - 1] == 0x13)
            {
                //message = Encoding.ASCII.GetString(received, 3, received.Length - 6);
                valor_sensor = BitConverter.ToInt16(received, 3);
                //Console.WriteLine("message: "+valor_sensor.ToString());
            }

            //int valor_sensor = int.Parse(message);

            double valor_convertido = Math.Round(calcula_sensor(valor_sensor),2);
            Console.WriteLine("unidade_:" + unidade);
            if (unidade != "")
            {
                Console.WriteLine("valor_convertido: " + valor_convertido);
                escritor.Write(valor_convertido.ToString());
            }
        }

        private double calcula_sensor(int valor_sensor)
        {
            //LM35: 1ºC/10mV (datasheet)
            //Arduino: 0 - 1023 (analogRead) => 0v - 5v
            //Para encontrar a temperatura em celsius, basta converter o valor analógico lido para tensão e dividir por 10mV
            double valor_calculado = (valor_sensor * 5.0 / 1023.0) / 0.01;
            if (unidade == "fahrenheit")
            {
                //Conversão Celsius para Fahrenheit
                valor_calculado = (9.0/5.0 * valor_calculado) + 32.0;
            }
            else if (unidade == "kelvin")
            {
                //Conversão Celsius para Kelvin
                valor_calculado = valor_calculado + 273.15;
            }
            return valor_calculado;
        }

        private UInt16 checkSum(byte[] data)
        {
            UInt16 cs = 0;
            for (int i = 0; i < data.Length - 3; i++)
            {
                cs += data[i];
            }
            return cs;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!sensorPort.IsOpen)
            {
                sensorPort.PortName = serialSelect.SelectedItem.ToString();
                sensorPort.Open();
                connectButton.Text = "Disconnect";
                Console.WriteLine(""+sensorPort.IsOpen);
            }
            else
            {
                sensorPort.Close();
                connectButton.Text = "Connect";
            }
        }
    }
}
