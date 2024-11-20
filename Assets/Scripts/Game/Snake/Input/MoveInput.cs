using Modules;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveInput : IMoveInput
    {
        private readonly GameCycle _gameCycle;
        private readonly InputMap _inputMap;

        public MoveInput(GameCycle gameCycle, InputMap inputMap)
        {
            _gameCycle = gameCycle;
            _inputMap = inputMap;
        }

        public SnakeDirection GetMoveDirection()
        {
            if (!_gameCycle.IsPlaying)
                return SnakeDirection.NONE;

            if (Input.GetKey(_inputMap.MoveUp))
                return SnakeDirection.UP;
            if (Input.GetKey(_inputMap.MoveDown))
                return SnakeDirection.DOWN;
            if (Input.GetKey(_inputMap.MoveLeft))
                return SnakeDirection.LEFT;
            if (Input.GetKey(_inputMap.MoveRight))
                return SnakeDirection.RIGHT;

            return SnakeDirection.NONE;
        }
    }
}