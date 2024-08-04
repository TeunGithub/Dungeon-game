using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarBehaviour
{
    // Start is called before the first frame update
    private GameObject _damagebar;
    private Transform _parentTransform;
    
    public HealthbarBehaviour(GameObject damagebar, Transform parentTransform)
    {
        _damagebar = damagebar;
        _parentTransform = parentTransform;
    }

    /// <summary>
    /// Updates the health bar so damage taken is visible
    /// </summary>
    /// <param name="stats">stats of the entity the healthbar has been bound to</param>
    public void UpdateHealth(EntityStats stats)
    {
        if (stats.Health <= 0) { return; }
        float healthRatio = (float)stats.Health / stats.GetMaxHealth();
        Debug.Log(stats.GetMaxHealth() +", " + stats.Health + ", " + healthRatio);
        float barLenght = 1 - (healthRatio);
        float damageXPos = _parentTransform.position.x + ((0.5f * healthRatio));
        _damagebar.transform.localScale = new Vector3(barLenght, 1 ,1);   
        _damagebar.transform.position = new Vector3(damageXPos, _parentTransform.position.y, -0.1f);
    }

}
