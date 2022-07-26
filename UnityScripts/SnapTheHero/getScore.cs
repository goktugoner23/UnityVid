using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getScore : MonoBehaviour

{
    public GameObject scoretext;
    private void Start()
    {
    }

    private void Update() {
        int score = CheckLens.score;
        scoretext.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}