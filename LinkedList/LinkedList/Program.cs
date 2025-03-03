namespace lab2;

public class Node(char data)
{
    public char Data { get; set; } = data;
    public Node? Next { get; set; } = null;
}

public class LinkedList
{
    private Node? _head = null;

    public LinkedList(Node head)
    {
        _head = head;
    }

    public void Add(char data)
    {
        Node? newNode = new Node(data);

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

    public void PrintList()
    {
        Node? current = _head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }

        Console.WriteLine("null");
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
}

static class Program
{
    static void Main(string[] args)
    {
        var MyNameList = new LinkedList(new Node('Z'));
        MyNameList.Add('i');
        MyNameList.Add('n');
        MyNameList.Add('e');
        MyNameList.Add('t');
        MyNameList.Add('s');
        MyNameList.PrintList();
        Console.WriteLine(MyNameList.Length());
    }
}