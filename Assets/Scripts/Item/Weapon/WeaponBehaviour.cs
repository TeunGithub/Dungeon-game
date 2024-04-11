using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _equippedWeapon;
    private GameObject _parent;
    private Vector3 _defaultOffset;
    void Start()
    {
     
        _equippedWeapon = gameObject.transform.GetChild(0).gameObject;
        _parent = gameObject.transform.parent.gameObject;
        _defaultOffset = gameObject.transform.position - _parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 parentPosition = _parent.transform.position;
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //reset the position;
            transform.position = parentPosition + _defaultOffset;
            transform.rotation = Quaternion.identity;
            
            transform.RotateAround(parentPosition, new Vector3(0, 0, 1), GetAngleToMouse(parentPosition,mousePositionInWorld));
      
    }

    private float GetAngleToMouse(Vector3 currentPos, Vector3 mousePos)
    {
       
        return Mathf.Atan2(mousePos.y - currentPos.y, mousePos.x - currentPos.x) * Mathf.Rad2Deg;
    }


}
