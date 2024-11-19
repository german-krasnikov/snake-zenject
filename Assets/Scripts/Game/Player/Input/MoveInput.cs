
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

        public Vector3 GetMoveDirection()
        {
            Vector3 direction = Vector3.zero;
            if (!_gameCycle.IsPlaying)
                return direction;

            if (Input.GetKey(_inputMap.MoveUp))
                direction.z = 1;
            else if (Input.GetKey(_inputMap.MoveDown)) 
                direction.z = -1;

            if (Input.GetKey(_inputMap.MoveLeft))
                direction.x = -1;
            else if (Input.GetKey(_inputMap.MoveRight)) 
                direction.x = 1;

            return direction;
        }
    }
}