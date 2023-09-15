using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Transform _parentObject;
    private List<T> _objects = new List<T>();
    private T elementOfPool;

    public Pool(T objects, int count)
    {
        _parentObject = new GameObject(objects.gameObject.name + " Pool").transform;
        elementOfPool = objects;
        for (int i = 0; i < count; i++)
        {
            CreateElement();
        }
    }

    private T CreateElement()
    {
        T element = Object.Instantiate(elementOfPool, _parentObject);
        _objects.Add(element);
        element.gameObject.SetActive(false);
        return element;
    }

    public T GetElement()
    {
        foreach (T obj in _objects)
        {
            if (!obj.gameObject.activeInHierarchy)
                return obj;
        }
        return CreateElement();
    }
}
