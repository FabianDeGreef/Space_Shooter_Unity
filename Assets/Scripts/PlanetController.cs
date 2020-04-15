using UnityEngine;

namespace Assets.Scripts
{
    public class PlanetController : MonoBehaviour
    {
        public float startingHp = 10f;
        public float hp { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            hp = startingHp;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = mousePosition - transform.position;
            direction.z = 0;
            transform.up = direction;
        }
    }
}
