namespace PPSUF.Service.Models.Common
{
    public class PublicPreachSchedule
    {
        public List<DaySchedule> DaySchedules { get; set; }
    }

    public class DaySchedule
    {
        public string DayOfWeek { get; set; }
        public DateTime SchuduleDate { get; set; }
        public List<Schedule> Schedules { get; set; }

    }

    public class Schedule
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Person> People { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
