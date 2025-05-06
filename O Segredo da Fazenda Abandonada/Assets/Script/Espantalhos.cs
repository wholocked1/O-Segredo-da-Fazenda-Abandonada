using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espantalhos : MonoBehaviour, IInteracao
{
    public Dialog Dialog;
    public bool podeInteragir = true;

    public void DialogoTrigger()
    {
        // Aqui você pode adicionar a lógica para iniciar o diálogo
        // Por exemplo, você pode usar um gerenciador de diálogos para exibir as falas
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
