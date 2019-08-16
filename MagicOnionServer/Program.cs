using System;
using Grpc.Core;
using MagicOnion.Server;

namespace MagicOnionServer
{
    class Program
    {
        private static readonly string serverIp = "10.32.154.25";

        static void Main(string[] args)
        {
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);

            var server = new global::Grpc.Core.Server
            {
                Services = { service },
                Ports = { new ServerPort(serverIp, 12345, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.ReadLine();
        }
    }
}
