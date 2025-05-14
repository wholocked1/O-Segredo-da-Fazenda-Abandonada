using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baia : MonoBehaviour, IInteracao
{
    public Dialog Dialog;
    public bool podeInteragir = true;
    public string IDItem;
    private ControledeInventario controledeInventario;
    public Dialog DialogTem;
    public Dialog DialogNaoTem;


    void Start() {
    controledeInventario = ControledeInventario.Instance;
    if (controledeInventario == null) {
        Debug.LogError("ControledeInventario.Instance está nulo! Verifique se o objeto foi instanciado corretamente.");
    }
    }
    public void DialogoTrigger()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(Dialog);
    }
    public void DialogoTriggerTem()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(DialogTem);
    }
    public void DialogoTriggerNaoTem()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(DialogNaoTem);
    }
public void Interagir()
{
    if (podeInteragir)
    {
        StartCoroutine(InteragirSequencia());
    }
}

private IEnumerator InteragirSequencia()
{
    

    DialogoTrigger(); // inicia o primeiro diálogo

    // espera o diálogo terminar (quando isTalking ficar false)
    yield return new WaitUntil(() => !DialogManager.instance.isTalking);

    // agora sim, verifica o inventário
    if (VerificaInventario())
    {
        DialogoTriggerTem();
        podeInteragir = false;
    }
    else
    {
        DialogoTriggerNaoTem();
    }
}

    public bool PodeInteragir()
    {
        return podeInteragir; // Retorna verdadeiro se o jogador puder interagir com o objeto
    }

    public bool VerificaInventario(){
    if (controledeInventario == null) {
        Debug.LogError("controledeInventario está nulo!");
        return false;
    }
    Debug.Log("IDItem: " + IDItem);
    
    List<InventorySaveData> inventorySaveDataList = controledeInventario.GetitemsInventory();
    foreach(InventorySaveData item in inventorySaveDataList){
        Debug.Log("Comparando com item ID: " + item.ID);
        if(item.ID == IDItem){
            return true;
        }
    }
    return false;
    }
}
