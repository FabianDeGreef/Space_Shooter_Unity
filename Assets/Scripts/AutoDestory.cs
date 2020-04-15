using UnityEngine;

namespace Assets.Scripts
{
    public class AutoDestory : MonoBehaviour
    {
        public float lifeTime = 2f;
        // Start is called before the first frame update

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            lifeTime = lifeTime - Time.deltaTime;

            if (lifeTime<=0)
            {
                Destroy(gameObject);
            }

        }
    }
}
