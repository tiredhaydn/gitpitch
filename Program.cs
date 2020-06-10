using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnionTest01
{
    enum Mnemonic
    {
        PUSH32,
    }

    /*
     * Instructionのメモリイメージ
     * 
     *  0 +----------------------+
     *    |      Mnemonic        |
     *  4 +------+-------+-------+
     *    |  b1  |       |       |
     *  5 +------+       |       |
     *    |  b2  |   i   |   f   |
     *  6 +------+   1   |   1   |
     *    |  b3  |       |       |
     *  7 +------+       |       |
     *    |  b4  |       |       |
     *  8 +------+---------------+
     */
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
    struct Instruction
    {
        [System.Runtime.InteropServices.FieldOffset(0)]
        public Mnemonic mnemonic;

        [System.Runtime.InteropServices.FieldOffset(4)]
        public byte b1;

        [System.Runtime.InteropServices.FieldOffset(5)]
        public byte b2;

        [System.Runtime.InteropServices.FieldOffset(6)]
        public byte b3;

        [System.Runtime.InteropServices.FieldOffset(7)]
        public byte b4;

        [System.Runtime.InteropServices.FieldOffset(4)]
        public int i1;

        [System.Runtime.InteropServices.FieldOffset(4)]
        public float f1;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var instruction = new Instruction();
            instruction.f1 = 3.14f;

            Console.WriteLine("{0:d}", instruction.i1);
            Console.WriteLine();
            Console.WriteLine("{0:x}", instruction.b1);
            Console.WriteLine("{0:x}", instruction.b2);
            Console.WriteLine("{0:x}", instruction.b3);
            Console.WriteLine("{0:x}", instruction.b4);
            Console.WriteLine();
            Console.WriteLine("{0:f9}", instruction.f1);

        }
    }
}
