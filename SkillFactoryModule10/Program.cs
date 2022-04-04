// See https://aka.ms/new-console-template for more information
using System; // Подключенное пространство имен

namespace FirstApplication.ConsoleApp
{
    static class Program
    {
        public static void Main()
        {
            var log = new Logger();
            var calculator = new Calculator(log);
            while (true)
            {
                try
                {
                    log.LogInfo("Enter first number");
                    
                    var first = float.Parse(Console.ReadLine());

                    log.LogInfo("Enter second number");
                    var second = float.Parse(Console.ReadLine());
                    log.LogInfo($"The answer is {calculator.Add(first, second)}");
                    
                }
                catch (Exception e)
                {
                    log.LogError("The value wasn't correct! Try again");
                }
                
            }
        }
    }

    public class MyException : Exception
    {
        //public override string Message => "My ex";

        public MyException() : base("This is my exception from hell (production hell)")
        {
        }
    } 
    public interface IAddition<T>
    {
        public T Add(T first, T second);
    }

    public class Calculator : IAddition<int>, IAddition<float>
    {
        private Logger log;
        public Calculator(Logger log)
        {
            this.log = log;
        }

        public int Add(int first, int second)
        {
            log.LogInfo($"trying to add {first} and {second}");
            return first + second;
        }

        public float Add(float first, float second)
        {
            log.LogInfo($"trying to add {first} and {second}");
            return first + second;
        }
    }

    public class Logger
    {
        public void LogError(string error)
        {
            var oldColor = Console.ForegroundColor; 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = oldColor;
        }
        public void LogInfo(string info)
        {
            var oldColor = Console.ForegroundColor; 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(info);
            Console.ForegroundColor = oldColor;
        }
    }
}
