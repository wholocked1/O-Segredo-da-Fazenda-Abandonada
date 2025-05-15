using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneIndex;
    public void LoadScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}