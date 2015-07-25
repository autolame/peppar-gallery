using UnityEngine;
using System.Collections;

public class CameraRaycast : MonoBehaviour
{


    Ray _ray;
    RaycastHit hit;
    float distanceToGround = 0;

    [SerializeField]
    public GameObject hitGO;

    [SerializeField]
    public WorldObjectManager WOM;

    [SerializeField]
    float _startTime;

    float _time;

    [SerializeField]
    GameObject _crosshair;

    // Use this for initialization
    void Awake()
    {
        if (_startTime == 0)
        {
            _startTime = 3;
        }
        _time = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;



        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
        //    Debug.Log(" mouse Hit:" + hit.transform.gameObject);
        //}

        ScaleCursor();
    }

    void ScaleCursor()
    {
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {

            _time -= Time.deltaTime;

            Debug.Log(_time);
            if (_time <= 0)
            {
                RotateObject();
            }

            var scale = _crosshair.transform.localScale;

            scale.x -= Time.deltaTime;
            scale.y -= Time.deltaTime;
            scale.z -= Time.deltaTime;

            scale = new Vector3(scale.x, scale.y, scale.z);

            //scale = new Vector3(Mathf.MoveTowards(scale.x, 0, .05f), Mathf.MoveTowards(scale.y, 0, .05f), Mathf.MoveTowards(scale.z, 0, .05f));
            //scale = new Vector3(scale.x );


            _crosshair.transform.localScale = scale;



        }
        else
        {
            _time = _startTime;
            _crosshair.transform.localScale = Vector3.one;
            WOM.GotHit = false;
        }

    }

    void RotateObject()
    {
        //if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        //{
        Debug.Log("rotating");
        hitGO = hit.transform.gameObject;
        WOM = hitGO.transform.parent.parent.GetComponent<WorldObjectManager>();

        Debug.Log("eye hit:" + hit.transform.gameObject);
        WOM.GotHit = true;
    }




}
