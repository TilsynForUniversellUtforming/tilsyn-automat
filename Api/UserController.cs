﻿using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<UserItem> GetAll()
        {
            return userRepository.GetAll();
        }

        [HttpGet]
        [Route("Exists/{sub}")]
        public bool Exists(string sub)
        {
            return userRepository.GetByIdPortenSub(sub) != null;
        }

        [HttpGet]
        [Route("Get/{sub}")]
        public UserItem Get(string sub)
        {
            return userRepository.GetByIdPortenSub(sub);
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(UserItem userItem)
        {
            return userRepository.Add(userItem);
        }

        [HttpPost]
        [Route("AddLink")]
        public bool AddLink(UserCompany userCompanyItem)
        {
            return userRepository.AddLink(userCompanyItem);
        }
    }
}