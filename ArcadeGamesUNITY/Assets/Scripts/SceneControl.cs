using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControl : MonoBehaviour
{
   private CreditHolder m_creditHolder;

    private void Start()
    {
        // finds the credit holder class for later reference
        m_creditHolder = FindFirstObjectByType<CreditHolder>();
    }
    public void F_openlevel()
    {
        // only opens the main level if the credit holder has available credits
       if (m_creditHolder != null && m_creditHolder.m_credits >0)
        {
            // removes a credit
            m_creditHolder.F_removeCredit();
            //opens the main level
            SceneManager.LoadScene("GameScene");
            
        }    

    }
    // opens the main menu
    public void F_openMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // exits the game when exit button is pressed
    public void F_exitGame()
    {
        
        Application.Quit();
    }
}

