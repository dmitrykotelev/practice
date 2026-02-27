using Microsoft.Data.SqlClient;
using task_3;
using Dapper;

public class Repository
{
	private SqlConnection db;
	public Repository(Connection _db)
	{
		db = _db.GetConnection();
	}

	public void Add(Tasks tasks)
	{
		string query = "INSERT INTO "
            + "Tasks (Title, Description, IsCompleted, CreatedAt) "
            + "VALUES(@Title, @Description, @IsCompleted, @CreatedAt)";

        db.Execute(query, tasks);
	}

	public void Delete(int id)
	{
		string sqlQuery = "DELETE FROM Tasks WHERE Id = @id";
		db.Execute(sqlQuery, new {id});

    }
    public Tasks GetById(int id)
    {
        return db.Query<Tasks>("SELECT * FROM Tasks WHERE Id = @id", new { id }).FirstOrDefault();
    }

    public void Update (int id)
	{
		Tasks task = new Tasks(GetById(id));
		task.ChangeStatus();
		string sqlQuery = "Update Tasks SET Title = @Title, "
			+ "Description = @Description,"
            + " IsCompleted = @IsCompleted,"
            + " CreatedAt = @CreatedAt"
            + " WHERE Id = @Id";

    }

	public List<Tasks> GetAll()
	{
		return db.Query<Tasks>("SELECT * FROM Tasks").ToList();
	}
}
