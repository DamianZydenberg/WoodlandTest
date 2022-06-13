using StarterAssets;
using UnityEngine;

namespace WoodlandTest
{
    public class Player : Entity
    {
        [HideInInspector] public ThirdPersonController thirdPersonController;
        override protected void Awake()
        {
            base.Awake();
            thirdPersonController = GetComponent<ThirdPersonController>();
        }
    }
}
