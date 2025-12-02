using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public static class FormulasStorage
{
    public static Dictionary<string, Func<float, float, float, float, float>> FormulaStorage;
    public static Dictionary<string, Func<float?, float?, float?, bool>> CheckingsStorage;
    public static void Start()
    {
        FormulaStorage = new Dictionary<string, Func<float, float, float, float, float>>
        {
            { "Harpoon0", Level0 },
            { "Harpoon1", Level1 },
            { "Harpoon2", Level2},
            { "Harpoon3", Level3},
            { "Harpoon4", Level4},
            { "Harpoon5", Level5},
            { "Harpoon6", Level6},
            { "Harpoon7", Level7},
            { "Harpoon8", Level8},
            { "Harpoon9", Level9},
            { "Harpoon10", Level10},
            { "Harpoon11", Level11},
            { "Harpoon12", Level12},
        };
        CheckingsStorage = new Dictionary<string, Func<float?, float?, float?, bool>>
        {
            { "Harpoon0", CheckLevel0 },
            { "Harpoon1", CheckLevel1 },
            { "Harpoon2", CheckLevel2},
            { "Harpoon3", CheckLevel3},
            { "Harpoon4", CheckLevel4},
            { "Harpoon5", CheckLevel5},
            { "Harpoon6", CheckLevel6},
            { "Harpoon7", CheckLevel7},
            { "Harpoon8", CheckLevel8},
            { "Harpoon9", CheckLevel9},
            { "Harpoon10", CheckLevel10},
            { "Harpoon11", CheckLevel11},
            { "Harpoon12", CheckLevel12},
        };
    }

    public static float Level0(float x, float k, float b, float c) => (x * k) + b;

    public static bool CheckLevel0(float? k, float? b, float? c) => b < 5 && b > -5 && k < 40 && k > -40;
    public static float Level1(float x, float k, float b, float c)
    {
        float y = 1;
        for (int i = 0; i < k; i++)
        {
            y *= x;
        }
        return y + b;
    }

    public static bool CheckLevel1(float? k, float? b, float? c) => k >= 0 && b < 5 && b > -5 && k < 40;

    public static float Level2(float x, float k, float b, float c) => (b / Mathf.Pow(x, k)) + c;

    public static bool CheckLevel2(float? k, float? b, float? c) => k >= 0 && k < 40 && c > -5 && c < 5;

    public static float Level3(float x, float k, float b, float c) => MathF.Log(x + c, k) + b;
    public static bool CheckLevel3(float? k, float? b, float? c) => k > 0 && k != 1 && c >= 0 && b < 5 && b > -5;

    public static float Level4(float x, float k, float b, float c) => MathF.Pow(k, x) + b;
    public static bool CheckLevel4(float? k, float? b, float? c) => b < 5 && b > -5 && k > 0;

    public static float Level5(float x, float k, float b, float c) => k * Mathf.Sin(x) + b;
    public static bool CheckLevel5(float? k, float? b, float? c) => k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level6(float x, float k, float b, float c) => k * Mathf.Cos(x) + b;
    public static bool CheckLevel6(float? k, float? b, float? c) => k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level7(float x, float k, float b, float c) => k * Mathf.Tan(x) + b;
    public static bool CheckLevel7(float? k, float? b, float? c) => k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level8(float x, float k, float b, float c) => k * (1 / Mathf.Tan(x)) + b;
    public static bool CheckLevel8(float? k, float? b, float? c) => k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level9(float x, float k, float b, float c) => (k* Mathf.Asin(x / 2.5f) + b) * 1.5f;
    public static bool CheckLevel9(float? k, float? b, float? c) =>  k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level10(float x, float k, float b, float c) => (k* Mathf.Acos(x / 2.5f) + b) * 1.5f;
    public static bool CheckLevel10(float? k, float? b, float? c) =>  k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level11(float x, float k, float b, float c) => k * Mathf.Atan(x) + b;
    public static bool CheckLevel11(float? k, float? b, float? c) =>  k < 11 && k > -11 && b < 5 && b > -5;

    public static float Level12(float x, float k, float b, float c) => k * (Mathf.PI / 2 - Mathf.Atan(x)) + b;
    public static bool CheckLevel12(float? k, float? b, float? c) =>  k < 11 && k > -11 && b < 5 && b > -5;
}
