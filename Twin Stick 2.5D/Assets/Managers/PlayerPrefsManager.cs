using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTERVOLUMEKEY = "master_volume";
    const string DIFFICULTYKEY = "difficulty";
    const string LEVELKEY = "level_unlocked_";

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTYKEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range !");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTYKEY);
    }


    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTERVOLUMEKEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of Range");
        }
    }


    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTERVOLUMEKEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVELKEY + level.ToString(), 1); // use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVELKEY + level.ToString());
        bool isLevelUnlocked = (level == 1);
        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {

            Debug.Log("Trying to query level not in build order");
            return false;
        }
    }
}
