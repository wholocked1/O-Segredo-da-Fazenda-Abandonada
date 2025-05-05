using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Mansion : MonoBehaviour
{
    public static System.Action portaMansion;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portaMansion.Invoke();
        }
    }
}
