using HospitalServer.DTOs;
using HospitalServer.Models;
using MongoDB.Driver;

namespace HospitalServer.Services
{
    public class UserService
    {
        private readonly IMongoCollection<AppUser> _users;

        // Connects to MongoDB and initializes the Users collection.
        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("HospitalManagementDb");
            _users = database.GetCollection<AppUser>("Users");
        }

        // Registers a user by checking if the username already exists and then inserting a new user document into the MongoDB collection.
        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _users.Find(u => u.Username == request.Username).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return new AuthResponse { Success = false, Message = "Username already exists." };
            }
            var newUser = new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                Role = request.Role
            };
            await _users.InsertOneAsync(newUser);
            return new AuthResponse
            {
                Success = true,
                Message = "Registration successful.",
                UserId = newUser.Id,
                Username = newUser.Username,
                Role = newUser.Role
            };
        }

        // Logs in a user by verifying the username and password against the MongoDB collection and returns an authentication response.
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _users.Find(u => u.Username == request.Username && u.Password == request.Password).FirstOrDefaultAsync();
            if (user == null)
            {
                return new AuthResponse { Success = false, Message = "Invalid username or password." };
            }
            return new AuthResponse
            {
                Success = true,
                Message = "Login successful.",
                UserId = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }
    }
}
