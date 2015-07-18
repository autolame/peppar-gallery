using UnityEngine;
using System.Collections;

public class CameraRaycast : MonoBehaviour
{


    Ray _ray;
    float distanceToGround = 0;

    [SerializeField]
    public GameObject hitGO;

    [SerializeField]
    public WorldObjectManager WOM;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        RaycastHit hit;


        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            hitGO = hit.transform.gameObject;
            WOM = hitGO.transform.parent.parent.GetComponent<WorldObjectManager>();


            Debug.Log("eye hit:" + hit.transform.gameObject);
            WOM.GotHit = true;
        }
        else
        {
            WOM.GotHit = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, Mathf.Infinity))
        {
            Debug.Log(" mouse Hit something");
        }
    }




}
