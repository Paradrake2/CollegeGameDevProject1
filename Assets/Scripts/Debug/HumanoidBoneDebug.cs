using UnityEngine;

public class HumanoidBoneDebug : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("No Animator found on " + gameObject.name);
            return;
        }

        Debug.Log("Animator isHuman: " + animator.isHuman);
        Debug.Log("Animator isInitialized: " + animator.isInitialized);
        Debug.Log("Avatar: " + (animator.avatar != null ? animator.avatar.name : "NULL"));
        Debug.Log("Avatar isHuman: " + (animator.avatar != null && animator.avatar.isHuman));
        Debug.Log("Avatar isValid: " + (animator.avatar != null && animator.avatar.isValid));

        PrintBone(HumanBodyBones.Hips);
        PrintBone(HumanBodyBones.Spine);
        PrintBone(HumanBodyBones.Chest);

        PrintBone(HumanBodyBones.LeftUpperArm);
        PrintBone(HumanBodyBones.LeftLowerArm);
        PrintBone(HumanBodyBones.LeftHand);

        PrintBone(HumanBodyBones.RightUpperArm);
        PrintBone(HumanBodyBones.RightLowerArm);
        PrintBone(HumanBodyBones.RightHand);

        PrintBone(HumanBodyBones.LeftUpperLeg);
        PrintBone(HumanBodyBones.LeftLowerLeg);
        PrintBone(HumanBodyBones.LeftFoot);

        PrintBone(HumanBodyBones.RightUpperLeg);
        PrintBone(HumanBodyBones.RightLowerLeg);
        PrintBone(HumanBodyBones.RightFoot);
    }

    void PrintBone(HumanBodyBones bone)
    {
        Transform t = animator.GetBoneTransform(bone);

        if (t == null)
        {
            Debug.LogError(bone + " -> NULL");
        }
        else
        {
            Debug.Log(
                bone + " -> " + t.name +
                " | Path: " + GetPath(t)
            );
        }
    }

    string GetPath(Transform t)
    {
        string path = t.name;

        while (t.parent != null)
        {
            t = t.parent;
            path = t.name + "/" + path;
        }

        return path;
    }
}