using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{
    private Image bubble;
    [SerializeField]private Text childText;


    private void Awake()
    {
        bubble = GetComponent<Image>();
        childText = GetComponentInChildren<Text>();
    }

    public void SetBubbleText(string input)
    {
        childText.text = "I want " + input;
    }

    public void SetBubbleVisibility(bool isEnabled)
    {
        bubble.enabled = isEnabled;
        childText.enabled = isEnabled;
    }

    public void Reset()
    {
        bubble.enabled = false;
        childText.enabled = false;
        childText.text = "";
    }
}