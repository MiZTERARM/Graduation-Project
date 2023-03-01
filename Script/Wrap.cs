using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    public Transform warpTarget;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = warpTarget.position;
        /*Camera.main.transform.position = warpTarget.position;*/
    }
}
