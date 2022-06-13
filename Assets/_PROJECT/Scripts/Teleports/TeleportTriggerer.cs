using Cysharp.Threading.Tasks;
using UnityEngine;

namespace WoodlandTest
{
    public class TeleportTriggerer : MonoBehaviour
    {
        [SerializeField] TeleportEntrance teleportPad;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player)) PerformTeleport(player).Forget();
        }

        async UniTaskVoid PerformTeleport(Player _player)
        {
            _player.thirdPersonController.enabled = false;
            GameEventsMain.OnTeleportTriggered(_player.transform, teleportPad.targetDestinationID);
            // Because character controller kept overriding the positiong with its
            // Move() method in Update(), teleportation required 2 - frame delay
            // for deactivation, position overwrite and activation
            await UniTask.DelayFrame(2);
            _player.thirdPersonController.enabled = true;
        }
    }
}
