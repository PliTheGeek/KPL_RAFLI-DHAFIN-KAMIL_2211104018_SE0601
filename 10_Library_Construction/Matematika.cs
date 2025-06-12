using System;
using System.Text;

namespace MatematikaLibraries
{
    public static class Matematika
    {
        public static int FPB(int input1, int input2)
        {
            while (input2 != 0)
            {
                int temp = input2;
                input2 = input1 % input2;
                input1 = temp;
            }
            return Math.Abs(input1);
        }

        public static int KPK(int input1, int input2)
        {
            return Math.Abs(input1 * input2) / FPB(input1, input2);
        }

        public static string Turunan(int[] persamaan)
        {
            if (persamaan == null || persamaan.Length < 2)
                return "0";

            StringBuilder sb = new StringBuilder();
            int degree = persamaan.Length - 1;
            for (int i = 0; i < persamaan.Length - 1; i++)
            {
                int coeff = persamaan[i] * (degree - i);
                if (coeff == 0) continue;

                if (sb.Length > 0)
                    sb.Append(coeff > 0 ? " + " : " - ");
                else if (coeff < 0)
                    sb.Append("-");

                int absCoeff = Math.Abs(coeff);
                if (absCoeff != 1 || degree - i - 1 == 0)
                    sb.Append(absCoeff);

                if (degree - i - 1 > 0)
                {
                    sb.Append("x");
                    if (degree - i - 1 > 1)
                        sb.Append(degree - i - 1);
                }
            }
            return sb.Length == 0 ? "0" : sb.ToString();
        }


        public static string Integral(int[] persamaan)
        {
            if (persamaan == null || persamaan.Length == 0)
                return "C";

            StringBuilder sb = new StringBuilder();
            int degree = persamaan.Length - 1;
            for (int i = 0; i < persamaan.Length; i++)
            {
                int newDegree = degree - i + 1;
                double coeff = (double)persamaan[i] / newDegree;
                if (coeff == 0) continue;

                if (sb.Length > 0)
                    sb.Append(coeff > 0 ? " + " : " - ");
                else if (coeff < 0)
                    sb.Append("-");

                double absCoeff = Math.Abs(coeff);
                if (absCoeff != 1 || newDegree == 0)
                    sb.Append(absCoeff % 1 == 0 ? ((int)absCoeff).ToString() : absCoeff.ToString("0.##"));

                if (newDegree > 0)
                {
                    sb.Append("x");
                    if (newDegree > 1)
                        sb.Append(newDegree);
                }
            }
            sb.Append(" + C");
            return sb.ToString();
        }



    }
}
