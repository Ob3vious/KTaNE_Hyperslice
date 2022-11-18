using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public struct Axis
{
    public static Axis X = new Axis(new Vector4(1, 0, 0, 0));
    public static Axis Y = new Axis(new Vector4(0, 1, 0, 0));
    public static Axis Z = new Axis(new Vector4(0, 0, 1, 0));
    public static Axis W = new Axis(new Vector4(0, 0, 0, 1));

    public Vector4 Vector { get; private set; }

    public Axis(Vector4 vector)
    {
        Vector = vector.normalized;
    }

}

public struct Rotation
{
    //from A to B
    public Axis A { get; private set; }
    public Axis B { get; private set; }
    private float _angle;

    public Rotation(Axis a, Axis b, float angle)
    {
        A = a;
        B = new Axis((b.Vector - a.Vector * Extract(b.Vector, a)).normalized);

        //angle where 1 is full rotation
        _angle = angle;
    }

    /// <param name="angle">The angle to rotate by. 1 means a full rotation of internal angle.</param>
    public Vector4 GetRotated(Vector4 vector, float angle)
    {
        //Vector4 position = Vector4.zero;
        Vector4 position = vector * 1;
        angle *= _angle * Mathf.PI * 2;

        position += ((Mathf.Cos(angle) - 1) * Extract(vector, A) - Mathf.Sin(angle) * Extract(vector, B)) * A.Vector;
        position += ((Mathf.Cos(angle) - 1) * Extract(vector, B) + Mathf.Sin(angle) * Extract(vector, A)) * B.Vector;

        return position.normalized * vector.magnitude;
    }

    private static float Extract(Vector4 vector, Axis axis)
    {
        return Vector4.Dot(vector, axis.Vector);
    }
}
