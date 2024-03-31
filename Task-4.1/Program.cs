using System;
using System.Linq;
using Task_3_4;
using static System.Runtime.InteropServices.JavaScript.JSType;

class HelloWorld
{
    static void Main()
    {
        OneDimentionalArray<int> array2 = new();
        array2.CreateArray();
        array2.Add(1);
        array2.Add(2);
        array2.Add(3);
        array2.Add(1);
        array2.Add(4);
        array2.Add(0);
        array2.Print();

        array2.Remove(2);
        array2.Print();

        Console.WriteLine(array2.CountEl());

        array2.CoupArray();
        array2.Print();

        Console.WriteLine(array2.ConditionCountEl(x => x % 3 == 0));

        Console.WriteLine(array2.ConditionFind(x => x % 3 == 0));

        Console.WriteLine(array2.ConditionAll(x => x % 2 == 0));

        Console.WriteLine(array2.IsEquals(0));

        Console.WriteLine(array2.Minimum());

    }
}
