using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Threading.Tasks;
using Godot;
using Serilog;

namespace TestGame.Game.Event;
using TestGame.Api.Event;

public partial class EventBus: Node, IEventBus {
	public static EventBus Instance { get; private set; } = null!;

	private static readonly ILogger Logger = Log.ForContext<EventBus>();

    private IReadOnlyDictionary<Type, IReadOnlyCollection<Func<Event, Task>>> MainSubs
        => (IReadOnlyDictionary<Type, IReadOnlyCollection<Func<Event, Task>>>?) Assembly.GetExecutingAssembly()
            .GetType("TestGame.Api.Generated.EventSubs")
            ?.GetField("Subs")
            ?.GetValue(null)
            ?? ImmutableDictionary<Type, IReadOnlyCollection<Func<Event, Task>>>.Empty;

    public override void _Ready() {
		Instance = this;
		Logger
			.ForContext(nameof(Instance), Instance)
			.Debug("Create instance");
	}

    public Task Publish<T>(T @event) where T : Event {
        List<Task> tasks = new();
        for (Type? type = @event.GetType(); type != null && type.IsSubclassOf(typeof(Event)); type = type.BaseType) {
            if (!MainSubs.TryGetValue(type, out IReadOnlyCollection<Func<Event, Task>>? actions))
                continue;
            foreach (Func<Event, Task> action in actions)
                tasks.Add(action(@event));
        }
        return Task.WhenAll(tasks);
    }
}
