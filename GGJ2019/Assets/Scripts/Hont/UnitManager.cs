using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    static bool mInit;

    static UnitManager mInstance;
    public static UnitManager Instance { get { return mInstance; } }

    public ListSO totalUnit;

    static UnitSO[] mStayHomeUnits;
    static UnitSO[] mLeaveHomeUnits;

    public UnitSO[] StayHomeUnits { get { return mStayHomeUnits; } }
    public UnitSO[] LeaveHomeUnits { get { return mLeaveHomeUnits; } }

    //static public bool spawnLeave;


    public bool isDirty;

    void Awake()
    {
        mInstance = this;

        if(!mInit)
        {
            Shuffle(totalUnit.units);

            mStayHomeUnits = totalUnit.units.Take(3).ToArray();
            mLeaveHomeUnits = totalUnit.units.Skip(3).ToArray();

            mLeaveHomeUnits[0].unitStatus = UnitStatus.Empty;
            mLeaveHomeUnits[1].unitStatus = UnitStatus.Empty;
            mLeaveHomeUnits[2].unitStatus = UnitStatus.Empty;

            //Debug.Log(mLeaveHomeUnits[0].objName +" "+ mLeaveHomeUnits[1].objName);

            mStayHomeUnits[0].unitStatus = UnitStatus.People;
            mStayHomeUnits[1].unitStatus = UnitStatus.People;
            mStayHomeUnits[2].unitStatus = UnitStatus.People;

            mInit = true;
            isDirty = true;
            //spawnLeave = false;
        }
    }

    void Shuffle<TSource>(IList<TSource> source)
    {
        for (int i = 0, iMax = source.Count; i < iMax; i++)
        {
            var randomIndex = Random.Range(0, iMax);

            var temp = source[i];
            var dst = source[randomIndex];
            source[i] = dst;
            source[randomIndex] = temp;
        }
    }
}
