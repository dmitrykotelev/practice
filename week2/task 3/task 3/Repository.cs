using Dapper;
using Microsoft.Data.SqlClient;
using task_3;

public class Repository
{
	private SqlConnection db;
	public Repository(Connection _db)
	{
		db = _db.GetConnection();
	}

	public void Add(Tasks tasks)
	{
		string query = "INSERT INTO Tasks (Name, Description, IsCompleted, CreatedAt) VALUES(@Name, @Description, @IsCompleted, @CreatedAt)";

        db.Execute(query, tasks);
	}

	public void Delete(int id)
	{
		string sqlQuery = "DELETE FROM Tasks WHERE Id = @id";
		db.Execute(sqlQuery, new {id});

    }
    public Tasks Get(int id)
    {
        return db.Query<Tasks>("SELECT * FROM Tasks WHERE Id = @id", new { id }).FirstOrDefault();
    }

    public void Update (int id)
	{
		Tasks task = new Tasks(Get(id));
		task.ChangeStatus();
		string sqlQuery = "Update Tasks SET Name = @Name, Description = @Description, IsCompleted = @IsCompleted, CreatedAt = @CreatedAt WHERE Id = @Id";

    }

	public List<Tasks> GetAll()
	{
		return db.Query<Tasks>("SELECT * FROM Tasks").ToList();
	}
}
