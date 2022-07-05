using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealfSystemPL : MonoBehaviour
{
    public Image imageHealf;
    public Image imageMana;
    public Image imageEndurance;

    public float healf;
    public float maxHeafl;

    public float endurance;
    public float maxendurance;


    public float mana;
    public float maxMana;


    PlayerVaribies playerVaribies;


    public float maxWait;
    public float WaitE;
    public float WaitM;


    public bool Shield;
    private Scene activeScene;


    public bool isRage;

    void Start()
    {

        Shield = false;
        playerVaribies = GetComponent<PlayerVaribies>();
        UpdateOnHEM();

        healf = maxHeafl;
        endurance = maxendurance;
        mana = maxMana;
        activeScene = SceneManager.GetActiveScene();


    }

    void Update()
    {

       
        UpdateOnHEM();
        imageHealf.fillAmount = healf/maxHeafl;
        imageMana.fillAmount = mana / maxMana;
        imageEndurance.fillAmount = endurance / maxendurance;


        if (WaitE>0)
        {
            WaitE -= Time.deltaTime;
        }

        if (WaitM >0)
        {
            WaitM -= Time.deltaTime;

        }
        RegenEM();



        //if (healf <=0)
        //{
        //    SceneManager.LoadScene(activeScene.name);

        //}

    }




    public void TakeDamage(float damage)
    {
        if (Shield == false)
        {
            healf -= damage;
        }
      
    }



    public void UseEndurance(float How)
    {
        endurance -= How;
    }

    public void UseMana(float How)
    {

        mana -= How;
    }


    void UpdateOnHEM()
    {
        maxHeafl = (float)(playerVaribies.strong * 2 + playerVaribies.agility * 0.5 + playerVaribies.smarts * 0.5);
        maxMana = (float)(playerVaribies.strong * 0.5 + playerVaribies.agility * 0.5 + playerVaribies.smarts * 2);

        if (!isRage)
        {
            maxendurance = (float)(playerVaribies.strong * 1 + playerVaribies.agility * 2);

        }

    }


    void RegenEM()
    {
        if (endurance < maxendurance && WaitE<=0)
        {
            endurance++;
            WaitE = 5;
        }

        else if (mana < maxMana )
        {
            mana++;
            WaitM = 5;
        }

        
    }


 
}
