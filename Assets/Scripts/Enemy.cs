using EZCameraShake;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        public  GameObject target;
        private PlanetController _planet;
        public float damage = 1f;
        public float speed = 3f;
        public float startHp;
        public Object explosionRef { get; set; }
        public AudioClip explosionSound;

        public float hp { get; set; }
        public float size;


        // Start is called before the first frame update
        void Start()
        {
            // Search scene for planetController;
            _planet = FindObjectOfType<PlanetController>();
            hp = startHp;
            size = Random.Range(0.04f, 0.10f);
            if (size > 0.05 && size < 0.06)
            {
                hp = 3;
            }
            else if (size >= 0.06)
            {
                hp = 5;
            }

            explosionRef = Resources.Load("explode");
        }


        // Update is called once per frame
        void Update()
        {
            //Debug.Log(size);
            transform.localScale = new Vector3(size,size);

            // Up vector setup chase behaviour 
            Vector3 direction = _planet.transform.position - transform.position;
            direction.z = 0;
            transform.up = direction;
            transform.position = transform.position + transform.up * speed * Time.deltaTime;
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            //did target planet
            if (col.gameObject == _planet.gameObject)
            {
                _planet.hp -= damage;
                CameraShaker.Instance.ShakeOnce(0.2f, 0.2f, 0.15f, 0.15f);
                //GameObject explosion = (GameObject) Instantiate(explosionRef);
                //explosion.transform.position = new Vector3(transform.position.x, transform.position.y+ .3f,transform.position.z);
                //Destroy(gameObject);
                Destroy();
                Debug.Log($"Planet HP: {_planet.hp}");
            }
        }

        public void Destroy()
        {
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, 1);
            Destroy(explosion,2f);
        }
    }
}
