using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WoodlandTest
{
    public class Enemy : Entity
    {
        [SerializeField] Transform eye;
        [SerializeField] Rigidbody rb;

        [SerializeField] float moveSpeed;
        [SerializeField] float scanningFrequency;
        [SerializeField] int scanningDensity;

        List<Vector3> raycastScanDirections = new List<Vector3>();
        float timer;

        delegate void Delegate();
        Delegate UpdateFunction;

        override protected void Awake()
        {
            base.Awake();
            // Cache vector list to avoid calculatin in runtime
            for (int i = 0; i <= scanningDensity; i++)
            {
                raycastScanDirections.Add(Quaternion.AngleAxis(i * 360f / scanningDensity, Vector3.up) * eye.forward);
            }
        }
        void Update()
        {
            UnspottedPlayerBehaviour();
        }

        private void UnspottedPlayerBehaviour()
        {
            timer += Time.deltaTime;
            if (timer >= scanningFrequency)
            {
                ScanForPlayer();
                timer = 0;
            }

            rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * Vector3.right);
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
                }
            }
        }
    }
}
