using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int pointCounter = 0;
    private InterfaceManager interfaceMan;
    
    private MusicController music;
    
    private ColorChanger colorChange;
    
    private int[] phrasePoints = {10, 15, 20, 30, 50};
    
    private int level = 0;
   
   void Start(){
       interfaceMan = FindObjectOfType<InterfaceManager>();
       music = gameObject.GetComponent<MusicController>();
       colorChange = gameObject.GetComponent<ColorChanger>();
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
               music.LevelUp();
               colorChange.SendMessage("ChangeColor");
           }
       }
   } 
   
   public int getLevel(){
       return level;
   }
}
