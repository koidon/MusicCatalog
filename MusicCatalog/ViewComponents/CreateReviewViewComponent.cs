using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Services.Reviews;

namespace MusicCatalog.ViewComponents;

public class CreateReviewViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(CreateReviewDto review)
    {
        return View(review);
    }
}