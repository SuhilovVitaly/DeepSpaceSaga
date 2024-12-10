namespace DeepSpaceSaga.Tests.Server;

internal class ServerMetrics : IServerMetrics
{
    public int TickCounter => throw new NotImplementedException();

    public int TurnCounter => throw new NotImplementedException();

    public void IncreaseTick()
    {
        
    }

    public void IncreaseTurn()
    {
        
    }

    private readonly ConcurrentDictionary<string, double> _metrics = new ConcurrentDictionary<string, double>();

    public void UpdateMetric(string metricName, double incrementValue)
    {
        if (string.IsNullOrWhiteSpace(metricName))
        {
            throw new ArgumentException("Metric name cannot be null or empty.", nameof(metricName));
        }

        // Обновляем значение метрики потокобезопасно
        _metrics.AddOrUpdate(
            metricName,
            incrementValue, // Если ключ не существует, создаём с начальным значением
            (key, currentValue) => currentValue + incrementValue // Если ключ существует, увеличиваем значение
        );
    }

    // Метод для получения текущего значения метрики
    public double GetMetric(string metricName)
    {
        if (_metrics.TryGetValue(metricName, out var value))
        {
            return value;
        }

        throw new KeyNotFoundException($"Metric '{metricName}' not found.");
    }
}
