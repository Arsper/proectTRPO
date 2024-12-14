using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public Slider SliderVolume;

    public Toggle ToggleLow;
    public Toggle ToggleMiddle;
    public Toggle ToggleHigh;

    public Toggle Filter;

    public GameObject OptionsObject;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Volume()
    {
        AudioListener.volume = SliderVolume.value; // ����������� �������� ������ ��������� �����
    }

    public void Graphics()
    {
        if (ToggleLow.isOn) { QualitySettings.currentLevel = QualityLevel.Fast; } // ������

        if (ToggleMiddle.isOn) { QualitySettings.currentLevel = QualityLevel.Simple; } // �������

        if (ToggleHigh.isOn) { QualitySettings.currentLevel = QualityLevel.Fantastic; } // �������

        //���� ������ ����������� ������ �� ������� �������� �� �� ������� ���� �������
    }

    public void Filtering()
    {
        if (Filter.isOn) { QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable; }
        else { QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;  }

        //���� ������ ������ �� � ������� ����������� ������
    }

    public void CloseButton()
    {
        OptionsObject.SetActive(false);
    }
}
