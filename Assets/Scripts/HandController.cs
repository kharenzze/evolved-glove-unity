using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public Transform palm = null;
    public Transform thumb = null;
    public Transform index = null;
    public Transform middle = null;
    public Transform pinky = null;
    public Transform ring = null;

    private Vector3 _palmReference;
    public HandState _hs = new HandState();

    private void setNodeRotation(Transform node, float rotationRate) {
        node.localEulerAngles = new Vector3(0, -90 * rotationRate, 0);
    }

    private void Update() {
        loadHandState(_hs);
    }

    public void setPalmReference(Vector3 palmReference) {
        _palmReference = palmReference;
    }

    public void loadHandState(HandState hs) {
        setNodeRotation(index, hs.index[0]);
        setNodeRotation(index.GetChild(0), hs.index[1]);
        setNodeRotation(index.GetChild(0).GetChild(0), hs.index[1]);

        setNodeRotation(thumb, hs.thumb[0]);
        setNodeRotation(thumb.GetChild(0), hs.thumb[1]);
        setNodeRotation(thumb.GetChild(0).GetChild(0), hs.thumb[1]);

        setNodeRotation(middle, hs.middle[0]);
        setNodeRotation(middle.GetChild(0), hs.middle[1]);
        setNodeRotation(middle.GetChild(0).GetChild(0), hs.middle[1]);

        setNodeRotation(ring, hs.ring[0]);
        setNodeRotation(ring.GetChild(0), hs.ring[1]);
        setNodeRotation(ring.GetChild(0).GetChild(0), hs.ring[1]);

        setNodeRotation(pinky, hs.pinky[0]);
        setNodeRotation(pinky.GetChild(0), hs.pinky[1]);
        setNodeRotation(pinky.GetChild(0).GetChild(0), hs.pinky[1]);
    }
}
