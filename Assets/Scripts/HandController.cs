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

    private const float _rate = .5f;

    private void setNodeRotation(Transform node, float rotationRate) {
        float angle = (-100 * rotationRate) + 10;
        var rotation = Quaternion.Euler(0, angle, 0); // +90 degrees Y rotation
        node.localRotation = Quaternion.Slerp(node.localRotation, rotation,  _rate);
    }

    private void setThumbRotation(Transform thumb, float rotationRate) {
        var rotation = Quaternion.Euler(0, 0, 90f * rotationRate); 
        thumb.localRotation = Quaternion.Slerp(thumb.localRotation, rotation,  _rate);
        print(thumb.localRotation.eulerAngles);
    }

    private void Update() {
        loadHandState(_hs);
    }

    public void setPalmReference(Vector3 palmReference) {
        _palmReference = new Vector3(-palmReference.z, palmReference.x, -palmReference.y);
        palm.localRotation = Quaternion.Euler(_palmReference);
    }

    private void loadHandState(HandState hs) {
        setNodeRotation(pinky, hs.pinky[0]);
        setNodeRotation(pinky.GetChild(0), hs.pinky[1]);
        setNodeRotation(pinky.GetChild(0).GetChild(0), hs.pinky[1]);
        
        setNodeRotation(ring, hs.ring[0]);
        setNodeRotation(ring.GetChild(0), hs.ring[1]);
        setNodeRotation(ring.GetChild(0).GetChild(0), hs.ring[1]);
        
        setNodeRotation(middle, hs.middle[0]);
        setNodeRotation(middle.GetChild(0), hs.middle[1]);
        setNodeRotation(middle.GetChild(0).GetChild(0), hs.middle[1]);  
        
        setNodeRotation(index, hs.index[0]);
        setNodeRotation(index.GetChild(0), hs.index[1]);
        setNodeRotation(index.GetChild(0).GetChild(0), hs.index[1]);

        setThumbRotation(thumb.GetChild(0), hs.thumb[0]);
        setThumbRotation(thumb.GetChild(0).GetChild(0), hs.thumb[1]);

        setPalmReference(hs.palm);
    }
}
