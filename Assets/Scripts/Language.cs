using UnityEngine;
using TMPro;

public class Language : MonoBehaviour
{
    //language selected by the user
    public string language;

    //the audio clip that will be send
    private AudioClip[] clips = new AudioClip[4];

    //the audio clips by language
    public AudioClip[] LtClips = new AudioClip[4];
    public AudioClip[] EnClips = new AudioClip[4];
    public AudioClip[] FrClips = new AudioClip[4];

    //the strings that contain the instructions and informations
    private string[] instructions = new string[5];
    private string[] informations = new string[4];
    private string[] hologramTexts = new string[7];

    //gameobject that will be updated with selected language    
    public GameObject[] textInformations = new GameObject[4];
    public GameObject[] audioInformations = new GameObject[4];
    public GameObject[] hologramObjects = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {
        LoadPrefs();
        ChangeLanguage(language);
    }

    //saves the prefered language
    public void SavePrefs()
    {
        PlayerPrefs.SetString("Language", language);
        PlayerPrefs.Save();
    }
 
    //load the preferred language
    public void LoadPrefs()
    {
        language = PlayerPrefs.GetString("Language", "LT"); 
    }

    //Change the language and save the preferrence
    public void ChangeLanguage(string tmpLanguage)
    {
        language = tmpLanguage;
        SavePrefs();

        if (tmpLanguage == "LT") {
            Lithuanian();
        }

        if (tmpLanguage == "EN") {
            English();
        }

        if (tmpLanguage == "FR") {
            French();
        }

        replaceString();
    }

    //assign the right language to the strings
    private void Lithuanian() {
        instructions[0] = "Instrukcijos";
        instructions[1] = "Paimkite vandens molekulę ir uždėkite ją ant prietaiso.";
        instructions[2] = "Paimkite tuščią stiklinę ir pripildykite ją vandens pasinaudodami kriaukle.";
        instructions[3] = "Padėkite stiklinę su vandeniu ant įkaitusios plokštės ir pažiūrėkite, kas nutiks.";
        instructions[4] = "Padėkite stiklinę su vandeniu ant šaltos plokštės.";
        

        informations[0] = 
            //when putting the water molecule on the device
            "Kiekvienoje molekulėje yra du vandenilio ir vienas deguonies atomas, išdėstyti taip, kad viena molekulės pusė (esanti arčiau vandenilio atomų) yra teigiamai įkrauta, o kita pusė (esanti arčiau deguonies atomų) - neigiamai. Susilietus dviem vandens molekulėms, vienos jų teigiama pusė traukia kitos neigiamą pusę, todėl molekulės prilimpa viena prie kitos.";
        informations[1] =
            //when filling the glass with water using the sink
            "Kai ledas įšyla aukščiau nulio, jis ištirpsta ir tampa skystu vandeniu. Skystyje susilpnėja traukos jėgos tarp molekulių ir atskiros molekulės gali pradėti judėti viena aplink kitą. Kadangi molekulės gali slysti viena aplink kitą, vanduo įgauna indo, kuriame yra, formą.";
        informations[2] =
            //when putting the glass of water on the cold plate
            "Kai vanduo yra kietos būsenos (ledas), vandens molekulės yra glaudžiai sukibusios viena prie kitos ir negali keisti formos. Ledas yra labai taisyklingos struktūros, o molekulės yra standžiai sujungtos vandeniliniais ryšiais. Ledas susidaro, kai temperatūra yra žemesnė nei užšalimo (0 °Celsijaus).";
        informations[3] =
            //when putting the glass of water on the hot plate
            "Tai dujinė vandens būsena (vandens garai). Šioje būsenoje vandens molekulės juda labai greitai ir nėra susietos tarpusavy. Nors dujinėje būsenoje pačio vandens nematome, tačiau karštą ir drėgną dieną jį galime pajusti ore. Įprastai vanduo užverda 100 °C temperatūroje ir taip susidaro vandens garai.";

        hologramTexts[0] = "VANDUO";
        hologramTexts[1] = "VANDENILIS (H)";
        hologramTexts[2] = "VANDENILIS (H)";
        hologramTexts[3] = "DEGUONIS (O)";
        hologramTexts[4] = "Ledas";
        hologramTexts[5] = "Skystas Vanduo";
        hologramTexts[6] = "Vandens Garai";

        for (int i = 0; i < 4; i++)
        {
            clips[i] = LtClips[i];
        }
    }

    private void English() {
        instructions[0] = "INSTRUCTIONS";
        instructions[1] = "Grab the Water Molecule and put it on the device";
        instructions[2] = "Grab the empty glass and fill it with water. Use the sink";
        instructions[3] = "Put the glass of water on the hot plate and see what happens";
        instructions[4] = "Put the glass of water on the cold plate";
        

        informations[0] = 
            //when putting the water molecule on the device
            "Each molecule contains two atoms of hydrogen and one atom of oxygen, arranged such that one side of the molecule (nearest the hydrogens) is positively charged while the other side (nearest the oxygen) is negatively charged. If two water molecules come together, the positive side of one is attracted to the negative side of the other, making the molecules cling together.";
        informations[1] =
            //when filling the glass with water using the sink
            "When ice is warmed above freezing, it melts and becomes liquid water. As a liquid, the attractive forces between molecules weaken and individual molecules can begin to move around each other. Because the molecules can slip and slide around one another, water takes the shape of any container it is in";
        informations[2] =
            //when putting the glass of water on the cold plate
            "When water is in its solid state (ice), the water molecules are packed close together preventing it from changing shape. Ice has a very regular pattern with the molecules rigidly apart from one another connected by the hydrogen bonds. Ice forms when the temperature is below freezing (0°Celsius)";
        informations[3] =
            //when putting the glass of water on the hot plate
            "This is the gaseous state of water (water vapor). In this state, water molecules move very rapidly and are not bound together. Although we cannot see water in its gaseous state, we can feel it in the air on a hot, humid day. Commonly, water boils at a temperature of 100°C, forming water vapor";
        
        hologramTexts[0] = "WATER";
        hologramTexts[1] = "HYDROGEN (H)";
        hologramTexts[2] = "HYDROGEN (H)";
        hologramTexts[3] = "OXYGEN (O)";
        hologramTexts[4] = "Ice";
        hologramTexts[5] = "Liquid Water";
        hologramTexts[6] = "Vapor Water";

        for (int i = 0; i < 4; i++)
        {
            clips[i] = EnClips[i];
        }
    }

    private void French() {
        instructions[0] = "INSTRUCTIONS";
        instructions[1] = "Prends la molécule d'eau, et pose la sur l'appareil";
        instructions[2] = "Prends le verre vide et remplis le d'eau en utilisant le robinet";
        instructions[3] = "Mets le verre d'eau sur la plaque chauffante et regarde ce qu'il se passe";
        instructions[4] = "Mets le verre d'eau sur la plaque refroidissante";
        

        informations[0] = 
            //when putting the water molecule on the device
            "Chaque molécule contient deux atomes d'hydrogène et un atome d'oxygène, disposés de telle sorte qu'un côté de la molécule (celui des hydrogènes) est chargé positivement tandis que l'autre côté (celui de l'oxygène) est chargé négativement. Si deux molécules d'eau se rejoignent, le côté positif de l'une est attiré par le côté négatif de l'autre, ce qui fait que les molécules s'accrochent ensemble.";
        informations[1] =
            //when filling the glass with water using the sink
            "Lorsque la glace est réchauffée au-dessus du point de congélation, elle fond et devient de l'eau liquide. En tant que liquide, les forces d'attraction entre les molécules s'affaiblissent et les molécules individuelles peuvent commencer à se déplacer les unes autour des autres. Parce que les molécules peuvent glisser et glisser les unes autour des autres, l'eau prend la forme de n'importe quel récipient dans lequel elle se trouve.";
        informations[2] =
            //when putting the glass of water on the cold plate
            "Lorsque l'eau est à l'état solide (glace), les molécules d'eau sont serrées les unes contre les autres, ce qui l'empêche de changer de forme. La glace a un motif très régulier avec les molécules rigidement placées les unes des autres et reliées par les liaisons hydrogène. La glace se forme lorsque la température est inférieure au point de congélation (0°Celsius)";
        informations[3] =
            //when putting the glass of water on the hot plate
            "C'est l'état gazeux de l'eau (vapeur d'eau). Dans cet état, les molécules d'eau se déplacent très rapidement et ne sont pas liées entre elles. Bien que nous ne puissions pas voir l'eau à l'état gazeux, nous pouvons la sentir dans l'air par une journée chaude et humide. Généralement, l'eau bout à une température de 100 ° C, formant de la vapeur d'eau";
        
        hologramTexts[0] = "EAU";
        hologramTexts[1] = "HYDROGENE (H)";
        hologramTexts[2] = "HYDROGENE (H)";
        hologramTexts[3] = "OXYGENE (O)";
        hologramTexts[4] = "Glace";
        hologramTexts[5] = "Eau Liquide";
        hologramTexts[6] = "Vapeur d'eau";

        for (int i = 0; i < 4; i++)
        {
            clips[i] = FrClips[i];
        }
    }

    //replace the strings and audioClips by the translated ones
    private void replaceString() {
        TextMeshPro myText;
        AudioSource audio;

        GameObject[] textInstructions = new GameObject[5];
        GameObject[] textInstructionsCorrect = new GameObject[5];
        textInstructions[0] = GameObject.Find("INSTRUCTIONS");

        myText = textInstructions[0].GetComponent<TextMeshPro>();
        myText.SetText(instructions[0]);

        for (int i = 1; i < 5; i++)
        {
            string name = "Guide ("+i.ToString()+")";
            textInstructions[i] = GameObject.Find(name);

            myText = textInstructions[i].GetComponent<TextMeshPro>();
            myText.SetText(instructions[i]);
        }


        for (int i = 0; i < 4; i++)
        {
            myText = textInformations[i].GetComponent<TextMeshPro>();
            myText.SetText(informations[i]);

            audio = audioInformations[i].GetComponent<AudioSource>();
            audio.clip = clips[i];
        }

        for (int i = 0; i < 7; i++)
        {
            myText = hologramObjects[i].GetComponent<TextMeshPro>();
            myText.SetText(hologramTexts[i]);
        }
    }
}