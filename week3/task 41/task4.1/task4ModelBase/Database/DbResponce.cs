using task4ModelBase.Interfaces;

namespace task4ModelBase.Database
{
    public class DbResponce<T> where T : IModel
    {
        public ResponceStatus Status = ResponceStatus.Failure;
        public T Model
        { 
            get 
            {
                if (Status == ResponceStatus.SuccessReturn)
                    return Model;
                else
                    throw new NullReferenceException();
            }
            set { }
        }

        public IEnumerable<T> Models
        {
            get
            {
                if (Status == ResponceStatus.SuccessReturnList)
                    return Models;
                else
                    throw new NullReferenceException();
            }
            set { }
        }

        public DbResponce(ResponceStatus status, T model)
        {
            Status = status;
            Model = model;
        }

        public DbResponce(ResponceStatus status)
        {
            Status = status;
        }

        public DbResponce(ResponceStatus status, List<T> models)
        {
            Status = status;
            Models = new List<T>(models);
        }
    }
}
