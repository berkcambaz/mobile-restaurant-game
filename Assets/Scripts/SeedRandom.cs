using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Globalization;

public class SeedRandom
{
    private System.Random random;

    public SeedRandom()
    {
        random = new System.Random(DateTime.Now.Millisecond.ToString().GetHashCode());
    }

    public int Number(int _minInclusive, int _maxExclusive)
    {
        return random.Next(_minInclusive, _maxExclusive);
    }
}
