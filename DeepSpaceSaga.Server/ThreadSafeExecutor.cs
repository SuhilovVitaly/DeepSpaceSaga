namespace DeepSpaceSaga.Server;

public class ThreadSafeExecutor
{
    private readonly ReaderWriterLockSlim _sessionLock = new();
    private readonly object _calculationLock = new object();
    private volatile bool _isCalculationInProgress;
    private static readonly ILog Logger = LogManager.GetLogger(typeof(ThreadSafeExecutor));

    public TResult ExecuteWithLock<TResult>(
        Func<TResult> operation,
        string operationName = "Operation")
    {
        // First check if calculation is already in progress using lock
        if (!Monitor.TryEnter(_calculationLock))
        {
            return default!; // Another thread is already executing
        }

        try
        {
            // Double-check pattern with volatile flag
            if (_isCalculationInProgress)
            {
                return default!;
            }

            _isCalculationInProgress = true;

            // Try to acquire write lock with timeout to prevent deadlocks
            if (!_sessionLock.TryEnterWriteLock(TimeSpan.FromSeconds(2)))
            {
                Logger.Info($"[ThreadSafeExecutor] Failed to acquire write lock within timeout for {operationName}");
                return default!;
            }

            try
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    return operation();
                }
                finally
                {
                    stopwatch.Stop();
                    Logger.Debug($"[ThreadSafeExecutor] {operationName} took {stopwatch.ElapsedMilliseconds}ms");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"[ThreadSafeExecutor] {operationName} error: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
            finally
            {
                if (_sessionLock.IsWriteLockHeld)
                {
                    _sessionLock.ExitWriteLock();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error($"[ThreadSafeExecutor] {operationName} error: {ex.Message}");
            throw;
        }
        finally
        {
            _isCalculationInProgress = false;
            Monitor.Exit(_calculationLock);
        }
    }
} 