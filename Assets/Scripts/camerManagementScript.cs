using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camerManagementScript : MonoBehaviour {


    public float hg;
    public float wg;
	// Use this for initialization
	void Start ()
    {
        hg = Screen.height;
        wg = Screen.width;
        if (hg == 1050 && wg == 1680)
        {
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = 5.25f;
        }

        if (hg == 900 && wg == 1440)
        {
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = 5.45f;
        }
        if (hg == 1050 && wg == 1400)
        {
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = 6.25f;
        }
        if (hg == 1024 && wg == 1280)
        {
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = 6.45f;
        }
        if (hg == 960 && wg == 1280)
        {
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = 6.45f;
        }
        if (hg == 600 && wg == 800)
        {
            Camera cam = this.GetComponent<Camera>();
            cam.orthographicSize = 6.75f;
        }
    }

}
