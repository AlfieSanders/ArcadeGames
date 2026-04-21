using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControl : MonoBehaviour
{

    [SerializeField] private string m_sceneName;

    
    public void F_openScene()
    {
       
        SceneManager.LoadScene(m_sceneName);

    }
}

