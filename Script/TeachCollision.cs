using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TeachManager.instance.CallTeach();
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TeachManager.instance.HideTeach();
        }
    }

}
