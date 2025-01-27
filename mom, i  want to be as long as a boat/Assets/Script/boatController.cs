using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatController : MonoBehaviour
{
    [SerializeField] KeyCode tap;

    void Start()
    {

    }

    
    void Update(){
        if(Input.GetKeyDown(tap)){
            transform.position += Vector3.up / 10;
        }
    }
}
