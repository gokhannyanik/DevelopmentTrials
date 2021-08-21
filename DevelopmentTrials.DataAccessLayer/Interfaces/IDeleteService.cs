using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Interfaces
{
    public interface IDeleteService<T> where T : class 
    {
        void Delete(T entity);
    }
}
