public enum GameState
{
    GamePlay,
    Paused
}

public class GameStateManager
{
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();

            return _instance;
        }
    }

    public GameState currentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    public void SetState(GameState newGameState)
    {
        if (newGameState == currentGameState)
            return;

        currentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}
