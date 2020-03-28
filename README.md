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

    var client pipeline.createClient(); // 调用pipeline.createClient()构建客户端对象
    client.connect(connectCallBack, messageCallBack, disconnectCallBack, errorCallBack); // 调用conne()方法连接服务端程序
    client.getState(); // 调用getState()方法获取客户端连接状态，包含状态'unconnected'、'connecting'、'connected'、'disconnecting'、'disconnected'
    client.send('hello'); // 调用send(msg)方法向服务端发送消息

    后端教程
    项目引入Pipeline.dll、StriveEngine.dll
    Server server = new Server(); // 创建服务端对象
    server.Start(
            CbDelegate<int> clientCountChanged,
            CbDelegate<IPEndPoint> clientConnected,
            CbDelegate<IPEndPoint> clientDisconnected,
            CbDelegate<IPEndPoint, byte[]> messageReceived
            ); // 开始服务端
    server.ReStart(); // 用户暂停服务端后重启服务端
    server.Pause(); // 暂停服务端（可以接收已连接客户端的消息）
    server.Close(); // 关闭服务端
    server.Send(IPEndPoint client, string msg); // 向客户端发送消息
    server.GetClientList(); // 获取所有连接客户端

    作者联系方式：987353057@qq.com
    感谢支持：
    
