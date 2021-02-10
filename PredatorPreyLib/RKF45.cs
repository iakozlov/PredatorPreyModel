using System;
using System.Collections.Generic;

namespace PredatorPreyLib
{
    public static class RKF45
    {
        const int NEQ = 3;//длина массива с популяциями(число уравнений + 1)
        public static double R { get; set; } = 2000.0; // максимальное число жертв
        public static double a { get; set; }
        static double[] y = new double[NEQ];
        public static List<double> time { get; set; } = new List<double>();
        public static List<double> preys { get; set; } = new List<double>();
        public static List<double> predators { get; set; } = new List<double>();
        private static double[] w1, w3, w4, w5, w6, w7;
        private static double
   w2, w8, w9;
        private static int iw1, iw2, iw3, iw4, iw5;

        /// <summary>
        /// Вычисляет правые части дифференциальных уравнений
        /// </summary>
        /// <param name="t"></param>
        /// <param name="y"></param>
        /// <param name="yp"></param>
        unsafe static void f(double t, double[] y, double[] yp)
        {
            // y[1] - число жертв, y[2] - число хищников
            yp[1] = 2.0 * (1.0 - y[1] / R) * y[1] - a * y[1] * y[2];
            yp[2] = -y[2] + a * y[1] * y[2];
        }

        /// <summary>
        /// Интегрирует систему из двух обыкновенных дифференциальных уравнений,
        /// где начальные значения и начальные производные заданы в некоторой начальной точке t
        /// </summary>
        /// <param name="neqn"></param>
        /// <param name="y"></param>
        /// <param name="t"></param>
        /// <param name="h"></param>
        /// <param name="yp"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        /// <param name="f4"></param>
        /// <param name="f5"></param>
        /// <param name="s"></param>
        unsafe static void fehl(int neqn, double[] y, ref double t, double h, double[] yp,
          double[] f1, double[] f2, double[] f3, double[] f4, double[] f5, double[] s)
        {
            double ch;
            int i;
            ch = h / 4.0;
            for (i = 1; i < NEQ; i++)
                f5[i] = y[i] + ch * yp[i];
            f(t + ch, f5, f1);
            ch = 3.0 * (h) / 32.0;
            for (i = 1; i < NEQ; i++)
                f5[i] = y[i] + ch * (yp[i] + 3.0 * f1[i]);
            f(t + 3.0 * (h) / 8.0, f5, f2);
            ch = h / 2197.0;
            for (i = 1; i < NEQ; i++)
                f5[i] = y[i] + ch * (1932.0 * yp[i]
                                    + (7296.0 * f2[i]
                                     - 7200.0 * f1[i]));
            f(t + 12.0 * (h) / 13.0, f5, f3);
            ch = h / 4104.0;
            for (i = 1; i < NEQ; i++)
                f5[i] = y[i] + ch * ((8341.0 * yp[i]
                                      - 845.0 * f3[i])
                                      + (29440.0 * f2[i]
                                      - 32832.0 * f1[i]));
            f(t + h, f5, f4);
            ch = h / 20520.0;
            for (i = 1; i < NEQ; i++)
                f1[i] = y[i] + ch * ((-6080.0 * yp[i]
                                      + (9295.0 * f3[i]
                                       - 5643.0 * f4[i]))
                                      + (41040.0 * f1[i]
                                       - 28352.0 * f2[i]));
            f(t + h / 2.0, f1, f5);
            // Можно совершить следующий шаг
            ch = h / 7618050.0;
            for (i = 1; i < NEQ; i++)
                s[i] = y[i] + ch * ((902880.0 * yp[i]
                                    + (3855735.0 * f3[i]
                                     - 1371249.0 * f4[i]))
                                    + (3953664.0 * f2[i]
                                      + 277020.0 * f5[i]));
        }

        /// <summary>
        /// Совершает очередной шаг интегрирования
        /// </summary>
        /// <param name="neqn"></param>
        /// <param name="y"></param>
        /// <param name="t"></param>
        /// <param name="tout"></param>
        /// <param name="relerr"></param>
        /// <param name="abserr"></param>
        /// <param name="iflag"></param>
        unsafe static void rkf45(int neqn, double[] y, ref double t, double tout, double relerr, double abserr,
           int* iflag)
        {

            iw1 = default;
            iw2 = default;
            iw3 = default;
            iw4 = 0;
            iw5 = 0;
            w1 = new double[NEQ];
            w2 = default;
            w3 = new double[NEQ];
            w4 = new double[NEQ];
            w5 = new double[NEQ];
            w6 = new double[NEQ];
            w7 = new double[NEQ];
            w8 = default;
            w9 = default;
            rkfs(neqn, y, ref t, ref tout, relerr, abserr, iflag,
    w1, w2, w3, w4, w5, w6, w7, w8, w9,
    iw1, iw2, iw3, iw4, iw5);
        }

        /// <summary>
        /// Интегрирует систему из двух обыкновенных дифференциальных уравнений первого порядка
        /// </summary>
        /// <param name="neqn"></param>
        /// <param name="y"></param>
        /// <param name="t"></param>
        /// <param name="tout"></param>
        /// <param name="relerr"></param>
        /// <param name="abserr"></param>
        /// <param name="iflag"></param>
        /// <param name="yp"></param>
        /// <param name="h"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        /// <param name="f4"></param>
        /// <param name="f5"></param>
        /// <param name="savre"></param>
        /// <param name="savae"></param>
        /// <param name="nfe"></param>
        /// <param name="kop"></param>
        /// <param name="init"></param>
        /// <param name="jflag"></param>
        /// <param name="kflag"></param>
        unsafe static void rkfs(int neqn, double[] y, ref double t, ref double tout, double relerr, double abserr,
          int* iflag, double[] yp, double h, double[] f1, double[] f2, double[] f3,
      double[] f4, double[] f5, double savre, double savae, int nfe, int kop,
      int init, int jflag, int kflag)
        {
            double remin = 1e-12;
            int maxnfe = 3000;
            double a, ae, dt, ee, eeoet, eps, epsp1, esttol, et, hmin, rer,
                 s, scale, tol, toln, ypk;
            bool hfaild, output;
            int i, k, mflag;
            eps = 0.0;

            // Проверка введённых параметров

            if (neqn < 1)
                goto l10;

            if (relerr < 0.0 || abserr < 0.0)
                goto l10;

            mflag = Math.Abs(*iflag);

            if (mflag == 0 || mflag > 8)
                goto l10;

            if (mflag != 1)
                goto l20;

            l5:
            eps /= 2.0;
            epsp1 = eps + 1.0;
            if (epsp1 > 1.0)
                goto l5;

            goto e50;


        l10:
            *iflag = 8;
            return;

        l20:
            if (t == tout && kflag != 3)
                goto l10;

            if (mflag != 2)
                goto e25;


            if (kflag == 3 || init == 0)
                goto e45;

            if (kflag == 4)
                goto e40;

            if (kflag == 5 && abserr == 0.0)
                goto l30;

            if (kflag == 6 && relerr <= savre && abserr <= savae)
                goto l30;

            goto e50;

        // iflag = 3,4,5,6,7 или 8

        e25:
            if (*iflag == 3)
                goto e45;

            if (*iflag == 4)
                goto e40;

            if (*iflag == 5 && abserr > 0.0)
                goto e45;

            l30:
            return;

        // Сброс счётчика оценивания функции

        e40:
            nfe = 0;
            if (mflag == 2)
                goto e50;

            //Сброс значения флага прошлого вызова

            e45:
            *iflag = jflag;
            if (kflag == 3)
                mflag = Math.Abs(*iflag);

            e50:
            jflag = *iflag;
            kflag = 0;

            // Сохранение relerr and abserr для проверки ввода в последующих вызовах

            savre = relerr;
            savae = abserr;
            rer = 2.0 * eps + remin;

            if (relerr >= rer)
                goto l55;

            relerr = rer;
            *iflag = 3;
            kflag = 3;
            return;

        l55:
            dt = tout - t;

            if (mflag == 1)
                goto e60;

            if (init == 0)
                goto e65;

            goto e80;

        e60:
            init = 0;
            kop = 0;
            a = t;
            unsafe
            {
                f(a, y, yp);
            }
            nfe = 1;

            if (t != tout)
                goto e65;

            *iflag = 2;
            return;

        e65:
            init = 1;
            h = Math.Abs(dt);
            toln = 0.0;
            for (k = 1; k < NEQ; k++)
            {
                tol = relerr * Math.Abs(y[k]) + abserr;
                if (tol <= 0.0)
                    continue; // goto l70;
                toln = tol;
                ypk = Math.Abs(yp[k]);
                if (ypk * Math.Pow(h, 5) > tol)
                    h = Math.Pow((tol / ypk), 0.2);
            }
            if (toln <= 0.0)
                h = 0.0;
            h = Max(h, 26.0 * eps * Max(Math.Abs(t), Math.Abs(dt)));
            jflag = ISign(2, *iflag);

        // Установка разера шага интегрирования в направлении от t к tout

        e80:
            h = Sign(h, dt);

            if (Math.Abs(h) >= 2.0 * Math.Abs(dt))
                kop = kop + 1;

            if (kop != 100)
                goto l85;

            kop = 0;
            *iflag = 7;
            return;

        l85:
            if (Math.Abs(dt) >= 26.0 * eps * Math.Abs(t))
                goto l95;

            for (i = 1; i <= neqn; i++)
                y[i] = y[i] + dt * yp[i];

            a = tout;
            f(a, y, yp);
            nfe += 1;
            goto l300;

        // Инициализация индикатора точки вывода

        l95:
            output = false;

            scale = 2.0 / relerr;
            ae = scale * abserr;

        // Интегрирование по шагам

        e100:
            hfaild = false;

            // установить наименьший возможный шаг

            hmin = 26.0 * eps * Math.Abs(t);

            dt = tout - t;

            if (Math.Abs(dt) >= 2.0 * Math.Abs(h))
                goto e200;

            // Слудующий успешный шаг интегрирования приведёт к точке вывода

            if (Math.Abs(dt) > Math.Abs(h))
                goto l150;

            output = true;
            h = dt;
            goto e200;

        l150:
            h = 0.5 * dt;

        e200:
            if (nfe <= maxnfe)
                goto l220;

            *iflag = 4;
            kflag = 4;
            return;

        l220:
            fehl(neqn, y, ref t, h, yp, f1, f2, f3, f4, f5, f1);
            nfe += 5;

            eeoet = 0.0;

            for (k = 1; k < NEQ; k++)
            {
                et = Math.Abs(y[k]) + Math.Abs(f1[k]) + ae;

                if (et > 0.0)
                    goto l240;

                *iflag = 5;
                return;

            l240:
                ee = Math.Abs((-2090.0 * yp[k]
                          + (21970.0 * f3[k]
                           - 15048.0 * f4[k]))
                          + (22528.0 * f2[k]
                           - 27360.0 * f5[k]));
                eeoet = Max(eeoet, ee / et);
            }

            esttol = Math.Abs(h) * eeoet * scale / 752400.0;
            if (esttol <= 1.0)
                goto e260;

            // Неудачный шаг. Нужно уменьшить размер шага

            hfaild = true;
            output = false;

            s = 0.1;
            if (esttol < 59049.0)
                s = 0.9 / Math.Pow(esttol, 0.2);

            h = s * (h);

            if (Math.Abs(h) < hmin)
                goto e200;

            *iflag = 6;
            kflag = 6;
            return;

        // Успешный шаг.Сохранение решения в T+H and вычисление производных.

        e260:
            t += h;

            for (i = 1; i < NEQ; i++)
                y[i] = f1[i];

            a = t;
            f(a, y, yp);
            nfe += 1;

            s = 5.0;

            if (esttol > 1.889568e-4)
                s = 0.9 / Math.Pow(esttol, 0.2);

            if (hfaild)
                s = Min(s, 1.0);

            h = Sign(Max(s * Math.Abs(h), hmin), h);

            if (output)
                goto l300;

            if (*iflag > 0)
                goto e100;

            // Успешное интегрирование
            *iflag = -2;
            return;

        l300:
            t = tout;
            *iflag = 2;
            return;
        }

        /// <summary>
        /// Метод вычисления численности популяций
        /// </summary>
        /// <param name="startPreys"></param>
        /// <param name="startPredators"></param>
        /// <param name="daysCount"></param>
        public static void StartCalculations(int startPreys, int startPredators, int daysCount)
        {
            double t, tout, relerr, abserr;
            double tfinal, tprint;
            int iflag;
            preys = new List<double>();
            predators = new List<double>();
            time = new List<double>();
            unsafe
            {
                relerr = 1.0e-9; // объявление rel ошибки
                abserr = 0.0; // объявление abs ошибки

                t = 0.0;
                tfinal = daysCount; // конец интегрирования
                tprint = 0.10;  // частота отображения числа жертв и хищников
                iflag = 1;
                tout = t;
                int neqn = 2;  // число уравнений
                y[1] = startPreys; // начальная численность жертв
                y[2] = startPredators; // начальная численность хищников

            l10:
                unsafe
                {
                    rkf45(neqn, y, ref t, tout, relerr, abserr, &iflag);
                    preys.Add(y[1]);
                    predators.Add(y[2]);
                    time.Add(t);
                    switch (iflag)
                    {
                        case 1: goto l80;
                        case 2: goto l20;
                        case 3: goto l30;
                        case 4: goto l40;
                        case 5: goto l50;
                        case 6: goto l60;
                        case 7: goto l70;
                        case 8: goto l80;
                    }

                l20:
                    tout = t + tprint;
                    if (t < tfinal)
                        goto l10;

                    return;

                l30:
                    goto l10;

                l40:
                    goto l10;

                l50:
                    abserr = 1.0e-9;
                    goto l10;

                l60:
                    relerr *= 10.0;
                    iflag = 2;
                    goto l10;

                l70:
                    iflag = 2;
                    goto l10;

                l80:
                    return;
                }
            }
        }
        // методы из фортран
        static int ISign(int a, int b)
        {
            if (b < 0) return -Math.Abs(a);
            else return Math.Abs(a);
        }

        static double Max(double a, double b)
        {
            if (a >= b) return a;
            else return b;
        }

        static double Min(double a, double b)
        {
            if (a <= b) return a;
            else return b;
        }

        static double Sign(double a, double b)
        {
            if (b < 0) return (-Math.Abs(a));
            else return Math.Abs(a);
        }
    }
}
