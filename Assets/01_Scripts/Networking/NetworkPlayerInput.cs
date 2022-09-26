using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerInput : MonoBehaviour
{

    Quaternion cameraRotation;
    Vector3 directionShoot;
    NetworkPlayerController thisController;
    private Vector3 movPosition;
    public Transform worldRefence;

   

    

    private void Awake()
    {
        
    }
    void Start()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
       
    }
    public PlayerInput GetInput()
    {
        PlayerInput temp = new PlayerInput();
        temp.movDirection = movPosition;
        temp.actPosition = transform.position;
        


        
        return temp;

    }

}

public struct PlayerInput : INetworkInput
{
    public Vector3 movDirection;
    public Vector3 actPosition;
   
}
