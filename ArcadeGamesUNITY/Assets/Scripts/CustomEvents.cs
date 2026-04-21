using UnityEngine;
using UnityEngine.Events;
public class CustomEvents : MonoBehaviour
{
    public UnityEvent m_blankScore;
    void Start()
    {
        m_blankScore.Invoke();
    }

    
}
