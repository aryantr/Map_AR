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
    public Image cameraInfoImage;
    public AbstractLocationProvider locationProvider;

    [SerializeField] float recenterThreshold = 10f;
    private Vector2d lastPlayerLocation;
    private float totalDistanceCovered = 0f;
    void Start()
    {
        totalDistanceCovered = 0f;
        cameraInfoImage.enabled = false;
        lastPlayerLocation = GetPlayerLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (locationProvider != null)
        {
            Vector2d currentPlayerLocation = GetPlayerLocation();
            float distance = (float)Vector2d.Distance(currentPlayerLocation, lastPlayerLocation);
            distance *= 10000f;

            if(distance > recenterThreshold)
            {
                map.UpdateMap(currentPlayerLocation);
                lastPlayerLocation = currentPlayerLocation;

            }

            totalDistanceCovered +=  distance;

            if(totalDistanceCovered > 2f)
            {
                cameraInfoImage.enabled = true;

            }

            debugText.text = "Distance = " + totalDistanceCovered.ToString();
        }
    }

    Vector2d GetPlayerLocation()
    {
        Location location = locationProvider.CurrentLocation;

        return new Vector2d(location.LatitudeLongitude.x, location.LatitudeLongitude.y);
    }

}
