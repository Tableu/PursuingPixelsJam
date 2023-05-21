using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
   [SerializeField] private GameObject quit;
   void OnClick()
   {
        Application.Quit();
   }
}
