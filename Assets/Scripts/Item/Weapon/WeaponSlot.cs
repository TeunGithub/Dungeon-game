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
    private bool _disabledPrimaryAttack = false;
    void Start()
    {
     
        _equippedWeapon = gameObject.transform.GetChild(0).gameObject;
        _parent = gameObject.transform.parent.gameObject;
        _defaultPositionOffset = gameObject.transform.position - _parent.transform.position;
        _defaultRotation = gameObject.transform.rotation;
    }

    /// <summary>
    /// Rotates the entity slot towards the mouse
    /// </summary>
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

    /// <summary>
    /// Gets parent object
    /// </summary>
    /// <returns>Parent ojbect</returns>
    public GameObject GetParentObject()
    {
        return _parent;
    }

    /// <summary>
    /// Returns collider2D of eqquiped weapon
    /// </summary>
    /// <returns>Collider2D of weapon</returns>
    public Collider2D GetHitboxOfWeapon()
    {
        return _equippedWeapon.GetComponent<Collider2D>();
    }

    /// <summary>
    /// Enabeles the primary attack
    /// </summary>
    public void EnablePrimaryAttack()
    {
        _disabledPrimaryAttack = false;
    }

    /// <summary>
    /// Disables the primary attack
    /// </summary>
    public void DisablePrimaryAttack()
    {
        _disabledPrimaryAttack = true;
    }

    /// <summary>
    /// Checks if primary attack is enabled
    /// </summary>
    /// <returns>true if primary attack is enabled, false if its disabled</returns>
    public bool PrimaryAttackDisabled()
    {
        return _disabledPrimaryAttack;
    }

    /// <summary>
    /// Gets the angle from the objects position to the position of the mouse
    /// </summary>
    /// <param name="currentPos">The position of the object</param>
    /// <param name="mousePos">The position of the mouse in world coordinates</param>
    /// <returns>Angle in degrees from object position to mouse position</returns>
    private float GetAngleToMouse(Vector3 currentPos, Vector3 mousePos)
    {
       
        return Mathf.Atan2(mousePos.y - currentPos.y, mousePos.x - currentPos.x) * Mathf.Rad2Deg;
    }
    /// <summary>
    /// Resets the position of the weaponslot to its original position
    /// </summary>
    public void ResetPosition()
    {
        _equippedWeapon.transform.position = transform.position;
        _equippedWeapon.transform.rotation = transform.rotation;
        Vector3 parentPosition = _parent.transform.position;
        transform.position = parentPosition + _defaultPositionOffset;
        transform.rotation = _defaultRotation;
    }


}
