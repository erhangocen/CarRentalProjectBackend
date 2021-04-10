using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, string value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPettern(string pattern);
    }
}
