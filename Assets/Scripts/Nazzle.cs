using UnityEngine;

namespace Assets.Scripts
{
    public class Nazzle : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject bulletPrefab;
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // Happens the moment the user clicks the left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.transform.up = transform.up;
            }
        }
    }
}
