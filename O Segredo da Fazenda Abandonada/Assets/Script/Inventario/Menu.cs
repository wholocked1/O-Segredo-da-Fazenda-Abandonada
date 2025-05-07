using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inventario;
    public GameObject settings;
    public GameObject controle;

    public void ToggleInventario()
    {
        if (inventario.activeSelf)
        {
            inventario.SetActive(false);
        }
        else
        {
            inventario.SetActive(true);
        }
    }

    public void ToggleSettings()
    {
        if (settings.activeSelf)
        {
            settings.SetActive(false);
        }
        else
        {
            settings.SetActive(true);
        }
    }

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
