using DeepSpaceSaga.Common.Tools;

namespace DeepSpaceSaga.Server.Generation
{
    internal class GameSessionGenerator
    {
        public static GameSession ProduceSession(int sessionId = -1)
        {
            if (sessionId == -1)
                return EmptySession();

            throw new NotImplementedException();
        }

        private static GameSession EmptySession()
        {
            var result = new GameSession
            {
                Id = RandomGenerator.GetId(),
                IsRunning = false,
                SpaceMap = CelestialMapGenerator.GenerateEmptyBase()
            };

            return result;
        }
    }
}
