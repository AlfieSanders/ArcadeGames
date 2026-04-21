using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class ScoreEntry
{
    public int Score;
    public int Highscore;

    public ScoreEntry(int score, int highscore)
    {
        Score = score;
        Highscore = highscore;
    }


   
}
