using UnityEngine;
using UnityEngine.UI;

public abstract class UI_Element
{
    public abstract void Hide();
    public abstract void Show();

    protected T Get_SceneObject<T>(T someVar, string name) where T : Object
    {
        if (someVar != null) return someVar;

        T[] objects = MonoBehaviour.FindObjectsOfType<T>();

        for (int i = 0; i < objects.Length; i++)
        {
            T obj = objects[i];

            if (obj.name.Contains(name))
                return obj;
        }

        Debug.Log($"'{name}' Object is not set as variable");
        return null;
    }
}
