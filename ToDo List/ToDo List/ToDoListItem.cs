namespace ToDo_List;

public class ToDoListItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public DateOnly DueDate { get; set; }


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