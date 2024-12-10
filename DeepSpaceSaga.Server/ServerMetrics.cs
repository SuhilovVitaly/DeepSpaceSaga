namespace DeepSpaceSaga.Server;

public class ServerMetrics : IServerMetrics
{
    public int TickCounter => throw new NotImplementedException();

    public int TurnCounter => throw new NotImplementedException();

    public void IncreaseTick()
    {

    }

    public void IncreaseTurn()
    {

    }

    private readonly ConcurrentDictionary<Metrics, double> _metrics = new ConcurrentDictionary<Metrics, double>();

    public void Add(Metrics metric, double incrementValue)
    {
        _metrics.AddOrUpdate(
            metric,
            incrementValue, // Если ключ не существует, создаём с начальным значением
            (key, currentValue) => currentValue + incrementValue // Если ключ существует, увеличиваем значение
        );
    }

    public void Add(Metrics metric)
    {
        Add(metric, 1);
    }

    // Метод для получения текущего значения метрики
    public double Get(Metrics metric)
    {
        if (_metrics.TryGetValue(metric, out var value))
        {
            return value;
        }

        throw new KeyNotFoundException($"Metric '{metric}' not found.");
    }
}
