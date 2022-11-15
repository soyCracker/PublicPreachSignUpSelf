using PPSUF.Service.Models.Common;

namespace PPSUF.Service.Interfaces
{
    public interface IStorageService
    {
        PublicPreachSchedule GetThisWeekSchedule();

        PublicPreachSchedule GetFixedSchedule();
    }
}
