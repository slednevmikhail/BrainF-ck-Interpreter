using System;

namespace Brainfuck
{
    public class Interpreter
    {
        public static string Code;
        public static int[] Memory = new int[100];
        public static int CurrentIndex;
        public static int PointerPos;
        public static OpeningBracket Bracket;
        public class OpeningBracket
        {
            public OpeningBracket PreviousBracket;
            public int BracketIndex;
        }
        public static void DoCommand(char symbol)
        {
            switch (symbol)
            {
                case '>':
                    PointerPos += 1;
                    break;
                case '<':
                    PointerPos -= 1;
                    break;
                case '[':
                    if (Memory[PointerPos] != 0)
                        Bracket = new OpeningBracket { BracketIndex = CurrentIndex, PreviousBracket = Bracket };
                    break;
                case ']':
                    if (Memory[PointerPos] != 0)
                    {
                        CurrentIndex = Bracket.BracketIndex;
                    }
                    else Bracket = Bracket.PreviousBracket;
                    break;
                case '+':
                    Memory[PointerPos] += 1;
                    break;
                case '-':
                    Memory[PointerPos] -= 1;
                    break;
                case ',':
                    Memory[PointerPos] += int.Parse(Console.ReadLine());
                    break;
                case '.':
                    Console.WriteLine(Memory[PointerPos]);
                    break;
            }
        }
    }
}
