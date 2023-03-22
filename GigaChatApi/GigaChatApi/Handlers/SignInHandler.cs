using MediatR;
using Microsoft.AspNetCore.Identity;
using GigaChatApi.Models;
using System.Net;
using GigaChatApi.Exceptions;
using GigaChatApi.Queries;
using AutoMapper;
using GigaChatApi.Dtos;
using GigaChatApi.Security;

namespace GigaChatApi.Handlers
{
    public class SignInHandler : IRequestHandler<SignInQuery, UserDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly JWTGenerator _jwtGenerator;

        public SignInHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, JWTGenerator jwtGenerator) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<UserDTO> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) { throw new RestException(HttpStatusCode.Unauthorized); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                userDto.Token = _jwtGenerator.GenerateToken(user);
                return userDto;
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}
