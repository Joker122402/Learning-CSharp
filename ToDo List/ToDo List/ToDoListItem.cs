namespace ToDo_List;

public class ToDoListItem
{
    public string Title { get; set; }
    private string Description { get; set; }
    private string Priority { get; set; }
    private string Status { get; set; }
    private DateOnly DueDate { get; set; }


    public ToDoListItem(string title, string description, string priority, string status, DateOnly dueDate)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
        DueDate = dueDate;
    }

    
    public override string ToString()
    {
        return $"Title: {Title} \n" +
               $"Description: {Description} \n" +
               $"Priority: {Priority} \n" +
               $"Status: {Status} \n" +
               $"DueDate {DueDate} \n";
    }
}