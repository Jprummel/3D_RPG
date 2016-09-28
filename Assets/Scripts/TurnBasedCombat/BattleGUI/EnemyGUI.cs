using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyGUI : MonoBehaviour {

    private Text _enemyName;
    private Text _enemyHealth;
    private Text _enemyEnergy;
    private Image _enemyHealthImage;
    private Image _enemyEnergyImage;

	void Start () 
    {
        //Gets enemy info components
        _enemyName = transform.FindChild("EnemyInfoContainer/EnemyPortrait/EnemyName").GetComponent<Text>();
        _enemyName.text = EnemyInformation.EnemyName;
        _enemyHealth = transform.FindChild("EnemyInfoContainer/EnemyHealthBar/EnemyHealthValue").GetComponent<Text>();
        _enemyEnergy = transform.FindChild("EnemyInfoContainer/EnemyEnergyBar/EnemyEnergyValue").GetComponent<Text>();
        _enemyHealthImage = transform.FindChild("EnemyInfoContainer/EnemyHealthBar").GetComponent<Image>();
        _enemyEnergyImage = transform.FindChild("EnemyInfoContainer/EnemyEnergyBar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        EnemyInfo();
	}

    void EnemyInfo()
    {
        _enemyName.text = EnemyInformation.EnemyName;
        _enemyHealth.text = EnemyInformation.EnemyHealth.ToString() + "/" + EnemyInformation.EnemyMaxHealth.ToString();
        _enemyHealthImage.fillAmount = EnemyInformation.EnemyHealth / EnemyInformation.EnemyMaxHealth;
        _enemyEnergy.text = EnemyInformation.EnemyEnergy.ToString() + "/" + EnemyInformation.EnemyMaxEnergy.ToString();
        _enemyEnergyImage.fillAmount = EnemyInformation.EnemyEnergy / 100;
    }
}
