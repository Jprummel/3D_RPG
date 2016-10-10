using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyGUI : MonoBehaviour {

    private Text _Name;
    private Text _Health;
    private Text _Energy;
    private Image _HealthImage;
    private Image _EnergyImage;

	void Start () 
    {
        //Gets enemy info components
        _Name = transform.FindChild("EnemyInfoContainer/EnemyPortrait/Name").GetComponent<Text>();
        _Name.text = EnemyInformation.Name;
        _Health = transform.FindChild("EnemyInfoContainer/HealthBar/HealthValue").GetComponent<Text>();
        _Energy = transform.FindChild("EnemyInfoContainer/EnergyBar/EnergyValue").GetComponent<Text>();
        _HealthImage = transform.FindChild("EnemyInfoContainer/HealthBar").GetComponent<Image>();
        _EnergyImage = transform.FindChild("EnemyInfoContainer/EnergyBar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        EnemyInfo();
	}

    void EnemyInfo()
    {
        _Name.text = EnemyInformation.Name;
        _Health.text = EnemyInformation.Health.ToString() + "/" + EnemyInformation.MaxHealth.ToString();
        _HealthImage.fillAmount = EnemyInformation.Health / EnemyInformation.MaxHealth;
        _Energy.text = EnemyInformation.Energy.ToString() + "/" + EnemyInformation.MaxEnergy.ToString();
        _EnergyImage.fillAmount = EnemyInformation.Energy / 100;
    }
}
