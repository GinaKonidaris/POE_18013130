using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private DisplayMap displayMap;
    // Use this for initialization
    void Start () {
        displayMap = GameObject.Find("Map").GetComponent<DisplayMap>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnMouseOver()
    {
        int x = (int)this.transform.position.x;
        int y = (int)this.transform.position.z;
        displayMap.Hit(x, y);
        Debug.Log("Selecting Map: " + x + "," + y);
    }

    void OnMouseEnter()
    {
        Debug.Log("Entering Tile");
    }
    private Camera cameraFreeWalk;
    public float zoomSpeed = 20f;
    public float minZoomFOV = 10f;

    public void ZoomIn()
    {
        cameraFreeWalk.fieldOfView -= zoomSpeed / 8;
        if (cameraFreeWalk.fieldOfView < minZoomFOV)
        {
            cameraFreeWalk.fieldOfView = minZoomFOV;
        }
    }

}
