using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern
{
    // интерфейс стратегии
    public interface IPrintStrategy
    {
        void Print(string document);
    }
    // стратегия для обычной печати
    public class SimplePrintStrategy : IPrintStrategy
    {
        public void Print(string document)
        {
            Console.WriteLine($"Простая печать: {document}");
        }
    }
    // стратегия для двусторонней печати
    public class DuplexPrintStrategy : IPrintStrategy
    {
        public void Print(string document)
        {
            Console.WriteLine($"Двусторонняя печать: {document}");
        }
    }
    public class Printer
    {
        private IPrintStrategy _printStrategy;

        public void SetPrintStrategy(IPrintStrategy printStrategy)
        {
            _printStrategy = printStrategy;
        }

        public void PrintDocument(string document)
        {
            if (_printStrategy == null)
            {
                Console.WriteLine("Выберите стратегию печати.");
                return;
            }

            _printStrategy.Print(document);
        }
    }
    class Program
    {
        static void Main()
        {
            // Создаем принтер
            var printer = new Printer();

            // Устанавливаем стратегию
            printer.SetPrintStrategy(new SimplePrintStrategy());
            printer.PrintDocument("Документ для простой печати");

            // Меняем стратегию
            printer.SetPrintStrategy(new DuplexPrintStrategy());
            printer.PrintDocument("Документ для двусторонней печати");
        }
    }

}
