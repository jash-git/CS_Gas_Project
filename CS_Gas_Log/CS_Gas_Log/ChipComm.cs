using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS_Gas_Log
{

    public class ChipComm
    {
        private TcpClient clientSocket = null;
        private byte[] MainCommand = new byte[200];
        public string StrResult = "";

        static private byte[] Int2TwoByte(int value)
        {
            byte[] bytResult = new byte[2];

            bytResult[0] = (byte)((value >> 8) & 0xFF); // Get the higher byte
            bytResult[1] = (byte)(value & 0xFF); // Get the lower byte

            return bytResult;
        }
        static public byte[] Function2Command(string strFunName,string strParam,ref int len)
        {
            byte[] bytResult = null;
            switch(strFunName)
            {
                case "Log":
                    bytResult = new byte[2] { 0x08, 0x42 };
                    break;
                case "SetTime":
                    bytResult = new byte[10];
                    bytResult[0] = 0x08;
                    bytResult[1] = 0x01;
                    Array.Copy(Int2TwoByte(DateTime.Now.Year), 0, bytResult, 2, 2);
                    bytResult[4] = (byte)DateTime.Now.Month;
                    bytResult[5] = (byte)DateTime.Now.Day;
                    bytResult[6] = (byte)DateTime.Now.Hour;
                    bytResult[7] = (byte)DateTime.Now.Minute;
                    bytResult[8] = (byte)DateTime.Now.Second;
                    bytResult[9] = (byte)DateTime.Now.DayOfWeek;
                    break;
            }
            if(bytResult!=null)
            {
                len = bytResult.Length;
            }
            else
            {
                len = 0;
            }
            return bytResult;
        }

        private string ByteArray2HexString(byte[] byteArray,int intLen)
        {
            string strResult = "";
            try
            {
                for (int i = 0; i < intLen; i++)//show hex
                {
                    if (i == 0)
                    {
                        strResult += Convert.ToString(byteArray[i], 16).ToUpper().PadLeft(2, '0');
                    }
                    else
                    {
                        strResult += "," + Convert.ToString(byteArray[i], 16).ToUpper().PadLeft(2, '0');
                    }
                }
            }
            catch 
            {
                strResult = "";
            }

            return strResult;
        }
        public void Close()
        {
            if ((clientSocket != null) && (clientSocket.Connected))
            {
                clientSocket.Close();
                clientSocket = null;
            }
        }

        public bool Connect(string host, int port)
        {
            bool blnResult = false;

            Close();
            try
            {
                clientSocket = new System.Net.Sockets.TcpClient();
                clientSocket.Connect(host, port);
                if (clientSocket.Connected)
                {
                    blnResult = true;
                    StrResult = $"設備: {host}:{port} 連線成功";
                }
                else
                {
                    blnResult = false;
                    StrResult = $"設備: {host}:{port} 連線失敗";
                }
            }
            catch (Exception ex)
            {
                blnResult = false;
                StrResult = $"程式連線系統錯誤: {ex.ToString()}";
            }

            return blnResult;
        }

        public string SendCommand(byte[] Command, int len)
        {
            string strResult = "";
            BinaryReader br;
            BinaryWriter bw;

            if(len == 0)
            {
                StrResult = $"指令產生錯誤";
                return strResult;
            }
            
            int Len = len + 3;//
            Array.Clear(MainCommand, 0, MainCommand.Length);

            MainCommand[0] = 0x05;
            MainCommand[1] = (byte)((len >> 8) & 0xFF); // Get the higher byte
            MainCommand[2] = (byte)(len & 0xFF); // Get the lower byte
            Array.Copy(Command, 0, MainCommand, 3, len);

            strResult = ByteArray2HexString(MainCommand, Len);

            try
            {
                NetworkStream clientStream = clientSocket.GetStream();
                bw = new BinaryWriter(clientStream);
                bw.Write(MainCommand, 0, Len);

                bool blnloop = true;
                byte[] inBuf = new byte[200];
                byte[] inStream = new byte[2000];


                Thread.Sleep(200);
                br = new BinaryReader(clientStream);
                int intLen = br.Read(inBuf, 0, inBuf.Length);
                Array.Copy(inBuf, 0, inStream, 0, intLen);

                StrResult = ByteArray2HexString(inStream, intLen);
            }
            catch (Exception ex)
            {
                StrResult = $"程式傳送命令系統錯誤: {ex.ToString()}";
            }

            return strResult;
        }

    }
}
