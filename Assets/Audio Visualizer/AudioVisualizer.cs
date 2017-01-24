using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour {

    //public AudioClip track;
    private AudioSource aud;

    //Individual Samples
    public static float[] samples = new float[512];
    //Frequency Bands - 0 = lowest freq, 7 = highest freq
    public static float[] freqBand = new float[8];
    //Buffers for Frequency Bands - Makes transitions smooth
    public static float[] bandBuffer = new float[8];
    //Controls how fast stuff 'falls' when buffered
    float[] bufferDecrease = new float[8];

    //some shit
    float[] freqBandHighest = new float[8];
    //a magic
    public static float[] audioBand = new float[8];
    //magic buffer
    public static float[] audioBandBuffer = new float[8];
    //It's the volume
    public static float volume;

    public static float amplitude, amplitudeBuffer;
    float amplitudeHighest = 1;

    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }
	
	//Calls all the funcitons below - updates the data
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetVolume();
        GetAmplitude();
    }

    //Loads up samples array with 512 samples
    void GetSpectrumAudioSource()
    {
        aud.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    //Fills freqBand array with 8 frequency levels
    void MakeFrequencyBands()
    {
        int count = 0;
        for(int i = 0; i < 8; i++)
        {
            float avg = 0;
            int sampleCount = (int)Mathf.Pow(2, i+1);
            if (i == 7) {
                sampleCount += 2;
            }
            for(int j = 0; j<sampleCount;j++)
            {
                avg += samples[count] * (count + 1);
                count++;
            }
            avg /= count;
            freqBand[i] = avg * 10;
        }
    }
    
    //Makes buffer for freqBand that makes transitions from high freq to low freq smooth
    void BandBuffer()
    {
        for(int i = 0; i < 8; i++)
        {
            if(freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = .005f;
            }
            if(freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    //magic
    void CreateAudioBands()
    {
        for(int i = 0;i < 8; i++)
        {
            if(freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetVolume()
    {
        volume = aud.volume;
    }

    void GetAmplitude()
    {
        float currentAmp = 0;
        float currentAmpBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            currentAmp += audioBand[i];
            currentAmpBuffer += audioBandBuffer[i];
        }
        if (currentAmp > amplitudeHighest)
            amplitudeHighest = currentAmp;

        amplitude = currentAmp / amplitudeHighest;
        amplitudeBuffer = currentAmpBuffer / amplitudeHighest;

    }
}
