using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState {

    public float[] thumb;
    public float[] index;
    public float[] middle;
    public float[] pinky;
    public float[] ring;
    public Vector3 palm; 

    public HandState() {
        thumb = new float[3];
        index = new float[3];
        middle = new float[3];
        pinky = new float[3];
        ring = new float[3];
    }
}