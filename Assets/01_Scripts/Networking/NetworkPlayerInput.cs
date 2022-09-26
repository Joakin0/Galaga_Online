using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerInput : MonoBehaviour
{

    Quaternion cameraRotation;
    Vector3 directionShoot;
    NetworkPlayerController thisController;
    private Vector2 movDirection;
    public Transform worldRefence;

   

    

    private void Awake()
    {
        
    }
    void Start()
    {

    }
    private void Update()
    {
        movDirection.x = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
    public PlayerInput GetInput()
    {



        PlayerInput temp = new PlayerInput();
        temp.movDirection = movDirection;
        temp.actPosition = transform.position;
       

        return temp;



    }

}

public struct PlayerInput : INetworkInput
{
    public Vector3 movDirection;
    public Vector3 actPosition;
   
}
