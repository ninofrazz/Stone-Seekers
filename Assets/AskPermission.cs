using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class AskPermission : MonoBehaviour
{
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
        SceneManager.LoadScene(1);
    }

    private void RequestLocationPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
}

