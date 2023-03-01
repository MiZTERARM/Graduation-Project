using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
          
        public Transform target;
        public float lerpSpeed = 1.0f;

        [SerializeField]
        float leftLimit;
        [SerializeField]
        float rightLimit;
        [SerializeField]
        float bottomLimit;
        [SerializeField]
        float topLimit;
        
        private Vector3 offset;

        private Vector3 targetPos;

        


        private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;


        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z
            );
        }

    }
}
