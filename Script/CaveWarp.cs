using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWarp : MonoBehaviour
{
    public Transform caveTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = caveTarget.position;
        Camera.main.transform.position = caveTarget.position;
    }
}
