using Microsoft.AspNetCore.Mvc.Filters;
using Domain.Interfaces.Notifications;
using Domain.Notifications;
using Newtonsoft.Json;

namespace SimianApplication.Helpers.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationHandler<Notification> _notification;
        public NotificationFilter(INotificationHandler<Notification> notification)
        {
            _notification = notification;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            if (_notification.HasNotification())
            {
                context.HttpContext.Response.StatusCode = _notification.GetStatusCode();
                context.HttpContext.Response.ContentType = "application/json";

                var result = new ErrorResponse(_notification.GetStatusCode(), _notification.GetMessage(), _notification.GetNotificationsErrors());
                var notifications = JsonConvert.SerializeObject(result);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }

    }
}