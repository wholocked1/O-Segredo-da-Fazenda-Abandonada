using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeira : MonoBehaviour, IInteracao
{
    public Dialog Dialog;
    public bool podeInteragir = true;

    public void ReadInstruction()
    {
        DialogManager.instance.StartDialog(Dialog);
    }
    public void Interagir()
    {
        if (podeInteragir)
        {
            ReadInstruction();
        }
    }

    public bool PodeInteragir()
    {
        return podeInteragir;
    }

}
