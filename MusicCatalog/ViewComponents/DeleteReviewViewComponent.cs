using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Review;

namespace MusicCatalog.ViewComponents;

public class DeleteReviewViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string songId, int id)
    {

        var review = new GetReviewDto
        {
            SongId = songId,
            Id = id
        };

        return View(review);
    }
}