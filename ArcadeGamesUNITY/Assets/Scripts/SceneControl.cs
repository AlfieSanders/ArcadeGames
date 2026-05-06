using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControl : MonoBehaviour
{
   private CreditHolder m_creditHolder;


    private void Start()
    {
        m_creditHolder = FindFirstObjectByType<CreditHolder>();
    }
    public void F_openlevel()
    {
       if (m_creditHolder != null && m_creditHolder.m_credits >0)
        {
            SceneManager.LoadScene("TestScene");
            m_creditHolder.F_removeCredit();
        }
        

    }
    public void F_openMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }


    public void F_exitGame()
    {
        Application.Quit();
    }
}

