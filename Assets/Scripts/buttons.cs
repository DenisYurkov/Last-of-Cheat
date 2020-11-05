using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public GameObject BgSet;
    public GameObject BgMenu;

    public void OnMouseUpAsButton() {
         switch (gameObject.name)
         {
            case "Back":
                BgMenu.SetActive(true);
                BgSet.SetActive(false);
                break;
             case "Settings":
                BgMenu.SetActive(false);
                BgSet.SetActive(true);
                Debug.Log("thhrhtrh");
                 break;
             case "Quit":
                Application.Quit();
                 Debug.Log("ghhtgt");
                     break;
         }

    }
}
