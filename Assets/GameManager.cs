using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static float time = 0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += 0.1f;
    }
}
