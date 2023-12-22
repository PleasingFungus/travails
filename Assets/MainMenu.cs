using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject BeginState;

    public void Begin()
    {
        gameObject.SetActive(false);
        BeginState.SetActive(true);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
