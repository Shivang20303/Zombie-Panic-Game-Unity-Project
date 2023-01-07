using UnityEditor;
using UnityEngine;

// Modified from code by bjennings76 at
// https://answers.unity.com/questions/118306/grouping-objects-in-the-hierarchy.html
public static class GroupCommand
{
    [MenuItem("GameObject/Group Selected %g")]
    private static void GroupSelected()
    {
        if (!Selection.activeTransform) { return; }

        // Calculate the selection bounds
        Bounds bounds = new Bounds(Selection.activeTransform.position, Vector3.zero);

        foreach (Transform t in Selection.transforms)
        {
            Renderer r = t.GetComponent<Renderer>();
            if (r != null)
            {
                bounds.Encapsulate(r.bounds);
            }
            else
            {
                bounds.Encapsulate(t.position);
            }
        }

        // Group selection under new GameObject
        GameObject go = new GameObject(Selection.activeTransform.name + "_group");
        Undo.RegisterCreatedObjectUndo(go, "Group Selected");
        go.transform.position = bounds.min;

        foreach (Transform t in Selection.transforms)
        {
            Undo.SetTransformParent(t, go.transform, "Group Selected");
        }

        Selection.activeGameObject = go;
    }
}