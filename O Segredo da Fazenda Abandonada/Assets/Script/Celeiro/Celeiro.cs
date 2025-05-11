using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celeiro : MonoBehaviour
{
    public Dialog Dialog;
    // Start is called before the first frame update
    void Start()
    {
        DialogManager.instance.StartDialog(Dialog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
