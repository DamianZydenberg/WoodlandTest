using UnityEngine;

namespace WoodlandTest
{
    public class DoorSlider : MonoBehaviour
    {
        [HideInInspector] public float directionFactor;

        public Door playerOnlyDoor;
        public DoorSide doorSide;

        Vector3 targetOpenedPosition;
        Vector3 targetClosedPosition;

        void Awake()
        {
            directionFactor = doorSide == DoorSide.Left ? -1 : 1;
            targetClosedPosition = transform.position;
            targetOpenedPosition = transform.position + directionFactor * transform.localScale.x * Vector3.right;
        }

        public void Open()
        {
            transform.position = targetOpenedPosition;
        }

        public void Close()
        {
            transform.position = targetClosedPosition;
        }
    }

}
