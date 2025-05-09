using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string id;
    public bool foiColetado;

    public void SetColetado(bool coletado)
    {
        Debug.Log($"SetColetado chamado para o item {id} com valor: {coletado}");
        foiColetado = coletado;
    }

    public void loadItem(ItemSaveData data)
    {
        Debug.Log($"loadItem chamado para {id}, data.foiColetado = {data.foiColetado}");
        foiColetado = data.foiColetado;

        if (foiColetado)
        {
            gameObject.SetActive(false);
            Debug.Log($"Item {id} foi desativado.");
        }
    }

}
