using System.Collections.Generic;
using UnityEngine;

namespace WoodlandTest
{
    public class DoorOpener : MonoBehaviour
    {
        [SerializeField] List<DoorSlider> doorSliders;
        [HideInInspector] public List<EntityType> acceptedEntities = new List<EntityType>();

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Entity entity) && acceptedEntities.Contains(entity.entityType))
            {
                foreach (DoorSlider doorSlider in doorSliders)
                    doorSlider.Open();
            }
        }

        void OnTriggerExit(Collider other)
        {
            foreach (DoorSlider doorSlider in doorSliders)
                doorSlider.Close();
        }
    }
}
