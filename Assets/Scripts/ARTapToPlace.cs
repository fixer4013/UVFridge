using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject clone;
    public GameObject placementIndicator;
    public GameObject animationManager;
    public GameObject colorChange;
    public bool existingFridge;

    [SerializeField]private ARRaycastManager raycastManager;
    [SerializeField] private Pose placementPose;
    [SerializeField] private bool placementPoseIsValid = false;

    void Start()
    {
        ARRaycastManager raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && existingFridge == false)
        {
            existingFridge = true;
            PlaceObject();
        }

        if(Input.GetKeyDown(KeyCode.Space) && existingFridge == false)
        {
            existingFridge = true;
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        clone = Instantiate (objectToPlace, placementPose.position, placementPose.rotation);
        animationManager.GetComponent<AnimationManager>().GetAnimations(clone);
        colorChange.GetComponent<ColorChange>().getMaterials(clone);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            Vector3 cameraForward = Camera.current.transform.forward;
            Vector3 cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
    public void DestroyFridge()
    {
        Destroy(clone);
        existingFridge = false;
    }
}
