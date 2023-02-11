using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class title : MonoBehaviour
{
    // ���
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject roadPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject fadePanel;

    // ��ʊǗ�
    private int SCENE_NUM = 0;

    // �t�F�[�h�A�E�g
    Image fadealpha;
    private float alpha;
    private bool fadeflag = false;

    // Start is called before the first frame update
    void Start()
    {
        titlePanel.SetActive(true);

        // �t�F�[�h
        fadealpha = fadePanel.GetComponent<Image>();
        alpha = fadealpha.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �^�C�g����ʊ֐�
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

    // ���[�h��ʊ֐�
    public void roadback()
    {
        SCENE_NUM = 0;
        roadPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
    // �ݒ��ʊ֐�
    public void settingsback()
    {
        SCENE_NUM = 0;
        settingsPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
    // �I����ʊ֐�
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
