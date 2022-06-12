using UnityEngine;

namespace WoodlandTest
{
    public class TeleportTriggerer : MonoBehaviour
    {
        [SerializeField] TeleportEntrance teleportPad;
        void OnTriggerEnter(Collider other) => GameEventsMain.OnTeleportTriggered(other.transform, teleportPad.targetDestinationID);
    }
}
