using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string id;
    public bool foiColetado = false;

    public void SetColetado(bool coletado)
    {
        foiColetado = coletado;
    }

    public void loadItem(ItemSaveData data)
    {
        if (data.foiColetado == true)
        {
            gameObject.SetActive(false);
        }
    }

}
