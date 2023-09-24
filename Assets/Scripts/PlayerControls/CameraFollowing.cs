using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public class CameraFollowing : MonoBehaviour
    {
        private float staticZCord;
        private void Awake() => staticZCord = transform.position.z;
        void Update()
        {
            if (transform.parent.gameObject.activeInHierarchy)
            {
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, staticZCord);
            }
        }
    }
}
