using System.Collections;using System.Collections.Generic;using UnityEngine;using System;public class HandState : MonoBehaviour {    public float[] thumb;    public float[] index;    public float[] middle;    public float[] pinky;    public float[] ring;    public Vector3 palm;     public HandState() {        thumb = new float[2];        index = new float[2];        middle = new float[2];        pinky = new float[2];        ring = new float[2];    }    private void setFinger(int finger, int i, float value) {
        if (finger == 0) {
            pinky[i] = value;
        } else if (finger == 1) {
            ring[i] = value;
        } else if (finger == 2) {
            middle[i] = value;
        } else if (finger == 3) {
            index[i] = value;
        } else if (finger == 4) {
            thumb[i] = value;
        }
    }    public static HandState handStateFromPacket(byte[] packet) {
        HandState hs = new HandState();
        int t = 8;
        int i = 8;
        for (int block = 0; block < 10; block++) {
            double fingerValue = BitConverter.ToDouble(packet, i);
            hs.setFinger(block / 2, block % 2, (float)fingerValue);
            i = i + t;
        }
        for (int block = 0; block < 3; block++) {
            double angleValue = BitConverter.ToDouble(packet, i);
            hs.palm[block] = (float)angleValue;
            i = i + t;
        }
        return hs;
    }}