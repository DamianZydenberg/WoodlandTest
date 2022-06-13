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

        delegate void Delegate();
        Delegate UpdateFunction;

        void Awake()
        {
            directionFactor = doorSide == DoorSide.Left ? -1 : 1;
            targetClosedPosition = transform.position;
            targetOpenedPosition = transform.position + directionFactor * transform.localScale.x * transform.right;
        }
        void Update() => UpdateFunction?.Invoke();

        public void Open() => UpdateFunction = OpeningFunction;
        public void Close() => UpdateFunction = ClosingFunction;

        void OpeningFunction()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetOpenedPosition, 10 * Time.deltaTime);
            if (Vector3.Magnitude(transform.position - targetOpenedPosition) < 0.01f)
            {
                transform.position = targetOpenedPosition;
                UpdateFunction = null;
            }
        }
        void ClosingFunction()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetClosedPosition, 10 * Time.deltaTime);
            if (Vector3.Magnitude(transform.position - targetClosedPosition) < 0.01f)
            {
                transform.position = targetClosedPosition;
                UpdateFunction = null;
            }
        }
    }
}
