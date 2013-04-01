using System;
using RepositoryBase.Models;
using RepositoryBase.Repositories.Interfaces;
using ServiceBase.Common.Exceptions;
using ServiceBase.Services.Interfaces;

namespace ServiceBase.Services
{
    public class UserService : BaseRepositoryService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        public UserService(IUserRepository userRepository, EncryptionService encryptionService)
            : base(userRepository)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public virtual User CreateUser(string email, string password)
        {
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Email cannot be empty");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be emtpy");

            var existingUser = GetUserByEmail(email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException(email);
            }

            var salt = _encryptionService.GenerateSalt();
            var user = new User
            {
                Email = email,
                Salt = salt,
                Hash = _encryptionService.GenerateHash(password + salt),
            };

            Repository.Save(user);

            return user;
        }

        public virtual bool ValidateUser(string email, string password)
        {
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Email cannot be empty");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be emtpy");

            var user = GetUserByEmail(email);

            if (user == null) return false;

            var hash = _encryptionService.GenerateHash(password + user.Salt);

            return (user.Hash == hash);
        }

        public virtual User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public virtual string GetUserNameByEmail(string email)
        {
            return _userRepository.GetUserNameByEmail(email);
        }
    }
}
