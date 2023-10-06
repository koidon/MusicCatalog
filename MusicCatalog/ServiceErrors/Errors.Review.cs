using ErrorOr;

namespace MusicCatalog.ServiceErrors;

public static class Errors
{
    public static class Review
    {

        public static Error InvalidDescription => Error.Validation(
            code: "Review.InvalidDescription",
            description: $"Review description must be at least {Models.Review.MinContentLength}" +
                         $" characters long and at most {Models.Review.MaxContentLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Review.NotFound",
            description: "Review not found");
    }
}

