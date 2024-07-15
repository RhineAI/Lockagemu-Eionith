using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUserName : MonoBehaviour
{
    public string playerName;
    public string playerBio;

    public TextMeshProUGUI playerNameText;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI playerBioText;
    public TMP_InputField playerBioInput;

    public Button nameChanger;
    public Button bioChanger;

    private bool isEditingName = false;
    private bool isEditingBio = false;

    void Start()
    {
        // Initialize the display text
        if (playerNameText != null)
        {
            playerNameText.text = playerName;
        }
        else
        {
            Debug.LogError("Player name text is not assigned.");
        }

        if (playerBioText != null)
        {
            playerBioText.text = playerBio;
        }
        else
        {
            Debug.LogError("Player bio text is not assigned.");
        }

        // Assign button click events
        if (nameChanger != null)
        {
            nameChanger.onClick.AddListener(ToggleEditName);
        }
        else
        {
            Debug.LogError("Name change button is not assigned.");
        }

        if (bioChanger != null)
        {
            bioChanger.onClick.AddListener(ToggleEditBio);
        }
        else
        {
            Debug.LogError("Bio change button is not assigned.");
        }

        // Hide the input fields initially
        if (playerNameInput != null)
        {
            playerNameInput.gameObject.SetActive(false);
        }

        if (playerBioInput != null)
        {
            playerBioInput.gameObject.SetActive(false);
        }
    }

    void ToggleEditName()
    {
        Debug.Log("ToggleEditName called");
        if (isEditingName)
        {
            Debug.Log("Ending name edit");
            // Save the edited name
            playerName = playerNameInput.text;
            playerNameText.text = playerName;
            playerNameText.gameObject.SetActive(true);
            playerNameInput.gameObject.SetActive(false);
            nameChanger.GetComponentInChildren<TextMeshProUGUI>().text = "Change";
        }
        else
        {
            Debug.Log("Starting name edit");
            // Switch to edit mode
            playerNameInput.text = playerName;
            playerNameText.gameObject.SetActive(false);
            playerNameInput.gameObject.SetActive(true);
            nameChanger.GetComponentInChildren<TextMeshProUGUI>().text = "Done";
        }
        isEditingName = !isEditingName;
    }

    void ToggleEditBio()
    {
        Debug.Log("ToggleEditBio called");
        if (isEditingBio)
        {
            Debug.Log("Ending bio edit");
            // Save the edited bio
            playerBio = playerBioInput.text;
            playerBioText.text = playerBio;
            playerBioText.gameObject.SetActive(true);
            playerBioInput.gameObject.SetActive(false);
            bioChanger.GetComponentInChildren<TextMeshProUGUI>().text = "Change";
        }
        else
        {
            Debug.Log("Starting bio edit");
            // Switch to edit mode
            playerBioInput.text = playerBio;
            playerBioText.gameObject.SetActive(false);
            playerBioInput.gameObject.SetActive(true);
            bioChanger.GetComponentInChildren<TextMeshProUGUI>().text = "Done";
        }
        isEditingBio = !isEditingBio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
