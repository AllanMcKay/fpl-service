using System.Collections.Generic;
using Data.Models;

namespace Data.Interfaces
{
    public interface IFPLRepository<T> where T : IStorable
    {
        void Save(T player);
        T Get(int id);
        List<T> Find(string[] Tags);
    }
}