using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChannelDemo
{
    public class Program
    {
        private readonly MyChannel<int> _myChannel = new MyChannel<int>();

        private static async Task Main()
        {
            await new Program().WriteThenReadByUsingCustomChannel();
        }

        public async Task WriteThenReadByUsingCustomChannel()
        {
            Console.WriteLine("Main Thread:" + Thread.CurrentThread.ManagedThreadId);

            _ = Task.Run(async () =>
            {
                Console.WriteLine("Producer Thread:" + Thread.CurrentThread.ManagedThreadId);
                for (var message = 0; message < 10; message++)
                {
                    await Task.Delay(1000);
                    _myChannel.Write(message);
                }
                _myChannel.Complete();
            });

            Console.WriteLine("Consumer Thread:" + Thread.CurrentThread.ManagedThreadId);
            while (!_myChannel.IsComplete())
            {
                var result = await _myChannel.ReadAsync();
                Console.WriteLine(result);
            }
        }
    }
}
