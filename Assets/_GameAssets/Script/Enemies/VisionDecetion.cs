using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class VisionDecetion : MonoBehaviour
{
    [SerializeField] GameObject visionAlert;
    [SerializeField] float detectionDistance;
    [SerializeField] float visionAngle;
    //[SerializeField] GameObject target;
    [SerializeField] Transform visionOrigin;
    [SerializeField] LayerMask layerMask;

    void Awake()
    {
        //target = GameObject.FindGameObjectWithTag("Player");
        GetComponent<SphereCollider>().radius = detectionDistance;
        GetComponent<SphereCollider>().isTrigger = true;
        visionAngle = visionAngle / 2;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (IsVisible(other.gameObject.transform.position))
            {
                if (!HasObstacle(other.gameObject.transform.position))
                {
                    PlayerDetected(true);
                }
                else
                {
                    PlayerDetected(false);
                }
            }
            else
            {
                PlayerDetected(false);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected(false);
        }
    }
    private void PlayerDetected(bool detected)
    {
        visionAlert.SetActive(detected);
    }
    private bool IsVisible(Vector3 playerPosition)
    {
        Vector3 targetDirection = playerPosition - visionOrigin.position;
        Debug.DrawRay(visionOrigin.position, targetDirection, Color.red);
        Debug.DrawRay(visionOrigin.position, visionOrigin.forward, Color.blue);

        if (Vector3.Angle(targetDirection, visionOrigin.forward) <= visionAngle)
        {
            return true;
        }
        return false;
    }
    private bool HasObstacle(Vector3 playerPosition)
    {
        Vector3 targetDirection = playerPosition - visionOrigin.position;
        Ray ray = new Ray(visionOrigin.position, targetDirection);
        RaycastHit hitInfo;
        //bool hasObstacle = Physics.Raycast(ray, out hitInfo);
        bool hasObstacle = Physics.Raycast(ray, out hitInfo, detectionDistance, layerMask);
        if (hasObstacle)
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
