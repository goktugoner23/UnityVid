using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTracker : MonoBehaviour
{
    public static bool levelPassed;

    [Header("Components")]
    [SerializeField]
    public Image passed;
    public TextMeshProUGUI deadText;
    public Button restart;
    public NumberCounter counter;
    public GameObject score;
    [Header("Variables")]
    private int finalScore;
    void Update()
    {
        if (levelPassed)
        {
            finalScore = ScoreTrack.score * BossRagdoll.scoreMultiplier;
            counter.Value = finalScore;
            score.SetActive(true);
            passed.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            levelPassed = false;
        }
        else if (PlayerMovement.dead) 
        {
            deadText.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }
}
