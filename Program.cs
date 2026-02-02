using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== TEST OF STACK64U ===\n");
        TestStack64U();

        Console.WriteLine("\n=== TEST OF STACK64ULIST ===\n");
        TestStack64UList();
    }

    static void TestStack64U()
    {
        Stack64U stack = new Stack64U();

        // Test 1: Tom stack
        Console.WriteLine("Test 1: Empty stack");
        Console.WriteLine($"IsEmpty: {stack.IsEmpty()}");
        Console.WriteLine($"Size: {stack.Size()}");

        // Test 2: Push och operationer
        Console.WriteLine("\nTest 2: Push(5), Push(3), Push(7), Push(2)");
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        stack.Push(2);
        Console.WriteLine($"Size: {stack.Size()}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"MinValue: {stack.MinValue()}");

        // Test 3: Pop
        Console.WriteLine("\nTest 3: Pop");
        stack.Pop();
        Console.WriteLine($"After Pop - Size: {stack.Size()}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"MinValue: {stack.MinValue()}");

        // Test 4: Pop på tom stack
        Console.WriteLine("\nTest 4: Pop until empty and test empty stack");
        stack.Pop();
        stack.Pop();
        stack.Pop();
        Console.WriteLine($"IsEmpty: {stack.IsEmpty()}");
        try
        {
            stack.Pop();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Pop on empty stack: {e.Message}");
        }
    }

    static void TestStack64UList()
    {
        Stack64UList stack = new Stack64UList();

        // Test 1: Tom stack
        Console.WriteLine("Test 1: Empty stack");
        Console.WriteLine($"IsEmpty: {stack.IsEmpty()}");
        Console.WriteLine($"Size: {stack.Size()}");

        // Test 2: Push och operationer
        Console.WriteLine("\nTest 2: Push(5), Push(3), Push(7), Push(2)");
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        stack.Push(2);
        Console.WriteLine($"Size: {stack.Size()}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"MinValue: {stack.MinValue()}");

        // Test 3: Pop
        Console.WriteLine("\nTest 3: Pop");
        ulong popped = stack.Pop();
        Console.WriteLine($"Popped: {popped}");
        Console.WriteLine($"After Pop - Size: {stack.Size()}");
        Console.WriteLine($"MinValue: {stack.MinValue()}");

        // Test 4: Pop på tom stack
        Console.WriteLine("\nTest 4: Pop until empty and test empty stack");
        stack.Pop();
        stack.Pop();
        stack.Pop();
        Console.WriteLine($"IsEmpty: {stack.IsEmpty()}");
        try
        {
            stack.Pop();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Pop on empty stack: {e.Message}");
        }
    }
}
