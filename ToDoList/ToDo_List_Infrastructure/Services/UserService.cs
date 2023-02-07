using AutoMapper;
using ToDo_List_Core.Models;
using ToDo_List_Core.Repositories;
using ToDo_List_Infrastructure.Commands.User;
using ToDo_List_Infrastructure.DTO;
using ToDo_List_Infrastructure.Extensions;
using ToDo_List_Infrastructure.Security;

namespace ToDo_List_Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        public UserService(IUserRepository userRepository,IMapper mapper,IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }
        public async Task<User> GetUserAsync(Guid id)
        {
            var @user = await _userRepository.GetOrFail(id);
            return @user;
        }
        public async Task<UserDTO> GetAsync(Guid id)
        {
            var @user = await _userRepository.GetOrFail(id);
            return  _mapper.Map<UserDTO>(@user);     
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var @user = await _userRepository.GetOrFail(email);
            return _mapper.Map<UserDTO>(@user);
        }
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var @user = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDTO>>(@user);
        }
        public Task<Guid> AddTaskAsync(Guid id,string title, string description, DateTime enddate)
        {
            var newTask = new Tasks(id, title, description, enddate);
            _userRepository.AddTaskAsync(id, newTask);
            return Task.FromResult(newTask.Id);
        }
        public async Task<TokenDTO> CreateAsync(string email, string password, string name, Role role)
        {
            var @user = _userRepository.GetAsync(@email).Result;
            if (@user != null)
            {
                throw new Exception($"User with email: {email} already exists");
            }
            @user = new User(email,SecurityClass.HashPassword(password), name, role);
            await _userRepository.CreateAsync(user);
            var jwt = _jwtHandler.CreateToken(user.Id, user.role);
            return new TokenDTO
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.role
            };
        }        
        public Task DeleteAsync(Guid id)
        {
            var user = _userRepository.DeleteAsync(@id);
            return Task.CompletedTask;            
        }

        public Task UpdateAsync(Guid id, string? name, string? email,string? password)
        {
            var @user = _userRepository.GetOrFail(id).Result;
            if (@user == null) 
            {
                throw new Exception($"User not exists");
            }
            user.UpdateUser(name, email, SecurityClass.HashPassword(password));
            _userRepository.UpdateAsync();
            return Task.CompletedTask;
        }
        public async Task<TokenDTO> LoginAsync(string username, string password)
        {
            var @user =  await Task.FromResult(_userRepository.GetOrFail(@username).Result);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }
            if (!SecurityClass.ComparePassword(password,user.password))
            {
                throw new Exception("Invalid credentials");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.role);
            return new TokenDTO
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.role
            };
        }
        public async Task<AccountDTO> GetAccountAsync(Guid id)
        {
            var @user = await _userRepository.GetOrFail(id);
            return _mapper.Map<AccountDTO>(@user);
        }
        public async Task<Details> GetAccountDetailsAsync(Guid id)
        {
            var @user = await _userRepository.GetOrFail(id);
            return _mapper.Map<Details>(@user);
        }
    }
}
