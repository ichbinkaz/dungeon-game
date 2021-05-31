using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneScript : MonoBehaviour
{
    public void ChangeToScene(int changeTheScene) {
        PlayerPrefs.Save();
        SceneManager.LoadScene(changeTheScene);
     
    }
}
