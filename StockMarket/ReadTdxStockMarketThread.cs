using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Stock.Market
{
    public class ReadTdxStockMarketThread : ReadStockMarketThread
    {
        TcpClient client;

        public override void Run()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Parse("218.18.103.38"), 7709);

        }

    }
}
