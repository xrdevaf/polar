using BlazorLocal.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Services
{
    public interface IPushNotificationsQueue
    {
        void Enqueue(LogMessageEntry message);

        Task<LogMessageEntry> DequeueAsync(CancellationToken cancellationToken);
    }
}