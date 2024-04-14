using Infrastructure.Entities;
using Infrastructure.Models;
using System;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CourseEntity Create(CourseRegistrationForm form)
    {
        try
        {
            var dateTime = DateTime.Now;

            return new CourseEntity
            {
                Id = Guid.NewGuid().ToString(),
                Titel = form.Titel,
                Author = form.Author,
                OriginalPrice = form.OriginalPrice,
                Hours = form.Hours,
                IsDigital = form.IsDigital,
                Created = dateTime,
                LastUpdated = dateTime,
                ImageUrl = form.ImageUrl,
                BigImageUrl = form.BigImageUrl,
            };
        }
        catch { }

        return null!;
    }

    public static CourseEntity Create(CourseRegistrationForm form, int categoryId)
    {
        try
        {
            var dateTime = DateTime.Now;

            return new CourseEntity
            {
                Id = Guid.NewGuid().ToString(),
                Titel = form.Titel,
                Author = form.Author,
                OriginalPrice = form.OriginalPrice,
                Hours = form.Hours,
                IsDigital = form.IsDigital,
                Created = dateTime,
                LastUpdated = dateTime,
                ImageUrl = form.ImageUrl,
                BigImageUrl = form.BigImageUrl,
                CategoryId = categoryId,
            };
        }
        catch { }

        return null!;
    }

    public static Course Create(CourseEntity entity)
    {
        try
        {
            return new Course
            {
                Id = entity.Id,
                Titel = entity.Titel,
                Author = entity.Author,
                OriginalPrice = entity.OriginalPrice,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                LikesInProcent = entity.LikesInProcent,
                LikesInNumbers = entity.LikesInNumbers,
                IsDigital = entity.IsDigital,
                IsBestseller = entity.IsBestseller,
                ImageUrl = entity.ImageUrl,
                BigImageUrl = entity.BigImageUrl,
            };
        }
        catch { }

        return null!;
    }

    public static IEnumerable<Course> Create(List<CourseEntity> entities)
    {
        var courses = new List<Course>();

        try
        {
            foreach (var entity in entities)
            {
                courses.Add(Create(entity));
            }



        }
        catch { }
        return courses;
    }
}
