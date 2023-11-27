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
        void CreateUser(User user);
        void EditUser(User user);
        void DisableUser(int userId);
        void AddInterviewPack(InterviewPack ip, int userId);
        void RemoveInterviewPack(InterviewPack ip, int userId);
    }
}
