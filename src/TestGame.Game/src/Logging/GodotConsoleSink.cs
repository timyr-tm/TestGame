using System.IO;
using Godot;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace TestGame.Game.Logging;

public sealed class GodotConsoleSink(ITextFormatter? formatter = null): ILogEventSink {
	private readonly ITextFormatter _formatter = formatter ?? new StructuredFormatter();
	
	public void Emit(LogEvent @event) {
		TextWriter writer = new StringWriter();
		_formatter.Format(@event, writer);
		GD.PrintRich(writer.ToString());
	}
}