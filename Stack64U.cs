using System;

class Stack64U
{
     private ulong[] stack = new ulong[5];
    private ulong[] minimum = new ulong[5];
    private long top = -1;

    public ulong Push(ulong value)
    {
        if (top + 1 == stack.Length) Resize(stack.Length * 2);

        top++;

        stack[top] = value;

        if (top == 0) minimum[top] = value;

        else if (value < minimum[top - 1]) minimum[top] = value;

        else minimum[top] = minimum[top - 1];

        return 1;
    }

    public int Pop()
    {
        if (top == -1) throw new Exception("The array is empty");

        top--;

        // Shrink when usage is low: when size <= 1/4 of capacity
        if (stack.Length > 1 && (top + 1) <= stack.Length / 4)
        {
            int newCapacity = Math.Max(stack.Length / 2, 1);
            Resize(newCapacity);
        }

        return 1;
    }

    public ulong Peek()
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is empty");
        }
        return stack[top];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public int Size()
    {
        return (int)(top + 1);

    }

    public int? MinValue()
    {
        if (top != -1) return (int)minimum[top];
        else throw new Exception("The array is empty");
    }

    private void Resize(int newCapacity)
    {
        // Ensure new capacity is at least the current number of elements
        if (newCapacity < top + 1) newCapacity = (int)(top + 1);

        ulong[] newstack = new ulong[newCapacity];
        ulong[] newminimum = new ulong[newCapacity];

        for (int i = 0; i < top + 1; i++)
        {
            newstack[i] = stack[i];
            newminimum[i] = minimum[i];
        }

        stack = newstack;
        minimum = newminimum;
    }
}