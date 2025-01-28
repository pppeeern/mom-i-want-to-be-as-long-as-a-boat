using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour
{
    bool finished = false;
    void Start (){
        transform.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player") && !finished){
            finished = true;
            Debug.Log($"{other.gameObject.name} finished");
            StartCoroutine(backToMainMenu());
        }
    }

    IEnumerator backToMainMenu(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
