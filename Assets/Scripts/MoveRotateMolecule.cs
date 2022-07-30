using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotateMolecule : MonoBehaviour {
    //Attach this script to the object you want to move
    private GameObject targetIce;
    private GameObject targetLiquid;
    private GameObject targetVapor;

    private Vector3 targetPosition;

    private Quaternion targetRotation;
    
    private float moveSpeed = 0.1f;

    private float smooth = 0.2f;

    void Start(){
        char num = gameObject.name[16];
        string snum = num.ToString();

        string iceString = "Ice Molecule ("+snum+")";
        targetIce = GameObject.Find(iceString);

        string liquidString = "Liquid Molecule ("+snum+")";
        targetLiquid = GameObject.Find(liquidString);
        
        string vaporString = "Steam Molecule ("+snum+")";
        targetVapor = GameObject.Find(vaporString);
    }

    void Update(){
        GameObject iceText = GameObject.FindGameObjectWithTag("IceText");
        GameObject liquidText = GameObject.FindGameObjectWithTag("LiquidText");
        GameObject vaporText = GameObject.FindGameObjectWithTag("VaporText");
        
        if (liquidText) {
            targetPosition = targetLiquid.transform.position;
            targetRotation = targetLiquid.transform.rotation;
            smooth = 0.5f;
        }

        if (iceText) {
            targetPosition = targetIce.transform.position;
            targetRotation = targetIce.transform.rotation;
            smooth = 0.5f;
        }

        if (vaporText) {
            targetPosition = targetVapor.transform.position;
            targetRotation = targetVapor.transform.rotation;
            smooth = 0.5f;
        }

        //Lets start by finding the direction between our object and the target position
        Vector3 directionToMove = targetPosition - transform.position;

        //Now we have the direction, but we need to calculate the distance to move.      
        directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;
    
        //Now we add our direction to our current position. We are going to clamp the vector here to make sure we don't go past our target destination
        float maxDistance = Vector3.Distance(transform.position, targetPosition);
        transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,  Time.deltaTime * smooth);
        
     }
 }