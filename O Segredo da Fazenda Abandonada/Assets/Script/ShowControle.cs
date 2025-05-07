using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControle : MonoBehaviour
{
    public GameObject controle;
    
    public void ToggleControle()
    {
        if (controle.activeSelf)
        {
            controle.SetActive(false);
        }
        else
        {
            controle.SetActive(true);
        }
    }
}
