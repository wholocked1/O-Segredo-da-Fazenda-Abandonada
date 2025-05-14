using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    public TMP_InputField charHolder;
    public GameObject botao1;
    public GameObject botao2;
    public GameObject botao3;
    public GameObject botao4;
    public GameObject botao5;
    public GameObject botao6;
    public GameObject botao7;
    public GameObject botao8;
    public GameObject botao9;
    public GameObject botao0;
    public GameObject clear;
    public GameObject enter;
    public bool acertou = false;
    public Cofre cofre;

void Start() {
    if (cofre == null) {
        cofre = FindObjectOfType<Cofre>();
        if (cofre == null) {
            Debug.LogError("Cofre não encontrado na cena!");
        }
    }
}
    public void b1(){
        charHolder.text = charHolder.text + "1";
    }
    public void b2(){
        charHolder.text = charHolder.text + "2";
    }
    public void b3(){
        charHolder.text = charHolder.text + "3";
    }
    public void b4(){
        charHolder.text = charHolder.text + "4";
    }
    public void b5(){
        charHolder.text = charHolder.text + "5";
    }
    public void b6(){
        charHolder.text = charHolder.text + "6";
    }
    public void b7(){
        charHolder.text = charHolder.text + "7";
    }
    public void b8(){
        charHolder.text = charHolder.text + "8";
    }
    public void b9(){
        charHolder.text = charHolder.text + "9";
    }
    public void b0(){
        charHolder.text = charHolder.text + "0";
    }
    public void clearEvent(){
        charHolder.text = null;
    }
    public void enterEvent(){
        if(charHolder.text == "9315"){
            Debug.Log("Sucesso");
            cofre.SetAcertouCodigo(true);
        }else{
            clearEvent();
        }
    }

}
