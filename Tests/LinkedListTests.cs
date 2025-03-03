using LinkedList;

namespace Tests;

public class LinkedListTests
{
    [Fact]
    public void CreateList_NotNull()
    {
        var node = new Node('A');
        var list = new LinkedList.LinkedList(node);

        // Act & Assert
        Assert.NotNull(list);
    }

    [Fact]
    public void Add_SingleChar_LengthIncreases()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('Z'));

        // Act
        list.Add('X');

        // Assert
        Assert.Equal(2, list.Length());
    }

    [Fact]
    public void Add_MultipleChars_LengthMatches()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('Z'));

        // Act
        list.Add('i');
        list.Add('n');
        list.Add('e');

        // Assert
        Assert.Equal(4, list.Length());
    }

    [Fact]
    public void Length_SingleNode_ReturnsOne()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('B'));

        // Act
        int length = list.Length();

        // Assert
        Assert.Equal(1, length);
    }

    [Fact]
    public void Length_EmptyList_ReturnsZero()
    {
        // Arrange
        var list = new LinkedList.LinkedList();
        // Assert
        Assert.Equal(0, list.Length());
    }

    [Fact]
    public void AddToPos_PositionIsCorrect()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('A'));
        // Act
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        list.AddToPos(3, 'N');
        // Assert
        Assert.Equal("ABCNDE", list.GetListStringSimple());
    }

    [Fact]
    public void AddToPos_PositionAtHead_IsCorrect()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('A'));
        // Act
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        list.AddToPos(0, 'N');
        // Assert
        Assert.Equal("NABCDE", list.GetListStringSimple());
    }

    [Fact]
    public void DeleteElement_IsCorrect()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('A'));
        // Act
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        list.DeleteElement(1);
        // Assert
        Assert.Equal("ACDE", list.GetListStringSimple());
    }

    [Fact]
    public void PrintList_DoesNotThrow()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('T'));

        // Act
        list.Add('E');
        list.Add('S');

        // Assert
        var exception = Record.Exception(() => Console.WriteLine(list.GetListString()));
        Assert.Null(exception);
    }
}
