using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class ExternalPathScanner : EditorWindow
{
    [MenuItem("Tools/Scan for External Paths")]
    static void Scan()
    {
        string[] csFiles = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
        Regex pattern = new Regex(@"(file://|/Users/|C:\\|\.png|\.jpg|\.jpeg|\.wav|\.mp3|\.txt|\.json)", RegexOptions.IgnoreCase);

        foreach (string file in csFiles)
        {
            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i++)
            {
                Match match = pattern.Match(lines[i]);
                if (match.Success)
                {
                    string relativePath = "Assets" + file.Substring(Application.dataPath.Length).Replace("\\", "/");
                    Debug.Log($"[FOUND] {match.Value} in {relativePath} at line {i + 1}:\n    {lines[i]}");
                }
            }
        }

        Debug.Log("Scan complete.");
    }
}
