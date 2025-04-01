using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CodingGym11 : MonoBehaviour
{
    public Tilemap tilemap;
    public CinemachineImpulseSource impulseSource;
    Vector2 movement;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        impulseSource = GetComponent<Cinemachine.CinemachineImpulseSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if(!isMoving && movement.magnitude > 0)
        {
            isMoving = true;

            impulseSource.GenerateImpulse();
        }
        else
        {
            isMoving = false;
        }
    }

}
