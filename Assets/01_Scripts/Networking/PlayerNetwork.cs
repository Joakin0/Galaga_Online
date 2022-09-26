using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    public static PlayerNetwork Local;
    public GameObject player;
    //public PlayerCanvasController canvas;
    
    
    

    public int team;
    [Networked(OnChanged = nameof(SetCheck))]
    public bool IsCheck { get; set; }
    public void Awake()
    {
        gameObject.GetComponent<MeshRenderer>();
    }
    public override void Spawned()
    {

        if(Object.HasInputAuthority)
        {
            Local = this;
            GameManager.current.LoadingCanvas.SetActive(false);
        }
        else
        {
            //canvas.Canvas.SetActive(false);
        }

        if(Object.Runner.IsServer)
        {
            
        }
       
          

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetCheck(Changed<PlayerNetwork>  change)
    {

    }


    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_OnBoolChange(bool b,RpcInfo info = default)
    {
        //canvas.CheckObject.SetActive(b);
    }

    


}
