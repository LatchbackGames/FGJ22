using System.Collections;
using System.Collections.Generic;
using TMPro;
using TouchControlsKit;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject touchControls;
    public GameObject joyControls;
    public GameObject menuCanvas;
    public TCKButton menuButton;
    private bool touchEnabled;
    private bool menuEnabled;
    private Button toggleTouch;
    private Button startTouch;
    private Camera camera;
    void Start()
    {
        touchEnabled = false;
        toggleTouch = GameObject.Find("TouchToggle").GetComponent<Button>();
        toggleTouch.onClick.AddListener(SetActiveTouch);
        menuEnabled = true;
        startTouch = GameObject.Find("StartGame").GetComponent<Button>();
        startTouch.onClick.AddListener(ToggleMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (touchEnabled)
        {
            joyControls.GetComponent<TCKJoystick>().enabled = true;
            touchControls.SetActive(touchEnabled);
        }
        else
        {
            joyControls.GetComponent<TCKJoystick>().enabled = false;
            touchControls.SetActive(touchEnabled);
        }
        
        if (menuEnabled)
        {
            menuCanvas.SetActive(menuEnabled);
        }
        else
        {
            menuCanvas.SetActive(menuEnabled);
        }

        if (Input.GetKey(KeyCode.Escape) || menuButton.isDOWN)
        {
            ToggleMenu();
        }
        

    }
    
    void SetActiveTouch()
    {
        touchEnabled = !touchEnabled;
    }

    void ToggleMenu()
    {
        menuEnabled = !menuEnabled;
    }
}
