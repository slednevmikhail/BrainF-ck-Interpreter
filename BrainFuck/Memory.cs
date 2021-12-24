using System;
using System.Collections.Generic;

namespace Brainfuck
{
    public static class Memory
    {
        public static int[] mainMemory = new int[100];
    }
    public static class Pointer
    {
        public static int position;

        public static void GetStartPosition()
        {
            position = 0;
        }
        public static void MoveRight()
        {
            position += 1;
        }
        public static void MoveLeft()
        {
            if (position < 1) throw new ArgumentException("slishkom VLEVO");
            position -= 1;
        }
    }

}
