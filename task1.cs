using System;

class Stack64U
{
    // Array som lagrar stackens element
    private ulong[] _data;

    // Parallell array som lagrar min-värdet vid varje nivå (för O(1) Min)
    private ulong[] _mins;

    // Antal element som faktiskt finns i stacken (inte kapacitet)
    private int _count;

    public Stack64U()
    {
        _data = new ulong[10];
        _mins = new ulong[10];
        _count = 0;
    }

    public void Push(ulong value)
    {
        if (_count == _data.Length)
        {
            Resize(_data.Length * 2);
        }

        _data[_count] = value;

        if (_count == 0)
        {
            _mins[_count] = value;
        }

        else
        {
            if (value < _mins[_count - 1])
            {
                _mins[_count] = value;
            }
            else
            {
                _mins[_count] = _mins[_count - 1];
            }
        }

        _count++;
    }

    public ulong Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        _count--;

        ulong value = _data[_count];

        if (_count > 0 && _count == _data.Length / 2)
        {
            Resize(_data.Length / 2);
        }
        return value;
    }

    public ulong Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _data[_count - 1];
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public int Size()
    {
        return _count;

    }

    public ulong Min()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _mins[_count - 1];
    }

    private void Resize(int newCapacity)
    {
        ulong[] newData = new ulong[newCapacity];
        ulong[] newMins = new ulong[newCapacity];

        for (int i = 0; i < _count; i++)
        {
            newData[i] = _data[i];
            newMins[i] = _mins[i];
        }

        _data = newData;
        _mins = newMins;
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

        Console.WriteLine("Current Min: " + stack.Min()); // Output: 2
        Console.WriteLine("Popped: " + stack.Pop());      // Output: 2
        Console.WriteLine("Current Min: " + stack.Min()); // Output: 3
        Console.WriteLine("Top Element: " + stack.Peek()); // Output: 7
    }
}