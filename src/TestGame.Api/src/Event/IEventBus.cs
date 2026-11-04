namespace TestGame.Api.Event;

public interface IEventBus {
    public Task Publish<T>(T @event) where T: Event;
}
