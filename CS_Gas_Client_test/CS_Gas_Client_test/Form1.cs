using System.Globalization;
using System.Net.Sockets;
using static System.Windows.Forms.AxHost;

namespace CS_Gas_Client_test
{
    public partial class Form1 : Form
    {
        //---
        //add public member
        public TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        public BinaryReader br;
        public BinaryWriter bw;
        public String StrResult = "";
        //---add public member
        private void SendCommand(byte[] Command)
        {
            try
            {
                NetworkStream clientStream = clientSocket.GetStream();
                bw = new BinaryWriter(clientStream);
                bw.Write(Command);

                bool blnloop = true;
                byte[] inBuf = new byte[200];
                byte[] inStream = new byte[2000];

                int intLen = 0;
                do
                {
                    Thread.Sleep(200);
                    br = new BinaryReader(clientStream);
                    int len = br.Read(inBuf, 0, inBuf.Length);
                    Array.Copy(inBuf, 0, inStream, intLen, len);
                    intLen+= len;
                    int count = (inStream[2] << 8) | inStream[1];//convert two bytes into an integer
                    if (count>= (intLen-3))
                    {
                        blnloop=false;
                    }
                } while (blnloop);
                
                


                StrResult = "";

                for (int i = 0; i < intLen; i++)//show hex
                {
                    if (i == 0)
                    {
                        StrResult += Convert.ToString(inStream[i], 16).ToUpper().PadLeft(2, '0');
                    }
                    else
                    {
                        StrResult += "," + Convert.ToString(inStream[i], 16).ToUpper().PadLeft(2, '0');
                    }
                }
            }
            catch (Exception ex) 
            {
                StrResult = ex.ToString();
            }
            initUI(false, "接收到的資料: "+StrResult);

        }
        private void initUI(bool state = true, String StrInfo = "")
        {
            textBox1.Enabled = state;
            textBox2.Enabled = state;
            button1.Enabled = state;

            textBox3.Enabled = !state;
            button2.Enabled = !state;

            richTextBox1.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ~") + StrInfo + "\r\n";
        }
        public Form1()
        {
            InitializeComponent();
            initUI();
        }

        private void button1_Click(object sender, EventArgs e)//設備連線
        {
            try
            {
                clientSocket.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
                if (clientSocket.Connected)
                {
                    initUI(false,$"設備: {textBox1.Text}:{textBox2.Text} 連線成功");
                }
                else
                {
                    initUI(true, $"設備: {textBox1.Text}:{textBox2.Text} 連線失敗");
                }
            }
            catch( Exception ex )
            {
                initUI(true, $"程式連線系統錯誤: {ex.ToString()}");
            }
        }

        private void button2_Click(object sender, EventArgs e)//命令傳送
        {
            string[] strs = textBox3.Text.Split(',');
            byte[] command = new byte[strs.Length];

            for(int i=0;i<strs.Length; i++)
            {
                command[i] = (byte)Int32.Parse(strs[i], NumberStyles.HexNumber);
            }
            initUI(false, "傳送的命令: " + textBox3.Text);
            SendCommand(command);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((clientSocket != null) && (clientSocket.Connected))
            {
                clientSocket.Close();
            }
        }
    }
}
