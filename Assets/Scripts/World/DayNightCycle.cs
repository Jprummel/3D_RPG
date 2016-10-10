using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

    private Light _light;

    [SerializeField]private float _minutesInDay;
                    private float _timer;
                    private float _percentageOfDay;
                    private float _turnSpeed;

	void Start () {
        _light = GetComponent<Light>();
        _timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CheckTime();
        UpdateLight();

        _turnSpeed = 360 / (_minutesInDay * 60) * Time.deltaTime;
        transform.RotateAround(transform.position, transform.right, _turnSpeed);
	}

    void CheckTime()
    {
        _timer += Time.deltaTime;
        _percentageOfDay = _timer / (_minutesInDay * 60); //_minutesInDay * 60 gives the seconds in a day
        if (_timer > (_minutesInDay * 60))
        {
            _timer = 0;
        }
    }

    void UpdateLight()
    {
        if (isNight())
        {
            if (_light.intensity > 0)
            {
                _light.intensity -= 0.05f;
            }
        }
        else
        {
            if (_light.intensity < 1)
            {
                _light.intensity += 0.05f;
            }
        }
    }

    bool isNight()
    {
        //Checks if it is nighttime
        bool c = false;
        if (_percentageOfDay == 0.5)
        {
            c = true;
        }
        return c;
    }
}
