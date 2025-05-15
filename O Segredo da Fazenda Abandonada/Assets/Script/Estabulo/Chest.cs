using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteracao
{
    public bool estaAberto {get; private set;}
    public string chestID;
    public GameObject itemPrefab; // o que o baú entrega ao player

    // Start is called before the first frame update
    

    public bool PodeInteragir(){
        return !estaAberto;
    }

    public void Interagir(){
        if(!PodeInteragir()) return;
        AbrirBau();
    }

    private void AbrirBau(){
        SetAberto(true);
        if(itemPrefab){
           GameObject itemDropado = Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
        }
    }
    public void SetAberto(bool aberto){
        estaAberto = aberto;
    }
}
