using DevelopmentTrails.SharedModels.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Interfaces
{
    public interface IUserService : ICreateService<UserCreateModel>,IUpdateService<UserUpdateModel>
    {
    }
}
