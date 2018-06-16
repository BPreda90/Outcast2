using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour {

    public Hex Hex;
    public HexMap HexMap;
    Camera myCamera;

    public void Start()
    {
        myCamera = Camera.main;
    }


    public float VerticalOffset = 0; // Map objects on this hex should be rendered higher than usual

    public void UpdatePosition()
    {
        this.transform.position = Hex.PositionFromCamera(
            myCamera.transform.position,
            HexMap.NumRows,
            HexMap.NumColumns
        );
    }

}
