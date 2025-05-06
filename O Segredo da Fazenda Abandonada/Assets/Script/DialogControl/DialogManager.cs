using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    // Mostra a ui com uma animacao
    public bool isTalking;
    public Animator animation;

    private Queue<string> text;
    public static DialogManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        text = new Queue<string>();
    }
    // Comeca o dialogo
    public void StartDialog(Dialog dialog)
    {
        animation.SetBool("isTalking", true);
        isTalking = true;

        text.Clear();
        foreach (string line in dialog.sentences)
        {
            text.Enqueue(line);
        }
        DisplayNextLine();
    }
    // Mostra a proxima linha do dialogo
    public void DisplayNextLine()
    {
        if (text.Count == 0)
        {
            EndDialog();
            return;
        }
        string line = text.Dequeue();
        dialogText.text = line;
        Debug.Log(line);
    }
    // Fecha o dialogo
    void EndDialog()
    {
        animation.SetBool("isTalking", false);
        isTalking = false;
    }

}
