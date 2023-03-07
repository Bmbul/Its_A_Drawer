using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [Range(3, 4)]
    [SerializeField]
    float loadTime;
    [SerializeField]
    GameObject rules;
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject credits;
    [SerializeField]
    GameObject house;

    Animation[] animations;

    private void Awake()
    {
        animations = house.GetComponentsInChildren<Animation>();
    }
    public void LoadScene(string functionName)
    {
        Invoke(functionName, loadTime);
    }


    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ActivateRules()
    {
        rules.SetActive(true);
    }
    private void ActivateOptions()
    {
        options.SetActive(true);
    }
    private void ActivateCredits()
    {
        credits.SetActive(true);
    }

    public void OnBack()
    {
        foreach (var element in animations)
        {
            string animationName = element.clip.name;
            element[animationName].speed = -1f;
            element[animationName].time = element[animationName].length;
            element.Play();
        }
    }

    public void PlayAnimation()
    {
        foreach (var element in animations)
        {
            element[element.clip.name].speed = 1f;
            element.Play();
        }
    }
}
