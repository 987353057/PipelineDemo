using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using StriveEngine;
using Pipeline;

namespace PipelineServer
{
    class Program
    {
        private void tcpServerEngine_MessageReceived(IPEndPoint client, byte[] bytes)
        {
            string msg = System.Text.Encoding.UTF8.GetString(bytes); // 消息使用UTF-8编码
            msg = msg.Substring(0, msg.Length - 1); // 将结束标记"\0"剔除
            Console.WriteLine("接受消息：" + msg);
        }

        private void tcpServerEngine_ClientDisconnected(IPEndPoint client)
        {
            Console.WriteLine(client + "连接断开");
        }

        private void tcpServerEngine_ClientConnected(IPEndPoint client)
        {
            Console.WriteLine(client + "连接成功");
        }

        private void tcpServerEngine_ClientCountChanged(int count)
        {
            Console.WriteLine("当前连接数：" + count);
        }

        static void Main(string[] args)
        {
            Server server = new Server();
            Program program = new Program ();
            while (true)
            {
                string directive = Console.ReadLine();
                if (directive == "close")
                {
                    server.Close();
                    Console.WriteLine("关闭监听");
                    Console.ReadKey();
                    break;
                }
                else if (directive == "start")
                {
                    server.Start(
                        new CbDelegate<int>(program.tcpServerEngine_ClientCountChanged),
                        new CbDelegate<IPEndPoint>(program.tcpServerEngine_ClientConnected),
                        new CbDelegate<IPEndPoint>(program.tcpServerEngine_ClientDisconnected),
                        new CbDelegate<IPEndPoint, byte[]>(program.tcpServerEngine_MessageReceived)
                        );
                    Console.WriteLine("开始监听");
                }
                else if (directive == "pause")
                {
                    server.Pause();
                }
                else if (directive == "send")
                {
                    List<IPEndPoint> list = server.GetClientList();
                    if (list.Count > 0)
                    {
                        Console.WriteLine("当前连接的客户端如下，请选择客户端（请输入客户端的序号）");
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine((i + 1) + "、" + list[i].Address);
                        }
                        int clientIndex;
                        while (true)
                        {
                            string clientIndexStr = Console.ReadLine();
                            if (int.TryParse(clientIndexStr, out clientIndex))
                            {
                                if (list.Count >= clientIndex && clientIndex > 0)
                                    break;
                            }
                        }
                        Console.WriteLine("请输入需要发送的消息");
                        string msg = Console.ReadLine();
                        server.Send(list[clientIndex-1], msg);
                    }   
                }
            }
        }
    }
}
