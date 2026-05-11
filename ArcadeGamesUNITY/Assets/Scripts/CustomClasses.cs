using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class ScoreEntry
{   
    // score entry class for the highscore Json file system. 
    public int Highscore;
    public ScoreEntry( int highscore)
    {   
        Highscore = highscore;  
    }  
}
