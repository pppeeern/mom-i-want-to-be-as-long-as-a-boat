using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class countdownControl : MonoBehaviour
{
    public float startTime = 3;
    private float leftTime;

    public TMP_Text timertext;
    public Button startbtn;

    public void startClick(){
        leftTime = startTime;
        startbtn.gameObject.SetActive(false);
        timertext.gameObject.SetActive(true);
        StartCoroutine(startCount());
    }

    private IEnumerator startCount(){
        while(leftTime > 0){
            timertext.text = Mathf.Ceil(leftTime).ToString();
            yield return new WaitForSeconds(1f);
            leftTime -= 1;
        }

        timertext.fontSize = 300;
        timertext.text = "ROW!!!";
        yield return new WaitForSeconds(1f);
        timertext.gameObject.SetActive(false);
    }
}
