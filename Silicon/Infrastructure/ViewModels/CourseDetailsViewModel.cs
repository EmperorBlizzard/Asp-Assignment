using Infrastructure.Models;
using WebApp.Models;

namespace Infrastructure.ViewModels;

public class CourseDetailsViewModel
{
    public Course Course { get; set; } = null!;

    public AuthorDescriptionModel AuthorDescription { get; set; } = null!;
    public CourseDescriptionModel CourseDescription { get; set; } = null!;

    public IEnumerable<CourseIncludeModel> Includes { get; set; } = [];

    public IEnumerable<CourseLearnModel> Learn { get; set; } = [];
    public IEnumerable<ProgramDetailsModel> ProgramDetails { get; set; } = [];
}
