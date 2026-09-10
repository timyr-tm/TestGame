using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Godot;
using Serilog.Events;
using Serilog.Formatting;

using static Serilog.Core.Constants;

namespace TestGame.Game.Logging;

public class StructuredFormatter(string dateTimeFormat = "") : ITextFormatter {
	private static readonly IReadOnlyDictionary<LogEventLevel, string> LevelColors = new System.Collections.Generic.Dictionary<LogEventLevel, string> {
		[LogEventLevel.Debug] = Colors.Gray.ToHtml(),
		[LogEventLevel.Information] = Colors.White.ToHtml(),
		[LogEventLevel.Warning] = Colors.Orange.ToHtml(),
		[LogEventLevel.Error] = Colors.OrangeRed.ToHtml(),
		[LogEventLevel.Fatal] = Colors.Red.ToHtml()
	};

	private static readonly int MaxLengthLevelName = Enum.GetNames<LogEventLevel>()
		.Select(name => name.Length)
		.Max();

	private static void RenderException(Exception exception, TextWriter output, bool hasProperties) {
		output.Write(hasProperties ? '│' : ' ');
		output.Write($" [color=red]{exception.GetType().Name}: {exception.Message}[/color]");

		if (exception.StackTrace != null) {
			char startChar = hasProperties? '│' : ' ';
			foreach (string line in exception.StackTrace.Split('\n')) {
				output.Write(output.NewLine);
				output.Write(startChar);
				output.Write($" [color=red]{line}[/color]");
			}
		}
		if (hasProperties) 
			output.Write(output.NewLine);
	}

	private static void RenderProperties(IReadOnlyDictionary<string, LogEventPropertyValue> properties, TextWriter output) {
		int lastIndex = properties.Count - 1;
		foreach ((int index, KeyValuePair<string, LogEventPropertyValue> item) in properties.Index()) {
			bool isLast = index == lastIndex;
			
			output.Write(isLast ? '└' : '├');
			output.Write($"╴[color=green]{item.Key}[/color]: ");
			item.Value.Render(output);
			
			if (!isLast)
				output.Write(output.NewLine);
		}
	}
	
	public void Format(LogEvent logEvent, TextWriter output) {
		Dictionary<string, LogEventPropertyValue> properties = new(logEvent.Properties);
		string context = "Unknown";
		
		if (properties.ContainsKey(SourceContextPropertyName)) {
			context = properties[SourceContextPropertyName].ToString("l", null);
			properties.Remove(SourceContextPropertyName);
		}
		
		bool hasProperties = properties.Count > 0;
		bool hasData = logEvent.Exception != null || hasProperties;

		output.Write(hasData ? "┌╴" : "  ");
		
		output.Write($"[color=blue]{logEvent.Timestamp.ToString(dateTimeFormat)}[/color] ");
		output.Write($"[color={LevelColors[logEvent.Level]}]{logEvent.Level.ToString().PadLeft(MaxLengthLevelName)}[/color] ");
		output.Write($"[color=green]{context}[/color] ");
		logEvent.MessageTemplate.Render(logEvent.Properties, output);

		if (hasData)
			output.Write(output.NewLine);
		
		if (logEvent.Exception != null)
			RenderException(logEvent.Exception, output, hasProperties);
		if (hasProperties)
			RenderProperties(properties, output);
	}
}