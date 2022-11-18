using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rnd = UnityEngine.Random;

public class HypersliceModule : MonoBehaviour
{
    void Start()
    {
        HypersliceSphere originalSphere = GetComponentInChildren<HypersliceSphere>();
        SphereManager sphereManager = new SphereManager();

        int res = 2;
        for (int i = 0; i < Mathf.Pow(res, 4); i++)
        {
            HypersliceSphere newSphere = Instantiate(originalSphere, originalSphere.transform.parent);
            newSphere.SetPosition(new Vector4(
                ((i / ((int)Mathf.Pow(res, 0))) % res + 0.5f),
                ((i / ((int)Mathf.Pow(res, 1))) % res + 0.5f),
                ((i / ((int)Mathf.Pow(res, 2))) % res + 0.5f),
                ((i / ((int)Mathf.Pow(res, 3))) % res + 0.5f))
                / res * 4 - Vector4.one * 2,
                true);
            newSphere.Scale = 2f / res;
            //Debug.Log(newSphere.Position + ", " + newSphere.Scale);
            sphereManager.AddSphere(newSphere);
            newSphere.GetComponent<MeshRenderer>().material.color = new Color(Rnd.Range(0.25f, 0.5f), Rnd.Range(0f, 0.125f), Rnd.Range(0.25f, 0.5f), 0.875f);
        }


        originalSphere.GetComponent<Renderer>().enabled = false;

        StartCoroutine(TryRotations(sphereManager));
    }

    private IEnumerator TryRotations(SphereManager sphereManager)
    {
        while (true)
        {
            yield return sphereManager.Rotate(new Rotation(Axis.X, Axis.Z, 1 / 4f));
            yield return sphereManager.Rotate(new Rotation(Axis.Y, Axis.X, 1 / 4f));
            yield return sphereManager.Rotate(new Rotation(Axis.W, Axis.Z, 1 / 4f));
            yield return sphereManager.Rotate(new Rotation(Axis.X, Axis.Y, 1 / 4f));
            yield return sphereManager.Rotate(new Rotation(Axis.X, Axis.W, 1 / 4f), new Rotation(Axis.Z, Axis.Y, 1 / 4f));
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 1, 0, 0)), new Axis(new Vector4(-1, 0, 1, 0)), 1 / 3f));
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 1, 0, 0)), new Axis(new Vector4(-1, 0, 0, 1)), 1 / 3f));
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 1, 0, 0)), Axis.Z, 1 / 2f), new Rotation(new Axis(new Vector4(1, -1, 0, 0)), Axis.W, 1 / 2f));
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 1, 1, 0)), Axis.W, 1f)); //bad idea
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 1, 1, 0)), new Axis(new Vector4(1, 0, 0, 1)), 1f)); //bad idea
            yield return sphereManager.Rotate(new Rotation(Axis.X, new Axis(new Vector4(0, -1, 1, -1)), 1f)); //bad idea
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 0, 0, -1)), new Axis(new Vector4(0, -1, 1, -1)), 1f)); //bad idea
            yield return sphereManager.Rotate(new Rotation(new Axis(new Vector4(1, 1, 1, 0)), new Axis(new Vector4(0, 1, 1, 1)), 1f)); //bad idea
            yield return sphereManager.Rotate(new Rotation(Axis.X, new Axis(new Vector4(0, 1, 1, 1)), 1f)); //bad idea
            yield return sphereManager.Rotate(new Rotation(Axis.Y, new Axis(new Vector4(1, 0, 0, -1)), 1f), new Rotation(Axis.Z, new Axis(new Vector4(1, 0, 0, 1)), 1f)); //do not



            //StartCoroutine(sphereManager.Rotate(new Rotation(Axis.X, Axis.Y), new Rotation(Axis.X, Axis.Z)));
            //yield return new WaitForSeconds(1);
            //StartCoroutine(sphereManager.Rotate(new Rotation(Axis.X, Axis.Z), new Rotation(Axis.X, Axis.Y)));
            //yield return new WaitForSeconds(1);
            //StartCoroutine(sphereManager.Rotate(new Rotation(Axis.X, Axis.Z), new Rotation(Axis.X, Axis.Z)));
            //yield return new WaitForSeconds(1);
            //StartCoroutine(sphereManager.Rotate(new Rotation(Axis.X, Axis.Z), new Rotation(Axis.X, Axis.W)));
            //yield return new WaitForSeconds(1);
            //StartCoroutine(sphereManager.Rotate(new Rotation(Axis.X, Axis.Y), new Rotation(Axis.Z, Axis.Y), new Rotation(Axis.X, Axis.Y)));
            //yield return new WaitForSeconds(1);
            //StartCoroutine(sphereManager.Rotate(new Rotation(Axis.X, Axis.Y), new Rotation(Axis.Y, Axis.Z), new Rotation(Axis.Z, Axis.W)));
            yield return new WaitForSeconds(1);
        }
    }

    void Update()
    {

    }
}
