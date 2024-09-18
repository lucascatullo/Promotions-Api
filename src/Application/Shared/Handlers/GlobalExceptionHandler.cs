

using MediatR.Pipeline;
using PromotionEngine.Application.Shared.Dto;
namespace PromotionEngine.Application.Shared.Handlers;


public class GlobalExceptionHandler<TRequest, TResponse, TException>
  : IRequestExceptionHandler<TRequest, TResponse, TException>
      where TRequest : notnull
      where TResponse : notnull, BaseResponse, new()
      where TException : notnull, Exception
{
    private readonly ILogger<GlobalExceptionHandler<TRequest, TResponse, TException>> _logger;
    public GlobalExceptionHandler(
       ILogger<GlobalExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }
    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        var response = new TResponse
        {
            Success = false,
            Exception = exception
        };
        state.SetHandled(response);
        return Task.CompletedTask;
    }
}