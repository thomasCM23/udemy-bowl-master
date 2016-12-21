using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public static class ScoreMaster {
    
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2)
        {
            if(frameList.Count == 10) { break; }                //prevents 11 frame score
            if (rolls[i - 1] + rolls[i] < 10)                   //Normal open frame
            {
                frameList.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1) break;                    // not enough elements to look ahead

            if (rolls[i - 1] == 10)                             //strike bonus
            {
                i--;                                            
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10)             //spare bonus
            {
                frameList.Add(10 + rolls[i + 1]);
            }
        }

        return frameList;
    }

    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeList = new List<int>();
        int runningTotal = 0;
        foreach(int frameScores in ScoreFrames(rolls))
        {
            runningTotal += frameScores;
            cumulativeList.Add(runningTotal);
        }
        return cumulativeList;
    }
}
