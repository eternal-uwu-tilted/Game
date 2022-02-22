using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeadButton : MonoBehaviour
{
    public GameObject Info;
    public GameObject main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Press()
    {
        Info.SetActive(true);
        main.SetActive(false);
    }
    public void Invert()
    {
        Info.SetActive(false);
        main.SetActive(true);
    }
}
