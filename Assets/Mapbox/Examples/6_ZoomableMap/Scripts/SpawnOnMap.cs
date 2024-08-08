namespace Mapbox.Examples
{
    using Mapbox.Unity.Map;
    using Mapbox.Unity.MeshGeneration.Factories;
    using Mapbox.Unity.Utilities;
    using Mapbox.Utils;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnOnMap : MonoBehaviour
    {

        public Vector2 eventPos;

        [SerializeField]
        AbstractMap _map;

        [SerializeField]
        [Geocode]
        string[] _locationStrings;

        [SerializeField]
        float _spawnScale = 100f;
        [SerializeField]
        float heightOffset = 0f;

        [SerializeField]
        GameObject _markerPrefab;

        List<GameObject> _spawnedObjects;

        Vector2d[] _locations;


        Vector2[] vector2s;

        void Start()
        {
            _locations = new Vector2d[_locationStrings.Length];
            _spawnedObjects = new List<GameObject>();

            for (int i = 0; i < _locationStrings.Length; i++)
            {
                // Convert location string to LatLon
                _locations[i] = Conversions.StringToLatLon(_locationStrings[i]);

                // Obtain the world position from the geo coordinates
                Vector3 worldPosition = _map.GeoToWorldPosition(_locations[i], true);

                // Apply an offset to the height (y-axis)
                worldPosition.y += heightOffset;

                // Instantiate the marker prefab
                var instance = Instantiate(_markerPrefab);

                instance.GetComponent<EventPointer>().eventPos = _locations[i];

                instance.GetComponent<EventPointer>().eventID = i + 1;

                // Set the instance's local position with the offset
                instance.transform.localPosition = worldPosition;

                // Set the instance's local scale
                instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);

                // Add the instance to the list of spawned objects
                _spawnedObjects.Add(instance);
            }
        }

        private void Update()
        {
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnedObjects[i];
                var location = _locations[i];

                // Obtain the updated world position from the geo coordinates
                Vector3 worldPosition = _map.GeoToWorldPosition(location, true);

                // Apply the height offset
                worldPosition.y += heightOffset;

                // Update the spawned object's position and scale
                spawnedObject.transform.localPosition = worldPosition;
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            }
        }
    }
}
