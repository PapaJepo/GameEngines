using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissplaceSphere : MonoBehaviour
{
    public GameObject MainSong;
    public float displacementAmount;
    MeshRenderer meshRender;
    public float[] m_audioSpectrum;
    private AudioSource m_Audio;

    private float[] spectrum = new float[1024];
    // Start is called before the first frame update
    void Start()
    {

        m_Audio = MainSong.GetComponent<AudioSource>();
        meshRender = GetComponent<MeshRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        // AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming);
        //displacementAmount = m_Audio.pitch * 1.1f;
        m_Audio.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 0; i < spectrum.Length; i++)
        {
            displacementAmount = spectrum[i] * 10000;

        }
        //displacementAmount = Mathf.Lerp(displacementAmount, 0, Time.deltaTime);
        meshRender.material.SetFloat("_Amount", displacementAmount);
    }


}
