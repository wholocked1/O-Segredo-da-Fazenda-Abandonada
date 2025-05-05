using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Estabulo : MonoBehaviour
{
    public static System.Action portaEstabulos;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portaEstabulos.Invoke();
        }
    }
}
