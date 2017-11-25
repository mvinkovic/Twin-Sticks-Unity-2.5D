using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float fixedDeltaTime;
    private bool isPaused = false;

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        //print(PlayerPrefsManager.IsLevelUnlocked(2));
        fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused) // resume game
        {
            ResumeGame();
            isPaused = false;
        }else if (Input.GetKeyDown(KeyCode.P) && !isPaused) // pause game
        {
            PauseGame();
            isPaused = true;
        }       
	}


    private void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }



    //void OnApplicationPause(bool pauseStatus)
    //{
    //    isPaused = pauseStatus;
    //}
}
