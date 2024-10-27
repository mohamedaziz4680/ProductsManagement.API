using MediatR;

namespace ProductsManagement.Application.Common.Commands;

public class PingCommandHandler : IRequestHandler<PingCommand, string>
{
    public Task<string> Handle(PingCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}