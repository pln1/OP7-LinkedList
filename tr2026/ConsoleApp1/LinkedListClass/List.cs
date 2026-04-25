using System.Collections;
using System.Transactions;

namespace OP7.LinkedListClass;

public class LinkedList : IEnumerable<short>
{
    private Node? _head;

    public LinkedList(short value)
    {
        _head = new Node(value);
    }

    public LinkedList(Node? h)
    {
        _head = h;
    }

    public LinkedList() : this(null)
    {
    }

    public void Add(short value)
    {
        if (value < short.MinValue || value > short.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "");
        }
        if (_head is null)
        {
            _head = new Node(value);
        }
        else
        {
            Node t = new Node(value);
            t.Next = _head;
            _head = t;
        }
    }

    public void Remove()
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head), "List is empty");
        }

        _head = _head.Next;
    }

    public void RemoveAtIndex(int idx)
    {
        if (idx < 0 || idx > int.MaxValue || _head is null)
        {
            throw new ArgumentOutOfRangeException(nameof(idx), "");
        }

        if (idx == 0)
        {
            _head = _head.Next;
            return;
        }

        Node? curr = _head;

        for (int i = 0; i < idx-1; ++i)
        {
            if (curr is null)
            {
                throw new ArgumentNullException(nameof(curr), "Index is out of range");
            }
            curr = curr.Next;
        }

        if (curr is null || curr.Next is null)
        {
            throw new ArgumentNullException(nameof(curr), "Index is out of range");
        }

        curr.Next = curr.Next.Next;
    }

    public short FindFirst(short value)
    {
        if (value == 0 || value < short.MinValue || value > short.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "");
        }

        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Value % value == 0)
            {
                return curr.Value;
            }

            curr = curr.Next;
        }

        return 0;
    }

    public int FindProduct()
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head), "");
        }

        int avg = 0;

        Node? curr = _head;

        int i = 0;

        for ( ; curr is not null; ++i)
        {
            avg += curr.Value;
            curr = curr.Next;
        }

        avg /= i;

        int prod = 1;

        curr = _head;

        while (curr is not null)
        {
            if (curr.Value < avg)
            {
                prod *= curr.Value;
            }
            curr = curr.Next;
        }

        return prod;
    }

    public LinkedList GenerateNewList(short value)
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head), "");
        }

        if (value == 0 || value < short.MinValue || value > short.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "");
        }

        LinkedList? result = new LinkedList();

        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Value % value == 0)
            {
                result.Add(curr.Value);
            }

            curr = curr.Next;
        }

        return result;
    }

    public void DeleteGreater()
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head), "");
        }

        int avg = 0;

        Node? curr = _head;

        int i = 0;

        for ( ; curr is not null; ++i)
        {
            avg += curr.Value;
            curr = curr.Next;
        }

        avg /= i;

        curr = _head;

        for (i = 0; curr is not null; ++i)
        {
            if (curr.Value > avg)
            {
                RemoveAtIndex(i);
                --i;
            }
            curr = curr.Next;
        }
    }

    public short this[int idx]
    {
        get
        {
            if (idx < 0 || idx > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(idx), "Index is out of range");
            }
            Node? curr = _head;

            for (int i = 0; i < idx; ++i)
            {
                if (curr is null)
                {
                    throw new ArgumentOutOfRangeException(nameof(idx), "Index is out of range");
                }
                curr = curr.Next;
            }

            if (curr == null)
            {
                throw new ArgumentOutOfRangeException(nameof(idx), "Index is out of range");
            }

            return curr.Value;
        }
    }

    public IEnumerator<short> GetEnumerator()
    {
        Node? curr = _head;

        while (curr != null)
        {
            yield return curr.Value;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
