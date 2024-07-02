using Assets.Scripts;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;

    [SerializeField] private FigurCreater _figurCreater;


    private void Start()
    {
        _raycastDrawer.objectHitEvent += DestoyObject;
    }

    public void DestoyObject(GameObject objectHit)
    {
        Explosion explosionObject = objectHit.GetComponent<Explosion>();
        
        if(explosionObject != null )
        {
            explosionObject.ExplodeObject(_figurCreater);
        }
    }
}
