using Mapbox.Examples;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EventPointer : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 50f;
    [SerializeField]
    float aplitude = 2.0f;
    [SerializeField]
    float frequency = 0.50f;

    LocationStatus playerLocation;
    public Vector2d eventPos;

    public int eventID;

    MenuUIManager menuUIManager;
    EventManager eventManager;
    Cam_Controls cam;
    public GameObject index;

    public Material[] material;



    // Start is called before the first frame update
    void Start()
    {
        menuUIManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        eventManager = GameObject.Find("-EventManager").GetComponent<EventManager>();
        cam = Camera.main.GetComponent<Cam_Controls>();

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true); // true to include inactive objects
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Index")
            {
                index = obj;
                return;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();

        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);

        if (distance < eventManager.maxDistance)
        {
            GetComponentInChildren<Renderer>().material = material[0];

        }
        else
        {

            GetComponentInChildren<Renderer>().material = material[1];
        }
    }

    void FloatAndRotatePointer()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * aplitude) + 15, transform.position.z);
    }
    private void OnMouseUp()
    {
        Debug.Log("clicking");
        if (!cam.isDragging || !cam.isZooming && !index.activeInHierarchy)
        {
            playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
            var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
            var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
            var distance = currentPlayerLocation.GetDistanceTo(eventLocation);

            //Debug.Log("Distance is: " + distance);

            if (distance < eventManager.maxDistance)
            {
                menuUIManager.DisplayStartEventPanel(eventID);
                GetComponentInChildren<Renderer>().material = material[0];

            }
            else
            {
                menuUIManager.DisplayUsetNotInRange();

                GetComponentInChildren<Renderer>().material = material[1];
            }
        }
    }

}
