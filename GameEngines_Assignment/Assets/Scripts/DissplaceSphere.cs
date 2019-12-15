using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissplaceSphere : MonoBehaviour
{
    public GameObject MainSong;
    public float displacementAmount;
    MeshRenderer meshRender;
    public ParticleSystem explosionParticles;
    private AudioSource m_Audio;

   
    // Start is called before the first frame update
    void Start()
    {

        m_Audio = MainSong.GetComponent<AudioSource>();
        meshRender = GetComponent<MeshRenderer>();


    }

    // Update is called once per frame
    void Update()//This sets the volume of the audio to affect the dispacement of the spheres vertices
    {
       
        displacementAmount = m_Audio.volume *5;
        meshRender.material.SetFloat("_Amount", displacementAmount);

        if(Input.GetButtonDown("Jump"))//Spawns in particle effects when the space button is pressed
        {
            Debug.Log("gogogo");
            displacementAmount += 2f;
            explosionParticles.Play();
        }
    }


}
