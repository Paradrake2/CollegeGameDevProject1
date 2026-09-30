using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Scriptable Objects/Key")]
public class Key : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private string keyName;
    [SerializeField] private string keyID; // used to unlock specific doors
    public Sprite Icon => icon;
    public string KeyName => keyName;
    public string KeyID => keyID;
}
