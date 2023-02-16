namespace TestToDoList;

public class UnitTest1
{
    [Fact]
    public void GetItemTitlesReturnsCorrectTitles()
    {
        // Arrange Test
        var list = new ToDoList("My To-Do List", "My To-Do List");

        list.AddItem(new ToDoListItem("Item 1", "Test Item 1", "Low", "In-Progress", new DateOnly(1999, 10, 22)));
        list.AddItem(new ToDoListItem("Item 2", "This is the second test item", "High", "Complete", new DateOnly(1800, 8, 12)));
        
        // Perform test
        var result = list.GetItemTitles();
        
        Assert.Equal(new[] {"Example Item", "Item 1", "Item 2"}, result);
    }

    [Fact]
    public void ListDetailedItemInfoReturnsCorrectInfo()
    {
        // Arrange Test
        var list = new ToDoList("My To-Do List", "My To-Do List");
        var item = new ToDoListItem("Item 1", "Test Item 1", "Low", "In-Progress", new DateOnly(1999, 10, 22));
        list.AddItem(item);
        
        // Perform Test
        var result = list.ListDetailedItemInfo("Item 1");
        
        Assert.Equal(item.ToString(), result);
    }

    [Fact]
    public void AddItemAddsItemToList()
    {
        // Arrange Test
        var list = new ToDoList("My To-Do List", "My To-Do List");
        var item = new ToDoListItem("Item 1", "Test Item 1", "Low", "In-Progress", new DateOnly(1999, 10, 22));
        
        //Perform Test
        var result = list.AddItem(item);
        
        Assert.Equal($"Item with title: {item.Title}, added to To-Do List", result);
        Assert.Contains(item, list.Items);
    }

    [Fact]
    public void RemoveItemRemovesItemFromList()
    {
        // Arrange Test
        var list = new ToDoList("My To-Do List", "My To-Do List");
        var item = new ToDoListItem("Item 1", "Test Item 1", "Low", "In-Progress", new DateOnly(1999, 10, 22));
        list.AddItem(item);
        
        // Perform Test
        var result = list.RemoveItem("Item 1");
        
        Assert.Equal($"Item with title: Item 1, removed from To-Do List", result);
        Assert.DoesNotContain(item, list.Items);
    }
    
    [Fact]
    public void RemoveItemProducesErrorIfItemNotFound
}