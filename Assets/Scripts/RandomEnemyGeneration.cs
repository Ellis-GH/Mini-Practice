using UnityEngine;
using UnityEngine.AI;

public class RandomEnemyGeneration : MonoBehaviour
{
    int max = 2;
    public GameObject EnemyPrefab;
    Vector2 GeneratedPosition()
    {
        int x, y;
        x = Random.Range(0, 50);
        y = Random.Range(0, 50);
        return new Vector2(x, y);
    }
    
    Vector2 NavMeshPosition()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(GeneratedPosition(), out hit, Mathf.Infinity, NavMesh.AllAreas);
        return hit.position;
    }
    
    void Start()
    {
        for (int i = 0; i < max; i++)
        {
            Instantiate(EnemyPrefab, NavMeshPosition(), Quaternion.identity);
        }
    }
}
