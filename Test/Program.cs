using System;

using Flags;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int type = 0;
            string typeoFnigger = string.Empty;
            bool set = false;
            
            Flag.IntVar(ref type, "-nigger", 5, "Testing nigger flag");
            Flag.StringVar(ref typeoFnigger, "-type", "game", "Testing game flag");
            Flag.BoolVar(ref set, "-set", false, "Testing set flag");

            if (Flag.Parse())
                return;

            Console.WriteLine(type);
            Console.WriteLine(typeoFnigger);
            Console.WriteLine(set);
        }
    }
}
