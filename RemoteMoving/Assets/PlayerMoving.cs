using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMoving : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public float ThresholdTime = 0.5f;
    private float timeCount = 0;

    private bool jump = false;
    public Button JumpButton;

    void Start()
    {
        JumpButton.onClick.AddListener(onJumpClick);
    }

    void Update()
    {
        NetworkClientUI.SendJoystickInfo(variableJoystick.Vertical, variableJoystick.Horizontal, jump);

        timeCount += Time.deltaTime;
        if (timeCount > ThresholdTime)
        {
            timeCount = 0;
            jump = false;
        }
    }

    private void onJumpClick()
    {
        jump = true;
    }
}