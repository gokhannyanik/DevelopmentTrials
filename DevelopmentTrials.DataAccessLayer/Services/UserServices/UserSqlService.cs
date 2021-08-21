using DevelopmentTrails.SharedModels.UserModels;
using DevelopmentTrials.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Services.UserServices
{
    public class UserSqlService : IUserService
    {
        private readonly ISqlService _sqlService;

        public UserSqlService(ISqlService sqlService)
        {
            _sqlService = sqlService;
        }

        public void Create(UserCreateModel entity)
        {
            _sqlService.ExecuteCommand($"INSERT INTO Users (FullName, Birthday, Email) VALUES('{entity.FullName}', '{entity.BirthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{entity.Email}'); ");
        }

        public void Update(UserUpdateModel entity)
        {
            _sqlService.ExecuteCommand($"UPDATE Users SET FullName='{entity.FullName}', Birthday='{entity.BirthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}' WHERE Email = '{entity.Email}'");
        }
    }
}
