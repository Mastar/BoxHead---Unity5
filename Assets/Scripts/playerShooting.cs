using UnityEngine;
using System.Collections;

public class playerShooting : MonoBehaviour
{


    public GameObject[] weapons;
    int currentWeapon = 0;
    // Use this for initialization
    void Start()
    {
        Transform weaponTransform = transform.GetChild(1).GetChild(0).transform;
        weapons[0] = (GameObject)Instantiate(Resources.Load("MachinGun"), weaponTransform.position, Quaternion.Euler(90, 0, 0));
        weapons[0].transform.parent = weaponTransform;


        weapons[1] = (GameObject)Instantiate(Resources.Load("RocketLauncher"), weaponTransform.position, Quaternion.Euler(90, 0, 0));
        weapons[1].transform.parent = weaponTransform;

        weapons[2] = (GameObject)Instantiate(Resources.Load("railgun"), weaponTransform.position, Quaternion.Euler(90, 0, 0));
        weapons[2].transform.parent = weaponTransform;


		weapons[currentWeapon].SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Screen.lockCursor = true;
          //  Debug.Log(currentWeapon);
            weapons[currentWeapon].GetComponent<Weapon>().Fire();

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
			weapons[currentWeapon].SetActive(false);
            currentWeapon = mod(currentWeapon -1,weapons.Length);
			weapons[currentWeapon].SetActive(true);

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
			weapons[currentWeapon].SetActive(false);
			currentWeapon = mod(currentWeapon + 1, weapons.Length);
			weapons[currentWeapon].SetActive(true);

        }

        if (Input.GetButtonDown("Weapon1"))
        {
			weapons[currentWeapon].SetActive(false);
			currentWeapon = 0;
			weapons[currentWeapon].SetActive(true);

        }

        if (Input.GetButtonDown("Weapon2"))
        {
			weapons[currentWeapon].SetActive(false);
			currentWeapon = 1;
			weapons[currentWeapon].SetActive(true);
		}

        if (Input.GetButtonDown("Weapon3"))
        {
			weapons[currentWeapon].SetActive(false);
			currentWeapon = 2;
			weapons[currentWeapon].SetActive(true);
		}
    }

    int mod(int a, int n)
    {
        return ((a % n) + n) % n;
    }
}