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
            throw new Exception("Position is out of range");
        
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