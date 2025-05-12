using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoinhoPuzzle : MonoBehaviour, IInteracao
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> estadosSprite; // 0 = quebrado, 1 = consertado
    public string itemNecessario = "madeira";
    public bool resolvido = false;
    public GameObject bilhete; 



    private ControledeInventario inventario;

    private void Start()
    {
        inventario = ControledeInventario.Instance;

        // Define sprite inicial como quebrado
        if (spriteRenderer != null && estadosSprite.Count > 0)
        {
            spriteRenderer.sprite = estadosSprite[0];
        }
    }

    public bool PodeInteragir()
    {
        return true;
    }

    public void Interagir()
{
    if (resolvido) return;

    Item itemEncontrado = null;
    Transform slotEncontrado = null;

    // Verifica todos os slots
    foreach (Transform slot in inventario.inventario.transform)
    {
        Slot s = slot.GetComponent<Slot>();
        if (s != null && s.itemSlot != null)
        {
            Item item = s.itemSlot.GetComponent<Item>();
            if (item != null && item.id.Contains("madeira"))
            {
                itemEncontrado = item;
                slotEncontrado = slot;
                break;
            }
        }
    }

    // Nenhuma madeira
    if (itemEncontrado == null)
    {
        Dialog dialog = new Dialog();
        dialog.sentences = new string[] {
            "O moinho está quebrado.",
            "Parece que está faltando alguma madeira..." };
        DialogManager.instance.StartDialog(dialog);
        return;
    }

    // Madeira verdadeira
    if (itemEncontrado.id == itemNecessario)
    {
        spriteRenderer.sprite = estadosSprite[1];
        resolvido = true;

        Destroy(itemEncontrado.gameObject);
        slotEncontrado.GetComponent<Slot>().itemSlot = null;
        Dialog dialog = new Dialog();
        dialog.sentences = new string[] {
            "Você usou a madeira para consertar o moinho.",
            "Agora ele está funcionando." };
        DialogManager.instance.StartDialog(dialog);
    }
    // Madeira falsa
    else
    {
        Destroy(itemEncontrado.gameObject);
        slotEncontrado.GetComponent<Slot>().itemSlot = null;

        Dialog dialog = new Dialog();
        dialog.sentences = new string[] {
            "Essa madeira não encaixa direito...",
            "Parece ser a errada." };
        DialogManager.instance.StartDialog(dialog);
    }
}


    bool ItemEstaNoInventario()
    {
        foreach (Transform slot in inventario.inventario.transform)
        {
            Slot s = slot.GetComponent<Slot>();
            if (s != null && s.itemSlot != null)
            {
                Item item = s.itemSlot.GetComponent<Item>();
                if (item != null && item.id == itemNecessario)
                {
                    Destroy(s.itemSlot);
                    s.itemSlot = null;
                    return true;
                }
            }
        }
        return false;
    }
}
