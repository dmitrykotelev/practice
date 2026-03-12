using task4ModelBase.Interfaces;

namespace task4ModelBase.Database.DbManager
{
    public class MyDbSet<T> where T : class , IModel 
    {
        private readonly List<T> _collection;
        private int counter;
        private readonly object _locker = new object();

        public MyDbSet()
        {
            _collection = new List<T>();
            counter = 0;
        }

        public DbResponce<T> Add(T data)
        {
            lock (_locker)
            {
                counter++;
                data.Id = counter;
                _collection.Add(data);

                return new DbResponce<T>(ResponceStatus.Success, data);
            }
        }

        public DbResponce<T> GetById(int id)
        {
            lock (_locker)
            {
                var data = _collection.FirstOrDefault(x => x.Id == id);

                if (data == null)
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error("Element not found"));
                else
                    return new DbResponce<T>(ResponceStatus.Success, data);
            }
        }

        public DbResponce<T> Delete(int id)
        {
            lock (_locker)
            {
                var data = GetById(id);

                if (data.Status == ResponceStatus.Success)
                {
                    _collection.Remove(data.Data);
                    return new DbResponce<T>(ResponceStatus.Success, data.Data);
                }
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error("Element not found"));
            }
        }

        public DbResponce<IEnumerable<T>> GetAll()
        {
            lock (_locker)
            {
                return new DbResponce<IEnumerable<T>>(ResponceStatus.Success, new List<T>(_collection));
            }
        }

        public DbResponce<T> Update(T data)
        {
            lock (_locker)
            {
                int index = _collection.FindIndex(x => x.Id == data.Id);

                if (_collection[index] != null)
                {
                    _collection[index] = data;
                    return new DbResponce<T>(ResponceStatus.Success, data);
                }
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error("Element not found"));
            }
        }

        public int Count()
        {
            lock (_locker)
            {
                return _collection.Count;
            }
        }

    }
}