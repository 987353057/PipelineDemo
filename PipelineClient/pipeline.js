(function () {
  if (typeof(WebSocket) !== 'undefined') {
    window.pipeline = {
      createClient: function (host) {
        return {
          host: host || 'ws://127.0.0.1:65531',
          webSocket: null,
          state: ['connecting', 'connected', 'disconnecting', 'disconnected'],
          getState: function () {
            if (this.webSocket === null) {
              return 'unconnected';
            } else {
              return this.state[this.webSocket.readyState];
            }
          },
          connect: function (connectCallBack, messageCallBack, disconnectCallBack, errorCallBack) {
            this.webSocket = new WebSocket(this.host);
            this.webSocket.onopen = function ()
            {
              if (connectCallBack) {
                connectCallBack();
              }
            }
            this.webSocket.onmessage = function (event)
            {
              // event.data
              if (messageCallBack) {
                messageCallBack(event.data);
              }
            }
            this.webSocket.onclose = function ()
            {
              if (disconnectCallBack) {
                disconnectCallBack();
              }
            }
            this.webSocket.onerror = function (error) {
              if (errorCallBack) {
                errorCallBack();
              }
            }
          },
          send: function (msg) {
            if (this.webSocket !== null) {
              if (this.getState() === 'connected') {
                this.webSocket.send(msg + '\0');
              }
            }
          },
          disconnect: function () {
            if (this.webSocket !== null) {
              if (this.getState() === 'connected') {
                this.webSocket.close();
                this.webSocket = null;
              }
            }
          }
        }
      } 
    }
  } else {
    console.log('browser is not compatible with pipeline');
  }
})()
