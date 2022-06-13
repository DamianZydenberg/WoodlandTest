using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WoodlandTest
{
    public class EnemyPartolSetter : MonoBehaviour
    {
        private void Awake()
        {
            PatrolLocation[] patrolLocations = FindObjectsOfType<PatrolLocation>();
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                enemy.partolLocations.AddRange(patrolLocations);
            }
        }
    }
}
