using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Repository;
using Microsoft.AspNetCore.Identity;

namespace BookMyShow.Service
{
    public class UserService
    {
        private IUserReository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public UserService(IUserReository userRepository)
        {
            _userRepository = userRepository;
        }
        public User RegisterUser(string email, string password)
        {
            var existingUser=_userRepository.GetAll().FirstOrDefault(u => u.Email == email);
            if (existingUser != null)
            {
                throw new InvalidRequestException("UserEmail is already registered");
            }

            var userToBeSaved = new User
            {
                Email = email
            };
            userToBeSaved.Password = _passwordHasher.HashPassword(userToBeSaved, password);

            var userCreated=_userRepository.Add(userToBeSaved);
            return userCreated;
        }

        public bool Login(string email, string password)
        {
            var user=_userRepository.GetAll().FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            var result=_passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result==PasswordVerificationResult.Success;
        }
    }
}
