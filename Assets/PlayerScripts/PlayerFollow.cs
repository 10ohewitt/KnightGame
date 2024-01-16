using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject player;
        [SerializeField] public float cameraHeight = 0f; 
        public void Update()
        {
            Vector3 pos = player.transform.position;
            pos.z += cameraHeight;
            transform.position = pos;
        }
    }
}
