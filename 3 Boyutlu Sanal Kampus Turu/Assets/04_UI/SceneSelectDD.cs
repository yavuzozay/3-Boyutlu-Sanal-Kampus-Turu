
using UnityEngine;
using UnityEngine.UI;

public class SceneSelectDD : MonoBehaviour
{
   [SerializeField] private Dropdown dropdown;
    static int m_DropdownValue;
    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();

    }
    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });

    }
    void DropdownValueChanged(Dropdown change)
    {
        m_DropdownValue = change.value;
    }
 

}
