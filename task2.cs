using System;
using System.Collections.Generic;

/// Stack64U – Task #2
/// Stack implementerad med List<ulong>.
/// Resize hanteras automatiskt av List.
public class Stack64U
{
    // ======== Privata attribut ========

    // Lagrar stackens element (toppen = sista elementet)
    private List<ulong> _data;

    // Lagrar min-värdet vid varje nivå för O(1) Min()
    private List<ulong> _mins;

    // ======== Konstruktor ========
    /// Parameterlös konstruktor.
    /// Initierar listorna.

    public Stack64U()
    {
        _data = new List<ulong>();
        _mins = new List<ulong>();

    }

    // ======== Publika metoder ========

    /// Lägger ett element överst på stacken.
    public void Push(ulong value)
    {
        _data.Add(value);
        if (_mins.Count == 0)
        {
            _mins.Add(value);
        }
        else
        {
            ulong currentMin = _mins[_mins.Count - 1];
            _mins.Add(value < currentMin ? value : currentMin);
        }
    }

    /// Tar bort och returnerar översta elementet.
    public ulong Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        ulong value = _data[_data.Count - 1];
        _data.RemoveAt(_data.Count - 1);
        _mins.RemoveAt(_mins.Count - 1);
        return value;
    }

    /// Returnerar översta elementet utan att ta bort det.
    public ulong Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _data[_data.Count - 1];
    }

    /// Returnerar true om stacken är tom.
    public bool IsEmpty()
    {
        return _data.Count == 0;
    }

    /// Returnerar antalet element i stacken.
    public int Size()
    {
        return _data.Count;
    }

    /// Returnerar minsta värdet i stacken i O(1).
    public ulong Min()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _mins[_mins.Count - 1];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stack64U stack = new Stack64U();

        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        stack.Push(2);

        Console.WriteLine("Min: " + stack.Min()); // Output: 2
        Console.WriteLine("Pop: " + stack.Pop()); // Output: 2
        Console.WriteLine("Min: " + stack.Min()); // Output: 3
        Console.WriteLine("Peek: " + stack.Peek()); // Output: 7
        Console.WriteLine("Size: " + stack.Size()); // Output: 3
    }
}