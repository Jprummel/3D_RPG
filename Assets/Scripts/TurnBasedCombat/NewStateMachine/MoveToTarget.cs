using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour{

    public bool MoveToTargetPos(Vector3 target, float animSpeed)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position , target, animSpeed * Time.deltaTime));
    }
}
