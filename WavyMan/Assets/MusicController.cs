using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public List<Fabric.AudioComponent> moans;
    public Fabric.RandomComponent randomness;
    private GameController controller;
    
    private float[] delays = {2.3f, 2.0f, 1.7f, 1.4f, 1.0f};
    private float[] delayRands = {2.0f, 1.6f, 1.2f, 0.8f, 0.3f};

	// Use this for initialization
	void Start () {
		controller = FindObjectOfType<GameController>();
        LevelUp();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void LevelUp(){
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio/Moans/Level " + (controller.getLevel() + 1));
        for(int i = 0; i < Mathf.Min(moans.Count, clips.Length); i++){
            moans[i].AudioClip = clips[i];
        }
        randomness._delay = delays[controller.getLevel()];
        randomness._delayMaxRandomization = delayRands[controller.getLevel()];
    }
}
