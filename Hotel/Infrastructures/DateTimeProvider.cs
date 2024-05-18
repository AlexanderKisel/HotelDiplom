using Hotel.Common;

namespace Hotel.Infrastructures
{
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTimeOffset IDateTimeProvider.UtcNow => DateTimeOffset.UtcNow;
    }
}
