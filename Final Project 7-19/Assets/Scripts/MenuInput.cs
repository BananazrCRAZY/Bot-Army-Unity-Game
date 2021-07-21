using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TextChanging(string inputText)
    {
        Debug.Log(inputText);
    }
    public void TextFinished(string inputText)
    {
        Debug.Log("You have logged in as: " + inputText);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
