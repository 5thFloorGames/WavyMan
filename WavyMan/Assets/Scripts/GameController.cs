using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int pointCounter = 0;
    private InterfaceManager interfaceMan;
   
   void Start(){
       interfaceMan = FindObjectOfType<InterfaceManager>();
   }
   
   public void AddPoints(){
       pointCounter++;
       if(pointCounter % 5 == 0){
           interfaceMan.SpawnText();
       }
   } 
}
