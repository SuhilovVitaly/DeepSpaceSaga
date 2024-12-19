namespace DeepSpaceSaga.Server.GameLoop.TurnCalculation;

/// <summary>
/// Интерфейс для калькуляции игрового хода
/// </summary>
public interface ITurnCalculator
{
    /// <summary>
    /// Асинхронно выполняет расчет игрового хода
    /// </summary>
    /// <param name="context">Контекст сессии с текущим состоянием игры</param>
    /// <returns>Обновленный контекст сессии после выполнения хода</returns>
    /// <exception cref="InvalidSessionException">Выбрасывается, если сессия недействительна</exception>
    /// <exception cref="InvalidGameStateException">Выбрасывается, если состояние игры не позволяет выполнить ход</exception>
    /// <exception cref="TurnCalculationException">Выбрасывается при ошибках во время расчета хода</exception>
    Task<SessionContext> ExecuteAsync(SessionContext context);

    /// <summary>
    /// Проверяет возможность выполнения хода для указанной сессии
    /// </summary>
    /// <param name="sessionId">Идентификатор игровой сессии</param>
    /// <returns>True, если ход может быть выполнен; иначе false</returns>
    Task<bool> CanCalculateTurnAsync(string sessionId);

    /// <summary>
    /// Отменяет текущий расчет хода для указанной сессии, если это возможно
    /// </summary>
    /// <param name="sessionId">Идентификатор игровой сессии</param>
    /// <returns>True, если отмена была успешной; иначе false</returns>
    Task<bool> CancelTurnCalculationAsync(string sessionId);
}
