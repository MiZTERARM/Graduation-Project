using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class RadioButtonSystem : MonoBehaviour
{
    ToggleGroup toggleGroup;

    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();

    }
    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + "_" + toggle.GetComponentInChildren<Text>().text);
    }

}
