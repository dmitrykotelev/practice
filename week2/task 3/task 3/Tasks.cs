public class Tasks
{
    public int Id { get; set; }
    public string Name { get; set; }
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
		Name = tasks.Name;
		Description = tasks.Description;
		IsCompleted = tasks.IsCompleted;
		CreatedAt = tasks.CreatedAt;
	}
	public Tasks(string name, string description)
	{
		Name = name;
		Description = description;
		IsCompleted = false;
		CreatedAt = DateTime.Now;
	}
}
