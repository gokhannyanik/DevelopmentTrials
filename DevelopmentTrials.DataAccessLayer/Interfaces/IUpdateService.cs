using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Interfaces
{
    public interface IUpdateService<T> where T : class
    {
        void Update(T entity);
    }
}
