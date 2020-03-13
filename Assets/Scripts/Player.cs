using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;
    public int maxEnergy = 10;
    public int currentEnergy;
    //to reference our healthbar object
    public HealthBar healthBar;
    public EnergyBar energyBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        healthBar.SetMaxHealth(maxHealth);
        //energyBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        //decrease or increase player health here
        //if(Input.GetKeyDown(KeyCode.C))
        //{
        //    TakeDamage(1);
        //}
        //decrease or increase player energy here
         
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }
    void SpendMeter(int spentmeter)
    {
        currentEnergy -= spentmeter;
        energyBar.SetEnergy(currentEnergy);
    }

    
    
}