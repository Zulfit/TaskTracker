using System.Text.Json.Serialization;

namespace TaskTracker.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Todo,
    InProgress,
    Done
}
