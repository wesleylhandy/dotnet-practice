using System;
using System.Collections.Generic;

namespace Tips
{
    public enum Steps
    {
        Step1,
        Step2,
        Step3
    }

    public static class StringExtensions
    {
        public static TEnum ParseEnum<TEnum>(this string value) where TEnum: struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Step1";
            // will still fail if input is not a string
            var value = input.ParseEnum<Steps>();
            Console.WriteLine(value);

            var list = new List<Item>();
            list.Add(new Item<int>());
            list.Add(new Item<double>());

            var a = new Thing<int>();
            var b = new Thing<int>();
            var c = new Thing<string>();

            Console.WriteLine(Thing.InstanceCount);
        }

        // will fail with use of generic type parameters since not all types work with Mathematical operators
        // better to overload functions
        private static double SampledAverage(double[] numbers)
        {
            var count = 0;
            var sum = 0.0;
            for (int i = 0; i < numbers.Length; i+=2)
            {
                sum += numbers[i];
                count += 1;
            }
            return sum / count;
        }
        private static double SampledAverage(int[] numbers)
        {
            var count = 0;
            var sum = 0.0;
            for (int i = 0; i < numbers.Length; i+=2)
            {
                sum += numbers[i];
                count += 1;
            }
            return sum / count;
        }
    }

    public class Item<T> : Item
    {

    }

    public class Item
    {
        public Item()
        {
            InstanceCount += 1;
        }
        public static int InstanceCount;
    }

    public class Thing<T> : Thing
    {
    }

    public class Thing
    {
        public Thing()
        {
            InstanceCount += 1;
        }
        public static int InstanceCount;
    }
}
