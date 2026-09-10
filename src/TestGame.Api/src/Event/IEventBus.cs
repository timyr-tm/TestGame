namespace TestGame.Api.Event;

public interface IEventBus {
	public void Subscribe<T>(Func<T, Task> action) where T: IEvent;

	public void Unsubscribe<T>(Func<T, Task> action) where T: IEvent;

	public Task Publish<T>(T @event) where T: IEvent;
}