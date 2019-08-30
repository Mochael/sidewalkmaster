using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggered : MonoBehaviour {
    public GameObject PanelCrack;
    Vector3 panelStart = new Vector3(0, 0, 5); //-8.54
                                               // Use this for initialization

    private void Start()
    {
        GameObject panel = Instantiate(PanelCrack, panelStart, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        //print("hit");
        GameObject panel = Instantiate(PanelCrack, panelStart, Quaternion.identity);
        //print("created");
    }
}
