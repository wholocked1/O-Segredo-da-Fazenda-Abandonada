using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeMaquina : MonoBehaviour, IInteracao
{
    public Dialog Dialogo;
    public Dialog DialogoNaoTem;
    public Dialog DialogoTem;
    public string[] IDItem;
    private ControledeInventario controledeInventario;
    public bool podeInteragir = true;
    public GameObject itemPrefab;
    private int qtdeItens = 0;
    void Start() {
    controledeInventario = ControledeInventario.Instance;
    if (controledeInventario == null) {
        Debug.LogError("ControledeInventario.Instance está nulo! Verifique se o objeto foi instanciado corretamente.");
    }}

    public void DialogoTrigger()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(Dialogo);
    }
    public void DialogoTriggerTem()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(DialogoTem);
    }
    public void DialogoTriggerNaoTem()
    {
        // Aqui voc� pode adicionar a l�gica para iniciar o di�logo
        // Por exemplo, voc� pode usar um gerenciador de di�logos para exibir as falas
        DialogManager.instance.StartDialog(DialogoNaoTem);
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
            Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
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
    foreach(string id in IDItem){
    foreach(InventorySaveData item in inventorySaveDataList){
        Debug.Log("Comparando com item ID: " + item.ID);
        if(string.Compare(item.ID, id) == 0){
            qtdeItens++;
        }
    }}
    if(qtdeItens == IDItem.Length){
        return true;
    }
    return false;
    }
}
