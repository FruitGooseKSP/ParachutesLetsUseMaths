using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ParachutesLetsUseMaths
{
    public class PlumUtilities
    {
        // Dictionaries that hold parachute effect factors for each planet/moon

        private Dictionary<int, double> bValsK = new Dictionary<int, double>();
        private Dictionary<int, double> bValsE = new Dictionary<int, double>();
        private Dictionary<int, double> bValsD = new Dictionary<int, double>();
        private Dictionary<int, double> bValsL = new Dictionary<int, double>();

        // main
        public PlumUtilities()
        {
            CreateDictionaryOfBValuesS();

        }

        // adds values to dictionaries
        private void CreateDictionaryOfBValuesS()
        {

            const double k0 = 0.0332;
            const double k1 = 0.0371;
            const double k2 = 0.0230;
            const double k3 = 1.3700;
            const double k4 = 1.2786;

            const double e0 = 0.0106;
            const double e1 = 0.0114;
            const double e2 = 0.0070;
            const double e3 = 0.4841;
            const double e4 = 0.3859;

            const double d0 = 0.0936;
            const double d1 = 0.1182;
            const double d2 = 0.0659;
            const double d3 = 3.7549;
            const double d4 = 3.3189;

            const double l0 = 0.0384;
            const double l1 = 0.0531;
            const double l2 = 0.0279;
            const double l3 = 1.7339;
            const double l4 = 1.5006;

            bValsK.Add(0, k0);
            bValsK.Add(1, k1);
            bValsK.Add(2, k2);
            bValsK.Add(3, k3);
            bValsK.Add(4, k4);

            bValsE.Add(0, e0);
            bValsE.Add(1, e1);
            bValsE.Add(2, e2);
            bValsE.Add(3, e3);
            bValsE.Add(4, e4);

            bValsD.Add(0, d0);
            bValsD.Add(1, d1);
            bValsD.Add(2, d2);
            bValsD.Add(3, d3);
            bValsD.Add(4, d4);

            bValsL.Add(0, l0);
            bValsL.Add(1, l1);
            bValsL.Add(2, l2);
            bValsL.Add(3, l3);
            bValsL.Add(4, l4);

        }

        public double BCodeBase(int planet, int chute)
        {
            // returns the chute power factor according to supplied planet/chute type

            switch (planet)
            {
                case 0:
                    return bValsK[chute];
                case 1:
                    return bValsE[chute];
                case 2:
                    return bValsD[chute];
                case 3:
                    return bValsL[chute];
                default:
                    return bValsK[chute];
            }


        }

        public string FetchATD(int selCode)
        {
            // returns the atmospheric pressure for the requested planet

            string bodyStr;

            switch (selCode)
            {
                case 0:
                    bodyStr = "101.325";
                    break;
                case 1:
                    bodyStr = "506.625";
                    break;
                case 2:
                    bodyStr = "6.75500";
                    break;
                case 3:
                    bodyStr = "60.7950";
                    break;
                default:
                    bodyStr = "101.325";
                    break;
            }

            return bodyStr;

        }

        public string FetchSG(int selCode)
        {
            // returns the surface gravity for the supplied planet

            string bodyStr;

            switch (selCode)
            {
                case 0:
                    bodyStr = "9.81";
                    break;
                case 1:
                    bodyStr = "16.7";
                    break;
                case 2:
                    bodyStr = "2.94";
                    break;
                case 3:
                    bodyStr = "7.85";
                    break;
                default:
                    bodyStr = "9.81";
                    break;
            }

            return bodyStr;


        }

        public float FetchDragDefault(int index)
        {
            switch (index)
            {
                case 0:
                    return 552.296f;
                case 1:
                    return 410.682f;
                case 2:
                    return 800.829f;
                case 3:
                    return 14.574f;
                case 4:
                    return 15.039f;
                default:
                    return 552.296f;

            }




        }

        public double GetMulti(int planet, int chute, int count)
        {
            // if there are multiple chutes, the formula is slightly different as there is a bonus for using radial chutes in symmetry.
            // this was originally calculated as a 1.5 bonus (as opposed to standard 1) however this doesn't work anymore/with enough accuracy.
            // As a compromise I've settled on 1.525 although this isn't 100% either. Unfortunately unless the offical details are released by
            // squad, it is near impossibe to calculate exactly.
            // To check whether radial chutes are in symmetry I've used a simple "is it divisable by 2" (ie an even number). This is of course
            // flawed as a player could technically put radial chutes in even numbers without being in symmetry but the hundreds of possibilites
            // aren't worth coding for the 1 in a million chance that might happen. Perhaps we could say the player is punished for such a ridiculous design!

            double toReturn;

            switch (planet)
            {
                case 0:
                    toReturn = chute == 0 || chute == 2 || chute == 3 ? count / bValsK[chute] : count % 2 == 0 ? Math.Pow(count, 1.525) / bValsK[chute] : count / bValsK[chute];
                    break;
                case 1:
                    toReturn = chute == 0 || chute == 2 || chute == 3 ? count / bValsE[chute] : count % 2 == 0 ? Math.Pow(count, 1.525) / bValsE[chute] : count / bValsE[chute];
                    break;
                case 2:
                    toReturn = chute == 0 || chute == 2 || chute == 3 ? count / bValsD[chute] : count % 2 == 0 ? Math.Pow(count, 1.525) / bValsD[chute] : count / bValsD[chute];
                    break;
                default:
                    toReturn = chute == 0 || chute == 2 || chute == 3 ? count / bValsL[chute] : count % 2 == 0 ? Math.Pow(count, 1.525) / bValsL[chute] : count / bValsL[chute];
                    break;

            }

            return toReturn;

        }


    }
}
