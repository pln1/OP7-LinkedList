using System.Buffers;

namespace OP7.LinkedListClass;

public class Node
{
    private short _value;

    private Node? _next;

    public Node(short v)
    {
        _value = v;
        _next = null;
    }

    public short Value
    {
        get { return _value; }
        set
        {
            if (value < short.MinValue || value > short.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value out of range");
            }
            _value = value;
        }
    }
    public Node Next
    {
        get { return _next; }
        set { _next = value; }
    }
}
