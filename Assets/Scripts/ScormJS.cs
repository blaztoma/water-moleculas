using UnityEngine;
using System.Runtime.InteropServices;

public class ScormJS : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void setAnswer(int number, int correct_nr, int answer_nr, string is_correct);

    [DllImport("__Internal")]
    private static extern void setScore();

    [DllImport("__Internal")]
    private static extern void saveScore();

    bool onetime0 = false;
    bool onetime1 = false;
    bool onetime2 = false;
    bool onetime3 = false;
    bool onetime4 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Guide (1) Correct") && !onetime0) {
            setAnswer(1, 1, 1, "true");
            saveScore();
            onetime0 = true;
        }

        if (GameObject.Find("Guide (2) Correct") && !onetime1) {
            setAnswer(2, 1, 1, "true");
            saveScore();
            onetime1 = true;
        }

        if (GameObject.Find("Guide (3) Correct") && !onetime2) {
            setAnswer(3, 1, 1, "true");
            saveScore();
            onetime2 = true;
        }

        if (GameObject.Find("Guide (4) Correct") && !onetime3) {
            setAnswer(4, 1, 1, "true");
            saveScore();
            onetime3 = true;
        }

        if (onetime0 && onetime1 && onetime2 && onetime3 && !onetime4) {
            setScore();
            onetime4 = true;
        }
    }
}
