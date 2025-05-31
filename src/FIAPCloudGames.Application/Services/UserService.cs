using AutoMapper;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Interfaces;
using FIAPCloudGames.Domain.Repositores;
using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;
using System.Linq.Expressions;

namespace FIAPCloudGames.Application.Services;

public class UserService: IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public UserService(IUnitOfWork unitOfWork, 
        IMapper mapper, 
        IUserRepository userRepository,
        IJwtProvider jwtProvider)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }


    public async Task<UserResponse> Create(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.CreatedAt = DateTime.UtcNow;

        // TODO: Criar metodo de criptografia do password.

        await _userRepository.AddAsync(user);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<UserResponse>(user);
    }

    public async Task Update(UpdateUserRequest request)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == request.Id);
        if (!exists)
            throw new Exception("The user doesn't exist");

        Expression<Func<User, bool>> predicate = x => x.Id == request.Id;
        var userCurrent = await _userRepository.GetByIdAsync(predicate);

        var user = _mapper.Map<User>(request);
        user.CreatedAt = userCurrent.CreatedAt;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist");

        Expression<Func<User, bool>> predicate = x => x.Id == id;
        var user = await _userRepository.GetByIdAsync(predicate);

        await _userRepository.DeleteAsync(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<UserResponse>> GetAll()
    {
        Expression<Func<User, bool>> predicate = x => x.IsActive == true;
        var users = await _userRepository.GetAllAsync(predicate);

        var response = _mapper.Map<IEnumerable<UserResponse>>(users);

        return response;
    }

    public async Task<UserResponse> GetById(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist.");

        Expression<Func<User, bool>> predicate = x => x.Id == id;
        var user = await _userRepository.GetByIdAsync(predicate);

        var response = _mapper.Map<UserResponse>(user);

        return response;
    }

    public async Task Active(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist.");

        Expression<Func<User, bool>> predicate = x => x.Id == id;
        var user = await _userRepository.GetByIdAsync(predicate);

        user.IsActive = true;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task Inactive(int id)
    {
        var exists = await _userRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("The user doesn't exist.");

        Expression<Func<User, bool>> predicate = x => x.Id == id; 
        var user = await _userRepository.GetByIdAsync(predicate);
        
        user.IsActive = false;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task<TokenResponse> Login(LoginRequest request)
    {
        bool passwordValid = await _userRepository.Login(request.Email, request.Password);

        if (request.Email.Contains("adm")) passwordValid = true;//TODO remover quando buscar no banco

        if (!passwordValid)
            throw new Exception("The specified email or password are incorrect.");

        var roleQueVaiVimDoCadastroUsuario = "admin";
        string token = _jwtProvider.GenerateToken(request.Email, roleQueVaiVimDoCadastroUsuario);

        return new TokenResponse(token, true);
    }
}
