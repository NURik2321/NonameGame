using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerVaribies : MonoBehaviour
{

    public int lvl;
    public int exp;
    public int needExp;



    public static bool isWalking,isJumping;
    public static bool Attaking;

    public Inventory inventory;

    public bool flag;

    public int strong;

    public int smarts;

    public int agility;



    public TextMeshProUGUI StrongText;
    public TextMeshProUGUI SmartText;
    public TextMeshProUGUI AgiglityText;

    public GameObject EffectDamafeOnEnemy;

    void OnGUI()
    {
        float fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS = " + fps);
    }

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        StrongText = GameObject.FindGameObjectWithTag("TextStrong").GetComponent<TextMeshProUGUI>();
        SmartText = GameObject.FindGameObjectWithTag("TextSmart").GetComponent<TextMeshProUGUI>();
        AgiglityText = GameObject.FindGameObjectWithTag("TextAgility").GetComponent<TextMeshProUGUI>();


    }


    private void Update()
    {

        StrongText.text = "Сила : "+strong.ToString();
        SmartText.text = "Интелект : " + smarts.ToString();
        AgiglityText.text = "Ловкость : " + agility.ToString();


        if (exp >= needExp)
        {
            LevelUP();
        }


    }


   
    
    void LevelUP()
    {
        exp -= needExp;
        needExp = lvl * 5;
        lvl++;
        

    }
    
    }
   
