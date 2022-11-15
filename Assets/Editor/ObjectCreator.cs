using System;
using Types;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class ObjectCreator : EditorWindow
{
    private Texture2D headerSectionTexture;
    private Texture2D mageSectionTexture;
    private Texture2D warriorSectionTexture;
    private Texture2D rougeSectionTexture;
    public static Texture2D mageTexture;
    public static Texture2D warriorTexture;
    public static Texture2D rougeTexture;

    private Color headerSectionColor = new Color(155f / 255f, 155f / 255f, 197f / 255f, 1);

    private Rect headerSection;
    private Rect mageSection;
    private Rect warriorSection;
    private Rect rougeSection;
    private Rect mageIconSection;
    private Rect warriorIconSection;
    private Rect rougeIconSection;
    

    public static GUISkin guiSkin;

    private static MageData mageData;
    private static WarrierData warrierData;
    private static RogueData RogueData;
    
    public static MageData MageInfo { get { return mageData; }}
    public static WarrierData WarriorInfo { get { return warrierData; }}
    public static RogueData RogueInfo { get { return RogueData; }}

    private static GUILayout mageLabel;

    public static float iconSize = 20;
    
    [MenuItem("Tools/Object Creater")]
    static void OpenWindow()
    {
        ObjectCreator window = (ObjectCreator)GetWindow(typeof(ObjectCreator));
        window.minSize = new Vector2(400, 200);
        window.Show();
    }

    /// <summary>
    /// Similar to Start() or Awake()
    /// </summary>
    private void OnEnable()
    {
        InitTextures();
        InitData();
        guiSkin = Resources.Load<GUISkin>("CharacterData/GUIStyles/EnemyDesignerSkin");
    }

    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        warrierData = (WarrierData)ScriptableObject.CreateInstance(typeof(WarrierData));
        RogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
    }
    
    /// <summary>
    /// Initialize Texture2D values
    /// </summary>
    private void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("Icons/11");
        warriorSectionTexture = Resources.Load<Texture2D>("Icons/10");
        rougeSectionTexture = Resources.Load<Texture2D>("Icons/13");

        mageTexture = Resources.Load<Texture2D>("Icons/1");
        warriorTexture = Resources.Load<Texture2D>("Icons/2");
        rougeTexture = Resources.Load<Texture2D>("Icons/3");
    }

    /// <summary>
    /// Similar to any Update function,
    /// Not called once per frame. Called 1 or more times per interaction.
    /// </summary>
    private void OnGUI()
    {
        DrawLayouts();
        Drawheader();
        DrawMageSettins();
        DrawRogueSettings();
        DrawWarriorSettings();
    }
    
    /// <summary>
    /// Defines Rect values and paints textures based on Rects
    /// </summary>
    private void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;
        
        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width / 3f;
        mageSection.height = Screen.width / 3f * 21 / 9;

        mageIconSection.x = mageSection.x + iconSize / 2f;
        mageIconSection.y = mageSection.y + 8;
        mageIconSection.width = mageIconSection.height = iconSize;
        
        warriorSection.x = Screen.width / 3f;
        warriorSection.y = 50;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.width / 3f * 21 / 9;
        
        warriorIconSection.x = warriorSection.x + iconSize / 2f;
        warriorIconSection.y = warriorSection.y + 8;
        warriorIconSection.width = warriorIconSection.height = iconSize;
        
        rougeSection.x = Screen.width / 3f * 2;
        rougeSection.y = 50;
        rougeSection.width = Screen.width / 3f;
        rougeSection.height = Screen.width / 3f * 21 / 9;
        
        rougeIconSection.x = rougeSection.x + iconSize / 2f;
        rougeIconSection.y = rougeSection.y + 8;
        rougeIconSection.width = rougeIconSection.height = iconSize;
        
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(rougeSection, rougeSectionTexture);
        GUI.DrawTexture(mageIconSection, mageTexture);
        GUI.DrawTexture(warriorIconSection, warriorTexture);
        GUI.DrawTexture(rougeIconSection, rougeTexture);
    }

    /// <summary>
    /// Draw contents of header
    /// </summary>
    private void Drawheader()
    {
        GUILayout.BeginArea(headerSection);
        
        GUILayout.Label("Enemy Designer", guiSkin.GetStyle("Header1"));
        
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of Mage region
    /// </summary>
    private void DrawMageSettins()
    {
        GUILayout.BeginArea(mageSection);
        
        GUILayout.Space(iconSize / 2f);
        GUILayout.Label("Mage", guiSkin.GetStyle("MageHeader"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage", guiSkin.GetStyle("MageField"));
        mageData.mageDamageType = (MageDamageType)EditorGUILayout.EnumPopup(mageData.mageDamageType, guiSkin.box);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", guiSkin.GetStyle("MageField"));
        mageData.mageWeaponType = (MageWeaponType)EditorGUILayout.EnumPopup(mageData.mageWeaponType, guiSkin.box);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", guiSkin.button))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Mage);
        }
        
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of Warrior region
    /// </summary>
    private void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);
        
        GUILayout.Space(iconSize / 2f);
        GUILayout.Label("Warrior", guiSkin.GetStyle("MageHeader"));
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Class", guiSkin.GetStyle("MageField"));
        warrierData.warriorClassType = (WarriorClassType)EditorGUILayout.EnumPopup(warrierData.warriorClassType, guiSkin.box);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", guiSkin.GetStyle("MageField"));
        warrierData.warriorWeaponType = (WarriorWeaponType)EditorGUILayout.EnumPopup(warrierData.warriorWeaponType, guiSkin.box);
        EditorGUILayout.EndHorizontal();
        
        if (GUILayout.Button("Create!", guiSkin.button))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Warrior);
        }
        
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of Rouge region
    /// </summary>
    private void DrawRogueSettings()
    {
        GUILayout.BeginArea(rougeSection);
        
        GUILayout.Space(iconSize / 2f);
        GUILayout.Label("Rogue", guiSkin.GetStyle("MageHeader"));
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Strategy", guiSkin.GetStyle("MageField"));
        RogueData.rogueStrategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(RogueData.rogueStrategyType, guiSkin.box);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", guiSkin.GetStyle("MageField"));
        RogueData.rogueWeaponType = (RogueWeaponType)EditorGUILayout.EnumPopup(RogueData.rogueWeaponType, guiSkin.box);
        EditorGUILayout.EndHorizontal();
        
        if (GUILayout.Button("Create!", guiSkin.button))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Rouge);
        }
        
        GUILayout.EndArea();
    }
}

public class GeneralSettings : EditorWindow
{
    public enum SettingsType
    {
        Mage,
        Warrior,
        Rouge
    }

    private static SettingsType dataSettings;
    private static GeneralSettings window;

    private Rect iconSection;
    private Rect backgroundSection;

    private Texture2D backgroundTexture;

    public static void OpenWindow(SettingsType settingsType)
    {
        dataSettings = settingsType;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 150);
        window.Show();
    }

    private void OnEnable()
    {
        backgroundTexture = Resources.Load<Texture2D>("Icons/12");
    }

    private void OnGUI()
    {
        DrawBackGround();
        switch (dataSettings)
        {
            case SettingsType.Mage:
                DrawSettings(ObjectCreator.MageInfo);
                DrawIcon(ObjectCreator.mageTexture);
                break;
            case SettingsType.Warrior:
                DrawSettings(ObjectCreator.WarriorInfo);
                DrawIcon(ObjectCreator.warriorTexture);
                break;
            case SettingsType.Rouge:
                DrawSettings(ObjectCreator.RogueInfo);
                DrawIcon(ObjectCreator.rougeTexture);
                break;
        }
    }

    private void DrawIcon(Texture2D texture2D)
    {
        iconSection.x = ObjectCreator.iconSize / 2f;
        
        iconSection.width = iconSection.height = ObjectCreator.iconSize;
        
        GUI.DrawTexture(iconSection, texture2D);
    }

    private void DrawBackGround()
    {
        backgroundSection.x = 0;
        backgroundSection.y = 0;
        backgroundSection.width = Screen.width;
        backgroundSection.height = backgroundSection.width / 9 * 21;
        
        GUI.DrawTexture(backgroundSection, backgroundTexture);
    }

    private void DrawSettings(CharacterData characterData)
    {
        GUILayout.Label(characterData.ToString(), ObjectCreator.guiSkin.GetStyle("MageHeader"));
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab", ObjectCreator.guiSkin.GetStyle("MageField"));
        characterData.prefab = (GameObject)EditorGUILayout.ObjectField(characterData.prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health", ObjectCreator.guiSkin.GetStyle("MageField"));
        characterData.maxHealth = EditorGUILayout.FloatField(characterData.maxHealth);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Energy", ObjectCreator.guiSkin.GetStyle("MageField"));
        characterData.maxEnergy = EditorGUILayout.FloatField(characterData.maxEnergy);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power", ObjectCreator.guiSkin.GetStyle("MageField"));
        characterData.power = EditorGUILayout.Slider(characterData.power, 0, 100);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Percent Crit Chance", ObjectCreator.guiSkin.GetStyle("MageField"));
        characterData.critChance = EditorGUILayout.Slider(characterData.critChance, 0, characterData.power);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Object Name", ObjectCreator.guiSkin.GetStyle("MageField"));
        characterData.Objectname = EditorGUILayout.TextArea(characterData.Objectname);
        EditorGUILayout.EndHorizontal();

        if (characterData.prefab == null)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created.", MessageType.Error);
        }
        else if (characterData.Objectname == null || characterData.Objectname.Length < 1)
        {
            EditorGUILayout.HelpBox("This enemy need to be Objectnamed in [Objectname].", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", ObjectCreator.guiSkin.GetStyle("BoxCustom")))
        {
            SaveCharacterData();
            window.Close();
        }
    }

    private void SaveCharacterData()
    {
        string prefabPath;
        string newPrefabPath = "Assets/Prefabs/Characters/";
        string dataPath = "Assets/Resources/CharacterData/Data/";
        
        switch (dataSettings)
        {
            case SettingsType.Mage:
                
                // Create the .asset file
                dataPath += "Mage/" + ObjectCreator.MageInfo.Objectname + ".asset";
                AssetDatabase.CreateAsset(ObjectCreator.MageInfo, dataPath);

                newPrefabPath += "Mage/" + ObjectCreator.MageInfo.Objectname + ".prefab";
                // Get prefab path
                prefabPath = AssetDatabase.GetAssetPath(ObjectCreator.MageInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!magePrefab.GetComponent<Mage>())
                {
                    magePrefab.AddComponent(typeof(Mage));
                    magePrefab.GetComponent<Mage>().mageData = ObjectCreator.MageInfo;
                }

                break;
            case SettingsType.Warrior:

                // Create the .asset file
                dataPath += "Warrior/" + ObjectCreator.WarriorInfo.Objectname + ".asset";
                AssetDatabase.CreateAsset(ObjectCreator.WarriorInfo, dataPath);

                newPrefabPath += "Warrior/" + ObjectCreator.WarriorInfo.Objectname + ".prefab";
                // Get prefab path
                prefabPath = AssetDatabase.GetAssetPath(ObjectCreator.WarriorInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!warriorPrefab.GetComponent<Warrier>())
                {
                    warriorPrefab.AddComponent(typeof(Warrier));
                    warriorPrefab.GetComponent<Warrier>().warrierData = ObjectCreator.WarriorInfo;
                }
                
                break;
            case SettingsType.Rouge:

                // Create the .asset file
                dataPath += "Rouge/" + ObjectCreator.RogueInfo.Objectname + ".asset";
                AssetDatabase.CreateAsset(ObjectCreator.RogueInfo, dataPath);

                newPrefabPath += "Rouge/" + ObjectCreator.RogueInfo.Objectname + ".prefab";
                // Get prefab path
                prefabPath = AssetDatabase.GetAssetPath(ObjectCreator.RogueInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject rougePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!rougePrefab.GetComponent<Rogue>())
                {
                    rougePrefab.AddComponent(typeof(Rogue));
                    rougePrefab.GetComponent<Rogue>().rogueData = ObjectCreator.RogueInfo;
                }
                
                break;
        }
    }
}