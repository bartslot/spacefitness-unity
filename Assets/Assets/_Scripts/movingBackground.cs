using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBackground : MonoBehaviour {
    // SETTING FOR THE SCROLLSPEED OF THE MOVING BACKGROUND
    public float scrollSpeed = 0.5F;
    public Renderer rend;
    void Start() {
        rend = GetComponent<Renderer>();
    }
    // MAKING THE BACKGROUND SCROLL
    void Update() {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}