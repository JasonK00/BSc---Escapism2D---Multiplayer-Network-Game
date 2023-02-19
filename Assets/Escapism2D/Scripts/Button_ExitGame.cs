using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ExitGame : MonoBehaviour
{
   public void Quit()
   {
      Debug.Log("Ended");
      Application.Quit();
   }
}
