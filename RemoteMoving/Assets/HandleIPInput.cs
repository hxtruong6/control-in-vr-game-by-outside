using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleIPInput : MonoBehaviour
{
    public InputField IpInputField;

    public Button EditButton;
    public NetworkClientUI NetworkClientUi;

    // Start is called before the first frame update
    void Start()
    {
        IpInputField.gameObject.SetActive(false);
        EditButton.GetComponentInChildren<Text>().text = "Edit";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickEditButton()
    {
        if (EditButton.GetComponentInChildren<Text>().text == "OK")
        {
            EditButton.GetComponentInChildren<Text>().text = "Edit";
            IpInputField.gameObject.SetActive(false);
            NetworkClientUi.SERVER_HOST = IpInputField.text;
        }
        else
        {
            EditButton.GetComponentInChildren<Text>().text = "OK";
            IpInputField.gameObject.SetActive(true);
            IpInputField.text = NetworkClientUi.SERVER_HOST;
        }
    }
}