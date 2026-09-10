using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using Serilog;
using TestGame.Api.Event;

namespace TestGame.Game.Event;

public partial class EventBus: Node, IEventBus {
	public static EventBus Instance { get; private set; } = null!;

	private static readonly ILogger Logger = Log.ForContext<EventBus>();

	private readonly IDictionary<Type, ISet<Delegate>> _subs = new Dictionary<Type, ISet<Delegate>>();
	
	public override void _Ready() {
		Instance = this;
		Logger.Debug("Create instance");
	}

	public void Subscribe<T>(Func<T, Task> action) where T: IEvent {
		ArgumentNullException.ThrowIfNull(action);
		
		Type type = typeof(T);
		if (!_subs.ContainsKey(type))
			_subs[type] = new HashSet<Delegate>();
		_subs[type].Add(action);
	}

	public void Unsubscribe<T>(Func<T, Task> action) where T : IEvent {
		ArgumentNullException.ThrowIfNull(action);
		
		Type type = typeof(T);
		if (!_subs.ContainsKey(type))
			return;
		if (_subs[type].Count <= 1)
			_subs.Remove(type);
		else _subs[type].Remove(action);
	}

	public async Task Publish<T>(T @event) where T : IEvent {
		ArgumentNullException.ThrowIfNull(@event);
		
		if (!_subs.TryGetValue(typeof(T), out ISet<Delegate>? value))
			return;
		foreach (Delegate @delegate in value) {
			Func<T, Task> action = null!;
			try {
				action = (Func<T, Task>) @delegate;
				await action.Invoke(@event);
			}
			catch (Exception exception) {
				Logger
					.ForContext("Action", action)
					.Error(exception, "Exception when publishing an event");
			}
		}
	}
}