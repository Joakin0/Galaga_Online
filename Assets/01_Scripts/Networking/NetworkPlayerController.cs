using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerController : NetworkBehaviour
{
    private Rigidbody2D rb;
    public float speed;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public override void FixedUpdateNetwork()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if(GetInput(out PlayerInput input))
        {
            rb.MovePosition(input.actPosition += input.movDirection * speed * Runner.DeltaTime);
            


        }

        

    }
}
