using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class RaycastTest : MonoBehaviour
{
    ARRaycastManager MyRaycastManager;
    List<ARRaycastHit> planesHitList = new List<ARRaycastHit>();
    public GameObject prefabtoinstantiate;
    GameObject instantiatedObject;
    bool deactivatePlanesOnce;
    // Start is called before the first frame update
    void Start()
    {
        MyRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && instantiatedObject == null)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (MyRaycastManager.Raycast(touchPosition, planesHitList, TrackableType.PlaneWithinPolygon))
            {
                Pose planeHitPose = planesHitList[0].pose;
                instantiatedObject = Instantiate(prefabtoinstantiate, planeHitPose.position, planeHitPose.rotation);
            }
        }
        if (instantiatedObject != null)
        {
            if (!deactivatePlanesOnce)
            {
                Planesmanager(true);
                deactivatePlanesOnce = true;
            } 
        }
        else
        {
            if(deactivatePlanesOnce)
        {
                deactivatePlanesOnce = false;
        }
                
                    }
            

    }
    void Planesmanager(bool status)
    {
        GameObject[] allPlanesInScene = GameObject.FindGameObjectsWithTag("ARPlanes");
        for (int i = 0; i < allPlanesInScene.Length; i++)
        {
            allPlanesInScene[i].SetActive(false);
        }
    }
}
