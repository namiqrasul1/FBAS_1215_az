using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Dinner
    {
        public static Error NotFound => Error.NotFound(
            code: "Dinner.NotFound",
            "Dinner not found");
    }
}