using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Silos : MonoBehaviour
{
    public static System.Action portaSilos;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portaSilos.Invoke();
        }
    }
}
