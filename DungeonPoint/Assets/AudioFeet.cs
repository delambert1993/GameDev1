using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeet : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
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
       
        
            this.audioSource.clip = GetRandomClip();
            audioSource.Play();
       
    }
}
