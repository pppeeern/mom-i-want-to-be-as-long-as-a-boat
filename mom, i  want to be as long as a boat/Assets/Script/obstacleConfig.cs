using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleConfig : MonoBehaviour
{
    [SerializeField] LayerMask rangeMask;
    [SerializeField] float range;
    [SerializeField] int hitTime = 1;
    [SerializeField] private KeyCode destroyKey;

    void Update(){
        Collider2D inRange = Physics2D.OverlapCircle(transform.position, range, rangeMask);

        if(inRange){
            if(Input.GetKeyDown(destroyKey)){
                hitTime--;
            }
        }

        if(hitTime <= 0){
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log($"{other.gameObject.name} crashed");
            Destroy(gameObject);
        }
    }
}
