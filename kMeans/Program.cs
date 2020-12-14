using System;
using System;
using System.Collections.Generic;
using System.Linq;
namespace kMeans
{
    class Program
    {
        static void Main(string[] args)
        {          
            List<List<string>> data = new List<List<string>>();
            List<List<string>> distance = new List<List<string>>();
            List<List<string>> distance2 = new List<List<string>>();

            List<List<string>> list = new List<List<string>>();

            List<List<string>> centers = new List<List<string>>();
            List<List<string>> centers2 = new List<List<string>>();

            List<List<string>> centersNew = new List<List<string>>();

            List<List<string>> countClassElements = new List<List<string>>();
            List<List<string>> countClassElements2 = new List<List<string>>();

            List<List<string>> average2 = new List<List<string>>();

            Console.Write("Введите кол-во класов: ");
            int countClass = Convert.ToInt32(Console.ReadLine()), count = 0, options = 0, pMasCheck = 0, pMasCheck2 = 0, step = 0, fin = 0, flag2 = 0;
      
            Console.WriteLine("");

            int count2 = -1, distanceCheck = -1, distanceCheck2 = -1, distanceCheck2New = -1, countClassElementsCheck = -1, countClassElementsCheck2 = -1, average2Check = -1, centersNewCheck = -1, centers2Check = -1, centers2CheckTry = -1, centersNewCount = -1;  

            kMeans();
            
            void kMeans()
            {
                Random rnd = new Random();
                int counter = 0, min = 0, max = 0;
                string line;

                System.IO.StreamReader file = new System.IO.StreamReader(@"F:\kMeans.txt");
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(new List<string> { line });
                    pars(counter, line);
                    counter++;
                }
                file.Close();

                Console.WriteLine("Данные");
                foreach (List<string> subList in list)
                {
                    foreach (string item in subList)
                    {
                        Console.Write(" " + item);
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        if (Convert.ToInt32(data[i][j]) >= max)
                        {
                            max = Convert.ToInt32(data[i][j]);
                        }
                    }                 
                }

                min = max;
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Count; j++)
                    {                     
                        if (Convert.ToInt32(data[i][j]) <= min)
                        {
                            min = Convert.ToInt32(data[i][j]);
                        }
                    }
                }

                for (int i2 = 0; i2 < long.MaxValue; i2++)
                {
                    if (i2 == 0)
                    {
                        for (int j2 = 0; j2 < countClass; j2++)
                        {                          
                            centers2.Add(new List<string> { });
                            for (int z2 = 0; z2 < options; z2++)
                            {
                                centers2[j2].Add(rnd.Next(min, max + 1).ToString());
                            }
                            centers2Check++;
                        }

                        count = 0;
                        count2 = -1;
                        List<double> pMas = new List<double>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            distance2.Add(new List<string> { });
                            count2++;
                            pMasCheck2 = 0;

                            double p = 0;
                            double sum = 0;
                            for (int z = 1; z <= countClass; z++)
                            {
                                for (int j = 0; j < options; j++)
                                {
                                    p = Math.Pow((Convert.ToInt32(data[j][i]) - Convert.ToInt32(centers2[z - 1][j])), 2);
                                    sum = sum + p;
                                }

                                p = Math.Sqrt(sum);

                                pMas.Add(p);
                                sum = 0;

                                if ((count + 1) % countClass == 0)
                                {
                                    double min2 = long.MaxValue;
                                    int center = 0;

                                    for (int k = 0; k < countClass; k++)
                                    {
                                        if (min2 > pMas[pMasCheck2 + k])
                                        {
                                            min2 = pMas[pMasCheck2 + k];
                                            center = k + 1;
                                        }
                                    }
                                    pMasCheck2 += countClass;
                                    distanceCheck2++;
                                    distance2[distanceCheck2].Add(min2.ToString());
                                    distance2[distanceCheck2].Add((center).ToString());
                                }
                                count++;
                            }
                        }

                        for (int i3 = 0; i3 < countClass; i3++)
                        {
                            countClassElementsCheck2++;
                            countClassElements2.Add(new List<string> { });
                            countClassElements2[countClassElementsCheck2].Add("0");
                            countClassElements2[countClassElementsCheck2].Add((i3 + 1).ToString());

                            for (int j3 = 0; j3 < distance2.Count; j3++)
                            {
                                if ((i3 + 1).ToString() == distance2[j3][1])
                                {
                                    countClassElements2[countClassElementsCheck2][0] = (Convert.ToInt32(countClassElements2[countClassElementsCheck2][0]) + 1).ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j2 = 0; j2 < countClass; j2++)
                        {
                            centers2.Add(new List<string> { });
                            for (int z2 = 0; z2 < options; z2++)
                            {
                                centers2[centers2Check + 1 + j2].Add(rnd.Next(min, max + 1).ToString());
                            }
                        }

                        count = 0;
                        count2 = -1;
                        pMasCheck2 = 0;

                        List<double> pMas = new List<double>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            distance2.Add(new List<string> { });
                            count2++;

                            double p = 0;
                            double sum = 0;
                            for (int z = 1; z <= countClass; z++)
                            {
                                for (int j = 0; j < options; j++)
                                {
                                    p = Math.Pow((Convert.ToInt32(data[j][i]) - Convert.ToInt32(centers2[centers2Check + z][j])), 2);
                                    sum = sum + p;
                                }

                                p = Math.Sqrt(sum);

                                pMas.Add(p);
                                sum = 0;

                                if ((count + 1) % countClass == 0)
                                {
                                    double min2 = long.MaxValue;
                                    int center = 0;

                                    for (int k = 0; k < countClass; k++)
                                    {
                                        if (min2 > pMas[pMasCheck2 + k])
                                        {
                                            min2 = pMas[pMasCheck2 + k];
                                            center = k + 1;
                                        }
                                    }
                                    pMasCheck2 += countClass;
                                    distanceCheck2++;
                                    distanceCheck2New++;

                                    distance2[distanceCheck2].Add(min2.ToString());
                                    distance2[distanceCheck2].Add((center).ToString());
                                }
                                count++;
                            }
                        }
                        centers2Check += countClass;
                        centers2CheckTry += countClass;

                        for (int i3 = 0; i3 < countClass; i3++)
                        {
                            countClassElementsCheck2++;
                            countClassElements2.Add(new List<string> { });
                            countClassElements2[countClassElementsCheck2].Add("0");
                            countClassElements2[countClassElementsCheck2].Add((i3 + 1).ToString());

                            for (int j3 = 0; j3 < distance2.Count - distanceCheck2New - 1; j3++)
                            {
                                if ((i3 + 1).ToString() == distance2[distanceCheck2New + 1 + j3][1])
                                {
                                    countClassElements2[countClassElementsCheck2][0] = (Convert.ToInt32(countClassElements2[countClassElementsCheck2][0]) + 1).ToString();
                                }
                            }
                        }
                    }

                    int zeroCoint = 0;
                    if (flag2 == 0)
                    {
                        for (int i = 0; i < countClass; i++)
                        {
                            if (Convert.ToInt32(countClassElements2[i][0]) == 0)
                            {
                                zeroCoint++;
                            }
                        }
                        if (zeroCoint == 0)
                        {
                            for (int i = 0; i < centers2.Count; i++)
                            {
                                centers.Add(new List<string> { });
                                for (int j = 0; j < centers2[i].Count; j++)
                                {
                                    centers[i].Add(centers2[i][j]);
                                }
                            }
                            break;
                        }
                        flag2++;
                    }
                    else
                    {
                        for (int i = 0; i < countClass; i++)
                        {
                            if (Convert.ToInt32(countClassElements2[countClassElementsCheck2-countClass+i+1][0]) == 0)
                            {
                                zeroCoint++;
                            }
                        }
                        if (zeroCoint == 0)
                        {
                            for (int i = 0; i < countClass; i++)
                            {
                                centers.Add(new List<string> { });
                                for (int j = 0; j < centers2[i].Count; j++)
                                {
                                    centers[i].Add(centers2[centers2Check - countClass + i + 1][j]);
                                }
                            }
                            break;
                        }
                    }                  
                }

                for (int i = 0; i < long.MaxValue; i++)
                {
                    step++;
                    distanceСalculation(i);
                    if (fin == 1)
                    {
                        break;  
                    }
                }           
            }


            void pars(int counter, string str)
            {
                string str1 = "";
                int param = 0;
                int paramStart = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        if (counter == 0)
                        {
                            data.Add(new List<string> { });
                        }
                        param++;
                    }
                }

                options = param;

                if (counter >= 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (param != 0)
                        {
                            for (int j = i; j < str.Length; j++)
                            {
                                if (str[j] != ' ')
                                {
                                    str1 += str[j];
                                }
                                if (str[j] == ' ')
                                {
                                    data[paramStart].Add(str1);
                                    str1 = null;
                                    paramStart++;
                                    i = j;
                                    break;
                                }
                            }
                            param--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            void distanceСalculation(int flag)
            {
                if (flag == 0)
                {
                    count = 0;
                    count2 = -1;
                    List<double> pMas = new List<double>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        distance.Add(new List<string> { });
                        count2++;
                        double p = 0;
                        double sum = 0;
                        for (int z = 1; z <= countClass; z++)
                        {
                            for (int j = 0; j < options; j++)
                            {
                                p = Math.Pow((Convert.ToInt32(data[j][i]) - Convert.ToInt32(centers[z-1][j])), 2);
                                sum = sum + p;
                            }

                            p = Math.Sqrt(sum);

                            pMas.Add(p);
                            sum = 0;

                            if ((count + 1) % countClass == 0)
                            {
                                double min = long.MaxValue;
                                int center = 0;

                                for (int k = 0; k < countClass; k++)
                                {
                                    if (min > pMas[pMasCheck + k])
                                    {
                                        min = pMas[pMasCheck + k];
                                        center = k+1;
                                    }
                                }
                                pMasCheck += countClass;
                                distanceCheck++;
                                distance[distanceCheck].Add(min.ToString());
                                distance[distanceCheck].Add((center).ToString());
                            }                                                                           
                            count++;
                        }
                    }
                    centeringСlassification(flag);
                }
                else
                {
                    count = 0;
                    count2 = -1;
                    pMasCheck = 0;
                    List<double> pMas = new List<double>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        distance.Add(new List<string> { });
                        count2++;
                        double p = 0;
                        double sum = 0;
                        for (int z = 0; z < countClass; z++)
                        {
                            for (int j = 0; j < options; j++)
                            {
                                p = Math.Pow((Convert.ToDouble(data[j][i]) - Convert.ToDouble(centersNew[z][j])), 2);
                                sum = sum + p;
                            }

                            p = Math.Sqrt(sum);

                            pMas.Add(p);    
                            sum = 0;

                            if ((count + 1) % countClass == 0)
                            {
                                double min = long.MaxValue;
                                int center = 0;

                                for (int k = 0; k < countClass; k++)
                                {
                                    if (min > pMas[pMasCheck + k])
                                    {
                                        min = pMas[pMasCheck + k];
                                        center = k + 1;
                                    }
                                }
                                pMasCheck += countClass;
                                distanceCheck++;
                                distance[distanceCheck].Add(min.ToString());
                                distance[distanceCheck].Add((center).ToString());
                            }

                            count++;
                        }
                    }
                    centeringСlassification(flag);
                }            
            }


            void centeringСlassification(int flag)
            {
                double sumA = 0;
                int check = 0;

                if (flag == 0)
                {
                    for (int i = 0; i < centers.Count; i++)
                    {
                        countClassElementsCheck++;
                        countClassElements.Add(new List<string> { });
                        countClassElements[countClassElementsCheck].Add("0");
                        countClassElements[countClassElementsCheck].Add((i + 1).ToString());

                        for (int j = 0; j < distance.Count; j++)
                        {
                            if ((i + 1).ToString() == distance[j][1])
                            {
                                countClassElements[countClassElementsCheck][0] = (Convert.ToInt32(countClassElements[countClassElementsCheck][0]) + 1).ToString();
                            }
                        }
                    }

                    for (int a2 = 0; a2 < countClassElements.Count; a2++)
                    {
                        for (int j = 0; j < options; j++)
                        {
                            average2.Add(new List<string> { });

                            for (int i = 0; i < Convert.ToInt32(countClassElements[a2][0]); i++)
                            {
                                sumA += Convert.ToDouble(data[j][i + check]);
                            }
                            average2Check++;
                            average2[average2Check].Add(Convert.ToDouble(sumA / Convert.ToDouble(countClassElements[a2][0])).ToString());
                            average2[average2Check].Add(countClassElements[a2][1]);

                            sumA = 0;
                        }
                        check += Convert.ToInt32(countClassElements[a2][0]);
                    }

                    for (int i = 0; i < centers.Count; i++)
                    {
                        centersNewCount++;
                        centersNew.Add(new List<string> { });

                        for (int j = 0; j < (average2.Count / centers.Count); j++)
                        {
                            centersNewCheck++;
                            centersNew[centersNewCount].Add(average2[centersNewCheck][0]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < centers.Count; i++)
                    {
                        countClassElementsCheck++;
                        countClassElements.Add(new List<string> { });
                        countClassElements[countClassElementsCheck].Add("0");
                        countClassElements[countClassElementsCheck].Add((i + 1).ToString());

                        for (int j = 0; j < distance.Count / (flag + 1); j++)
                        {
                            if ((i + 1).ToString() == distance[distance.Count / (flag + 1) + j][1])
                            {
                                countClassElements[countClassElementsCheck][0] = (Convert.ToInt32(countClassElements[countClassElementsCheck][0]) + 1).ToString();
                            }
                        }
                    }

                    for (int a2 = 0; a2 < countClassElements.Count/(flag+1); a2++)
                    {
                        for (int j = 0; j < options; j++)
                        {
                            average2.Add(new List<string> { });
                            
                            for (int i = 0; i < Convert.ToInt32(countClassElements[(countClassElementsCheck + 1) / (flag + 1) + a2][0]); i++)
                            {
                                sumA += Convert.ToDouble(data[j][i + check]);
                            }
                            average2Check++;
                            average2[average2Check].Add(Convert.ToDouble(sumA / Convert.ToDouble(countClassElements[(countClassElementsCheck + 1) / (flag + 1) + a2][0])).ToString());
                            average2[average2Check].Add(countClassElements[(countClassElementsCheck + 1) / (flag + 1) + a2][1]);

                            sumA = 0;
                        }
                        check += Convert.ToInt32(countClassElements[(countClassElementsCheck + 1) / (flag + 1) + a2][0]);
                    }

                    for (int i = 0; i < centers.Count; i++)
                    {
                        centersNewCount++;
                        centersNew.Add(new List<string> { });

                        for (int j = 0; j < (average2.Count / (flag + 1) / centers.Count); j++)
                        {
                            centersNewCheck++;
                            centersNew[centersNewCount].Add(average2[centersNewCheck][0]);
                        }
                    }                   
                }

                if (centersNewCount >= countClass)
                {
                    int fin2 = 0;
                    int step2 = 0;
                    for (int i = centersNewCount; i > countClass - 1; i--)
                    {
                        for (int j = 0; j < options; j++)
                        {
                            if (centersNew[i][j] == centersNew[centersNewCount - countClass - step2][j])
                            {
                                fin2++;

                                if (fin2 == (countClass * options))
                                {
                                    Console.WriteLine("");

                                    for (int i2 = 0; i2 < countClass ; i2++)
                                    {
                                        Console.WriteLine(" Класс № " + (i2+1) + " содержит " + countClassElements[countClassElementsCheck - countClass + i2 + 1][0]);                                      
                                    }
                                    fin = 1;
                                    Console.WriteLine("");
                                }
                            }
                        }
                        step2++;
                    }
                }
            }          
        }    
    }
}

