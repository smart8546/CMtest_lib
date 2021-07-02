using System;
using System.Text;
using System.Linq;
using System.IO.Ports;
using System.Threading;
using Microsoft.VisualBasic;


namespace Cmtest_lib
{
    public static class Methods
    {
        #region UART Setting
        public static String UART_baud = "115200"; //鮑率
        public static string UART_Comport = "COM1"; //端口
        public static string UART_Databite = "8"; //資料位元
        public static string UART_stopbit=  "1"; //停止位元
        public static string UART_Parity = "Null"; //同為檢查
        public static string UART_flow_control = "Null"; //流量控制
        #endregion
        public static void Test() 
        {
            
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
