using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NetworkB
{
    public class SpawnPoint : MonoBehaviour
    {
        private static List<SpawnPoint> spawnPoints = new List<SpawnPoint>(); // static List로 세팅한 이유?

        // 해당 script를 소유한 객체들이 전부 List<SpawnPoint> 자료구조를 가리키게 하기 위해서.

        private void OnEnable()
        {
            spawnPoints.Add(this);
        }

        private void OnDisable()
        {
            spawnPoints.Remove(this);
        }

        public static Vector3 GetRandomSpawnPos()
        {
            if (spawnPoints.Count == 0)
            {
                return Vector3.zero;
            }

            return spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 1);
        }
    } 
}
