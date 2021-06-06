using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitTest : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerExit(Collider other)
   {
       Debug.Log("Acaba trigger");
   }
}
