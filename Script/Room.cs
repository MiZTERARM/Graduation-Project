using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private string roomName;
    [SerializeField] private StringValue roomNameHolder;
    [SerializeField] private Notification roomnotification;
    [SerializeField] private string playerTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag) && !other.isTrigger)
        {
            roomNameHolder.value = roomName;
            roomnotification.Raise();
        }
    }

}
