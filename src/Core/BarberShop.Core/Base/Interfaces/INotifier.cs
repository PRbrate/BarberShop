using BarberShop.Core.Base.Notifications;

namespace BarberShop.Core.Base.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}
