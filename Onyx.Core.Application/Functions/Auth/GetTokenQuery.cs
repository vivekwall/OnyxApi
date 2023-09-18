using MediatR;
using Onyx.Core.Application.Common;

namespace Onyx.Core.Application.Functions.Auth;

public class GetTokenQuery : IRequest<string>
{
    public UserLogin UserLogin { get; set; }
}

public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
{
    private readonly IAuthService _authService;

    public GetTokenQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellation)
    {
        return _authService.GetAuthToken(request.UserLogin);
    }
}