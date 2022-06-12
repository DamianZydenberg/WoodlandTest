using UnityEngine;

namespace WoodlandTest
{
    public class PlayerOnlyDoor : MonoBehaviour
    {
        public float openingSpeed;
        public float doorWidth;

        void OnValidate()
        {
            DoorSlider[] doorSliders = GetComponentsInChildren<DoorSlider>();

            foreach (DoorSlider doorSlider in doorSliders)
            {
                doorSlider.directionFactor = doorSlider.doorSide == DoorSide.Left ? -1 : 1;
                doorSlider.transform.localPosition = new Vector3(doorSlider.directionFactor * doorSlider.playerOnlyDoor.doorWidth / 4, 2, 0);
                doorSlider.transform.localScale = new Vector3(doorSlider.playerOnlyDoor.doorWidth / 2, 5, 0.1f);
            }
        }
    }
}
