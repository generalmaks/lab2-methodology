namespace LinkedList;

public class LinkedListDoubleSided
{
    private Node? _head;

    public LinkedListDoubleSided(Node head)
    {
        _head = head;
    }

    public LinkedListDoubleSided(){}

    public void Add(char data)
    {
        Node newNode = new Node(data);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node? current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Prev = current;
        }
    }

    public string GetListString()
    {
        Node? current = _head;
        string result = "";
        while (current != null)
        {
            result += current.Data + " -> ";
            current = current.Next;
        }

        result += "null";
        return result;
    }

    public string GetListStringSimple()
    {
        Node? current = _head;
        string result = "";
        while (current != null)
        {
            result += current.Data;
            current = current.Next;
        }

        return result;
    }

    public int Length()
    {
        Node? current = _head;
        int length = 0;
        while (current != null)
        {
            length++;
            current = current.Next;
        }

        return length;
    }

    public void AddToPos(int pos, char data)
    {
        if (pos < 0 || pos > Length())
            throw new IndexOutOfRangeException("Position is out of range");

        Node newNode = new Node(data);

        if (pos == 0)
        {
            newNode.Next = _head;
            if (_head != null)
            {
                _head.Prev = newNode;
            }
            _head = newNode;
            return;
        }

        Node? current = _head;

        for (int i = 0; i < pos - 1; i++)
        {
            if (current == null)
                throw new Exception("Invalid position");
            current = current.Next;
        }

        if (current == null)
            throw new Exception("Invalid position");

        newNode.Next = current.Next;
        newNode.Prev = current;
        if (current.Next != null)
        {
            current.Next.Prev = newNode;
        }
        current.Next = newNode;
    }

    public void DeleteElement(int pos)
    {
        if (pos < 0 || pos >= Length())
            throw new IndexOutOfRangeException("Position is out of range");

        if (_head == null)
            throw new Exception("List is empty");

        if (pos == 0)
        {
            _head = _head.Next;
            return;
        }

        Node current = _head;
        for (int i = 0; i < pos - 1; i++)
        {
            if (current == null || current.Next == null)
                throw new Exception("Invalid position");
            current = current.Next;
        }

        if (current.Next == null)
            throw new Exception("Invalid position");
        current.Next = current.Next.Next;
    }

    public char GetElement(int pos)
    {
        if (pos < 0 || pos >= Length())
            throw new IndexOutOfRangeException("Position is out of range");
        Node? current = _head;
        for (int i = 0; i < pos; i++)
        {
            if (current == null)
                throw new Exception("Invalid position");
            current = current.Next;
        }

        return current!.Data;
    }

    public LinkedListDoubleSided Copy()
    {
        var newList = new LinkedListDoubleSided();
        Node? current = _head;
        while (current != null)
        {
            newList.Add(current.Data);
            current = current.Next;
        }

        return newList;
    }

    public LinkedListDoubleSided Reverse()
    {
        Node? previous = null;
        Node? current = _head;

        while (current != null)
        {
            Node? next = current.Next;
            current.Next = previous;
            current.Prev = next;
            previous = current;
            current = next;
        }

        _head = previous;

        return this;
    }

    public int Find(char data)
    {
        Node? current = _head;
        int index = 0;
        while (current != null)
        {
            if (current.Data == data)
                return index;
            current = current.Next;
            index++;
        }

        return -1;
    }

    public Node FindLast()
    {
        Node? current = _head;
        while (current != null && current.Next != null)
        {
            current = current.Next;
        }
        return current!;
    }

    public int FindFromEnd(char data)
    {
        Node? current = FindLast();
        int index = 0;
        while (current != null)
        {
            if (current.Data == data)
                return index;
            current = current.Prev;
            index++;
        }
        return -1;
    }

    public void Clear()
    {
        Node? current = _head;
        while (current != null)
        {
            Node? next = current.Next;
            current.Next = null;
            current.Prev = null;
            current = next;
        }
        _head = null;
    }

    public void AddList(LinkedListDoubleSided list)
    {
        FindLast().Next = list._head;
    }
}