using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeteccaoInteracao : MonoBehaviour
{
    private IInteracao interativoProximo = null;
    public GameObject icone;
    // Start is called before the first frame update
    void Start()
    {
        icone.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interativoProximo?.Interagir();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteracao interativo) && interativo.PodeInteragir())
        {
            interativoProximo = interativo;
            icone.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteracao interativo) && interativo == interativoProximo)
        {
            interativoProximo = null;
            icone.SetActive(false);
        }
    }
}
