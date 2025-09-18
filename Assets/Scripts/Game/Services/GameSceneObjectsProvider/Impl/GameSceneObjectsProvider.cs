namespace Game.Services.GameSceneObjectsProvider.Impl
{
    public class GameSceneObjectsProvider : IGameSceneObjectsProvider
    {
        public GameSceneObjects GameSceneObjects { get; }

        public GameSceneObjectsProvider(GameSceneObjects gameSceneObjects)
        {
            GameSceneObjects = gameSceneObjects;
        }
    }
}