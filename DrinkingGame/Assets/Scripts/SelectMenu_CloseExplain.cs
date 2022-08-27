using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu_CloseExplain : MonoBehaviour
{
    public GameObject ExplainMenu;

    public void CloseExplainMenu() {
        ExplainMenu.SetActive(false);
    }
}
