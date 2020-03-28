# PipelineDemo

    前端教程：
    <!DOCTYPE html>
    <html>
      <head>
        <meta charset="utf-8">
        <title>pipeline</title>
      </head>
      <body>

       <script src="./pipeline.js"></script>
     </body>
    </html>

    var client = pipeline.createClient(); // 新建客户端
    client.connect(connectCallBack, messageCallBack, disconnectCallBack, errorCallBack); // 连接服务端
    client.getState(); // 获取客户端连接状态：'unconnected'、'connecting'、'connected'、'disconnecting'、'disconnected'
    client.send('hello'); // 向服务端发送消息

    后端教程：
    项目引入Pipeline.dll、StriveEngine.dll
    Server server = new Server(); // 新建服务端
    server.Start(
            CbDelegate<int> clientCountChanged,
            CbDelegate<IPEndPoint> clientConnected,
            CbDelegate<IPEndPoint> clientDisconnected,
            CbDelegate<IPEndPoint, byte[]> messageReceived
            ); // 开启服务端
    server.ReStart(); // 重启服务端
    server.Pause(); // 暂停服务端（可以继续接收已连接客户端的消息）
    server.Close(); // 关闭服务端
    server.Send(IPEndPoint client, string msg); // 向客户端发送消息
    server.GetClientList(); // 获取所有连接客户端

    联系方式：987353057@qq.com

    感谢支持：
![](https://github.com/987353057/PipelineDemo/blob/987353057-patch-1/1585396041.png)
