using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTrack : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI scoreind;

    private void Update()
    {
        scoreind.text = ProgressBar.indicatorScore.ToString();
        if (float.Parse(scoreind.text) == 1.0f)
        {
            SpeedUp.superboosted = true;
        }
    }
}
