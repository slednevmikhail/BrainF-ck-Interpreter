using System;

namespace Brainfuck
{
    public class Program
    {
        static void Main()
        {
            Pointer.GetStartPosition();
            Console.ReadLine().Parse();
            for (Interpreter.currentIndex = 0; Interpreter.currentIndex < Parser.ParsedCode.Length; Interpreter.currentIndex++)
            {
                var currentSymbol = Parser.ParsedCode[Interpreter.currentIndex];
                Interpreter.DoSymbolAction(currentSymbol);
            }
            for (int i = 0; i < 11; i++)
                Console.Write(" [{0}] ", Memory.mainMemory[i]);
        }
    }

}
