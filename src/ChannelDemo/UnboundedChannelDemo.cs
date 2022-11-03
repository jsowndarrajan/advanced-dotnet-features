using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelDemo
{
    public class UnboundedChannelDemo : IChannelDemo
    {
        public async Task Run()
        {
            var boundedChannel = Channel.CreateUnbounded<int>();

            _ = Task.Run(async () =>
            {
                for (var message = 0; message < 12; message++)
                {
                    await Task.Delay(30);
                    Console.WriteLine($"w:{message}");
                    await boundedChannel.Writer.WriteAsync(message);
                }
                boundedChannel.Writer.Complete();
            });

            while (await boundedChannel.Reader.WaitToReadAsync())
            {
                await Task.Delay(90);
                Console.WriteLine($"r:{await boundedChannel.Reader.ReadAsync()}");
            }
        }
    }
}