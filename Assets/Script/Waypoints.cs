using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] positions;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        positions = new Transform[transform.childCount];

        for (int i = 0; i < positions.Length; ++i) {
            positions[i] = transform.GetChild(i);
        }
    }
}
