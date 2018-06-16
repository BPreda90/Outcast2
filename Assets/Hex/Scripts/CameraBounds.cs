using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{


    Camera myCamera;
    Vector3 myPosition;
    HexMap_Continent myMap;
    int verticalBoundBuffer, topVerticalBound, bottomVerticalBound;
    // Use this for initialization
    void Start()
    {
        myCamera = Camera.main;
        
        myMap = GameObject.Find("HexMap").GetComponent<HexMap_Continent>();
        verticalBoundBuffer = Mathf.RoundToInt(myMap.NumRows * 1 / 3);
        topVerticalBound = myMap.NumRows + verticalBoundBuffer;
        bottomVerticalBound = -5;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (myCamera.transform.position.z >= topVerticalBound)
        {
            myCamera.transform.position =  new Vector3 (myCamera.transform.position.x,myCamera.transform.position.y ,topVerticalBound);
        }

        if(myCamera.transform.position.z <= bottomVerticalBound)
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, bottomVerticalBound);
        }
    }
}
