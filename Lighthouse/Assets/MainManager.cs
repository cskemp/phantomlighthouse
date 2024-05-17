using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now
    // public const int TRIALS_PER_ILLUSION = 4;
    public const int TRIALS_PER_STAIRCASE = 2;
    public const int TRIALS_PER_ADJUST = 4;
    public const int TRIALS_PER_DEMO = 2;
    public const float CLICK_DELAY= 0.1f;
    public const int INFLECTIONS_PER_DEMO = 4;
    public const int INFLECTIONS_PER_ILLUSION = 6;
    public const int LIGHTHOUSE_HEIGHT= 30;

    public static MainManager Instance;
    public int sceneCounter;
    public int illusionCounter;
    public string illusionType;
    public bool Adjust;
    public GameObject illusionObject;

    [System.Serializable]   
    public class IllusionData
    {
        public string name;
        public int condition_number;
        public string[] illusions_base=  new string[9];
        public string[] illusions =  new string[9];
        public bool[] adjustFlag_base =  new bool[9];
        public bool[] adjustFlag=  new bool[9];
        public float[] demoInit;
        public float[] phantomInit; 
        public float[] bentBeamInit;
        public float[] bentBeamDepthInit;
        public List<Response> demoResponse= new List<Response>();
        public List<Response> phantomResponse= new List<Response>();
        public List<Response> bentBeamResponse= new List<Response>();
        public List<Response> bentBeamDepthResponse= new List<Response>();
        public List<Response> demoResponseAdj= new List<Response>();
        public List<Response> phantomResponseAdj= new List<Response>();
        public List<Response> bentBeamResponseAdj= new List<Response>();
        public List<Response> bentBeamDepthResponseAdj= new List<Response>();
        public List<Response> endResponse= new List<Response>();
    }

    [System.Serializable]
    public class Response
    {
        public float data;
        public float time;
    }

    public IllusionData IData = new IllusionData();
    public List<Response> currResponse;
    public List<Response>[] allResponse_base =  new List<Response>[9];
    public List<Response>[] allResponse=  new List<Response>[9];


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        illusionCounter = 0;
        sceneCounter = 0;
        Instance = this;
        DontDestroyOnLoad(gameObject);


        int[] p0 = {0,1,2,3,4,5,6,7,8};
        int[] p1 = {0,1,3,2,4,5,7,6,8};
        int[] p2 = {0,2,1,3,4,6,5,7,8};
        int[] p3 = {0,2,3,1,4,6,7,5,8};
        int[] p4 = {0,3,1,2,4,7,5,6,8};
        int[] p5 = {0,3,2,1,4,7,6,5,8};
        List<int[]> permutations = new List<int[]> { p0, p1, p2, p3, p4, p5 };

        IData.condition_number = Random.Range(0,6);
        int[] condition_perm = permutations[IData.condition_number];

        IData.name = "Lighthouse_staircase_nocue_v1_" + IData.condition_number + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss_PID_") + Random.Range(0, 100000).ToString();
        Debug.Log("IData.name: " + IData.name);
        IData.illusions_base[0] = "AdjustDemo"; 
        IData.illusions_base[1] = "Phantom"; 
        IData.illusions_base[2] = "BentBeam"; 
        IData.illusions_base[3] = "BentBeamDepth";
        IData.illusions_base[4] = "AdjustDemo";
        IData.illusions_base[5] = "Phantom"; 
        IData.illusions_base[6] = "BentBeam"; 
        IData.illusions_base[7] = "BentBeamDepth";
        IData.illusions_base[8] = "End"; // placeholder -- doesn't  need to be an actual scene

        allResponse_base[0] = IData.demoResponse;
        allResponse_base[1] = IData.phantomResponse;
        allResponse_base[2] = IData.bentBeamResponse;
        allResponse_base[3] = IData.bentBeamDepthResponse;
        allResponse_base[4] = IData.demoResponseAdj;
        allResponse_base[5] = IData.phantomResponseAdj;
        allResponse_base[6] = IData.bentBeamResponseAdj;
        allResponse_base[7] = IData.bentBeamDepthResponseAdj;
        allResponse_base[8] = IData.endResponse;

        // is this an adjustment scene?
        IData.adjustFlag_base[0] = false;
        IData.adjustFlag_base[1] = false;
        IData.adjustFlag_base[2] = false;
        IData.adjustFlag_base[3] = false;
        IData.adjustFlag_base[4] = true;
        IData.adjustFlag_base[5] = true;
        IData.adjustFlag_base[6] = true;
        IData.adjustFlag_base[7] = true;
        IData.adjustFlag_base[8] = true;

        for (int i = 0; i < condition_perm.Length; i++) 
        {
            IData.illusions[i] = IData.illusions_base[condition_perm[i]];
            allResponse[i] = allResponse_base[condition_perm[i]];
            IData.adjustFlag[i] = IData.adjustFlag_base[condition_perm[i]];
        }

        Debug.Log("condition_number: " + IData.condition_number);
        Debug.Log("condition_perm: " +  string.Join(", ", condition_perm));
        Debug.Log("illusions: " +  string.Join(", ", IData.illusions));
        Debug.Log("adjustFlag: " +  string.Join(", ", IData.adjustFlag));

        IData.demoInit = new float[] { 0.666f, 1.5f, 0.666f, 1.5f, 0.5f };
        // Older versions when we had 4 staircases
        //IData.phantomInit = new float[] { -30f, -150f, -50f, -130f, -70f};
        //IData.bentBeamInit = new float[] { -10f, 10f, -5f, 5f, -7f};
        //IData.bentBeamDepthInit = new float[] { 10f, -10f, 5f, -5f, -7f};

        IData.phantomInit = new float[] { -30f, -150f, -30f, -150f, -70f};
        IData.bentBeamInit = new float[] { -10f, 10f, -10f, 10f, -7f};
        IData.bentBeamDepthInit = new float[] { 10f, -10f, 10f, -10f, -7f};

        IData.demoInit = randomizeInit(IData.demoInit);
        IData.phantomInit= randomizeInit(IData.phantomInit);
        IData.bentBeamInit= randomizeInit(IData.bentBeamInit);
        IData.bentBeamDepthInit= randomizeInit(IData.bentBeamDepthInit);

        illusionType = IData.illusions[illusionCounter]; 
        currResponse = allResponse[illusionCounter];
        Adjust = IData.adjustFlag[illusionCounter];

        }

        // randomize order of initializations
        private float[] randomizeInit(float [] init)
        {
            if (Random.Range(0, 2) == 0) // swap the two up cases
            {
                float tmp = init[0];
                init[0] = init[2];
                init[2] = tmp;
            }
            if (Random.Range(0, 2) == 0) // swap the two down cases
            {
                float tmp = init[1];
                init[1] = init[3];
                init[3] = tmp;
            }
            if (Random.Range(0, 2) == 0) // exchange up cases with down cases
            {
                float tmp = init[0];
                init[0] = init[1];
                init[1] = tmp;
                tmp = init[2];
                init[2] = init[3];
                init[3] = tmp;
            }
            return(init);
        }
}
