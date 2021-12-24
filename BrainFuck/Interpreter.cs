using System;

namespace Brainfuck
{
    public class Interpreter
    {
        public static string Code;
        public static int[] Memory = new int[100];
        public static int CurrentIndex;
        public static int PointerPos;
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
                    if (Memory[PointerPos] == 0)
                        Loop.GoToBracket();
                    break;
                case ']':
                    if (Memory[PointerPos] != 0)
                    {
                        Loop.GoToBracket();
                        CurrentIndex -= 1;
                    }
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

    public class Loop: Interpreter
    {
        private static int bracketsTracker;
        public static void GoToBracket()
        {
            TrackBrackets();
            while (bracketsTracker != 0)
            {
                if (bracketsTracker < 0) CurrentIndex += 1;
                    else CurrentIndex -= 1;
                TrackBrackets();
            }
        }
        public static void TrackBrackets()
        {
            if (Code[CurrentIndex] == ']')
                bracketsTracker += 1;
            if (Code[CurrentIndex] == '[')
                bracketsTracker -= 1;
        }

    }

}
