using Modules;
using UnityEngine;

namespace SampleGame
{
    public interface IMoveInput
    {
        SnakeDirection GetMoveDirection();
    }
}