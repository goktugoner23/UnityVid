using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image fillindicatorUI;

    public static float indicatorScore = 0f;
    public float maxIndicatorScore = 1f;
    private bool barFull = false;

    private void Update()
    {
        if (RagdollDeath.IScored && indicatorScore < maxIndicatorScore) //when score changed
        {
            RagdollDeath.IScored = false;

            if (barFull == false) //fill the progress bar if not full
            {
                indicatorScore += 0.06f;
                fillindicatorUI.fillAmount = indicatorScore;  
            }   
        }
        if (fillindicatorUI.fillAmount >= maxIndicatorScore) 
        {
            SpeedUp.superboosted = true;
            barFull = true;
            StartCoroutine(ProgressBarCheck());
        }
    }

    IEnumerator ProgressBarCheck() //decrease progress bar value 1 every second if higher than 5
    {
        while (fillindicatorUI.fillAmount > 0)
        {   //reduce progress bar
            indicatorScore -= 0.06f;
            fillindicatorUI.fillAmount = Mathf.Lerp(fillindicatorUI.fillAmount, indicatorScore, 0.8f * Time.deltaTime);
            if (fillindicatorUI.fillAmount < 0) fillindicatorUI.fillAmount = 0;
            yield return new WaitForSeconds(8f * Time.deltaTime);
        }
        barFull = false;
        indicatorScore = 0f;
    }
}
