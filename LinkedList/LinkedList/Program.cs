using LinkedList;

namespace LinkedList;

static class Program
{
    static void Main(string[] args)
    {
        var myNameList = new global::LinkedList.LinkedListDoubleSided(new Node('Z'));
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