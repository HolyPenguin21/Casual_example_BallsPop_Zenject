using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportBounds
{
    public float[] x_bounds;
    public float[] y_bounds;

    public ViewportBounds(Camera camera)
    {
        Vector3 max_Vector = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        x_bounds = new float[2] {0, max_Vector.x };
        y_bounds = new float[2] { 0, max_Vector.y };
    }
}
