using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour
{
    void Start (){
        transform.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log($"{other.gameObject.name} finished");
            transform.gameObject.SetActive(false);
        }
    }
}
