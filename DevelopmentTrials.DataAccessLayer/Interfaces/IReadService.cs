using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Interfaces
{
    public interface IReadService<T> where T : class
    {
        void Read(T entity);
    }
}
