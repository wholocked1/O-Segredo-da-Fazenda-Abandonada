using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livro : MonoBehaviour, IInteracao
{
    public Dialog Dialog;
    public bool podeInteragir = true;

    public void ReadBook()
    {
        DialogManager.instance.StartDialog(Dialog);
    }
    public void Interagir()
    {
        if (podeInteragir)
        {
            ReadBook();
        }
    }

    public bool PodeInteragir()
    {
        return podeInteragir;
    }

}
