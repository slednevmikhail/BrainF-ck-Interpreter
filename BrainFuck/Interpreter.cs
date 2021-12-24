using System;

namespace Brainfuck
{
    public class Interpreter
    {
        public static int currentIndex = 0;
        public static void DoSymbolAction(char symbol)
        {
            if (symbol == '>') Pointer.MoveRight();
            else if (symbol == '<') Pointer.MoveLeft();
            else if (symbol == '[')
            {
                if (Memory.mainMemory[Pointer.position] == 0)
                    Loop.GoToNextBrackets();
            }
            else if (symbol == ']')
            {
                if (Memory.mainMemory[Pointer.position] != 0)
                    Loop.GoToNextBrackets();
            }
            else if (symbol == '+')
                Memory.mainMemory[Pointer.position] += 1;
            else if (symbol == '-')
                Memory.mainMemory[Pointer.position] -= 1;
            else if (symbol == ',')
                Memory.mainMemory[Pointer.position] += int.Parse(Console.ReadLine());
            else if (symbol == '.')
                Console.WriteLine(Memory.mainMemory[Pointer.position]);
        }
    }
    public static class Loop
    {
        private static int openedBrackets;
        private static int closedBrackets;
        public static void GoToNextBrackets()
        {
            CountBrackets();
            while (openedBrackets != closedBrackets)
            {
                if (openedBrackets > closedBrackets) Interpreter.currentIndex += 1;
                if (openedBrackets < closedBrackets) Interpreter.currentIndex -= 1;
                CountBrackets();
            }
            if (Parser.ParsedCode[Interpreter.currentIndex] == '[') Interpreter.currentIndex -= 1;
        }
        public static void CountBrackets()
        {
            if (Parser.ParsedCode[Interpreter.currentIndex] == ']')
                closedBrackets += 1;
            if (Parser.ParsedCode[Interpreter.currentIndex] == '[')
                openedBrackets += 1;
        }

    }

}
