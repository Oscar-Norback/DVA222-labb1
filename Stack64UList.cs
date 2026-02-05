using System;
using System.Collections.Generic;

public class Stack64UList
{
    private List<ulong> stack;
    private List<ulong> minimum;

    public Stack64UList()
    {
        stack = new List<ulong>();
        minimum = new List<ulong>();

    }

    public void Push(ulong value)
    {
        stack.Add(value);
        if (minimum.Count == 0)
        {
            minimum.Add(value);
        }
        else
        {
            ulong currentMin = minimum[minimum.Count - 1];
            minimum.Add(value < currentMin ? value : currentMin);
        }
    }

    public ulong Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is empty");
        }

        ulong value = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        minimum.RemoveAt(minimum.Count - 1);
        return value;
    }

    public ulong Peek()
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is empty");
        }
        return stack[stack.Count - 1];
    }

    public bool IsEmpty()
    {
        return stack.Count == 0;
    }

    public int Size()
    {
        return stack.Count;
    }

    public ulong MinValue()
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is empty");
        }
        return minimum[minimum.Count - 1];
    }
}