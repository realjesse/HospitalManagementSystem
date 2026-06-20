using HospitalServer.Data;
using HospitalServer.DTOs;
using HospitalServer.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HospitalServer.Services
{
    public class UserService
    {
        private readonly IMongoCollection<AppUser> _users;
        private readonly HospitalDbContext _db;

        // Connects to MongoDB and initializes the Users collection.
        public UserService(IConfiguration config, HospitalDbContext db)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("HospitalManagementDb");
            _users = database.GetCollection<AppUser>("Users");
            _db = db;
        }

        public async Task<AuthResponse> RegisterProviderAsync(RegisterProviderRequest request)
        {
            var existingUser = await _users
                .Find(u => u.Username == request.Username)
                .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Username already exists."
                };
            }

            var user = new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                Role = "Provider"
            };

            await _users.InsertOneAsync(user);

            return new AuthResponse
            {
                Success = true,
                Message = "Provider registration successful.",
                UserId = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }

        public async Task<AuthResponse> RegisterPatientAsync(RegisterPatientRequest request)
        {
            var existingUser = await _users
                .Find(u => u.Username == request.Username)
                .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Username already exists."
                };
            }

            // Generate a MongoDB Id to save into SQL and Mongo databases to connect them
            var mongoUserId = ObjectId.GenerateNewId().ToString();

            var user = new AppUser
            {
                Id = mongoUserId,
                Username = request.Username,
                Password = request.Password,
                Role = "Patient"
            };

            var patient = new Patient
            {
                MongoUserId = mongoUserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };

            try
            {
                _db.Patients.Add(patient);
                await _db.SaveChangesAsync();

                await _users.InsertOneAsync(user);

                return new AuthResponse
                {
                    Success = true,
                    Message = "Patient registration successful.",
                    UserId = user.Id,
                    Username = user.Username,
                    Role = user.Role
                };
            }
            catch
            {
                // if Mongo insertion doesn't work, then delete row from SQL database
                if (patient.PatientId != 0)
                {
                    _db.Patients.Remove(patient);
                    await _db.SaveChangesAsync();
                }

                throw;
            }
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
