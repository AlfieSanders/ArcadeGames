using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class HighScoreEntry
{
    public int Score;

    public HighScoreEntry(int score)
    {
        Score = score;
    }
}
