using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    //public Scene mainplayer;
    public void StartGame(){
        SceneManager.LoadScene("MainPlayer");
    }
}
