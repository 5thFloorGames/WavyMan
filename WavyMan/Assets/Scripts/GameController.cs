using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int pointCounter = 0;
    private InterfaceManager interfaceMan;
    
    private int[] phrasePoints = {10, 15, 20, 30, 50};
    
    private int level = 0;
   
   void Start(){
       interfaceMan = FindObjectOfType<InterfaceManager>();
   }
   
   public void AddPoints(){
       pointCounter++;
       if(pointCounter % phrasePoints[level] == 0){
           interfaceMan.SpawnText();
           if(pointCounter % (phrasePoints[level] * 5) == 0){
               level++;
               pointCounter = 0;
               if(level > 4){
                   level = 4;
               }
               print("LEVELUP");
           }
       }
   } 
   
   public int getLevel(){
       return level;
   }
}
