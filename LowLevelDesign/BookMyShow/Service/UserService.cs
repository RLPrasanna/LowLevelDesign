using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Repository;
using Microsoft.AspNetCore.Identity;

namespace BookMyShow.Service
{
    public class UserService
    {
        private IUserReository _userRepository;

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
                Email = email,
                Password = password // Note: In reality, never store plain text passwords
            };

            var userCreated=_userRepository.Add(userToBeSaved);
            return userCreated;
        }
    }
}
