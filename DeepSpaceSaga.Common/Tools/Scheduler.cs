namespace DeepSpaceSaga.Tools;

public class Scheduler
{
    private static Scheduler _instance;
    private readonly List<Timer> _timers = new List<Timer>();

    private Scheduler() { }

    public static Scheduler Instance => _instance ?? (_instance = new Scheduler());

    public void ScheduleTask(int delayInMilliseconds, double intervalInMilliseconds, Action task, Action<string> logger = null)
    {
        var now = DateTime.Now;
        var firstRun = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond).AddMilliseconds(delayInMilliseconds);

        if (now > firstRun)
        {
            firstRun = firstRun.AddDays(1);
        }

        var timeToGo = firstRun - now;

        if (timeToGo <= TimeSpan.Zero)
        {
            timeToGo = TimeSpan.Zero;
        }

        var timer = new Timer(x =>
        {
            task.Invoke();
        }, null, timeToGo, TimeSpan.FromMilliseconds(intervalInMilliseconds));

        logger?.Invoke("Add schedule task.");

        _timers.Add(timer);
    }
}