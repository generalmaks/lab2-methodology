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
    public void PrintList_DoesNotThrow()
    {
        // Arrange
        var list = new LinkedList.LinkedList(new Node('T'));

        // Act
        list.Add('E');
        list.Add('S');

        // Assert
        var exception = Record.Exception(() => list.PrintList());
        Assert.Null(exception);
    }
}
