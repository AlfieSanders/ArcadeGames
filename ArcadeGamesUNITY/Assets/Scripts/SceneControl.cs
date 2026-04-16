using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControl : MonoBehaviour
{

    [SerializeField] private string m_sceneName;
 
    public void F_openScene()
    {
        SceneManager.LoadScene(m_sceneName);
    }
}

