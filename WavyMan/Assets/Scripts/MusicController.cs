using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public List<Fabric.AudioComponent> moans;
    public Fabric.RandomComponent randomness;
    private GameController controller;
    
    private float[] delays = {2.3f, 2.0f, 1.7f, 1.4f, 1.0f};
    private float[] delayRands = {2.0f, 1.6f, 1.2f, 0.8f, 0.3f};
    private List<AudioClip[]> preloadedLevels;


	// Use this for initialization
	void Start () {
		controller = FindObjectOfType<GameController>();
        preloadedLevels = new List<AudioClip[]>();
        preloadedLevels.Add(Resources.LoadAll<AudioClip>("Audio/Moans/Level 1"));
        preloadedLevels.Add(Resources.LoadAll<AudioClip>("Audio/Moans/Level 2"));
        preloadedLevels.Add(Resources.LoadAll<AudioClip>("Audio/Moans/Level 3"));
        preloadedLevels.Add(Resources.LoadAll<AudioClip>("Audio/Moans/Level 4"));
        preloadedLevels.Add(Resources.LoadAll<AudioClip>("Audio/Moans/Level 5"));
        LevelUp();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void LevelUp(){
        AudioClip[] clips = preloadedLevels[controller.getLevel()];
        for(int i = 0; i < Mathf.Min(moans.Count, clips.Length); i++){
            moans[i].AudioClip = clips[i];
        }
        randomness._delay = delays[controller.getLevel()];
        randomness._delayMaxRandomization = delayRands[controller.getLevel()];
    }
}
