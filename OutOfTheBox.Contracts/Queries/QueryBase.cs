using MediatR;

namespace OutOfTheBox.Contracts.Queries
{
    public class QueryBase<T> : IRequest<T> where T : class
    {
    }
}
