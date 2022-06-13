using UnityEngine;
using UnityEngine.AI;

namespace WoodlandTest
{
    public class Door : MonoBehaviour
    {
        public DoorType doorType;
        public float doorWidth;

        public Material materialGreen;
        public Material materialRed;

        void OnValidate()
        {
            DoorSlider[] doorSliders = GetComponentsInChildren<DoorSlider>();
            DoorOpener[] doorOpeners = GetComponentsInChildren<DoorOpener>();

            foreach (DoorSlider doorSlider in doorSliders)
            {
                doorSlider.directionFactor = doorSlider.doorSide == DoorSide.Left ? -1 : 1;
                doorSlider.transform.localPosition = new Vector3(doorSlider.directionFactor * doorSlider.playerOnlyDoor.doorWidth / 4, 2, 0);
                doorSlider.transform.localScale = new Vector3(doorSlider.playerOnlyDoor.doorWidth / 2, 5, 0.1f);

                if (doorType == DoorType.PlayerOnly) doorSlider.gameObject.GetComponent<MeshRenderer>().material = materialGreen;
                else 
                {
                    doorSlider.gameObject.GetComponent<MeshRenderer>().material = materialRed;
                    doorSlider.gameObject.GetComponent<NavMeshObstacle>().carving = false;
                }
            }

            if (doorType == DoorType.PlayerOnly)
            {
                doorOpeners[0].acceptedEntities.Clear();
                doorOpeners[0].acceptedEntities.Add(EntityType.Player);
            }
            else
            {
                doorOpeners[0].acceptedEntities.Clear();
                doorOpeners[0].acceptedEntities.Add(EntityType.Player);
                doorOpeners[0].acceptedEntities.Add(EntityType.Enemy);
            }
        }
    }
}
