using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeet : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] clips;
    private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        clips = new AudioClip[29];
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
    //Play Event in animation
    protected AudioClip GetRandomClip()
    {        
        return clips[Random.Range(0, clips.Length)];
    }
    public void PlaySound()
    {   
            clip = GetRandomClip();        
            this.audioSource.PlayOneShot(clip);
    }
}
