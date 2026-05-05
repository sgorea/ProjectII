using System.Collections.Generic;

namespace RailwayConformityApp.Data
{
    public interface IRepository<T>
    {
        void Save(T entity);

        T GetById(int id);

        List<T> GetAll();

        void Delete(int id);

        List<T> GetByFilter(string filter);
    }
}