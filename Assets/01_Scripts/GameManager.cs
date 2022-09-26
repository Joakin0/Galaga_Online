using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager current;




    public GameObject LoadingCanvas;


    
    private void Awake()
    {

        if (current == null)
            current = this;
        else if (current != this)
            Destroy(this.gameObject);


    }
}
