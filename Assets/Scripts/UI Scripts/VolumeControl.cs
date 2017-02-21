using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour {

    public enum AudioState
    {
        Min,
        Max,
        FadingIn,
        FadingOut
    }
    public AudioState state = AudioState.Max;
    AudioSource src;

    // Use this for initialization
    void Start()
    {
        src = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
        float add = 0.5f * Time.deltaTime;

        switch (state)
        {
            case AudioState.Min:
                break;
            case AudioState.Max:
                break;
            case AudioState.FadingIn:
                if (src.volume + add >= 1)
                {
                    state = AudioState.Max;
                    src.volume = 1;
                }
                else src.volume += add;

                break;
            case AudioState.FadingOut:
                if (src.volume - add <= 0)
                {
                    state = AudioState.Min;
                    src.volume = 0;
                }
                else src.volume -= add;

                break;
            default:
                break;
        }
    }
    void FadeOut()
    {
        state = AudioState.FadingOut;
    }
    void FadeIn()
    {
        state = AudioState.FadingIn;
    }
}
