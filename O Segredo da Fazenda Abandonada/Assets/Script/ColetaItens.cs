using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaItens : MonoBehaviour, IInteracao
{
    private ControledeInventario controledeInventario;
    public bool podeInteragir = true;
    public Item item; // Refer�ncia ao script Item
    void Start()
    {
        controledeInventario = ControledeInventario.Instance;
        item = GetComponent<Item>(); // Obt�m o componente Item do objeto
    }
    public bool PodeInteragir()
    {
        return podeInteragir; // Retorna verdadeiro se o jogador puder interagir com o objeto
    }

    public void Interagir()
    {
        if (podeInteragir)
        {
            // Aqui voc� pode adicionar a l�gica para coletar o item
            // Por exemplo, voc� pode usar o ControledeInventario para adicionar o item ao invent�rio
            controledeInventario.AdicionaItem(gameObject);
            item.SetColetado(true); // Marca o item como coletado

            Destroy(gameObject); // Destroi o objeto ap�s colet�-lo
        }
    }
    }
