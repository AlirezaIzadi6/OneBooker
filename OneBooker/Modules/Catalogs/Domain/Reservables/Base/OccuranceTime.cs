namespace OneBooker.Modules.Catalogs.Domain.Reservables.Base;

public record OccuranceTime
{
    public WeekDays Days { get; init; }

    public TimeOnly StartAt { get; init; }

    public TimeOnly EndAt { get; init; }

    public TimeSpan Duration { get; init; }
}

public static class WeekDaysExtensions
{
    public static bool HasFlagFast(this WeekDays value, WeekDays flag)
    {
        return (value & flag) != 0;
    }
}