namespace LinkedList;

public class Node(char data)
{
    public char Data { get; set; } = data;
    public Node? Next { get; set; }
    public Node? Prev { get; set; }
}