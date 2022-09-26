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
    private bool goJail;
    public Transform worldRefence;

   

    

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //movDirection.x = Input.GetAxis("Horizontal");
        //movDirection.z = Input.GetAxis("Vertical");
        movPosition = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        cameraRotation = GameManager.current.mainCamera.transform.rotation;

        RaycastHit hit;
        if (Physics.Raycast(GameManager.current.mainCamera.transform.position, GameManager.current.mainCamera.transform.forward, out hit, Mathf.Infinity))
        {
            directionShoot = hit.point;
        }
        else
        {
            directionShoot = GameManager.current.mainCamera.transform.forward * 1000;
        }


        //if(Input.GetButtonDown("Jump"))
        //{
        //    goJail = true;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && PlayerNetwork.Local.team == 2)
        {
            goJail = true;
        }
    }
    public PlayerInput GetInput()
    {
        PlayerInput temp = new PlayerInput();
        temp.movDirection = movPosition;
        temp.actPosition = transform.position;
        temp.directionShoot = directionShoot;
        temp.goJail = goJail;

        temp.cameraRotation = cameraRotation;
        goJail = false;

        
        return temp;

    }

}

public struct PlayerInput : INetworkInput
{
    public Vector3 movDirection;
    public Vector3 actPosition;
    public Vector3 directionShoot;
    public bool goJail;
    public Quaternion cameraRotation;
}
