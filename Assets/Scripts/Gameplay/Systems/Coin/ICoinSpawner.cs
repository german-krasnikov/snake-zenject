using Modules;
using UnityEngine;

namespace Gameplay
{
    public interface ICoinSpawner
    {
        Coin CreateAt(Vector2Int position);
        void Remove(Coin coin);
    }
}