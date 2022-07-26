using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    void Update() {
        if (RotateAround.levelFinished)
        {
            StartCoroutine(LoadScoreScreen());
        }
    }

    IEnumerator LoadScoreScreen()
    {
            yield return new WaitForSeconds(0.1f); //0.3 sn de bir kontrol etsin level bitmiş mi diye.
            SceneManager.LoadScene("ScoreScreen");
            RotateAround.levelFinished = false;
    }

    void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOver"); //oluştur.
    }
}
