using System;

namespace Brainfuck
{
    public class Program : Interpreter
    {
        static void Main()
        {
            Code = Console.ReadLine();
            for (CurrentIndex = 0; CurrentIndex < Code.Length; CurrentIndex++)
            {
                DoCommand(Code[CurrentIndex]);
            }
            for (int i = 0; i < 11; i++)
                Console.Write("[{0}] ", Memory[i]);
        }
    }
}
