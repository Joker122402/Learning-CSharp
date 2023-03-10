namespace ToDo_List;

public class ToDoList
{
    // Title
    private string Title { get; init; }
    //Description
    private string Description { get; init; }
    // Items
    public List<ToDoListItem> Items { get; set; }


    //constructor
    public ToDoList(string title, string description)
    {
        Title = title;
        Description = description;

        Items = new List<ToDoListItem>()
        {
            new ToDoListItem("Example Item", "This is an example to-do list item", "Low", "In-Progress",
                new DateOnly(2000, 1, 1))
        };
    }

    public List<string> GetItemTitles()
    {
        return Items.Select(item => item.Title).ToList();
    }

    public string ListDetailedItemInfo(string title)
    {
        var item = (Items.Where(i => i.Title.Equals(title))).FirstOrDefault();

        return item is null ? $"Item not found with title: {title}" : item.ToString();
    }

    public string AddItem(ToDoListItem item)
    {
        Items.Add(item);

        return $"Item with title: {item.Title}, added to To-Do List";
    }

    public string RemoveItem(string? title)
    {
        var itemToRemove = Items.FirstOrDefault(i => i.Title.Equals(title));
        if (itemToRemove == null)
        {
            return $"Item with title: {title}, not found in To-Do List";
        }

        Items.Remove(itemToRemove);
        return $"Item with title: {title}, removed from To-Do List";
    }
}