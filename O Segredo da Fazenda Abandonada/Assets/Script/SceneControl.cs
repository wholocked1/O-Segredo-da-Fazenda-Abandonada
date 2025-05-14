using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    void OnGUI(){
        if(GUI.Button(new Rect(Screen.width - 220, 300, 120, 53), "JOGAR")){
            SceneManager.LoadScene("Celeiro");
        }
    }
}