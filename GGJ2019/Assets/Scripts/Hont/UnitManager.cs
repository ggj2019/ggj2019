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


    void Awake()
    {
        mInstance = this;

        if(!mInit)
        {
            Shuffle(totalUnit.units);

            mStayHomeUnits = totalUnit.units.Take(4).ToArray();
            mLeaveHomeUnits = totalUnit.units.Skip(4).ToArray();

            mInit = true;
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
