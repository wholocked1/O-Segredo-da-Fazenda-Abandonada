using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Moinho : MonoBehaviour
{
    public static System.Action portaMoinho;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portaMoinho.Invoke();
        }
    }
}
