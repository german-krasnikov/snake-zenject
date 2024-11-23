using Modules;
using UnityEngine;

namespace Gameplay
{
    public interface ICoinSpawner
    {
        ICoin CreateAt(Vector2Int position);
    }
}