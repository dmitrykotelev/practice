namespace task4ModelBase.Database.DbManager
{
    public class DbResponce<T> where T : class
    {
        public readonly ResponceStatus Status = ResponceStatus.Failure;
        public readonly T Data;
        public readonly Error Error;

        public DbResponce(ResponceStatus status, T model)
        {
            Status = status; 
            Data = model; 
        }

        public DbResponce(ResponceStatus status, Error error)
        {
            Status = status;
            Error = error;
        }

        public DbResponce(ResponceStatus status)
        {
            Status = status;
        }
    }
}