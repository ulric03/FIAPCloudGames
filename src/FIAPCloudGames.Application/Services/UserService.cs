using AutoMapper;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Repositores;
using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;
using FIAPCloudGames.Domain.Services;

namespace FIAPCloudGames.Application.Services;

public class UserService: IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }


    public async Task<UserResponse> Create(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResponse>(user);
    }

    public async Task Update(UpdateUserRequest request)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == request.Id);
        if (!exists)
            throw new Exception("The user doesn't exist");

        var user = _mapper.Map<User>(request);

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist");

        var user = await _userRepository.GetByIdAsync(id);

        await _userRepository.DeleteAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<UserResponse>> GetAll()
    {
        var users = await _userRepository.GetAllAsync();

        var response = _mapper.Map<IEnumerable<UserResponse>>(users);

        return response;
    }

    public async Task<UserResponse> GetById(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist.");

        var user = await _userRepository.GetByIdAsync(id);
        var response = _mapper.Map<UserResponse>(user);

        return response;
    }

    public async Task Active(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist.");

        var user = await _userRepository.GetByIdAsync(id);

        user.IsActive = true;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task Inactive(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist.");

        var user = await _userRepository.GetByIdAsync(id, new List<string> { "User" });
        
        user.IsActive = false;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task<TokenResponse> Login(LoginRequest request)
    {
        bool passwordValid = await _userRepository.Login(request.Email, request.Password);

        if (!passwordValid)
            throw new Exception("The specified email or password are incorrect.");

        string token = string.Empty; //_jwtProvider.Create(request);

        return new TokenResponse(token, true);
    }
}
