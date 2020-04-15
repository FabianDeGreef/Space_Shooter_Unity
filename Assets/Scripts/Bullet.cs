using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        // Basic Game Design Tips
        // Unity real code is in  C++ 
        // most used objects 
        // -GameObject
        // -Time.DeltaTime // Time that moved -> frame rate faster -> delta time slower , frame rate slower delta time longer
        // -Transform (transform game object component)
        // Start and update always used 
        // Spawn ups
        // Bos Fight 
        // Reload
        // Recoil
        // Random enemy scale, color, hp
        // UI Score

        public float speed = 10f;
        public float damage = 1f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

            //Move the bullet forward in the direction of the up vector
            transform.position = transform.position + transform.up * speed * Time.deltaTime; // arrow + arrow , speed to make bullet slower
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            var enemy = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                var enemyHp = enemy.hp -= damage;
                if (enemyHp <= 0)
                {
                    Debug.Log("Enemy Destroyed");
                    //Destroy(enemy.gameObject);
                    enemy.Destroy();
                }
                Destroy(gameObject);
            }
        }
    }
}
