using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _equippedWeapon;
    private GameObject _parent;
    private Vector3 _defaultPositionOffset;
    private Quaternion _defaultRotation;
    void Start()
    {
     
        _equippedWeapon = gameObject.transform.GetChild(0).gameObject;
        _parent = gameObject.transform.parent.gameObject;
        _defaultPositionOffset = gameObject.transform.position - _parent.transform.position;
        _defaultRotation = gameObject.transform.rotation;
    }

    public void RotateToMouse()
    {
        Vector3 parentPosition = _parent.transform.position;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //transform.position = parentPosition + new Vector3(1, 0, 0);
        //transform.rotation = Quaternion.identity;
        ResetPosition();

        transform.RotateAround(parentPosition, new Vector3(0, 0, 1), GetAngleToMouse(parentPosition, mousePositionInWorld));
    }
    // Update is called once per frame
    void Update()
    {
      
           
      
    }
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    private float GetAngleToMouse(Vector3 currentPos, Vector3 mousePos)
    {
       
        return Mathf.Atan2(mousePos.y - currentPos.y, mousePos.x - currentPos.x) * Mathf.Rad2Deg;
    }

    public void ResetPosition()
    {
        Vector3 parentPosition = _parent.transform.position;
        transform.position = parentPosition + _defaultPositionOffset;
        transform.rotation = _defaultRotation;
    }


}
