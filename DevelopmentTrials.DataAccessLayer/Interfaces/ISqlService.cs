using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Interfaces
{
    public interface ISqlService
    {
        void ExecuteCommand(string commandText);
        object ExecuteReader(string commandText);

    }
}
