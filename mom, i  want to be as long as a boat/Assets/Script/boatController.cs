using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatController : MonoBehaviour
{
    [SerializeField] KeyCode tap;
    public int _stamina = 100, stamina, dec;
    public bool regen = false;
    float lastTap;

    void Start(){
        stamina = _stamina;
    }

    
    void Update(){
        dec = stamina/10;
        
        if(stamina > _stamina) stamina = _stamina;

        if(Input.GetKeyDown(tap)){
            if(stamina > 0){
                stamina -= 10;
                lastTap = Time.time;
            }
            Vector3 dir = Vector3.up * 10;
            transform.position += dir / (20 - dec);
        }

        if(Time.time - lastTap > 0.5f){
            if(!regen) StartCoroutine(staminaRegen());
        }
        else regen = false;
    }

    IEnumerator staminaRegen(){
        regen = true;
        while(regen && stamina < 100){     
            stamina += 20;
            yield return new WaitForSeconds(0.2f);
        }
        regen = false;
    }
}
