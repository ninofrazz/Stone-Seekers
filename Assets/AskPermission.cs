using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class AskPermission : MonoBehaviour
{
    public GameObject beCar;

    void Start()
    {
        RequestLocationPermission();

        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            StartLocationService();
        }
        else
        {
            // Handle permission not granted scenario
        }
    }

    private void Update()
    {
        RequestLocationPermission();

        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            StartLocationService();
        }
        else
        {
            // Handle permission not granted scenario
        }
    }

    void StartLocationService()
    {
        // Start using location services here
        //SceneManager.LoadScene(1);
        // asyncManager.LoadLevel("map");
        beCar.SetActive(true);
    }

    private void RequestLocationPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
}

