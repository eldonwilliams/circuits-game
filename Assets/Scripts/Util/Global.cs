using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Helps with misc. tasks that involve some global scope
 */
public class Global
{
    /**
     * Will find the first occurence of a component T in the scene
     * Bad for finding a specific gameobject
     */
    public static T GetFirstOccurenceOfInScene<T>(Scene? scene = null)
    {
        scene ??= SceneManager.GetActiveScene();
        var roots = scene.GetValueOrDefault().GetRootGameObjects();

        foreach (var gameObject in roots)
        {
            var found = gameObject.GetComponent<T>();
            found ??= gameObject.GetComponentInChildren<T>();
            if (found != null) return found;
        }

        return default;
    }

    /**
     * Looks for a gameobject of type T in the root objects of scene only
     */
    public static T GetFirstOccurenceOfInRootScene<T>(Scene? scene = null)
    {
        scene ??= SceneManager.GetActiveScene();
        var roots = scene.GetValueOrDefault().GetRootGameObjects();

        foreach (var gameObject in roots)
        {
            var found = gameObject.GetComponent<T>();
            if (found != null) return found;
        }

        return default;
    }
}
