using System.Collections.Generic;
using UnityEngine;

namespace WoodlandTest
{
    public class DoorOpener : MonoBehaviour
    {
        [SerializeField] List<DoorSlider> doorSliders;

        void OnTriggerEnter(Collider other)
        {
            foreach (DoorSlider doorSlider in doorSliders)
                doorSlider.Open();
        }

        void OnTriggerExit(Collider other)
        {
            foreach (DoorSlider doorSlider in doorSliders)
                doorSlider.Close();
        }
    }
}
