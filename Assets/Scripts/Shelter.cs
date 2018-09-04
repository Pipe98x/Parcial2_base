using UnityEngine;
using System.Collections;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;
    [SerializeField]
    private int resistencia;
    private float regenTime = 3;
    [SerializeField]
    private KillVolume gameOver;

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    public void Damage(int damage)
    {
        if (resistencia <= MaxResistance)
        {
            resistencia -= 1;
            if(resistencia == 0)
            {
              Destroy(gameObject);
            }
        }

        StartCoroutine(Regenerar(resistencia));
        
    }

   private IEnumerator Regenerar(int resistenciaPasada)
    {
        yield return new WaitForSeconds(regenTime);
        if(resistencia == resistenciaPasada)
        {
            resistencia += 1;
        }

    }
}