using UnityEngine;

namespace WoodlandTest
{
    public class Entity : MonoBehaviour
    {
        public EntityType entityType;
        protected Transform respawnTransform;
        virtual protected void Awake()
        {
            // Autograb respawn point based on position on scene
            respawnTransform = transform;
        }
    }
}
