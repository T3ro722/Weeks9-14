using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        if (player == null)
        {
            PlayerMoveSystem found = FindObjectOfType<PlayerMoveSystem>();
            if (found != null)
                player = found.transform;
        }

        // keep camera from offset
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }

    public void ResetCamera()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
