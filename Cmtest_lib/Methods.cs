using System;
using System.Text;
using System.Linq;
using System.IO.Ports;
using System.Threading;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Cmtest_lib
{
    public static class Methods
    {
        #region 宣告
        public  static BackgroundWorker bgwWorker = new BackgroundWorker();
        #endregion
        #region UART Setting
        public static String UART_baud = "115200"; //鮑率
        public static string UART_Comport = "COM1"; //端口
        public static string UART_Databite = "8"; //資料位元
        public static string UART_stopbit=  "One"; //停止位元
        public static string UART_Parity = "None"; //同為檢查
        public static string UART_flow_control = "None"; //流量控制
        public static SerialPort serialPort = new SerialPort();
        public static Thread Serial_thread;
        #endregion
        public static void Test() 
        {
            string str = "aaaa";
            double aaaa = Convert.ToDouble(str);
            if (aaaa%1 == 0)
            {
                Console.WriteLine("{0}整數 ",str);
            
            }
            else 
            {
                Console.WriteLine("{0}小數",str);
            }
            //bool isNumeric = Regex.IsMatch(str, @"^([+-]?)/d*[.]?/d*$");
            //Console.WriteLine(isNumeric);
        }
        #region Device 
        #region Backupgroud
        private static void bgwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string receive = "";//数据接收


            if (serialPort.IsOpen)
            {
                Console.WriteLine("test1");
                try
                {
                    for (int j = 0; j < j + 2; j++)
                    {
                        Thread.Sleep(50);  //（毫秒）等待一定时间，确保数据的完整性 int len        
                        int len = serialPort.BytesToRead;
                        Console.WriteLine(len.ToString());
                        if (len != 0)
                        {
                            byte[] buff = new byte[len];
                            serialPort.Read(buff, 0, len);
                            receive = Encoding.Default.GetString(buff);//数据接收内容
                            Console.WriteLine(receive);

                            ///RX_TXT.Refresh();
                        }

                    }

                }
                catch
                {
                    // ToolData.WriteLog(lrtxtLog, "接收数据出错", 1);
                    return;
                }

            }
            else
            {
                return;
            }
        }
        public static void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        #endregion
        public static void Disconnect(string Device_name) 
        {
            if (serialPort.IsOpen)
            {

                Console.WriteLine("Dis");
             //   Serial_thread.Abort();
                serialPort.Close();               
            }
        
        }
        public static void Connect(string Device_name)
        {
            try 
            {
                int Check = Device_name.IndexOf("COM");
                if (Check == 0 && !serialPort.IsOpen) 
                {
                    Console.WriteLine("connect");
                    //Com port name
                    serialPort.PortName = Device_name;
                    //Setting BaudRate
                    int BaudRate = Convert.ToInt32(UART_baud);
                    serialPort.BaudRate = BaudRate;
                    //Setting Databite
                    int DataRate = Convert.ToInt32(UART_Databite);
                    serialPort.DataBits = DataRate;
                    //Setting Parity
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), UART_Parity);
                    //Setting Stop bit
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), UART_stopbit);
                    //Setting Flow control
                    serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), UART_flow_control);
                    // 讀取作業未完成時，發生逾時之前的毫秒數。
                    serialPort.ReadTimeout = 500;
                    //發生逾時之前的毫秒數。
                    serialPort.WriteTimeout = 500;
                    serialPort.Open();
                     serialPort.DataReceived += serialPort_DataReceived;
                  //  Serial_thread = new Thread(SerialPort_Received);
                  //  Serial_thread.Start();


                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            

        }
        public static void UART_list() 
        {
            try
            {
                string[] names = SerialPort.GetPortNames();
                for (int k = 0; k < names.Count(); k++)
                {
                    Console.WriteLine(names[k]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            
            }

            
            

        }
        private static void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receive = "";//数据接收


            if (serialPort.IsOpen)
            {
                Console.WriteLine("test1");
                try
                {
                    for (int j = 0; j < j + 2; j++)
                    {
                        Thread.Sleep(50);  //（毫秒）等待一定时间，确保数据的完整性 int len        
                        int len = serialPort.BytesToRead;
                        Console.WriteLine(len.ToString());
                        if (len != 0)
                        {
                            byte[] buff = new byte[len];
                            serialPort.Read(buff, 0, len);
                            receive = Encoding.Default.GetString(buff);//数据接收内容
                            Console.WriteLine(receive);

                            ///RX_TXT.Refresh();
                        }

                    }

                }
                catch
                {
                    // ToolData.WriteLog(lrtxtLog, "接收数据出错", 1);
                    return;
                }

            }
            else
            {
                return;
            }


        }
        public static void Send(String Device_name, String Command) 
        {
            int Check = Device_name.IndexOf("COM");
            if (Check == 0 && serialPort.IsOpen) 
            {
              
                bool Check1 = Command.Contains("\r\n");
                Console.WriteLine(Command);
                if (Check1)
                {
                    string[] Sub = Command.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    int Max_count = Sub.Count();
                    int count = 0;
                    while(count < Max_count) 
                    {
                        if (Sub[count] == null)
                        {
                            break;
                        }
                        string cmd = Sub[count];
                        Console.WriteLine(cmd);
                        serialPort.WriteLine(cmd + '\r' + '\n');
                        count++;
                    }
                }
            }
        
        }
        #endregion
        public static int Sum(int a, int b)
        {
            return a + b;
        }
         public static int Product(int a, int b)
        {
            return a * b;
        }
        public static bool IsNumber(string str)
        {
            if (str == null || str.Length == 0)    //驗證這個引數是否為空
                return false;                           //是，就返回False
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的例項
            byte[] bytestr = ascii.GetBytes(str);         //把string型別的引數儲存到數組裡

            foreach (byte c in bytestr)                   //遍歷這個數組裡的內容
            {
                if (c < 48 || c > 57)                          //判斷是否為數字
                {
                    ////判斷是否是數值，有小數點
                    bool isNumeric = str.Contains(".");
                    if (isNumeric) 
                    {
                        try 
                        {
                            double aaaa = Convert.ToDouble(str);

                            if (aaaa % 1 != 0)
                            {
                               // Console.WriteLine("isNumeric");
                                return true;

                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("不是數字");
                        }
                       
                    }
                    else
                    return false;                              //不是，就返回False
                }
            }
            return true;                                        //是，就返回True
        }
        public static bool Split_string(string input,char[] split_char) 
        {
            String out_str = "";
            try 
            {
                string[] Str_split = input.Split(split_char, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < Str_split.Count(); k++)
                {
                    if (Str_split[k] != "" && Str_split[k] != " ")
                    {
                        out_str = Str_split[k];
                        Console.WriteLine(out_str);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

         //   return out_str;
        }
        public static void Split_str_Ind(string input, char[] split_char,int count)
        {
           // String out_str = "";
            try
            {
                string[] Str_split = input.Split(split_char, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(Str_split[count]);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            //   return out_str;
        }


    }
}
