using UnityEngine;

namespace WoodlandTest
{
    public class GameEvents
    {
        public delegate void GameEventVoid();
        public delegate void GameEventCoin(Coin _coin);
        public delegate void GameEventTransformInt(Transform transform,int _value);
    }
}
