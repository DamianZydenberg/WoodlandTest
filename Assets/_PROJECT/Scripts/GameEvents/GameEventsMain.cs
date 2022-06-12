using UnityEngine;

namespace WoodlandTest
{
    public class GameEventsMain : GameEvents
    {
        public static GameEventTransformInt TeleportTriggered;

        public static void OnTeleportTriggered(Transform _transform, int _value) => TeleportTriggered?.Invoke(_transform, _value);
    }
}
