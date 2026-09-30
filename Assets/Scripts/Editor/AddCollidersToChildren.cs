using UnityEditor;
using UnityEngine;

public class AddCollidersToChildren
{
    [MenuItem("Tools/Add Mesh Colliders To Selected")]
    public static void AddMeshColliders()
    {
        foreach (GameObject selectedObject in Selection.gameObjects)
        {
            MeshFilter[] meshFilters = selectedObject.GetComponentsInChildren<MeshFilter>(true);

            foreach (MeshFilter meshFilter in meshFilters)
            {
                GameObject obj = meshFilter.gameObject;

                if (obj.GetComponent<Collider>() == null)
                {
                    Undo.AddComponent<MeshCollider>(obj);
                }
            }
        }

        Debug.Log("Finished adding colliders.");
    }
}