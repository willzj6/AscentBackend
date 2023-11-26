using AscentBackend.Models;

namespace AscentBackend.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        // Task<User> GetMe
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllRecruiters();
        Task<List<User>> GetAllTrainers();
        Task<List<User>> GetAllAccountManagers();
        Task<List<User>> GetAllInterviewers();
        Task<User> CreateUser(User user);
        Task<User> EditUser(User user);
        Task<User> DeleteUser(int userId);
        Task<User> AddInterviewPack(InterviewPack ip, int userId);
        Task<User> RemoveInterviewPack(InterviewPack ip, int userId);
    }
}
