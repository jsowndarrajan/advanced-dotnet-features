using System;
using System.Threading.Tasks;

namespace ChannelDemo
{
    public class MyChannelDemo : IChannelDemo
    {
        private readonly MyChannel<int> _myChannel = new MyChannel<int>();

        public async Task Run()
        {
            _ = Task.Run(async () =>
            {
                for (var message = 0; message < 12; message++)
                {
                    Console.WriteLine($"w:{message}");
                    await Task.Delay(500);
                    _myChannel.Write(message);
                }
                _myChannel.Complete();
            });

            while (!_myChannel.IsComplete())
            {
                var result = await _myChannel.ReadAsync();
                Console.WriteLine($"r:{result}");
            }
        }
    }
}