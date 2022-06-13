using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace WoodlandTest
{
    public class Enemy : Entity
    {
        [SerializeField] Transform eye;
        [SerializeField] NavMeshAgent navMeshAgent;

        [SerializeField] float scanningFrequency;
        [SerializeField] int scanningDensity;

        public List<PatrolLocation> partolLocations = new List<PatrolLocation>();

        Transform spottedPlayerTransform;
        List<Vector3> raycastScanDirections = new List<Vector3>();
        float scanTimer, destinationRefreshTimer;

        delegate void Delegate();
        Delegate UpdateFunction;

        override protected void Awake()
        {
            base.Awake();
            UpdateFunction = UnspottedPlayerBehaviour;

            // Cache vector list to avoid calculating in runtime
            for (int i = 0; i <= scanningDensity; i++)
            {
                raycastScanDirections.Add(Quaternion.AngleAxis(i * 360f / scanningDensity, Vector3.up) * eye.forward);
            }
        }

        // Moved away from Awake() method to avoid race conditions where
        // Awake of EnemyPatrolSetter would execute too late, resulting in 
        // attempt to choose from list of empty patrol locations (index out of range)
        void Start() => navMeshAgent.SetDestination(partolLocations[Random.Range(0, partolLocations.Count)].transform.position);
        void Update() => UpdateFunction?.Invoke();

        void UnspottedPlayerBehaviour()
        {
            scanTimer += Time.deltaTime;

            if (scanTimer >= scanningFrequency)
            {
                ScanForPlayer();
                scanTimer = 0;
            }

            if (Vector3.Magnitude(navMeshAgent.destination - transform.position) < 1f)
            {
                Debug.Log("Reached patrol position");
                navMeshAgent.SetDestination(partolLocations[Random.Range(0, partolLocations.Count)].transform.position);
            }
        }
        void SpottedPlayerBehaviour()
        {
            destinationRefreshTimer += Time.deltaTime;
            if (destinationRefreshTimer >= 1f)
            {
                navMeshAgent.SetDestination(spottedPlayerTransform.position);
            }
        }
        void ScanForPlayer()
        {
            // This should not be in update btw
            foreach (Vector3 scanDirection in raycastScanDirections)
            {
                Physics.Raycast(eye.position, scanDirection, out RaycastHit hitinfo, 100);
                if (hitinfo.collider.gameObject.TryGetComponent(out Player player))
                {
                    Debug.Log("Player spotted !");
                    spottedPlayerTransform = player.transform;
                    navMeshAgent.SetDestination(spottedPlayerTransform.position);
                    scanTimer = 0;
                    UpdateFunction = SpottedPlayerBehaviour;
                }
            }
        }
    }
}
