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

    private void setNodeRotation(Transform node, float rotation) {
        Vector3 euler = node.rotation.eulerAngles;
        node.rotation = Quaternion.Euler(new Vector3(euler.x, 90 * rotation, euler.z));
    }
}
