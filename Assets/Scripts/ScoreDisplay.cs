using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ScoreDisplay : MonoBehaviour
{
    public Text[] rollTexts, frameTexts;
    void Update()
    {

    }


    public void FillRollCard(List<int> rolls)
    {
        string scoreString = FormateRolls(rolls);
        for(int i = 0; i < scoreString.Length; i++)
        {
            rollTexts[i].text = scoreString[i].ToString();
        }
    }
    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }
    public static string FormateRolls(List<int> rolls)
    {
        string output = string.Empty;
        for (int i = 0; i < rolls.Count; i++)
        {
            int roll = output.Length + 1;
            if(rolls[i] == 0)
            {
                output += "-";
            }
            else if(roll % 2 == 0 || roll == 21 && rolls[i-1] + rolls[i] == 10)
            {
                output += "/";
            }
            else if(roll >= 19 && rolls[i] == 10)
            {
                output += "X";
            }
            else if (rolls[i] == 10)
            {
                output += "X ";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }
        return output;
    }
}