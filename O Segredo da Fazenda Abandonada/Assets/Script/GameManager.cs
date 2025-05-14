using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Objetos Persistentes")]
    public GameObject[] objetosPersistentes;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ObjetosMarcadosPersistentes();
        }
        else
        {
            LimpaDestroi();
            return;
        }
    }

    private void ObjetosMarcadosPersistentes()
    {
        foreach (GameObject objeto in objetosPersistentes)
        {
            if (objeto != null)
            {
                DontDestroyOnLoad(objeto);
            }
        }
    }

    private void LimpaDestroi()
    {
        foreach (GameObject objeto in objetosPersistentes)
        {
            if (objeto != null)
            {
                Destroy(objeto);
            }
        }
        Destroy(gameObject);
    }
}
