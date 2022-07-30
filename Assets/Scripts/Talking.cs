using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    public GameObject[] audioObjects = new GameObject[4];
    private AudioSource[] audioSources = new AudioSource[4];
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        for (int i = 0; i < 4; i++)
        {
            audioSources[i] = audioObjects[i].GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioObjects[0]) {
            if (audioSources[0].isPlaying) {
                anim.Play("talk.Talk");
            } 
        }
        if (audioObjects[1]) {
            if (audioSources[1].isPlaying) {
                anim.Play("talk.Talk");
            } 
        }
        if (audioObjects[2]) {
            if (audioSources[2].isPlaying) {
                anim.Play("talk.Talk");
            } 
        }
        if (audioObjects[3]) {
            if (audioSources[3].isPlaying) {
                anim.Play("talk.Talk");
            } 
        }

        if (!audioObjects[0] && !audioObjects[1] && !audioObjects[2] && !audioObjects[3]) {
            anim.Play("talk.Idle");
        }
    }
}
