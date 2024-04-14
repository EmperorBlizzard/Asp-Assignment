using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscribeEntity Create(SubscribeRegistrationForm form)
    {
        try
        {
            return new SubscribeEntity
            {
                Email = form.Email,
                DailyNewsletter = form.DailyNewsletter,
                AdvertisingUpdates = form.AdvertisingUpdates,
                WeekinReview = form.WeekinReview,
                EventUpdates = form.EventUpdates,
                StartupsWeekly = form.StartupsWeekly,
                Podcasts = form.Podcasts,
                Created = DateTime.Now,
                Modified = DateTime.Now,
            };
        }
        catch (Exception ex)
        {

        }
        return null!;
    }
}
