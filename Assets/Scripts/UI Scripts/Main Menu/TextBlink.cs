using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlink : MonoBehaviour {

    float nextUpdateTime;
    public float blinkDuration = 0.5f;
    UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<UnityEngine.UI.Text>();
        nextUpdateTime = Time.time + blinkDuration;	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextUpdateTime) Blink();
	}

    void Blink()
    {
        text.enabled = !text.enabled;

        //gameObject.SetActive(!gameObject.activeSelf);
        nextUpdateTime = Time.time + blinkDuration;
    }
}
