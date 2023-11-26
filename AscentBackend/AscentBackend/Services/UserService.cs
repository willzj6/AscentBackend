using AscentBackend.Data;
using AscentBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AscentBackend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }

        public async Task<User> AddInterviewPack(InterviewPack ip, int userId)
        {
            User user = await context.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            else
            {
                user.interviewPacks.Add(ip);
                context.Update(user);
                return user;
            }

        }

        public async Task<User> CreateUser(User user)
        {
            User findUser = await context.Users.FindAsync(user.userId);
            if ( findUser == null)
            {
                // New User
                context.Add(user);
                await context.SaveChangesAsync();
                return user;
            }
            else
            {
                return null;
            }
        }

        public Task<User> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAccountManagers()
        {
            List<User> ams = await context.Users.Where(u => u.role == "am").ToListAsync();
            return ams;
        }

        public async Task<List<User>> GetAllInterviewers()
        {
            List<User> interviewers = await context.Users.Where(u => u.role == "trainer" || u.role == "am").ToListAsync();
            return interviewers;
        }

        public async Task<List<User>> GetAllRecruiters()
        {
            List<User> recruiters = await context.Users.Where(u => u.role == "recruiter").ToListAsync();
            return recruiters;
        }

        public async Task<List<User>> GetAllTrainers()
        {
            List<User> trainers = await context.Users.Where(u => u.role == "trainer").ToListAsync();
            return trainers;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.email == email);
            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await context.Users.FindAsync(userId);
            return user;
        }

        public async Task<User> RemoveInterviewPack(InterviewPack ip, int userId)
        {
            User user = await context.Users.FindAsync(userId);
            if (user != null && user.interviewPacks.Contains(ip))
            {
                user.interviewPacks.Remove(ip);
                context.Update(user);
                await context.SaveChangesAsync();
                return user;
            } 
            else
            {
                return null;
            }
        }
    }
}
