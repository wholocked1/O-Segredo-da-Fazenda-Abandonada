using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteracao
{
    public bool podeInteragir = true;
    public GameObject KeyPad;
    public Dialog Dialogo;
    public GameObject itemPrefab;
    public bool acertouCodigo = false;
    public KeyPad keypad;
    
    public void DialogoTrigger(){
        DialogManager.instance.StartDialog(Dialogo);
    }
    public void ToggleKeyPad(){
        if(KeyPad.activeSelf){
            KeyPad.SetActive(false);
        }else{
            KeyPad.SetActive(true);
        }
    }
    public bool PodeInteragir(){
        return true;
    }
    public void Interagir(){
    if(!PodeInteragir()) return;
    StartCoroutine(AbrirCofre());
}
    public IEnumerator AbrirCofre(){
        DialogoTrigger();
        Debug.Log("Fala");
        yield return new WaitUntil(() => !DialogManager.instance.isTalking);
        Debug.Log("Keypad");
        ToggleKeyPad();
        yield return new WaitUntil(() => acertouCodigo);
        Debug.Log("Acertou");
        ToggleKeyPad();
        Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
        Debug.Log("Drop");
        podeInteragir = false;
    }

    public void SetAcertouCodigo(bool acerto){
        acertouCodigo = acerto;
    }
}
