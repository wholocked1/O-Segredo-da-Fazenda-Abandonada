using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portas : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Load the specified scene
            player = collision.transform;
            player.position = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            //Debug.Log("Bateu na porta");
        }
    }
}
