using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public void MudarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}
