using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothing);
        }
    }

}
