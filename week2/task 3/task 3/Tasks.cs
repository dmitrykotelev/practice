using System.ComponentModel.DataAnnotations;

public class Tasks
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public void ChangeStatus()
	{
		IsCompleted = !IsCompleted;
	}

	public Tasks() { }
	public Tasks(Tasks tasks)
	{
		Id = tasks.Id;
		Title = tasks.Title;
		Description = tasks.Description;
		IsCompleted = tasks.IsCompleted;
		CreatedAt = tasks.CreatedAt;
	}
	public Tasks(string name, string description)
	{
		Title = name;
		Description = description;
		IsCompleted = false;
		CreatedAt = DateTime.Now;
	}
}
