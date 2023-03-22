using AutoMapper;
using GigaChatApi.Commands;
using GigaChatApi.Dtos;
using GigaChatApi.Exceptions;
using GigaChatApi.Models;
using GigaChatApi.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace GigaChatApi.Handlers
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, UserDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly JWTGenerator _jwtGenerator;

        public SignUpHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, JWTGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<UserDTO> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByNameAsync(request.Username);
            if (user != null) { throw new RestException(HttpStatusCode.BadRequest, "User exists"); }

            IdentityResult result = await _userManager.CreateAsync(
                    new AppUser() { UserName = request.Username },
                    request.Password
            );
            var newUser = await _userManager.FindByNameAsync(request.Username);
            if (newUser == null) { throw new RestException(HttpStatusCode.InternalServerError); }

            await _signInManager.SignInAsync(newUser, false);

            if (result.Succeeded)
            {
                var userDto = _mapper.Map<UserDTO>(newUser);
                userDto.Token = _jwtGenerator.GenerateToken(newUser);
                return userDto;
            }

            throw new RestException(HttpStatusCode.BadRequest);
        }
    }
}
