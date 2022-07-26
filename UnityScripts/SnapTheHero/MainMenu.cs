using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); //level1 load. build settings de score screen in indexi araya karıştığı için böyle yaptım.
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); //editorda oyundan çıkmaz o yüzden kontrol için debug.log ekledim.
        Application.Quit();
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        CheckLens.score = 0; //2nci levelda skoru sıfırlıyorum.
    }
}
