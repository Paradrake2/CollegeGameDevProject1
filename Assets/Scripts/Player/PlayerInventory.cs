using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Key[] ownedKeys;
    public Key[] OwnedKeys => ownedKeys;

    public bool HasKey(string keyID)
    {
        foreach (var key in ownedKeys)
        {
            if (key.KeyID == keyID)
            {
                return true;
            }
        }
        return false;
    }
    public void RemoveKey(string keyID)
    {
        for (int i = 0; i < ownedKeys.Length; i++)
        {
            if (ownedKeys[i].KeyID == keyID)
            {
                var temp = new Key[ownedKeys.Length - 1];
                for (int j = 0, k = 0; j < ownedKeys.Length; j++)
                {
                    if (j == i) continue;
                    temp[k++] = ownedKeys[j];
                }
                ownedKeys = temp;
                break;
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
