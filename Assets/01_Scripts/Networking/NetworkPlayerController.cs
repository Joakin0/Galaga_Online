using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerController : NetworkBehaviour
{
    private Rigidbody rb;
    public float speed;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public override void FixedUpdateNetwork()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if(GetInput(out PlayerInput input))
        {
            rb.MovePosition(input.actPosition += input.movDirection * speed * Runner.DeltaTime);

            transform.rotation = Quaternion.Euler(0, input.cameraRotation.eulerAngles.y, 0);


            if (input.goJail)
            {
                rb.MovePosition(GameManager.current.JailPoscition);
            }
            


        }

        

    }
}