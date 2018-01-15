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
    private Vector3 _palmOffset = Vector3.zero;
    public HandState _hs = new HandState();

    private const float _rate = .5f;

    private void setNodeRotation(Transform node, float angle) {
        var rotation = Quaternion.Euler(0, angle, 0); // +90 degrees Y rotation
        node.localRotation = Quaternion.Slerp(node.localRotation, rotation,  _rate);
    }

    private float baseNodeAngle(float rotationRate) {
        return (-110 * rotationRate) + 20;
    }

    private float middleNodeAngle(float rotationRate) {
        return -90 * rotationRate;
    }

    private void setThumbRotation(Transform thumb, float angle) {
        var rotation = Quaternion.Euler(0, 0, -angle); 
        thumb.localRotation = Quaternion.Slerp(thumb.localRotation, rotation,  _rate);
    }

    private void Update() {
        loadHandState(_hs);
        if (Input.GetKeyDown(KeyCode.Space)) {
            _palmOffset = -palm.localEulerAngles + _palmOffset;
        }
    }

    public void setPalmReference(Vector3 palmReference) {
        _palmReference = new Vector3(-palmReference.z, palmReference.x, -palmReference.y);
        palm.localRotation = Quaternion.Euler(_palmReference + _palmOffset);
    }

    private void loadHandState(HandState hs) {
        setNodeRotation(pinky, baseNodeAngle(hs.pinky[0]));
        setNodeRotation(pinky.GetChild(0), middleNodeAngle(hs.pinky[1]));
        setNodeRotation(pinky.GetChild(0).GetChild(0), middleNodeAngle(hs.pinky[1]));
        
        setNodeRotation(ring, baseNodeAngle(hs.ring[0]));
        setNodeRotation(ring.GetChild(0), middleNodeAngle(hs.ring[1]));
        setNodeRotation(ring.GetChild(0).GetChild(0), middleNodeAngle(hs.ring[1]));
        
        setNodeRotation(middle, baseNodeAngle(hs.middle[0]));
        setNodeRotation(middle.GetChild(0), middleNodeAngle(hs.middle[1]));
        setNodeRotation(middle.GetChild(0).GetChild(0), middleNodeAngle(hs.middle[1]));  
        
        setNodeRotation(index, baseNodeAngle(hs.index[0]));
        setNodeRotation(index.GetChild(0), middleNodeAngle(hs.index[1]));
        setNodeRotation(index.GetChild(0).GetChild(0), middleNodeAngle(hs.index[1]));

        setThumbRotation(thumb.GetChild(0), baseNodeAngle(hs.thumb[0]));
        setThumbRotation(thumb.GetChild(0).GetChild(0), baseNodeAngle(hs.thumb[1]));

        setPalmReference(hs.palm);
    }
}
