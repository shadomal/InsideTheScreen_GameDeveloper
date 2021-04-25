using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCooldown : MonoBehaviour
{
    private float shoot, whip, playerSwitch;
    public float waitShoot, waitTimeWhip, waitPlayerSwitch;
    public bool shootAttackOn, switchOn, whipAttackOn;

    void Awake()
    {
        waitShoot = 3;
        waitTimeWhip = 3;
        waitPlayerSwitch = 5;
    }
    public void CoolDownWhip()
    {
        if (!whipAttackOn)
        {
            whip += waitTimeWhip * Time.deltaTime;
            if (waitTimeWhip >= whip)
            {
                whipAttackOn = true;
            }
        }

    }
    public void CoolDownShoot()
    {
        if (!shootAttackOn)
        {
            shoot += waitShoot * Time.deltaTime;
            if (shoot >= waitShoot)
            {
                shootAttackOn = true;
            }
        }
    }
    public void SwitchCoolDown()
    {
        if (!switchOn)
        {
            playerSwitch += waitPlayerSwitch * Time.deltaTime;
            if (playerSwitch >= waitPlayerSwitch)
            {
                switchOn = true;
            }
        }
    }
}
