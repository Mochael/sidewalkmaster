using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if(other.name.Equals("Toes_R")||other.name.Equals("Toes_L")){
            print("YA LOST THE GAME BUB");
        }
    }
}
