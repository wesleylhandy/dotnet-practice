using System;

namespace DataStructures
{
    class Program
    {

        static void Main(string[] args)
        {
            // Converter<double, string> converter = d => d.ToString();
            // Action<double> print = d => Console.WriteLine(d);
            // Func<double, double> square = d => d * d;
            // Func<double, double, double> add = (x, y) => x + y;
            // Predicate<double> isLessThan10 = d => d < 10;

            var buffer = new CircularBuffer<double>(capacity:3);
            buffer.ItemDiscarded += ItemDiscarded;

            ProcessInput(buffer);

            // Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);

            // var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));
            // foreach( var item in asDates)
            // {
            //     Console.WriteLine(item);
            // }
            ProcessBuffer(buffer);
        }

        private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
           Console.WriteLine("Buffer full. Discarding {0} New Item is {1}", e.ItemDiscarded, e.NewItem);
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while(!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while( true )
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
