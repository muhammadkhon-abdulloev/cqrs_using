namespace Application.Common.Behaviours;

public class OrderBehaviour<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest: notnull
{
    public OrderBehaviour()
    { }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var response = await next();

        return response;
    }
}