using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject enemyPrefab;
        public float spawnTime = 4f;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            spawnTime = spawnTime - Time.deltaTime;
            if (spawnTime <= 0)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = transform.position;
                enemy.transform.up = transform.up;
                spawnTime = 4;
            }

        }
    }
}
