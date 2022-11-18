using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypersliceSphere : MonoBehaviour {

    public Vector4 Position { get; set; }
    public float Scale { get; set; }

    void Start () {
        //SetPosition(new Vector4(0, 0, 0, -1) * 0.05f, true);
    }
    
    public void SetPosition(Vector4 position, bool isNewDefault)
    {
        if (isNewDefault)
            Position = position;

        float offset = 0.75f;
        //Debug.Log(offset + ", " + position + ", " + Scale);

        transform.localPosition = position;
        transform.localScale = Mathf.Pow(position.w + offset, 2) <= Mathf.Pow(Scale / 2, 2) ? 2 * Mathf.Sqrt(Mathf.Pow(Scale / 2, 2) - Mathf.Pow(position.w + offset, 2)) * Vector3.one : Vector3.zero;
    }
}

