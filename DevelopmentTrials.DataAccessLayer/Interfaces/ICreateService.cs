using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Interfaces
{
    public interface ICreateService<T> where T : class
    {
        void Create(T entity);
    }
}
