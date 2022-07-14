using UnityEngine;

public class SceneSettings : ISceneSettings
{
    Camera camera;
    ViewportBounds screenBounds;

    public ViewportBounds Get_ViewportBounds()
    {
        if (camera == null) 
            camera = Camera.main;

        if (screenBounds == null)
            screenBounds = new ViewportBounds(camera);

        return screenBounds;
    }
}
