using Modules;
using Zenject;

namespace SampleGame
{
    public sealed class SnakeController : ITickable
    {
        private readonly IMoveInput _moveInput;
        private readonly GameCycle _gameCycle;
        private readonly ISnake _snake;
        
        public SnakeController(IMoveInput moveInput, GameCycle gameCycle, ISnake snake)
        {
            _moveInput = moveInput;
            _gameCycle = gameCycle;
            _snake = snake;
        }

        public void Tick()
        {
            if (!_gameCycle.IsPlaying)
                return;

            _snake.Turn(_moveInput.GetMoveDirection());
        }
    }
}