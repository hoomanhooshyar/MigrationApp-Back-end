﻿using Core.Entities;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Result> Signup(Signup user);
        Task<User> Login(string username, string password);
        Task<UserDTO> GetUserData(string token);

    }
}
