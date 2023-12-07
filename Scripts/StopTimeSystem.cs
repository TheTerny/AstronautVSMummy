using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTimeSystem : MonoBehaviour
{
    public float invincibilityDuration = 3f;  // ƒлительность неу€звимости в секундах
    public float slowMotionDuration = 3f;      // ƒлительность замедлени€ в секундах
    public float slowMotionFactor = 0.5f;      // ‘актор замедлени€

    public Button invincibilityButton;
    public Button slowMotionButton;

    public static bool invincibilityActive = false;
    private bool slowMotionActive = false;

    void Start()
    {
        invincibilityButton.onClick.AddListener(ActivateInvincibility);
        slowMotionButton.onClick.AddListener(ActivateSlowMotion);
    }

    void Update()
    {
        if (invincibilityActive)
        {
            invincibilityDuration -= Time.deltaTime;
            if (invincibilityDuration <= 0)
            {
                DeactivateInvincibility();
            }
        }

        if (slowMotionActive)
        {
            slowMotionDuration -= Time.deltaTime;
            if (slowMotionDuration <= 0)
            {
                DeactivateSlowMotion();
            }
        }
    }

    void ActivateInvincibility()
    {
        invincibilityActive = true;
        Destroy(invincibilityButton.gameObject);
    }

    void DeactivateInvincibility()
    {

        invincibilityActive = false;

    }

    void ActivateSlowMotion()
    {
        slowMotionActive = true;
        Time.timeScale = slowMotionFactor;
        Destroy(slowMotionButton.gameObject);
    }

    void DeactivateSlowMotion()
    {
        slowMotionActive = false;
        Time.timeScale = 1f;
    }
}
