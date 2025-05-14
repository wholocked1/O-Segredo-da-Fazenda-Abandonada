using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espantalhos : MonoBehaviour, IInteracao
{
    public Dialog Dialog;
    public bool podeInteragir = true;

    public void DialogoTrigger()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(Dialog);
    }
    public void Interagir()
    {
        if (podeInteragir) 
        {
            DialogoTrigger();
        }
    }

    public bool PodeInteragir()
    {
        return podeInteragir; // Retorna verdadeiro se o jogador puder interagir com o objeto
    }
}
