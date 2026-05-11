using UnityEngine;

public class AttractModeScript : MonoBehaviour
{
    // script for activating the menu overlay on top of the attract mode.
    // When the player clicks the button overlay becopme active on top of the attract mode video
    public GameObject m_button;
    public GameObject m_menuBits;
    

    public void F_changeMenu()
    {
        m_button.SetActive(false);
        m_menuBits.SetActive(true);
       
    }
}
