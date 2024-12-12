using System.Collections.Concurrent;

namespace DeepSpaceSaga.Common.Tools.Telemetry;

public class ServerMetrics : IServerMetrics
{
    private int _tickCounter;
    private int _turnCounter;

    public int TickCounter => _tickCounter;
    public int TurnCounter => _turnCounter;

    public void IncreaseTick()
    {
        _tickCounter++;
    }

    public void IncreaseTurn()
    {
        _turnCounter++;
    }

    private readonly ConcurrentDictionary<Metrics, double> _metrics = new ConcurrentDictionary<Metrics, double>();

    private readonly ConcurrentDictionary<Metrics, (double Sum, int Count)> _averageMetrics = new ConcurrentDictionary<Metrics, (double Sum, int Count)>();

    private readonly ConcurrentDictionary<Metrics, int> _metricCounts = new ConcurrentDictionary<Metrics, int>();


    public void Add(Metrics metric, double incrementValue)
    {
        _metrics.AddOrUpdate(
            metric,
            incrementValue,
            (key, currentValue) => currentValue + incrementValue
        );
    }

    public void Add(Metrics metric)
    {
        Add(metric, 1);
    }

    public void AddMilliseconds(Metrics metric, double milliseconds)
    {
        _metricCounts.AddOrUpdate(
            metric,
            1,
            (key, currentCount) => currentCount + 1
        );

        _averageMetrics.AddOrUpdate(
            metric,
            (milliseconds, 1),
            (key, current) =>
            {
                double newSum = current.Sum + milliseconds;
                int newCount = current.Count + 1;

                return (newSum, newCount);
            }
        );

        var avg = GetAverageMilliseconds(metric);

        _metrics.AddOrUpdate(
            metric,
            avg,
            (key, currentValue) => avg
        );
    }

    public double GetAverageMilliseconds(Metrics metric)
    {
        if (_averageMetrics.TryGetValue(metric, out var value))
        {
            return value.Sum / value.Count;
        }

        throw new KeyNotFoundException($"Metric '{metric}' not found.");
    }

    public double Get(Metrics metric)
    {
        if (_metrics.TryGetValue(metric, out var value))
        {
            return value;
        }

        throw new KeyNotFoundException($"Metric '{metric}' not found.");
    }
}
