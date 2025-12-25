using MediatR;
using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Events;

namespace Pearogram.BuildingBlocks.Persistence.ServiceConfigurations;

public sealed class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;
    public MediatRDomainEventDispatcher(IMediator mediator) => _mediator = mediator;

    public Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken ct = default)
    {
        try
        {
            var list = events.ToList();
            Console.WriteLine($"[DISPATCH] {list.Count} domain events");
            return Task.WhenAll(list.Select(e => _mediator.Publish(e, ct)));
        }
        catch (Exception ex)
        {

            throw;
        }
   
    }
}