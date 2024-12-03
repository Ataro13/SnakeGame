

public class SnakeGameLogic : BaseGameLogic
{
    private SnakeGameplayState gameplayState = new SnakeGameplayState();

    public override void Update(float deltaTime)
    {
        gameplayState.Update(deltaTime);
    }

    public override void OnArrowUp() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Up);
    public override void OnArrowDown() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Down);
    public override void OnArrowLeft() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Left);
    public override void OnArrowRight() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Right);

    public void GotoGameplay() => gameplayState.Reset();
}