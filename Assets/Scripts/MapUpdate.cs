using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using UnityEngine.UI;

public class MapUpdate : MonoBehaviour
{
    public AbstractMap map;
    public Transform player;
    public Text debugText;
    public GameObject cameraInfoImage;
    public AbstractLocationProvider locationProvider;

    [SerializeField] float recenterThreshold = 10f;
    [SerializeField] float arThreshold = 1f;
    private Vector2d lastPlayerLocation;
    private Vector2d initialPlayerLocation;

    void Start()
    {
        cameraInfoImage.SetActive(false);
        initialPlayerLocation = GetPlayerLocation();
        lastPlayerLocation = initialPlayerLocation;

    }

    // Update is called once per frame
    void Update()
    {
        if (locationProvider != null)
        {
            Vector2d currentPlayerLocation = GetPlayerLocation();
            float distance = (float)Vector2d.Distance(currentPlayerLocation, lastPlayerLocation);
            float totalDistance = (float)Vector2d.Distance(currentPlayerLocation, initialPlayerLocation);
            distance *= 10000f;
            totalDistance *= 10000f;

            if(distance > recenterThreshold)
            {
                // Recenter the map based on player location exceeds the threshold
                map.UpdateMap(currentPlayerLocation);
                lastPlayerLocation = currentPlayerLocation;

            }
            else{}

            if(totalDistance > arThreshold)
            {
                cameraInfoImage.SetActive(true);
            }
            else{}

            debugText.text = "Distance = " + totalDistance.ToString();
        }
        else
        {
            debugText.text = "Waiting for location....\nCheck location is enabled in device";
        }
    }

    Vector2d GetPlayerLocation()
    {
        Location location = locationProvider.CurrentLocation;

        return new Vector2d(location.LatitudeLongitude.x, location.LatitudeLongitude.y);
    }

}
