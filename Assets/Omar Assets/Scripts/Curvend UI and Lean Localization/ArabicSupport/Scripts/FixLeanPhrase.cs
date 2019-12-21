using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;
using Lean.Localization;
using System.Collections.Generic;
using UnityEditor;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FixLeanPhrase : MonoBehaviour
{
    [Multiline] public string text;
    protected LeanPhrase Target;
    public bool tashkeel = true;
    public bool hinduNumbers = true;

    private void Update()
    {
        //Target.Data = (LeanPhrase.DataType)GUILayout.Toolbar((int)Target.Data, new string[] { "Text", "Object", "Sprite" });

        //var entry = default(LeanPhrase.Entry);

        //if (Target.TryFindTranslation("arabic", ref entry) == true ||
        //    Target.TryFindTranslation("Arabic", ref entry) == true)
        //{
        //    entry.Text = ArabicFixer.Fix(text, tashkeel, hinduNumbers);
        //}
        //print("A7aaa");
        //ArabicFixer.Fix(text, tashkeel, hinduNumbers);

    }
    public string fixTheText()
    {

        return ArabicFixer.Fix(text, tashkeel, hinduNumbers);
    }
}

