using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;

    private void Start()
    {
        Explosion explosionObject = FindObjectOfType<Explosion>();
        Explosion[] explosionObjects = FindObjectsOfType<Explosion>();

        _raycastDrawer.objectHitEvent += DestoyObject;
    }

    public void DestoyObject(GameObject objectHit)
    {
        if (objectHit.GetComponent<Explosion>())
        {
            Explosion explosionObject = objectHit.GetComponent<Explosion>();
            explosionObject.ExplodeObject();
        }
    }
}
