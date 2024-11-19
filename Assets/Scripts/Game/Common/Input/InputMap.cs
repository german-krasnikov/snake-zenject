using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "InputMap",
        menuName = "SampleGame/New InputMap"
    )]
    public sealed class InputMap : ScriptableObject
    {
        [field: SerializeField]
        public KeyCode MoveLeft { get; private set; } = KeyCode.LeftArrow;

        [field: SerializeField]
        public KeyCode MoveRight { get; private set; } = KeyCode.RightArrow;

        [field: SerializeField]
        public KeyCode MoveUp { get; private set; } = KeyCode.UpArrow;

        [field: SerializeField]
        public KeyCode MoveDown { get; private set; } = KeyCode.DownArrow;
    }
}