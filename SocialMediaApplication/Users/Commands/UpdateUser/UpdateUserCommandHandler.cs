using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger,
        IUsersRepository usersRepository,
        UserManager<User> userManager,
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("Updating User with Id: {UserId}, {Updated}", currentUser!.Id, request);

        var user = await userManager.FindByIdAsync(currentUser!.Id)
            ?? throw new NotFoundException(nameof(User), currentUser.Id);

        mapper.Map(request, user);

        await usersRepository.UpdateAsync(user);
    }
}
