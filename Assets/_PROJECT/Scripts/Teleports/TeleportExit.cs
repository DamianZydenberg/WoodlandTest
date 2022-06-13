using UnityEngine;

namespace WoodlandTest
{
    public class TeleportExit : MonoBehaviour
    {
        [SerializeField] int portalID;

        void OnEnable() => GameEventsMain.TeleportTriggered += TeleportEntityToLocation;
        void OnDisable() => GameEventsMain.TeleportTriggered -= TeleportEntityToLocation;

        void TeleportEntityToLocation(Transform _entityTransform, int _portalID)
        {
            if (_portalID == portalID)
            {
                // So apparently Character Controller scripts keeps overriding position
                // making teleportaion somehow difficult to implement (works on every other object)
                _entityTransform.position = transform.position;
                _entityTransform.rotation = transform.rotation;
            }
        }
    }
}
