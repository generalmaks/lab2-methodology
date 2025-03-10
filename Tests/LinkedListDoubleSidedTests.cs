﻿using LinkedList;
using LinkedListDoubleSided = LinkedList.LinkedListDoubleSided;

namespace Tests;

public class LinkedListDoubleSidedTests
{
    [Fact]
    public void CreateList_NotNull()
    {
        var node = new Node('A');
        var list = new LinkedListDoubleSided(node);

        // Act & Assert
        Assert.NotNull(list);
    }

    [Fact]
    public void Add_SingleChar_LengthIncreases()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('Z'));

        // Act
        list.Add('X');

        // Assert
        Assert.Equal(2, list.Length());
    }

    [Fact]
    public void Add_MultipleChars_LengthMatches()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('Z'));

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
        var list = new LinkedListDoubleSided(new Node('B'));

        // Act
        int length = list.Length();

        // Assert
        Assert.Equal(1, length);
    }

    [Fact]
    public void Length_EmptyList_ReturnsZero()
    {
        // Arrange
        var list = new LinkedListDoubleSided();
        // Assert
        Assert.Equal(0, list.Length());
    }

    [Fact]
    public void AddToPos_PositionIsCorrect()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
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
        var list = new LinkedListDoubleSided(new Node('A'));
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
        var list = new LinkedListDoubleSided(new Node('A'));
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
    public void GetElement_IsCorrect()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        var element = list.GetElement(2);
        // Assert
        Assert.Equal('C', element);
    }

    [Fact]
    public void GetElement_IndexOutOfBounds_Throws()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        var exception = Record.Exception(() => list.GetElement(5));
        // Assert
        Assert.IsType<IndexOutOfRangeException>(exception);
    }

    [Fact]
    public void PrintList_DoesNotThrow()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('T'));

        // Act
        list.Add('E');
        list.Add('S');

        // Assert
        var exception = Record.Exception(() => Console.WriteLine(list.GetListString()));
        Assert.Null(exception);
    }

    [Fact]
    public void Copy_CorrectCopy()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        var copy = list.Copy();
        // Assert
        Assert.Equal(list.GetListStringSimple(), copy.GetListStringSimple());
    }

    [Fact]
    public void Copy_EmptyList_CorrectCopy()
    {
        // Arrange
        var list = new LinkedListDoubleSided();
        // Act
        var copy = list.Copy();
        // Assert
        Assert.Equal(list.GetListStringSimple(), copy.GetListStringSimple());
    }

    [Fact]
    public void Copy_ReturnsModifiedList()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        list.DeleteElement(0);
        list.AddToPos(1, 'F');

        // Act
        var copy = list.Copy();
        // Assert
        Assert.Equal(list.GetListStringSimple(), copy.GetListStringSimple());
    }

    [Fact]
    public void Reverse_CorrectReverse()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        list.Reverse();
        // Assert
        Assert.Equal("EDCBA", list.GetListStringSimple());
    }
    
    [Fact]
    public void Reverse_EmptyList_CorrectReverse()
    {
        // Arrange
        var list = new LinkedListDoubleSided();
        // Act
        list.Reverse();
        // Assert
        Assert.Equal("", list.GetListStringSimple());
    }

    [Fact]
    public void Find_ElementExists_ReturnsIndex()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        var index = list.Find('C');
        // Assert
        Assert.Equal(2, index);
    }

    [Fact]
    public void Find_ElementDoesNotExist_ReturnsNegativeOne()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        var index = list.Find('F');
        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void FindFromEnd_ElementExists_ReturnsIndex()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        var index = list.FindFromEnd('D');
        // Assert
        Assert.Equal(1, index);
    }
    [Fact]
    public void Clear_EmptyList_CorrectClear()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');
        // Act
        list.Clear();
        // Assert
        Assert.Equal(0, list.Length());
    }

    [Fact]
    public void AddList_CorrectAdd()
    {
        // Arrange
        var list = new LinkedListDoubleSided(new Node('A'));
        list.Add('B');
        list.Add('C');
        var list2 = new LinkedListDoubleSided(new Node('D'));
        list2.Add('E');
        // Act
        list.AddList(list2);
        // Assert
        Assert.Equal("ABCDE", list.GetListStringSimple());
    }
}