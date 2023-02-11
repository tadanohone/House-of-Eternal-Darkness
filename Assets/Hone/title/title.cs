using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class title : MonoBehaviour
{
    // 画面
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject roadPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject fadePanel;

    // 画面管理
    private int SCENE_NUM = 0;

    // フェードアウト
    Image fadealpha;
    private float alpha;
    private bool fadeflag = false;

    // Start is called before the first frame update
    void Start()
    {
        titlePanel.SetActive(true);

        // フェード
        fadealpha = fadePanel.GetComponent<Image>();
        alpha = fadealpha.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // タイトル画面関数
    public void start()
    {
        fadePanel.SetActive(true);
        StartCoroutine("Fade");
    }

    public void road()
    {
        SCENE_NUM = 1;
        titlePanel.SetActive(false);
        roadPanel.SetActive(true);
    }

    public void settings()
    {
        SCENE_NUM = 2;
        titlePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void exit()
    {
        SCENE_NUM = 3;
        exitPanel.SetActive(true);
    }

    IEnumerator Fade()
    {
        alpha += 0.01f;

        yield return new WaitForSeconds(0.005f);

        fadealpha.color = new Color(0, 0, 0, alpha);

        if(alpha <= 1)
        {
            StartCoroutine("Fade");
        }else
        {
            Debug.Log("end");
            SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
        }
    }

    // ロード画面関数
    public void roadback()
    {
        SCENE_NUM = 0;
        roadPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
    // 設定画面関数
    public void settingsback()
    {
        SCENE_NUM = 0;
        settingsPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
    // 終了画面関数
    public void exitback()
    {
        SCENE_NUM = 0;
        exitPanel.SetActive(false);
    }

    public void exittrue()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
