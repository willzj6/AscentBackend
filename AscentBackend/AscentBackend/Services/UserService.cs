using AscentBackend.Data;
using AscentBackend.Models;
using Microsoft.EntityFrameworkCore;
using AscentBackend.Exceptions;


namespace AscentBackend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async void AddInterviewPack(InterviewPack ip, int userId)
        {
            User? user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            else
            {
                user.interviewPacks.Add(ip);
                _context.Update(user);
            }

        }

        public async void CreateUser(User user)
        {
            //User? foundUser = await _context.Users.FindAsync(user.userId);
            var foundUser = await GetUserById(user.userId); // Potential error if user.userId is empty
            if ( foundUser == null)
            {
                // New User
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ConflictException("User already exists");
            }
        }

        public async void DisableUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            Console.WriteLine("Database connection debugger!");
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            user.isActive = !user.isActive;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public async Task<User> EditUser(User user)
        {
            var foundUser = await _context.Users.FindAsync(user.userId);
            if (foundUser == null)
            {
                throw new NotFoundException("User not found");
            }
            foundUser.firstName = user.firstName;
            foundUser.lastName = user.lastName;
            foundUser.password = user.password;
            foundUser.email = user.email;
            foundUser.role = user.role;
            foundUser.contact = user.contact;
            _context.Update(foundUser);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAccountManagers()
        {
            List<User> ams = await _context.Users.Where(u => u.role == "am").ToListAsync();
            return ams;
        }

        public async Task<List<User>> GetAllInterviewers()
        {
            List<User> interviewers = await _context.Users.Where(u => u.role == "trainer" || u.role == "am").ToListAsync();
            return interviewers;
        }

        public async Task<List<User>> GetAllRecruiters()
        {
            List<User> recruiters = await _context.Users.Where(u => u.role == "recruiter").ToListAsync();
            return recruiters;
        }

        public async Task<List<User>> GetAllTrainers()
        {
            List<User> trainers = await _context.Users.Where(u => u.role == "trainer").ToListAsync();
            return trainers;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
            if (user == null)
            {
                throw new NotFoundException("user not found");
            }
            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            return user;
        }

        public async void RemoveInterviewPack(InterviewPack ip, int userId)
        {
            User? user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            else if (await _context.InterviewsPacks.FindAsync(ip) == null)
            {
                throw new NotFoundException($"Interview Pack {ip} not found");
            }
            else if (!user.interviewPacks.Contains(ip))
            {
                throw new MethodNotAllowedException($"User {user.firstName} {user.lastName} does not have permission for interview pack: {ip}");
            }
            else
            {
                user.interviewPacks.Remove(ip);
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
