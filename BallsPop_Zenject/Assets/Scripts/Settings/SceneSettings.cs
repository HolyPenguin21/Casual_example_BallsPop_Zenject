using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSettings
{
    Camera camera;
    ViewportBounds screenBounds;

    public SceneSettings(Camera camera)
    {
        this.camera = camera;
    }

    public ViewportBounds Get_ViewportBounds()
    {
        if (screenBounds == null)
            screenBounds = new ViewportBounds(camera);

        return screenBounds;
    }
}
