﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/10 19:24
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Core.DefaultPlugins.Options;

#pragma warning disable 1591
namespace DG.Tweening.Plugins.Core.DefaultPlugins
{
    public class UintPlugin : ABSTweenPlugin<uint, uint, NoOptions>
    {
        public override uint ConvertT1toT2(NoOptions options, uint value)
        {
            return value;
        }

        public override uint GetRelativeEndValue(NoOptions options, uint startValue, uint changeValue)
        {
            return startValue + changeValue;
        }

        public override uint GetChangeValue(NoOptions options, uint startValue, uint endValue)
        {
            return endValue - startValue;
        }

        public override float GetSpeedBasedDuration(float unitsXSecond, uint changeValue)
        {
            float res = changeValue / unitsXSecond;
            if (res < 0) res = -res;
            return res;
        }

        public override uint Evaluate(NoOptions options, Tween t, bool isRelative, DOGetter<uint> getter, float elapsed, uint startValue, uint changeValue, float duration)
        {
            return (uint)Math.Round(EaseManager.Evaluate(t, elapsed, startValue, changeValue, duration, 0, 0));
        }
    }
}