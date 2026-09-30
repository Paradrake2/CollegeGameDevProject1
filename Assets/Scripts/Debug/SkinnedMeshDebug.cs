using UnityEngine;

public class SkinnedMeshDebug : MonoBehaviour
{
    void Start()
    {
        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();

        if (smr == null)
        {
            Debug.LogError("No SkinnedMeshRenderer found.");
            return;
        }

        Debug.Log("Root Bone: " + 
            (smr.rootBone != null ? smr.rootBone.name : "None"));

        Debug.Log("Bone count: " + smr.bones.Length);

        for (int i = 0; i < smr.bones.Length; i++)
        {
            if (smr.bones[i] != null)
                Debug.Log(i + ": " + smr.bones[i].name);
            else
                Debug.Log(i + ": NULL");
        }
    }
}