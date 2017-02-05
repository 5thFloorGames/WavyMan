using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int pointCounter = 0;
    private InterfaceManager interfaceMan;
    
    private MusicController music;
    
    private ColorChanger colorChange;
    
    private int[] phrasePoints = {10, 15, 20, 30, 50};
    
    private int level = 0;

    public Image FadeOut;
   
   void Start(){
       interfaceMan = FindObjectOfType<InterfaceManager>();
       music = gameObject.GetComponent<MusicController>();
       colorChange = gameObject.GetComponent<ColorChanger>();
   }

   void Update(){
       if(Input.GetKeyDown(KeyCode.E)){
            StartCoroutine(EndGame());
       }
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
                   StartCoroutine(EndGame());
               }
               music.LevelUp();
               colorChange.SendMessage("ChangeColor");
           }
       }
   } 
   
   public int getLevel(){
       return level;
   }

   IEnumerator EndGame(){
       print("Spawning stopped!");
       FindObjectOfType<EnemySpawner>().StopSpawning();
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
       foreach(GameObject enemy in enemies){
           if(enemy != null){
                enemy.GetComponent<EnemyController>().DestroyEnemy();
           }
           FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, FadeOut.color.a + 1.0f / enemies.Length);
           yield return new WaitForSeconds(0.1f);
       }
       SceneManager.LoadScene("Credits");
   }

}
