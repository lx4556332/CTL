using System.Collections.Generic;

namespace CTL.BLL.Interfaces
{
    public interface IServices<T> where T: class
    {
        void Create(T item);
        T Read(int? id);
        IEnumerable<T> ReadAll();
        void Update(T item);
        void Delete(int? id);
    }
}
