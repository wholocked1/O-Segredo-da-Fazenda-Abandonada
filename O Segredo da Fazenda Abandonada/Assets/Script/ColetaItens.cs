using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaItens : MonoBehaviour, IInteracao
{
    private ControledeInventario controledeInventario;
    public bool podeInteragir = true;
    public Item item; // Referência ao script Item
    private Collider2D collider2D;
    void Start()
    {
        controledeInventario = ControledeInventario.Instance;
        item = GetComponent<Item>(); // Obtém o componente Item do objeto
    }
    //public void Interagir()
    //{
    //    pegaObjeto(collider2D);
    //}

    public bool PodeInteragir()
    {
        return podeInteragir; // Retorna verdadeiro se o jogador puder interagir com o objeto
    }

    //public void pegaObjeto(Collider2D collider)
    //{


    //}

    public void Interagir()
    {
        if (podeInteragir)
        {
            // Aqui você pode adicionar a lógica para coletar o item
            // Por exemplo, você pode usar o ControledeInventario para adicionar o item ao inventário
            controledeInventario.AdicionaItem(gameObject);
            item.foiColetado = true; // Marca o item como coletado

            Destroy(gameObject); // Destroi o objeto após coletá-lo
        }
    }
    }
