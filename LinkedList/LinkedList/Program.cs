namespace LinkedList;

public class Node(char data)
{
    public char Data { get; set; } = data;
    public Node? Next { get; set; }
}

public class LinkedList
{
    private Node? _head;

    public LinkedList(Node head)
    {
        _head = head;
    }

    public LinkedList(){}
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
        
        Node? newNode = new Node(data);
        
        if (pos == 0)
        {
            newNode.Next = _head;
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

        newNode.Next = current.Next;
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

    public LinkedList Copy()
    {
        var newList = new LinkedList();
        Node? current = _head;
        while (current != null)
        {
            newList.Add(current.Data);
            current = current.Next;
        }
        return newList;
    }
}

static class Program
{
    static void Main(string[] args)
    {
        var myNameList = new LinkedList(new Node('Z'));
        myNameList.Add('i');
        myNameList.Add('n');
        myNameList.Add('e');
        myNameList.Add('t');
        myNameList.Add('s');
        Console.WriteLine(myNameList.GetListString());
        Console.WriteLine(myNameList.GetListStringSimple());
        Console.WriteLine(myNameList.Length());
    }
}