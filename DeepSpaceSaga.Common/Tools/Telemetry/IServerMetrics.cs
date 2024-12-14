namespace DeepSpaceSaga.Common.Tools.Telemetry;

public interface IServerMetrics
{
    void Add(Metrics metric, double incrementValue = 1);

    void AddMilliseconds(Metrics metric, double milliseconds);

    double Get(Metrics metric);

    double GetAverageMillisecondst(Metrics metric);
}
