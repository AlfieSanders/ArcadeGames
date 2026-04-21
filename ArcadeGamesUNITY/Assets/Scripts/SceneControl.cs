using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneControl : MonoBehaviour
{

    [SerializeField] private string m_sceneName;

    public UnityEvent sceneChanged;
    public void F_openScene()
    {
        sceneChanged.Invoke();
        SceneManager.LoadScene(m_sceneName);

    }
}

