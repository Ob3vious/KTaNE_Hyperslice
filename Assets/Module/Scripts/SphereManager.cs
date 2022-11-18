using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager {

    private List<HypersliceSphere> _spheres = new List<HypersliceSphere>();

    public void AddSphere(HypersliceSphere sphere)
    {
        _spheres.Add(sphere);
    }

    public IEnumerator Rotate(params Rotation[] rotations)
    {
        yield return null;

        for (float t = 0; t < 1; t += Time.deltaTime / 1f)
        {
            foreach (HypersliceSphere sphere in _spheres)
            {
                Vector4 newPos = sphere.Position;
                foreach (Rotation rotation in rotations)
                    newPos = rotation.GetRotated(newPos, (1 - Mathf.Cos(t * Mathf.PI)) / 2);
                sphere.SetPosition(newPos, false);
            }
            yield return null;
        }

        foreach (HypersliceSphere sphere in _spheres)
        {
            Vector4 newPos = sphere.Position;
            foreach (Rotation rotation in rotations)
                newPos = rotation.GetRotated(newPos, 1);
            sphere.SetPosition(newPos, true);
        }
    }
}
