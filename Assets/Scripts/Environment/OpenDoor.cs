using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private string openID; // used to identify which key can open this door
    [SerializeField] private Collider colliderComponent;
    public Collider ColliderComponent => colliderComponent;
    public string OpenID => openID;

    private void OnTriggerEnter(Collider other)
    {
        // Logic for when something enters the trigger collider
        if (other.CompareTag("Player"))
        {
            // pop up prompt to open door
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Logic for when something exits the trigger collider
        if (other.CompareTag("Player"))
        {
            // hide prompt to open door
        }
    }
    private void OpenTheDoor()
    {
        Destroy(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
