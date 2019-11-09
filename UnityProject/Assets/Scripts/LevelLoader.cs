using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Button yourButton;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(LoadLevel);
	}

    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
