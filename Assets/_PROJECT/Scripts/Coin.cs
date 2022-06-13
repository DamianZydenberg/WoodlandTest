using UnityEngine;

namespace WoodlandTest
{
    public class Coin : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player _))
            {
                GameEventsMain.OnCoinPickedUp(this);
            }
        }

        void Update() => transform.rotation *= Quaternion.Euler(90 * Time.deltaTime, 0, 0);
    }
}
