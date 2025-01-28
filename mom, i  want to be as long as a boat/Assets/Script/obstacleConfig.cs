using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleConfig : MonoBehaviour
{
    [SerializeField] int playerIndex;
    [SerializeField] LayerMask rangeMask;
    [SerializeField] float range;
    [SerializeField] int hitTime = 1;
    private KeyCode destroyKey;
    private List<KeyCode> keyList;

    void Start(){
        switch(playerIndex){
            case 1:
                keyList = new List<KeyCode>(){
                    KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R,
                    KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F,
                    KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V
                };
                break;
            case 2:
                keyList = new List<KeyCode>(){
                    KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9,
                    KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6,
                    KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3
                };
                break;
        }

        int ran = Random.Range(0, keyList.Count);
        destroyKey = keyList[ran];
    }

    void Update(){
        Collider2D inRange = Physics2D.OverlapCircle(transform.position, range, rangeMask);

        if(inRange){
            Debug.Log($"{destroyKey}");
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
