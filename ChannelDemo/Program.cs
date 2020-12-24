using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Int32;

namespace ChannelDemo
{
    public class Program
    {
        private static async Task Main()
        {
            var demos = new List<IChannelDemo>
                { 
                    new MyChannelDemo(),
                    new BoundedChannelDemo(),
                    new UnboundedChannelDemo()
                };
            do
            {
                Console.WriteLine(@"Select your option: 1. MyChannel 2. BoundedChannel 3.UnboundedChannel");
                if (TryParse(Console.ReadLine(), out var option))
                {
                    if (option < 1 || option > 4) Console.WriteLine("Invalid Option");
                    await demos[option - 1].Run();
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
                Console.WriteLine("Would you like to continue? [Y]es | [N]o:");
            } while (Console.ReadLine()?.ToLower() == "y");
        }
    }
}
